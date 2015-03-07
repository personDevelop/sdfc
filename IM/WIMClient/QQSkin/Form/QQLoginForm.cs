using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using WIMClient.Skin;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using NetworkCommsDotNet; 
using System.IO;
using WIMClient;

namespace WIMClient.Skin
{
    public partial class QQLoginForm : Form
    {
        #region 参数
        private Graphics g = null;
        private Bitmap Bmp = null;
        private Bitmap closeBmp = null;
        private Bitmap minBmp = null;
        private Bitmap maxBmp = null;
        private Brush titleColor = Brushes.Black;

        private int xwidth;
        private Icon icon = null;
        private bool isOneLoad=true;
        private bool _allowResize = true;
        private bool _allowMove = true;
        private Font f = null;
        #endregion

        #region 初始化

        public QQLoginForm()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            f = new Font("Tahoma", 9F, FontStyle.Bold);
            InitializeComponent();
            InitControl();
            Initialize();
        }

        private void InitControl() 
        {
            icon = new Icon(this.Icon, 16, 16);
            MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            closeBmp = ResClass.GetImgRes("btn_close_normal");
            minBmp = ResClass.GetImgRes("btn_mini_normal");
            maxBmp = ResClass.GetImgRes("btn_max_normal");
            if (this.WindowState == FormWindowState.Maximized)
            {
                maxBmp = ResClass.GetImgRes("btn_restore_normal");
            }
        }

        private void Initialize()
        {
            // 保存传入的应用程序名称
         
            // 设置标题
            this.Text = "微风IM V3";

            //从配置文件中获取IP
            IPAddress = System.Configuration.ConfigurationManager.AppSettings["IPAddress"];

            //从配置文件中获取端口
            Port = int.Parse(System.Configuration.ConfigurationManager.AppSettings["Port"]);

            connInfo = new ConnectionInfo(IPAddress, Port);

            newTcpConnection = TCPConnection.GetConnection(connInfo);

            Common.TcpConn = newTcpConnection;
        }

        #endregion

