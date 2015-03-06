//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;


namespace WIMServer
{
    /// <summary>
    /// 用来把一些日志或者文本信息写入到根目录下
    /// </summary>
    public class LogInfo
    {
        /// <summary>
        /// 同步锁
        /// </summary>
        static object errorLocker = new object();
 

        public static void LogMessage(string info, string fileName)
        {

            string entireFileName;

            lock (errorLocker)
            {
                //如果文件名称太长则截取一下
                if (fileName.Length > 40)
                    fileName = fileName.Substring(0, 40);

                using (Process currentProcess = System.Diagnostics.Process.GetCurrentProcess())
                   //文件名
                    entireFileName = fileName;


                try
                { 
                    string logFileName = AppDomain.CurrentDomain.BaseDirectory + entireFileName + ".txt";

                    //如果文件已经存在，则追加写入
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(logFileName, true))
                    { 
                        sw.WriteLine(info);
                        //写入换行符
                        sw.WriteLine(System.Environment.NewLine);

                    }

                }
                catch (Exception)
                {
                     
                }
            }

           
        }


       
    }
}
