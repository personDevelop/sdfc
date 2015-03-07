using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;
using System.Net;
using CCWin.Win32;
using CCWin.Win32.Const;
using CCWin.SkinControl;
using System.Threading;
using FrameSession;
using Sharp.Common;
using NetworkCommsDotNet;
using IMInterface;
using AuthorityEntity;

namespace ChatClient
{
    public partial class frmLogin : CCSkinMain
    {
        //连接信息类
        public ConnectionInfo connInfo = null;

        Connection newTcpConnection;

        #region 卢永列  自动登录
        private string userNo;
        private string Pwd;
        private bool IsAutoLoin = false;
        #endregion
        public frmLogin(string[] args)
        {
            InitializeComponent();
            if (args != null && args.Length == 2)
            {
                userNo = args[0];
                Pwd = args[1];
                IsAutoLoin = true;
            }
            try
            {
                connInfo = new ConnectionInfo(Common.ServerIP, Common.Port);
                newTcpConnection = TCPConnection.GetConnection(connInfo);
                Common.TcpConn = newTcpConnection;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);


            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            #region 自动登录
            if (IsAutoLoin)
            {
                buttonLogin_Click(sender, e);
            }
            #endregion
        }



        private void buttonLogin_Click(object sender, EventArgs e)
        {

            if (!IsAutoLoin)
            {
                userNo = this.textBoxId.SkinTxt.Text;
                Pwd = this.textBoxPwd.SkinTxt.Text;
            }
            imgLoadding.Visible = true;

            if (string.IsNullOrWhiteSpace(userNo))
            {
                MessageBox.Show("请输入用户");
                return;
            }
            if (string.IsNullOrWhiteSpace(Pwd))
            {
                MessageBox.Show("请输入密码");
                return;
            }
            TCPConnection.StartListening(connInfo.LocalEndPoint);
            // 保存登录身份是否合法验证结果
            bool isPass = false;

            //在契约类中保存用户名和密码
            IMUserInfo userinfo = new IMUserInfo();
            userinfo.Code = userNo;
            userinfo.Pwd = Pwd;

            //发送契约类给服务器端，并获取返回的结果
            UserLoginContract loginContract = newTcpConnection.
                SendReceiveObject<UserLoginContract>("UserLogin", "ResUserLogin", 8000, userinfo);
            //如果登陆成功
            if (string.IsNullOrWhiteSpace(loginContract.Message))
            {

                //为简便，在此处使用了静态类保存用户相关信息  
                Common.ClientUser = loginContract.UserContract;
                Common.ConnInfo = connInfo;
                isPass = true;
                this.Hide();
                frmMain f = new frmMain();
                f.Show();
            }


            // 如果未通过验证
            if (!isPass)
            {

                MessageBox.Show(loginContract.Message);
            }

        }

    }
}
