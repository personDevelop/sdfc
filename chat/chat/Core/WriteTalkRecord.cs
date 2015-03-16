using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ChatClient.Core
{
    public class TalkRecordManager
    {
        /// <summary>
        /// 记录消息记录
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <param name="userid">我的用户ID</param>
        /// <param name="talerID">对方用户ID</param>
        public static void Write(string msg, string talerID)
        {
            string userid = Common.CurrentUser.ID;
            DateTime now = DateTime.Now;
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, userid, now.ToString("YYYY"), now.ToString("MM"), now.ToString("dd"));
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filePath = Path.Combine(path, talerID + ".chat");
            using (FileStream fs = new FileStream(filePath, FileMode.Append))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    //开始写入
                    sw.Write(msg);
                }
            }
        }


        public static bool ReadMsg(string talerID, DateTime now, StringBuilder sb)
        {
            string userid = Common.CurrentUser.ID;
            string fileName = talerID + ".chat";
            sb = new StringBuilder();
            string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, userid);
            if (!Directory.Exists(basePath))
            {
                return false;
            }
            List<string> years = new List<string>();
            bool hasLoadYear = false;
            bool isLoop = true;
            do
            {


                string yearpath = Path.Combine(basePath, now.ToString("YYYY"));
                if (Directory.Exists(yearpath))
                {
                    string mothpath = Path.Combine(yearpath, now.ToString("MM"));
                    if (Directory.Exists(mothpath))
                    {
                        string daypath = Path.Combine(mothpath, now.ToString("dd"));
                        string filePath = Path.Combine(daypath, fileName);
                        if (Directory.Exists(daypath) && File.Exists(filePath))
                        {
                            sb.Append(File.ReadAllText(filePath));
                            isLoop = false;
                        }
                        else
                        {
                            //该天的没有
                            now.AddDays(-1);
                        }
                    }
                    else
                    {
                        //该月的没有
                        now = new DateTime(now.Year, now.Month - 1, 20);
                        now = new DateTime(now.Year, now.Month, GetWeekDay(now.Year, now.Month));
                    }
                }
                else
                {
                    if (!hasLoadYear)
                    {
                        hasLoadYear = true;
                        years.AddRange(Directory.GetDirectories(basePath));
                        years.Sort();
                    }
                    string lastYear = string.Empty;
                    if (years.Count > 0)
                    {


                        string curentyear = now.ToString("yyyy");

                        foreach (var item in years)
                        {
                            if (item.CompareTo(curentyear) >= 0)
                            {
                                break;
                            }
                            else
                            {
                                lastYear = item;
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                    if (string.IsNullOrEmpty(lastYear))
                    {
                        return false;
                    }
                    else
                    {
                        //该年的没有
                        now = new DateTime(int.Parse(lastYear), 12, 31);
                    }

                }

            } while (isLoop);


            return true;

        }

        static int GetWeekDay(int year, int month)
        {
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;

                case 2:
                    if (DateTime.IsLeapYear(year))
                        return 29;
                    else
                        return 28;

                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                default:
                    return 0;
            }
        }
    }
}