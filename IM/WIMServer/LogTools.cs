﻿//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;


namespace  WIMServer
{
    /// <summary>
    /// Quickly log exceptions and information to a file.
    /// </summary>
    public class LogTools
    {
        /// <summary>
        /// Locker for log methods which ensures threadSafe save outs.
        /// </summary>
        static object errorLocker = new object();

        /// <summary>
        /// Appends the provided logString to end of fileName.txt. If the file does not exist it will be created.
        /// </summary>
        /// <param name="fileName">The filename to use. The extension .txt will be appended automatically</param>
        /// <param name="logString">The string to append.</param>
        public static void AppendStringToLogFile(string fileName, string logString)
        {
            try
            {
                //Catch filenames that are too long
                if (fileName.Length > 50)
                    fileName = fileName.Substring(0, 50);

                lock (errorLocker)
                {
#if NETFX_CORE
                    Task writeTask = new Task(async () =>
                        {
                            StorageFolder folder = ApplicationData.Current.LocalFolder;
                            StorageFile file = await folder.CreateFileAsync(fileName + ".txt", CreationCollisionOption.OpenIfExists);
                            await FileIO.AppendTextAsync(file, logString);
                        });

                    writeTask.ConfigureAwait(false);
                    writeTask.Start();
                    writeTask.Wait(); 
#else
                    //添加01
                    string logFileName = AppDomain.CurrentDomain.BaseDirectory + fileName + ".txt";
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(logFileName, true))
                        sw.WriteLine(logString);
                    //using (System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName + ".txt", true))
                    //    sw.WriteLine(logString);
#endif
                }
            }
            catch (Exception)
            {
                //If an error happens here, such as if the file is locked then we lucked out.
            }
        }

        /// <summary>
        /// Logs the provided exception to a file to assist troubleshooting.
        /// </summary>
        /// <param name="ex">The exception to be logged</param>
        /// <param name="fileName">The filename to use. A time stamp and extension .txt will be appended automatically</param>
        /// <param name="optionalCommentStr">An optional string which will appear at the top of the error file</param>
        /// <returns>The entire fileName used.</returns>
        public static string LogException(Exception ex, string fileName, string optionalCommentStr = "")
        {
            string entireFileName;

            lock (errorLocker)
            {
                //Catch filenames that are too long
                if (fileName.Length > 40)
                    fileName = fileName.Substring(0, 40);
 
                using (Process currentProcess = System.Diagnostics.Process.GetCurrentProcess())
                    entireFileName = fileName + " " + DateTime.Now.ToString("HH.mm.ss.fff") + " " + DateTime.Now.ToString("dd-MM-yyyy" + " [" + currentProcess.Id.ToString() + "-" + Thread.CurrentContext.ContextID.ToString() + "]");
 

                try
                {
 
                    //using (System.IO.StreamWriter sw = new System.IO.StreamWriter(entireFileName + ".txt", false))
                    //添加02
                    string logFileName = AppDomain.CurrentDomain.BaseDirectory + entireFileName + ".txt";
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(logFileName, false))
                    {
                        if (optionalCommentStr != "")
                        {
                            sw.WriteLine("Comment: " + optionalCommentStr);
                            sw.WriteLine("");
                        }

                        if (ex.GetBaseException() != null)
                            sw.WriteLine("Base Exception Type: " + ex.GetBaseException().ToString());

                        if (ex.InnerException != null)
                            sw.WriteLine("Inner Exception Type: " + ex.InnerException.ToString());

                        if (ex.StackTrace != null)
                        {
                            sw.WriteLine("");
                            sw.WriteLine("Stack Trace: " + ex.StackTrace.ToString());
                        }
                    }
 
                }
                catch (Exception)
                {
                    //This should never really happen, but just incase.
                }
            }

            return entireFileName;
        }

        public static string LogException(string errorMessage, string fileName)
        {

            string entireFileName;

            lock (errorLocker)
            {
                //Catch filenames that are too long
                if (fileName.Length > 40)
                    fileName = fileName.Substring(0, 40);

                using (Process currentProcess = System.Diagnostics.Process.GetCurrentProcess())
                    entireFileName = fileName + " " + DateTime.Now.ToString("HH.mm.ss.fff") + " " + DateTime.Now.ToString("dd-MM-yyyy" + " [" + currentProcess.Id.ToString() + "-" + Thread.CurrentContext.ContextID.ToString() + "]");


                try
                {

                    //using (System.IO.StreamWriter sw = new System.IO.StreamWriter(entireFileName + ".txt", false))
                    //添加02
                    string logFileName = AppDomain.CurrentDomain.BaseDirectory + entireFileName + ".txt";
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(logFileName, false))
                    {
                          
                            sw.WriteLine("");
                            sw.WriteLine(errorMessage);
                         
                    }

                }
                catch (Exception)
                {
                    //This should never really happen, but just incase.
                }
            }

            return entireFileName;
        }
    }
}
