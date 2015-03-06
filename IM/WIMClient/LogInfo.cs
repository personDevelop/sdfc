using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;


namespace WIMClient
{
    /// <summary>
    /// Quickly log exceptions and information to a file.
    /// </summary>
    public class LogInfo
    {
        /// <summary>
        /// Locker for log methods which ensures threadSafe save outs.
        /// </summary>
        static object errorLocker = new object();
 

        public static void LogMessage(string info, string fileName)
        {

            string entireFileName;

            lock (errorLocker)
            {
                //Catch filenames that are too long
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
                    //This should never really happen, but just incase.
                }
            }

           
        }


       
    }
}
