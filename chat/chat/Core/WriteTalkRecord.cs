using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ChatClient.Core
{
    public class WriteTalkRecord
    {
        /// <summary>
        /// 记录消息记录
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <param name="userid">我的用户ID</param>
        /// <param name="talerID">对方用户ID</param>
        public static void Write(string msg, string userid, string talerID)
        {
       
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, userid, DateTime.Now.ToString("YYYY"), DateTime.Now.Month.ToString("MM"), DateTime.Now.Month.ToString("dd"));
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
    }
}
