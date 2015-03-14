using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogEntity;
using System.IO;

namespace LogDataAccess
{
    public class LogDal : Sharp.Data.BaseManager
    {
        public int DeleteByIds(List<string> idlist)
        {
            return Dal.Delete<T_Log>(idlist);
        }
        public int Delete(string id)
        {
            return Dal.Delete<T_Log>(id);
        }

        public int Write(T_Log log)
        {
            return Dal.Submit(log);
        }

        /// <summary>
        /// public enum MsgAlertType
        ///{
        ///    消息,
        ///    错误,
        ///    成功,
        ///   致命错误  会记录到数据库的 
        /// }
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="msgOrder"></param>
        /// <param name="modleName"></param>
        /// <param name="funName"></param>
        /// <param name="?"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public int Write(string msg, LogOrder msgOrder = LogOrder.严重错误, string funName = "", string className = "", string modleName = "", string context = "")
        {
            T_Log log = new T_Log();
            log.ID = Guid.NewGuid().ToString();
            log.Info = msg;
            log.msgOrder = (int)msgOrder;
            log.FunNameSource = funName;
            log.ClassNameSource = className;
            log.ModleNameSource = modleName;
            log.ContextInfo = context;
            log.CrateDate = DateTime.Now;
            int i = Write(log);
            if (i < 1)
            {
                string path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Templates), "Gold");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string filePath = Path.Combine(path, DateTime.Now.ToString("yyyyMMdd") + ".txt");
                using (FileStream fs = new FileStream(filePath, FileMode.Append))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {

                        //开始写入
                        sw.Write(context + System.Environment.NewLine);
                    }
                }
            }
            return i;
        }

        public static void Write(Exception ex)
        {
            string info = "发生异常:" + Environment.NewLine;
            info += ex.Message + Environment.NewLine;
            info += ex.Source + Environment.NewLine;
            info += ex.StackTrace + Environment.NewLine;
            new LogDal().Write(info);
        }
        public static void Write(Exception ex, string context)
        {
            string info = "发生异常:" + Environment.NewLine;
            info += ex.Message + Environment.NewLine;
            info += ex.Source + Environment.NewLine;
            info += ex.StackTrace + Environment.NewLine;
            new LogDal().Write(info, LogOrder.严重错误, "", "", "", context);
        }

        public int DeleteAll()
        {
            return Dal.FromCustomSql("delete from T_Log").ExecuteNonQuery();
        }
    }
}