        #region 系统事件

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            TaskMenu.ShowSYSMENU(this);
            if (this.ControlBox)
            {
                this.ButtonClose.Visible = true;
                if (!this.MinimizeBox)
                    this.ButtonMin.Visible = false;
                else
                    this.ButtonMin.Visible = true;
                if (!this.MaximizeBox)
                    this.ButtonMax.Visible = false;
                else
                    this.ButtonMax.Visible = true;
            }
            else
            {
                this.ButtonClose.Visible = false;
                this.ButtonMin.Visible = false;
                this.ButtonMax.Visible = false;
            }
            ResizeControl();
            int Rgn = Win32.CreateRoundRectRgn(0, 0, this.Width + 1, this.Height + 1, 5, 5);
            Win32.SetWindowRgn(this.Handle, Rgn, true);
            isOneLoad = false;
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            titleColor = Brushes.Black;
            this.Invalidate(new Rectangle(26, 7, xwidth - 26, 31));
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            titleColor = Brushes.Black;
            this.Invalidate(new Rectangle(26, 7, xwidth - 26, 31));
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Invalidate(new Rectangle(26, 7, xwidth - 26, 31));
        }

        protected override void OnPaint(PaintEventArgs e)              
        {
            base.OnPaint(e);
            g = e.Graphics;
            Bmp = ResClass.GetImgRes("login_png_bkg");
            g.DrawImage(Bmp, new Rectangle(0, 0, 5, 31), 0, 0, 5, 31, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(5, 0, Width - 10, 31), 5, 0, Bmp.Width - 10, 31, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(Width - 5, 0, 5, 31), Bmp.Width - 5, 0, 5, 31, GraphicsUnit.Pixel);

            g.DrawImage(Bmp, new Rectangle(0, 31, 1, Height - 36), 0, 31, 1, Bmp.Height - 36, GraphicsUnit.Pixel);
            if (Height >= 340)
            {
                g.DrawImage(Bmp, new Rectangle(1, 121, Width - 2, 15), 2, 31, Bmp.Width - 4, 25, GraphicsUnit.Pixel);
                g.DrawImage(Bmp, new Rectangle(1, 136, Width - 2, Height - 306), 2, Bmp.Height - 200, Bmp.Width - 5, 35, GraphicsUnit.Pixel);
            }
            else 
            {
                g.DrawImage(Bmp, new Rectangle(1, 31, Width - 2, 15), 2, 31, Bmp.Width - 4, 25, GraphicsUnit.Pixel);
                g.DrawImage(Bmp, new Rectangle(1, 46, Width - 2, Height - 216), 2, Bmp.Height - 200, Bmp.Width - 5, 35, GraphicsUnit.Pixel);
            }
            g.DrawImage(Bmp, new Rectangle(Width - 1, 31, 1, Height - 36), Bmp.Width - 1, 31, 1, Bmp.Height - 36, GraphicsUnit.Pixel);

            g.DrawImage(Bmp, new Rectangle(0, Height - 5, 5, 5), 0, Bmp.Height - 5, 5, 5, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(Width - 5, Height - 5, 5, 5), Bmp.Width - 5, Bmp.Height - 5, 5, 5, GraphicsUnit.Pixel);

            g.DrawImage(Bmp, new Rectangle(5, Height - 5, Width - 10, 5), 5, Bmp.Height - 5, Bmp.Width - 10, 5, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(1, Height - 170, Width - 2, 165), 2, Bmp.Height - 170, Bmp.Width - 5, 165, GraphicsUnit.Pixel);
            
            //g.DrawImage(Bmp, new Rectangle(this.Width - 5, 56, 5, Height - 90), Bmp.Width - 5, Bmp.Height - 264, 5, Bmp.Height - 90, GraphicsUnit.Pixel);

            g.DrawString(this.Text, f, titleColor, 10, 3);

            if (Height >= 340)
            {
                Bmp = ResClass.GetImgRes("holiday_normal");
                g.DrawImage(Bmp, new Rectangle(1, 31, Width - 2, Bmp.Height), 0, 0, 2, Bmp.Height, GraphicsUnit.Pixel);
                if (Bmp.Width > Width)
                    g.DrawImage(Bmp, new Rectangle(1, 31, Width - 2, Bmp.Height), (Bmp.Width - Width - 2) / 2, 0, Width - 2, Bmp.Height, GraphicsUnit.Pixel);
                else
                    g.DrawImage(Bmp, new Rectangle((Width - Bmp.Width) / 2, 31, Bmp.Width, Bmp.Height), 0, 0, Bmp.Width, Bmp.Height, GraphicsUnit.Pixel);
            }
            Bmp.Dispose();
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg) 
            {
                case Win32.WM_NCPAINT:
                    break;
                case Win32.WM_NCACTIVATE:
                    if (m.WParam == (IntPtr)0)
                    {
                        m.Result = (IntPtr)1;
                    }
                    if (m.WParam == (IntPtr)2097152)
                    {
                        m.Result = (IntPtr)1;
                    }
                    break;
                case Win32.WM_NCCALCSIZE:
                    break;
                case Win32.WM_NCHITTEST:
                        Point vPoint = new Point((int)m.LParam & 0xFFFF, (int)m.LParam >> 16 & 0xFFFF);
                        vPoint = PointToClient(vPoint);
                        if (AllowResize && MaximizeBox)
                        {
                            if (vPoint.X <= 3)
                            {
                                if (vPoint.Y <= 3)
                                    m.Result = (IntPtr)Win32.HTTOPLEFT;
                                else if (vPoint.Y >= Height - 3)
                                    m.Result = (IntPtr)Win32.HTBOTTOMLEFT;
                                else m.Result = (IntPtr)Win32.HTLEFT;
                            }
                            else if (vPoint.X >= Width - 3)
                            {
                                if (vPoint.Y <= 3)
                                    m.Result = (IntPtr)Win32.HTTOPRIGHT;
                                else if (vPoint.Y >= Height - 3)
                                    m.Result = (IntPtr)Win32.HTBOTTOMRIGHT;
                                else m.Result = (IntPtr)Win32.HTRIGHT;
                            }
                            else if (vPoint.Y <= 3)
                            {
                                m.Result = (IntPtr)Win32.HTTOP;
                            }
                            else if (vPoint.Y >= Height - 3)
                                m.Result = (IntPtr)Win32.HTBOTTOM;
                        }
                        if (AllowMove) 
                        {
                            if (vPoint.Y < Height-3 && vPoint.Y > 2 && (vPoint.X > 3 && vPoint.X < Width - 3))
                                m.Result = (IntPtr)Win32.HTCAPTION;
                        }
                        else
                        {
                            if (vPoint.Y < 31 && vPoint.Y > 2 && (vPoint.X > 3 && vPoint.X < Width - 3))
                                m.Result = (IntPtr)Win32.HTCAPTION;
                        }
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (!isOneLoad)
            {
                if (this.WindowState != FormWindowState.Maximized)
                {
                    int Rgn = Win32.CreateRoundRectRgn(0, 0, this.Width + 1, this.Height + 1, 5, 5);
                    Win32.SetWindowRgn(this.Handle, Rgn, true);
                }
                else
                {
                    int Rgn = Win32.CreateRoundRectRgn(0, 0, this.Width + 1, this.Height + 1, 0, 0);
                    Win32.SetWindowRgn(this.Handle, Rgn, true);
                }
            }
            MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
            ResizeControl();

            if (Height < 340)
            {
                txtUserID.Top = 105;
                label1.Top = txtUserID.Top - 18;
                txtPassword.Top = txtUserID.Top + txtUserID.Height + 33;
                label2.Top = txtPassword.Top - 18;
                btnLogin.Top = txtPassword.Top + txtPassword.Height + 29;
                savepass_CheckBox.Visible = autologin_CheckBox.Visible = false;
            }
            if (Height < 420 && Height >= 340)
            {
                txtUserID.Top = 195;
                label1.Top = txtUserID.Top - 18;
                txtPassword.Top = txtUserID.Top + txtUserID.Height + 33;
                label2.Top = txtPassword.Top - 18;
                savepass_CheckBox.Visible = autologin_CheckBox.Visible = false;
                btnLogin.Top = txtPassword.Top + txtPassword.Height + 29;
            }
            if (Height >= 420 && Height < 525)
            {
                savepass_CheckBox.Visible = autologin_CheckBox.Visible = true;
                btnLogin.Top = txtPassword.Top + txtPassword.Height + 97;
            }
            if (Height>= 525)
            { 
                txtUserID.Top = 195;
                label1.Top = txtUserID.Top - 18;
                txtPassword.Top = txtUserID.Top + txtUserID.Height + 33;
                label2.Top = txtPassword.Top - 18;
                savepass_CheckBox.Visible = autologin_CheckBox.Visible = true;
                btnLogin.Top = txtPassword.Top + txtPassword.Height + 100;
            }
        }

        public new void Show(IWin32Window owner) 
        {
            base.Show(owner);
            this.BackColor = ((Form)owner).BackColor;
            this.BackgroundImage = ((Form)owner).BackgroundImage;
        }

        #endregion

        #region 其他操作

        private void ResizeControl()
        {
            if (this.ControlBox)
            {
                this.ButtonClose.Left = this.Width - ButtonClose.Width;
            }

            if (this.MinimizeBox)
            {
                if (this.MaximizeBox)
                {
                    this.ButtonMax.Left = ButtonClose.Left - ButtonMax.Width;
                    this.ButtonMin.Left = ButtonMax.Left - ButtonMin.Width;
                    xwidth = ButtonMin.Left;
                }
                else
                {
                    this.ButtonMin.Left = ButtonClose.Left - ButtonMin.Width;
                    xwidth = ButtonMin.Left;
                }
                //colour.Left = ButtonMin.Left - 25;
            }
            else
            {
                //colour.Left = ButtonClose.Left - 25;
                xwidth = ButtonClose.Left;
            }
            //colour.Visible = ShowColorButton;
            //color_Btn.Left = Width - color_Btn.Width - 3;
        }

        #endregion

        #region 辅助函数
        private Bitmap GetImg(string ImgName)
        {
            Image srcImg = ResClass.GetImgRes(ImgName);
            return GetImg(ImgName, srcImg.Width, srcImg.Height, 0, 0, srcImg.Width, srcImg.Height);
        }

        private Bitmap GetImg(string ImgName, int i)
        {
            Image srcImg = ResClass.GetImgRes(ImgName);
            return GetImg(ImgName, srcImg.Width / 4, srcImg.Height, srcImg.Width / 4 * i, 0, srcImg.Width / 4, srcImg.Height);
        }

        private Bitmap GetImg(string ImgName, int width, int height, int sleft, int stop, int sWidth, int sHeight)
        {
            Image srcImg = ResClass.GetImgRes(ImgName);

            Bitmap newImg = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(newImg);

            graphics.DrawImage(srcImg, new Rectangle(0, 0, width, height), (sleft < 0 ? srcImg.Width + sleft : sleft), (stop < 0 ? srcImg.Height + stop : stop), (sWidth < 0 ? srcImg.Width + sWidth : sWidth), (sHeight < 0 ? srcImg.Height + sHeight : sHeight), GraphicsUnit.Pixel);
            graphics.Dispose();
            srcImg.Dispose();
            return newImg;
        }
        #endregion

        #region 控制按钮实现

        private void ButtonClose_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.Close();
        }

        private void ButtonClose_MouseDown(object sender, MouseEventArgs e)
        {
            closeBmp = ResClass.GetImgRes("btn_close_down");
            ButtonClose.Invalidate();
        }

        private void ButtonClose_MouseUp(object sender, MouseEventArgs e)
        {
            if (!ButtonClose.IsDisposed)
            {
                closeBmp = ResClass.GetImgRes("btn_close_normal");
                ButtonClose.Invalidate();
            }
        }

        private void ButtonClose_MouseLeave(object sender, EventArgs e)
        {
            closeBmp = ResClass.GetImgRes("btn_close_normal");
            ButtonClose.Invalidate();
        }

        private void ButtonClose_MouseEnter(object sender, EventArgs e)
        {
            closeBmp = ResClass.GetImgRes("btn_close_highlight");
            toolTip1.SetToolTip(ButtonClose, "关闭");
            ButtonClose.Invalidate();
        }

        private void ButtonClose_Paint(object sender, PaintEventArgs e)
        {
            if (this.ControlBox)
            {
                g = e.Graphics;
                g.DrawImage(closeBmp, new Rectangle(0, 0, closeBmp.Width, closeBmp.Height), 0, 0, closeBmp.Width, closeBmp.Height, GraphicsUnit.Pixel);
            }
        }

        private void ButtonMin_MouseEnter(object sender, EventArgs e)
        {
            minBmp = ResClass.GetImgRes("btn_mini_highlight");
            toolTip1.SetToolTip(ButtonMin, "最小化");
            ButtonMin.Invalidate();
        }

        private void ButtonMin_MouseDown(object sender, MouseEventArgs e)
        {
            minBmp = ResClass.GetImgRes("btn_mini_down");
            ButtonMin.Invalidate();
        }

        private void ButtonMin_MouseUp(object sender, MouseEventArgs e)
        {
            minBmp = ResClass.GetImgRes("btn_close_normal");
            ButtonMin.Invalidate();
        }

        private void ButtonMin_MouseLeave(object sender, EventArgs e)
        {
            minBmp = ResClass.GetImgRes("btn_mini_normal");
            ButtonMin.Invalidate();
        }

        private void ButtonMin_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!this.ShowInTaskbar)
                {
                    this.Hide();
                }
                else
                {
                    this.WindowState = FormWindowState.Minimized;
                }
            }
        }

        private void ButtonMin_Paint(object sender, PaintEventArgs e)
        {
            if (this.MinimizeBox)
            {
                g = e.Graphics;
                g.DrawImage(minBmp, new Rectangle(0, 0, minBmp.Width, minBmp.Height), 0, 0, minBmp.Width, minBmp.Height, GraphicsUnit.Pixel);
            }
        }

        private void ButtonMax_MouseDown(object sender, MouseEventArgs e)
        {
            g = ButtonMax.CreateGraphics();
            maxBmp = ResClass.GetImgRes("btn_max_down");
            if (this.WindowState == FormWindowState.Maximized)
            {
                maxBmp = ResClass.GetImgRes("btn_restore_down");
            }
            g.DrawImage(maxBmp, new Rectangle(0, 0, maxBmp.Width, maxBmp.Height), 0, 0, maxBmp.Width, maxBmp.Height, GraphicsUnit.Pixel);
        }

        private void ButtonMax_MouseEnter(object sender, EventArgs e)
        {
            g = ButtonMax.CreateGraphics();
            maxBmp = ResClass.GetImgRes("btn_max_highlight");
            toolTip1.SetToolTip(ButtonMax, "最大化");
            if (this.WindowState == FormWindowState.Maximized)
            {
                maxBmp = ResClass.GetImgRes("btn_restore_highlight");
                toolTip1.SetToolTip(ButtonMax, "还原");
            }
            g.DrawImage(maxBmp, new Rectangle(0, 0, maxBmp.Width, maxBmp.Height), 0, 0, maxBmp.Width, maxBmp.Height, GraphicsUnit.Pixel);
        }

        private void ButtonMax_MouseLeave(object sender, EventArgs e)
        {
            maxBmp = ResClass.GetImgRes("btn_max_normal");
            if (this.WindowState == FormWindowState.Maximized)
            {
                maxBmp = ResClass.GetImgRes("btn_restore_normal");
            }
            ButtonMax.Invalidate();
        }

        private void ButtonMax_MouseUp(object sender, MouseEventArgs e)
        {
            maxBmp = ResClass.GetImgRes("btn_max_normal");
            if (this.WindowState == FormWindowState.Maximized)
            {
                maxBmp = ResClass.GetImgRes("btn_restore_normal");
            }
            ButtonMax.Invalidate();
        }

        private void ButtonMax_Paint(object sender, PaintEventArgs e)
        {
            if (this.MaximizeBox)
            {
                g = e.Graphics;
                maxBmp = ResClass.GetImgRes("btn_max_normal");
                if (this.WindowState == FormWindowState.Maximized)
                {
                    maxBmp = ResClass.GetImgRes("btn_restore_normal");
                }
                g.DrawImage(maxBmp, new Rectangle(0, 0, maxBmp.Width, maxBmp.Height), 0, 0, maxBmp.Width, maxBmp.Height, GraphicsUnit.Pixel);
                maxBmp.Dispose();
            }
        }

        private void ButtonMax_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.WindowState == FormWindowState.Normal)
                    this.WindowState = FormWindowState.Maximized;
                else
                    this.WindowState = FormWindowState.Normal;
                this.Invalidate();
            }
        }

        #endregion

        #region 微风 IM

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


        //连接信息类
        public ConnectionInfo connInfo = null;

        Connection newTcpConnection;


        private bool UserInputCheck()
        {
            // 保存登录名称
            string loginName = this.txtUserID.Texts.Trim(); 
            // 保存用户密码
            string userPwd = this.txtPassword.Texts.Trim();

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
                
                this.txtPassword.Focus();
            }
        }
        string IPAddress = "";
        int Port = 0;

        #endregion

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            g = ((PictureBox)sender).CreateGraphics();
            Bmp = ResClass.GetImgRes("allbtn_highlight");
            g.DrawImage(Bmp, new Rectangle(0, 0, 22, 22), 0, 0, 22, 22, GraphicsUnit.Pixel);
            Bmp.Dispose();
            g.Dispose();
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Invalidate();
        }

        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox p = sender as PictureBox;
                g = p.CreateGraphics();
                g.Clear(this.BackColor);
                Bmp = ResClass.GetImgRes("allbtn_down");
                g.DrawImage(Bmp, new Rectangle(0, 0, 22, 22), 0, 0, 22, 22, GraphicsUnit.Pixel);
                g.DrawImage(p.Image, new Rectangle(2, 3, 18, 18), 0, 0, 18, 18, GraphicsUnit.Pixel);
                Bmp.Dispose();
                g.Dispose();
            }
        }

        private void btn_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ((PictureBox)sender).Invalidate();
            }
        }

        [Description("允许用户拖动边框调整大小"), Category("Appearance")]
        public bool AllowResize 
        {
            get 
            {
                return _allowResize;
            } 
            set
            {
                _allowResize = value;
            } 
        }

        [Description("允许用户拖动任意处移动窗口"), Category("Appearance")]
        public bool AllowMove
        {
            get
            {
                return _allowMove;
            }
            set
            {
                _allowMove = value;
            }
        }

        //登陆按钮
        private void loginButton_MouseClick(object sender, MouseEventArgs e)
        {
            // 如果通过输入验证
            if (UserInputCheck())
            {

             
                TCPConnection.StartListening(connInfo.LocalEndPoint);
                // 保存登录身份是否合法验证结果
                bool isPass = false;

                //在契约类中保存用户名和密码
                //UserInfo userInfo = new UserInfo();
                //userInfo.UserID = txtUserID.Texts.Trim();
                //userInfo.Password = txtPassword.Texts.Trim();

                ////发送契约类给服务器端，并获取返回的结果
                //UserLoginContract loginContract = newTcpConnection.SendReceiveObject<UserLoginContract>("UserLogin", "ResUserLogin", 8000, userInfo);


                ////如果登陆成功
                //if (loginContract.Message == "success")
                //{

                //    //为简便，在此处使用了静态类保存用户相关信息
                //    Common.UserID = loginContract.UserContract.UserID;
                //    Common.UserName = loginContract.UserContract.Name;
                //    Common.ClientUser = new User(loginContract.UserContract.UserID, loginContract.UserContract.Name, "", UserSex.Male, Properties.Resources.q1, "", "");
                //    //Common.PassWord = Encry.encode(txtPassword.Text);

                //    //保存客户端的Tcp连接
                 
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

        private void newid_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterUser registerUser = new RegisterUser();
            registerUser.Show();
        }

        private void btnLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
