//www.networkcomms.cn  www.networkcomms.net
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NetworkCommsDotNet;  
using System.IO;
using AuthorityEntity;

namespace WIMClient
{
    public partial class LoginForm : Form
    {

        #region Private Members
        /// <summary>
        /// 应用程序名称
        /// </summary>
        private string _applicationName = string.Empty;
        /// <summary>
        /// 保存窗体旧坐标的X轴值和Y轴值
        /// </summary>
        int _x, _y;
        /// <summary>
        /// 保存窗体是否可移动标识
        /// </summary>
        bool isMove = false;


        #endregion


        #region 公有属性

        //连接信息类
        public  ConnectionInfo connInfo = null;
        
        Connection newTcpConnection;

         

        #endregion

        #region Private Methods
        /// <summary>
        /// 用户输入验证
        /// </summary>
        /// <returns></returns>
        private bool UserInputCheck()
        {
            // 保存登录名称
            string loginName = this.txtUserID.Text.Trim();
            // 保存用户密码
            string userPwd = this.txtPassword.Text.Trim();

            // 开始验证
            if (string.IsNullOrEmpty(loginName))
            {
                this.toolTip.ToolTipIcon = ToolTipIcon.Info;
                this.toolTip.ToolTipTitle = "登录提示";
                Point showLocation = new Point(
                    this.txtUserID.Location.X + this.txtUserID.Width,
                    this.txtUserID.Location.Y);
                this.toolTip.Show("请您输入登录名称！", this, showLocation, 5000);
                this.txtPassword.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(userPwd))
            {
                this.toolTip.ToolTipIcon = ToolTipIcon.Info;
                this.toolTip.ToolTipTitle = "登录提示";
                Point showLocation = new Point(
                    this.txtPassword.Location.X + this.txtPassword.Width,
                    this.txtPassword.Location.Y);
                this.toolTip.Show("请您输入用户密码！", this, showLocation, 5000);
                this.txtPassword.Focus();
                return false;
            }
            else if (userPwd.Length < 1)
            {
                this.toolTip.ToolTipIcon = ToolTipIcon.Warning;
                this.toolTip.ToolTipTitle = "登录警告";
                Point showLocation = new Point(
                    this.txtPassword.Location.X + this.txtPassword.Width,
                    this.txtPassword.Location.Y);
                this.toolTip.Show("用户密码不能为空", this, showLocation, 5000);
                this.txtPassword.Focus();
                return false;
            }

            // 如果已通过以上所有验证则返回真
            return true;
        }

        /// <summary>
        /// 显示登录失败工具提示
        /// </summary>
        /// <param name="ex">引发登录失败的异常</param>
        private void ShowLoginLostToolTip(Exception ex)
        {

            // 如果登录界面未被释放
            if (!this.IsDisposed)
            {
                this.toolTip.ToolTipIcon = ToolTipIcon.Error;
                this.toolTip.ToolTipTitle = "登录失败";
            
                Point showLocation = new Point(
                    this.btnLogin.Location.X,
                    this.btnLogin.Location.Y);
                  this.toolTip.Show("网络没有连接，无法连到服务器", this, showLocation, 5000);
                this.txtUserID.SelectAll();
                this.txtPassword.Focus();
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// 带参构造
        /// </summary>
        /// <param name="applicationName">当前应用程序名称</param>
        /// 
        string IPAddress = "";
        int Port = 0;
        public LoginForm(string applicationName)
        {
            // 构建设计器
            InitializeComponent();

            // 保存传入的应用程序名称
            _applicationName = applicationName;
            // 设置标题
            this.Text = _applicationName;

            //从配置文件中获取IP
            IPAddress = System.Configuration.ConfigurationManager.AppSettings["IPAddress"];

            //从配置文件中获取端口
            Port = int.Parse(System.Configuration.ConfigurationManager.AppSettings["Port"]);

            connInfo = new ConnectionInfo(IPAddress, Port);


        }
         
    
        #endregion

   

    

        #region Event Handlers
        /// <summary>
        /// 登录按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        { 
            // 如果通过输入验证
            if (UserInputCheck())
            {
                 
                    newTcpConnection = TCPConnection.GetConnection(connInfo);
                    TCPConnection.StartListening(connInfo.LocalEndPoint);
                    // 保存登录身份是否合法验证结果
                    bool isPass = false;

                    //在契约类中保存用户名和密码
                    UserInfo userInfo = new UserInfo();
                    //userInfo.UserID = txtUserID.Text.Trim();
                    //userInfo.Password = txtPassword.Text.Trim();

                    ////发送契约类给服务器端，并获取返回的结果
                    //UserLoginContract loginContract = newTcpConnection.SendReceiveObject<UserLoginContract>("UserLogin", "ResUserLogin", 8000, userInfo);

               
                    //如果登陆成功
                    //if (loginContract.Message =="success")
                    //{

                    //    //为简便，在此处使用了静态类保存用户相关信息
                    //    Common.UserID = loginContract.UserContract.UserID;
                    //    Common.UserName = loginContract.UserContract.Name;
                    //    Common.ClientUser = new User(loginContract.UserContract.UserID, loginContract.UserContract.Name, "", UserSex.Male, Properties.Resources.q1, "", "");
                    //    //Common.PassWord = Encry.encode(txtPassword.Text);

                    //    //保存客户端的Tcp连接
                    //    Common.TcpConn = newTcpConnection;
                    //    Common.ConnInfo = connInfo;
                   
                    //    isPass = true;
                     
                       
                    //    this.DialogResult = DialogResult.OK;
                    //}
              
                
                    //// 如果未通过验证
                    //if (!isPass)
                    //{
                    //    btnLogin.Enabled = true; 
                    //    MessageBox.Show(loginContract.Message);
                    //}
               
            }
        }

        /// <summary>
        /// 退出按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            NetworkComms.Shutdown();
            this.Dispose();
            this.Close();
        }



        /// <summary>
        /// 鼠标指针在窗体上方并按下按键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            // 仅响应鼠标左键点击事件
            if (e.Button == MouseButtons.Left)
            {
                // 保存旧坐标
                this._x = e.X;
                this._y = e.Y;

                // 标识窗体可移动
                this.isMove = true;
            }
        }

        /// <summary>
        /// 鼠标指针在窗体上方并移动鼠标指针事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLogin_MouseMove(object sender, MouseEventArgs e)
        {
            // 如果可移动
            if (this.isMove)
            {
                // 根据旧坐标的相对偏移位置移动窗体
                // 方法一：
                // this.Left += e.X - this._x;
                // this.Top += e.Y - this._y;
                // 方法二：
                this.SetDesktopLocation(this.Left + e.X - this._x, this.Top + e.Y - this._y);

                // 在标题栏显示当前坐标
                string xPoint = this.Left.ToString().Trim();
                string yPoint = this.Top.ToString().Trim();
                this.Text = string.Format(
                    "「{0},{1}」",
                    xPoint.Length < 5 ? (xPoint.PadLeft(5)) : xPoint,
                    yPoint.Length < 5 ? (yPoint.PadRight(5)) : yPoint);
            }
        }

        /// <summary>
        /// 鼠标指针在窗体上方并释放按键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLogin_MouseUp(object sender, MouseEventArgs e)
        {
            // 标识窗体不可移动
            this.isMove = false;

            // 还原标题栏显示
            this.Text = _applicationName;
        }



        #endregion
 
 

      
    }
}
