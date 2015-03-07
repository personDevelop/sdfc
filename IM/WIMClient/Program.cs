//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;
using NetworkCommsDotNet; 

namespace WIMClient
{
    static class Program
    {
        //本程序基于networkcomms通信框架 
        static string applicationName = "微风IM";

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] Args)
        {
            
            Application.EnableVisualStyles();   //这行实现 XP 可视风格 
            Application.SetCompatibleTextRenderingDefault(false);
            Application.DoEvents();
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            NetworkComms.DisableLogging();
            //NetworkComms.DefaultSendReceiveOptions = new SendReceiveOptions<ProtobufSerializer>();
            //上面的写法由于在.net Framework V4中出错，更如下写法
            SendReceiveOptions nullCompressionSRO = null;// new SendReceiveOptions(DPSManager.GetDataSerializer<ProtobufSerializer>(), null, null);
            NetworkComms.DefaultSendReceiveOptions = nullCompressionSRO;
            //在全局处理函数中忽略相关消息 不添加日志
            NetworkComms.IgnoreUnknownPacketTypes = true;

            //连接服务器完成******************************************

            ////初始化主窗口
            //MsgForm msgForm = new MsgForm();


            ////显示登录窗口
            //LoginForm loginForm = new LoginForm(applicationName);

            ////如果登陆成功，则进入主窗口

            //if (loginForm.ShowDialog() == DialogResult.OK)
            //{ 
            //    msgForm.Initialize();
            //    Application.Run(msgForm);                 

            //} 
            //else
            //{
            //    return;
            //}

            //初始化窗口

            WIMClient.Skin.QQMainForm mainForm = new Skin.QQMainForm();

            WIMClient.Skin.QQLoginForm qqLoginForm = new WIMClient.Skin.QQLoginForm();

            if (qqLoginForm.ShowDialog() == DialogResult.OK)
            {
                mainForm.Initialize();
                Application.Run(mainForm);
            }

 
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            NetworkComms.Shutdown();
        }
 
    }
}
