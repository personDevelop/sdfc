using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

using System.Windows.Forms;
using System.Drawing;


namespace chat
{

    public interface ITwinkleNotifySupporter
    {
        IChatForm GetChatForm(string friendID);
        IChatForm GetExistedChatForm(string friendID);
        string GetFriendName(string friendID);

        Icon GetHeadIcon(string userID);
        Icon GetIcon();
        Icon Icon64 { get; }
        Icon NoneIcon64 { get; }
    }

    public interface IChatForm
    {
        void HandleReceivedMessage(List<byte[]> MessageList);
        void HandleReceivedMessage(int informationType, byte[] info, object tag);
    }



    public partial class TwinkleNotifyIcon : Component
    {
        private Control control;
        private object locker = new object();
        private List<UnhandleFriendMessageBox> friendQueue = new List<UnhandleFriendMessageBox>();
        private System.Windows.Forms.Timer timer = new Timer();
        private Icon twinkleIcon = null;
        private Icon normalIcon;
        private ITwinkleNotifySupporter twinkleNotifySupporter;
        private string normalText = null;
        public event MouseEventHandler MouseClick;
        public TwinkleNotifyIcon(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
        public void Initialize(ITwinkleNotifySupporter getter, Control ctrl)
        {
            this.control = ctrl;
            this.twinkleNotifySupporter = getter;
            this.timer.Tick += new EventHandler(timer_Tick);
            this.timer.Interval = 500;
            //this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "福彩即时通";
            this.notifyIcon1.Visible = true;
            this.normalIcon = this.twinkleNotifySupporter.Icon64;
            this.notifyIcon1.Icon = this.normalIcon;
            this.notifyIcon1.MouseClick += new MouseEventHandler(notifyIcon1_MouseClick);
        }

        public void ChangeMyStatus()
        {
            this.normalIcon = this.twinkleNotifySupporter.GetIcon();
            if (!this.timer.Enabled)
            {
                this.notifyIcon1.Icon = this.normalIcon;
            }
        }
        bool isnone = true;
        void timer_Tick(object sender, EventArgs e)
        {
            //if (this.friendQueue.Count == 0)
            //{
            //    this.ControlTimer(false);
            //    return;
            //}
            if (isnone)
            {
                this.notifyIcon1.Icon = this.twinkleIcon;
                isnone = false;
            }
            else {
                this.notifyIcon1.Icon = this.twinkleNotifySupporter.NoneIcon64;
                isnone = true;
            }
            //if (this.notifyIcon1.Icon == this.twinkleNotifySupporter.NoneIcon64)
            //{
            //    this.notifyIcon1.Icon = this.twinkleIcon;
            //}
            //else
            //{
            //    this.notifyIcon1.Icon = this.twinkleNotifySupporter.NoneIcon64;
            //}
        }
        private delegate void BeginInvokeDelegate(bool data);//声明一个委托类型
        private void BeginInvokeMethod(bool start)
        {
            ControlTimer(start);
            //C代码段
        }
        private void ControlTimer(bool start)
        {
            if (this.control.InvokeRequired)
            {
                this.control.BeginInvoke(new BeginInvokeDelegate(BeginInvokeMethod), start);
            }
            else
            {
                if (start)
                {
                    this.timer.Start(); ;
                }
                else
                {
                    this.timer.Stop();
                    //2014.11.05
                    this.notifyIcon1.Icon = this.normalIcon;
                    this.notifyIcon1.Text = this.normalText;
                }
            }
        }

        /// <summary>
        /// 用户发消息传递给消息队列
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="info"></param>
        public void PushFriendMessage(string userID, byte[] info)
        {
            this.twinkleIcon = this.twinkleNotifySupporter.GetHeadIcon(userID);
            ControlTimer(true);

        }

        public void Stop() 
        {
            ControlTimer(false);
        
        }

        /// <summary>
        /// 单机闪动图标触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {

            if (this.MouseClick != null)
            {
                this.MouseClick(sender, e);
            }
        }

    }


    #region UnhandleFriendMessageBox 为处理的消息记录类型
    public class UnhandleFriendMessageBox
    {

        //初始化用户 是谁发来的
        public UnhandleFriendMessageBox(string user)
        {
            this.User = user;
        }

        public string User { get; set; }
        //object 用于存放解析后的数据
        public List<byte[]> MessageList = new List<byte[]>();//记录消息记录的list
    }
    #endregion


}
