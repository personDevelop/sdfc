 
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WIMServer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            Application.Run(new MainForm());
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            //Environment.Exit(0);
        }
    }
}
