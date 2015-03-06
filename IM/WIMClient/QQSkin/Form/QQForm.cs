using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using SimpleIMClient.Skin;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace SimpleIMClient.Skin
{
    public partial class QQForm : Form
    {
        #region 参数
        private Graphics g = null;
        private Bitmap Bmp = null;
        private Bitmap closeBmp = null;
        private Bitmap minBmp = null;
        private Bitmap maxBmp = null;
        private Brush titleColor = Brushes.Black;

        private int xwidth;
        private bool isOneLoad = true;
        private bool miniMode = false;
        private Size oldSize;
        private List<string> slist = null;
        private Thread skinThread = null;
        private string currentSkin;
        private Font f = null;

        [Description("所有按钮的鼠标单击事件"), Category("Action")]
        public delegate void QzoneMouseClickEventHandler(object sender, MouseEventArgs e);
        public delegate void MailMouseClickEventHandler(object sender, MouseEventArgs e);
        public delegate void SearchMouseClickEventHandler(object sender, MouseEventArgs e);
        public delegate void MenuMouseClickEventHandler(object sender, MouseEventArgs e);
        public delegate void ToolsMouseClickEventHandler(object sender, MouseEventArgs e);
        public delegate void MessageMouseClickEventHandler(object sender, MouseEventArgs e);
        public delegate void FindMouseClickEventHandler(object sender, MouseEventArgs e);
        public event QzoneMouseClickEventHandler QzoneMouseClick;
        public event MailMouseClickEventHandler MailMouseClick;
        public event SearchMouseClickEventHandler SearchMouseClick;
        public event MenuMouseClickEventHandler MenuMouseClick;
        public event ToolsMouseClickEventHandler ToolsMouseClick;
        public event MessageMouseClickEventHandler MessageMouseClick;
        public event FindMouseClickEventHandler FindMouseClick;
        private string SelectTab = "";
        private string _NikeName = "翱翔的雄鹰";
        #endregion

        #region 初始化

        public QQForm()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                this.Font = new Font("微软雅黑", 9F, FontStyle.Regular);
            }
            else
            {
                this.Font = new Font("宋体", 9F, FontStyle.Regular);
            }
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            f = new Font("Tahoma", 9F, FontStyle.Bold);
            InitializeComponent();
            InitControl();
        }

        private void InitControl() 
        {
            MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            closeBmp = ResClass.GetResObj("btn_close_normal");
            minBmp = ResClass.GetResObj("btn_mini_normal");
            maxBmp = ResClass.GetResObj("btn_max_normal");
            if (this.WindowState == FormWindowState.Maximized)
            {
                maxBmp = ResClass.GetResObj("btn_restore_normal");
            }
            SelectTab = fd_btn.Name;
            fd_btn.BackgroundImage = ResClass.GetResObj("main_tab_check");
            gp_btn.BackgroundImage = nt_btn.BackgroundImage = lt_btn.BackgroundImage = ResClass.GetResObj("main_tab_bkg");
            fd_btn.Image = ResClass.GetResObj("MainPanel_ContactMainTabButton_texture");
            gp_btn.Image = ResClass.GetResObj("MainPanel_GroupMainTabButton_texture2");
            nt_btn.Image = ResClass.GetResObj("WBlog_TabBtn_Normal");
            lt_btn.Image = ResClass.GetResObj("MainPanel_RecentMainTabButton_texture2");

            userImg.BackgroundImage = ResClass.GetResObj("Padding4Normal");
            userImg.Image = ResClass.GetResObj("big1");

            qzone16_btn.Image = ResClass.GetResObj("qzone16");
            mail_btn.Image = ResClass.GetResObj("mail");
            color_Btn.Image = ResClass.GetResObj("colour");
            tools_Btn.Image = ResClass.GetResObj("Tools");
            message_Btn.Image = ResClass.GetResObj("message");
            find_Btn.Image = ResClass.GetResObj("find");
            menu_Btn.Image = ResClass.GetResObj("menu_btn_normal");
        }

        #endregion

        #region 系统事件

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.FormBorderStyle != FormBorderStyle.None)
                TaskMenu.InitSYSMENU(this);
            else
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

            slist = new List<string>(14);
            slist.Add("pic_defaultcolor_normal");
            if (Directory.Exists(Application.StartupPath + "\\skins"))
            {
                string[] sd = Directory.GetDirectories(Application.StartupPath + "\\skins");
                for (int i = 0; i < sd.Length; i++)
                {
                    string[] sf = Directory.GetFiles(sd[i], "main*");
                    if (sf.Length > 0)
                    {
                        slist.Add(sd[i]);
                    }
                } 
            }
            LoadSkinList();
            string msg = "我的好友;12;0;0ッ20000;芭比娃娃;暂无;big1;2;0000-00-00;;127.0.0.1;3300;1ソ20002;低调华丽;暂无;big1;2;0000-00-00;;127.0.0.1;3301;0ソ20003;☆Kiss☆;暂无;big1;1;0000-00-00;;127.0.0.1;3303;0ソ20004;☆Kiss☆;暂无;big1;1;0000-00-00;;127.0.0.1;3303;0ソ20005;☆Kiss☆;暂无;big1;1;0000-00-00;;127.0.0.1;3303;0ソ20006;☆Kiss☆;暂无;big1;1;0000-00-00;;127.0.0.1;3303;0ソ20007;☆Kiss☆;暂无;big1;1;0000-00-00;;127.0.0.1;3303;0ソ20008;☆Kiss☆;暂无;big1;1;0000-00-00;;127.0.0.1;3303;0ソ20009;☆Kiss☆;暂无;big1;1;0000-00-00;;127.0.0.1;3303;0ソ20010;☆Kiss☆;暂无;big1;1;0000-00-00;;127.0.0.1;3303;0ソ20011;☆Kiss☆;暂无;big1;1;0000-00-00;;127.0.0.1;3303;0ソ20012;☆Kiss☆;暂无;big1;1;0000-00-00;;127.0.0.1;3303;0テlove;1;0;1ッ20001;翱翔雄鹰;暂无;big1;1;0000-00-00;;127.0.0.1;3301;0テaaaaa;1;0;2ッ20013;翱翔雄鹰13;暂无;big1;1;0000-00-00;;127.0.0.1;3301;0テrrrtrr;1;0;3ッ20014;翱翔雄鹰14;暂无----------------------------;big1;1;0000-00-00;;127.0.0.1;3301;0テgggg;1;0;4ッ20015;翱翔雄鹰15;暂无15;big1;1;0000-00-00;;127.0.0.1;3301;0";
            Login(msg);
        }

        private void Login(string msg)
        {
            List<Group> list = new List<Group>();
            string[] ss = msg.Split("テ".ToCharArray());
            for (int i = 0; i < ss.Length; i++)
            {
                string[] sss = ss[i].ToString().Split("ッ".ToCharArray());
                string[] s1 = sss[0].ToString().Split(";".ToCharArray());
                Group fc = new Group();
                fc.Title = s1[0];
                fc.Count = int.Parse(s1[1]);
                fc.OnlineCount = int.Parse(s1[2]);
                fc.Id = int.Parse(s1[3]);
                if (sss.Length > 1)
                {
                    string[] s2 = sss[1].ToString().Split("ソ".ToCharArray());
                    for (int j = 0; j < s2.Length; j++)
                    {
                        Friend f = new Friend();
                        object[] info = s2[j].Split(";".ToCharArray());
                        f.Uin = int.Parse(info[0].ToString());
                        f.NikeName = info[1].ToString();
                        f.Description = info[2].ToString();
                        f.HeadIMG = info[3].ToString();
                        f.IsSysHead = true;
                        //sex = int.Parse(ss[4].ToString().Equals("") ? "0" : ss[4].ToString());
                        //BirsDay = ss[5].ToString();
                        //contray = ss[6].ToString();
                        //ip = IPAddress.Parse(ss[7].ToString().Equals("") ? "0.0.0.0" : ss[7].ToString());
                        //port = int.Parse(ss[8].ToString().Equals("") ? "0" : ss[8].ToString());
                        f.State = int.Parse(info[9].ToString().Equals("") ? "0" : info[9].ToString());
                        fc.List.Add(f);
                    }
                }
                list.Add(fc);
            }
            friendListView.BgColorMode = true;
            friendListView.InitFriendList(list);
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

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            //if (miniMode && WindowState == FormWindowState.Normal)
                //miniTimer.Enabled = true;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            //if (this.Top == 0 && WindowState == FormWindowState.Normal)
            //{
            //    Point p = Control.MousePosition;
            //    if (p.X < this.Left || p.X > this.Left + this.Width || p.Y > this.Top + this.Height)
            //        miniTimer.Enabled = true;
            //}
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            g = e.Graphics;
            Bmp = ResClass.GetResObj("main_png_bkg");
            g.DrawImage(Bmp, new Rectangle(0, 0, 5, 121), 5, 5, 5, 121, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(5, 0, this.Width - 10, 121), 10, 5, Bmp.Width - 20, 121, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(this.Width - 5, 0, 5, 121), Bmp.Width - 10, 5, 5, 121, GraphicsUnit.Pixel);

            g.DrawImage(Bmp, new Rectangle(0, 121, 2, this.Height - 182), 5, 126, 2, Bmp.Height - 192, GraphicsUnit.Pixel);
            //g.FillRectangle(Brushes.White, 2, 121, this.Width - 4, this.Height - 182);
            //g.DrawImage(Bmp, new Rectangle(2, 121, this.Width - 4, this.Height - 182), 7, 126, Bmp.Width - 14, Bmp.Height - 192, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(this.Width - 2, 121, 2, this.Height - 182), Bmp.Width - 7, 126, 2, Bmp.Height - 192, GraphicsUnit.Pixel);

            g.DrawImage(Bmp, new Rectangle(0, this.Height - 61, 5, 61), 5, Bmp.Height - 66, 5, 61, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(5, this.Height - 61, this.Width - 10, 61), 10, Bmp.Height - 66, Bmp.Width - 20, 61, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(this.Width - 5, this.Height - 61, 5, 61), Bmp.Width - 10, Bmp.Height - 66, 5, 61, GraphicsUnit.Pixel);

            g.DrawString(this.Text, f, titleColor, 10, 3);
            g.DrawString(NikeName, new Font(Font.FontFamily,10F,FontStyle.Bold), titleColor, 90, 34);

            Bmp = ResClass.GetResObj("main_search_bkg");
            g.DrawImage(Bmp, new Rectangle(2, 99, 9, Bmp.Height), 0, 0, 9, Bmp.Height, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(11, 99, this.Width - 22, Bmp.Height), 9, 0, Bmp.Width - 18, Bmp.Height, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(this.Width - 11, 99, 9, Bmp.Height), Bmp.Width-9, 0, 9, Bmp.Height, GraphicsUnit.Pixel);
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
                case Win32.WM_NCLBUTTONDOWN:
                    description.Focus();
                    skinPanel_Leave(null, null);
                    base.WndProc(ref m);
                    break;
                case Win32.WM_LBUTTONDOWN:
                    description.Focus();
                    skinPanel_Leave(null, null);
                    base.WndProc(ref m);
                    break;
                case Win32.WM_SYSCOMMAND:
                    if (m.WParam.ToInt32() == Win32.SC_MAXIMIZE || m.WParam.ToInt32() == Win32.SC_MAXIMIZE + 2)
                    {
                        if (!isOneLoad)
                        {
                            oldSize = this.Size;
                        }
                    }
                    else if (m.WParam == (IntPtr)Win32.SC_RESTORE || m.WParam.ToInt32() == Win32.SC_RESTORE + 2)
                    {
                        if (!isOneLoad)
                        {
                            this.Size = oldSize;
                        }
                    }
                    else if (m.WParam == (IntPtr)Win32.SC_MINIMIZE || m.WParam.ToInt32() == Win32.SC_MINIMIZE + 2)
                    {
                        if (oldSize.Width == 0)
                            oldSize = this.Size;
                    }
                    else if (m.WParam == (IntPtr)Win32.SC_CLOSE || m.WParam.ToInt32() == Win32.SC_CLOSE + 2)
                    {
                        Application.Exit();
                    }
                    base.WndProc(ref m);
                    break;
                case Win32.WM_NCHITTEST:
                    if (!miniMode)
                    {
                        Point vPoint = new Point((int)m.LParam & 0xFFFF, (int)m.LParam >> 16 & 0xFFFF);
                        vPoint = PointToClient(vPoint);
                        if (Top != 0)
                        {
                            if (vPoint.X <= 5)
                            {
                                if (vPoint.Y <= 5)
                                    m.Result = (IntPtr)Win32.HTTOPLEFT;
                                else if (vPoint.Y >= Height - 5)
                                    m.Result = (IntPtr)Win32.HTBOTTOMLEFT;
                                else m.Result = (IntPtr)Win32.HTLEFT;
                            }
                            else if (vPoint.X >= Width - 5)
                            {
                                if (vPoint.Y <= 5)
                                    m.Result = (IntPtr)Win32.HTTOPRIGHT;
                                else if (vPoint.Y >= Height - 5)
                                    m.Result = (IntPtr)Win32.HTBOTTOMRIGHT;
                                else m.Result = (IntPtr)Win32.HTRIGHT;
                            }
                            else if (vPoint.Y <= 5)
                            {
                                m.Result = (IntPtr)Win32.HTTOP;
                            }
                            else if (vPoint.Y >= Height - 5)
                                m.Result = (IntPtr)Win32.HTBOTTOM;
                        }
                        if (((vPoint.Y < 121 && vPoint.Y > 5) || (vPoint.Y > Height - 61 && vPoint.Y < Height - 5)) && (vPoint.X > 5 && vPoint.X < Width - 5))
                            m.Result = (IntPtr)Win32.HTCAPTION;
                    }
                    OnMouseEnter(null);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ResizeControl();
            if (!isOneLoad)
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    int Rgn = Win32.CreateRoundRectRgn(0, 0, this.Width + 1, this.Height + 1, 5, 5);
                    Win32.SetWindowRgn(this.Handle, Rgn, true);
                }
                else if (this.WindowState == FormWindowState.Maximized)
                {
                    int Rgn = Win32.CreateRoundRectRgn(0, 0, this.Width + 1, this.Height + 1, 0, 0);
                    Win32.SetWindowRgn(this.Handle, Rgn, true);
                }
            }
            Size size = Screen.PrimaryScreen.WorkingArea.Size;
            MaximizedBounds = new Rectangle(0, 0, size.Width, size.Height - 1);
            //this.Invalidate();
            GC.Collect();
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            oldSize = this.Size;
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
            }
            else
            {
                xwidth = ButtonClose.Left;
            }
            color_Btn.Left = Width - color_Btn.Width - 3;

            int tw = (Width - 4) / 4;
            fd_btn.Width = tw;
            gp_btn.Left = fd_btn.Left + fd_btn.Width;
            gp_btn.Width = tw;
            nt_btn.Left = gp_btn.Left + gp_btn.Width;
            nt_btn.Width = tw;
            lt_btn.Left = nt_btn.Left + nt_btn.Width;
            lt_btn.Width = Width - lt_btn.Left - 2;

            search_Btn.Left = Width - search_Btn.Width - 3;
            friendListView.Size = groupListView.Size = webBrowser1.Size = lastListView.Size = new Size(this.Width - 4, this.Height - 211);

            menu_Btn.Top = Height - menu_Btn.Height - 2;
            tools_Btn.Top = Height - tools_Btn.Height - 5;
            message_Btn.Top = Height - message_Btn.Height - 5;
            find_Btn.Top = Height - find_Btn.Height - 6;
        }

        private void LoadSkinList()
        {
            for (int i = 0; i < slist.Count; i++)
            {
                QQPictureBox pic = new QQPictureBox();
                pic.Texts = slist[i];
                pic.SizeMode = PictureBoxSizeMode.AutoSize;
                if (Directory.Exists(slist[i]))
                    pic.Image = Image.FromFile(slist[i] + "\\preview.png");
                else
                    pic.Image = ResClass.GetResObj(slist[i]);
                if (i < 7)
                {
                    pic.Left = i * 30 + 10 + i;
                    pic.Top = 45;
                }
                else
                {
                    pic.Left = (i - 7) * 30 + 10 + (i - 7);
                    pic.Top = 87;
                }
                pic.MouseEnter += new EventHandler(pic_MouseEnter);
                pic.MouseLeave += new EventHandler(pic_MouseLeave);
                pic.MouseClick += new MouseEventHandler(pic_MouseClick);
                skinPanel.Controls.Add(pic);
            }
        }

        private void pic_MouseClick(object sender, MouseEventArgs e)
        {
            QQPictureBox pic = sender as QQPictureBox;
            if (pic.Texts != currentSkin)
            {
                if (Directory.Exists(pic.Texts))
                {
                    friendListView.BgColorMode = false;
                    this.BackgroundImage = Image.FromFile(GetRealFile(pic.Texts + "\\main"));
                }
                else
                {
                    friendListView.BgColorMode = true;
                    this.BackgroundImage = null;
                }
                currentSkin = pic.Texts;
                GC.Collect();
                skinThread = new Thread(new ParameterizedThreadStart(ChangeSkin));
                skinThread.Start(this.BackgroundImage);
            }
            
        }

        private void ChangeSkin(object obj) 
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form f in fc)
            {
                if(f.Name!=this.Name)
                    f.BackgroundImage = (Image)obj;
            }
            GC.Collect();
        }

        private void pic_MouseLeave(object sender, EventArgs e)
        {
            (sender as QQPictureBox).Invalidate();
        }

        private void pic_MouseEnter(object sender, EventArgs e)
        {
            Bmp = ResClass.GetResObj("shading_highlight");
            g = (sender as QQPictureBox).CreateGraphics();
            g.DrawImage(Bmp, new Rectangle(0, 0, 30, 41), 0, 0, 30, 41, GraphicsUnit.Pixel);
            Bmp.Dispose();
            g.Dispose();
        }

        private void miniTimer_Tick(object sender, EventArgs e)
        {
            if (miniMode)
            {
                if (this.Top != 0)
                    this.Top = 0;
                else
                {
                    miniMode = false;
                    miniTimer.Enabled = false;
                }
            }
            else
            {
                if (this.Top == -(this.Height - 3))
                {
                    miniMode = true;
                    miniTimer.Enabled = false;
                }
                else
                    this.Top = -(this.Height - 3);
            }
        }

        private void tab_MouseEnter(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            p.BackgroundImage = ResClass.GetResObj("main_tab_highlight");
        }

        private void tab_MouseLeave(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            if (SelectTab == p.Name)
                p.BackgroundImage = ResClass.GetResObj("main_tab_check");
            else
                p.BackgroundImage = ResClass.GetResObj("main_tab_bkg");
        }

        private void tab_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            if (p.Name != SelectTab)
            {
                p.BackgroundImage = ResClass.GetResObj("main_tab_check");
                (Controls[SelectTab] as PictureBox).BackgroundImage = ResClass.GetResObj("main_tab_bkg");
                ChangeTabImg(p.Name, true);
                ChangeTabImg(SelectTab, false);
                ShowTab(p.Name);
                GC.Collect();
            }
        }

        private void ChangeTabImg(string name, bool select)
        {
            switch (name)
            {
                case "fd_btn":
                    if (select)
                        (Controls[name] as PictureBox).Image = ResClass.GetResObj("MainPanel_ContactMainTabButton_texture");
                    else
                        (Controls[name] as PictureBox).Image = ResClass.GetResObj("MainPanel_ContactMainTabButton_texture2");
                    break;
                case "gp_btn":
                    if (select)
                        (Controls[name] as PictureBox).Image = ResClass.GetResObj("MainPanel_GroupMainTabButton_texture");
                    else
                        (Controls[name] as PictureBox).Image = ResClass.GetResObj("MainPanel_GroupMainTabButton_texture2");
                    break;
                case "nt_btn":
                    if (select)
                        (Controls[name] as PictureBox).Image = ResClass.GetResObj("WBlog_TabBtn_Focus");
                    else
                        (Controls[name] as PictureBox).Image = ResClass.GetResObj("WBlog_TabBtn_Normal");
                    break;
                case "lt_btn":
                    if (select)
                        (Controls[name] as PictureBox).Image = ResClass.GetResObj("MainPanel_RecentMainTabButton_texture");
                    else
                        (Controls[name] as PictureBox).Image = ResClass.GetResObj("MainPanel_RecentMainTabButton_texture2");
                    break;
            }
        }

        private void ShowTab(string selectTab)
        {
            switch (SelectTab)
            {
                case "fd_btn":
                    friendListView.Hide();
                    switch (selectTab)
                    {
                        case "gp_btn":
                            groupListView.Show();
                            break;
                        case "nt_btn":
                            webBrowser1.Show();
                            break;
                        case "lt_btn":
                            lastListView.Show();
                            break;
                    }
                    break;
                case "gp_btn":
                    groupListView.Hide();
                    switch (selectTab)
                    {
                        case "fd_btn":
                            friendListView.Show();
                            break;
                        case "nt_btn":
                            webBrowser1.Show();
                            break;
                        case "lt_btn":
                            lastListView.Show();
                            break;
                    }
                    break;
                case "nt_btn":
                    webBrowser1.Hide();
                    switch (selectTab)
                    {
                        case "fd_btn":
                            friendListView.Show();
                            break;
                        case "gp_btn":
                            groupListView.Show();
                            break;
                        case "lt_btn":
                            lastListView.Show();
                            break;
                    }
                    break;
                case "lt_btn":
                    lastListView.Hide();
                    switch (selectTab)
                    {
                        case "fd_btn":
                            friendListView.Show();
                            break;
                        case "nt_btn":
                            webBrowser1.Show();
                            break;
                        case "gp_btn":
                            groupListView.Show();
                            break;
                    }
                    break;
            }
            SelectTab = selectTab;
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackgroundImage = ResClass.GetResObj("allbtn_highlight");
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackgroundImage = null;
        }

        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ((PictureBox)sender).BackgroundImage = ResClass.GetResObj("allbtn_down");
            }
        }

        private void btn_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ((PictureBox)sender).Invalidate();
            }
        }

        private void con_MouseEnter(object sender, EventArgs e)
        {
            Control label = ((Control)sender);
            g = ((Control)sender).CreateGraphics();
            Bmp = ResClass.GetResObj("allbtn_highlight");
            g.DrawImage(Bmp, new Rectangle(0, 0, 2, label.Height), 0, 0, 2, Bmp.Height, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(2, 0, label.Width - 5, label.Height), 2, 0, Bmp.Width - 5, Bmp.Height, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(label.Width - 3, 0, 3, label.Height), Bmp.Width - 3, 0, 3, Bmp.Height, GraphicsUnit.Pixel);
            Bmp.Dispose();
            g.Dispose();
        }

        private void con_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).Invalidate();
        }

        private void menu_Btn_MouseEnter(object sender, EventArgs e)
        {
            menu_Btn.Image = ResClass.GetPNG("menu_btn_highlight");
        }

        private void menu_Btn_MouseLeave(object sender, EventArgs e)
        {
            menu_Btn.Image = ResClass.GetPNG("menu_btn_normal");
        }

        private void color_Btn_Click(object sender, EventArgs e)
        {
            if (skinPanel.Visible)
            {
                skinPanel.Hide();
            }
            else
            {
                skinPanel.Left = this.Width - skinPanel.Width - 2;
                skinPanel.Height = 140;
                skinPanel.BringToFront();
                skinPanel.Show();
                skinPanel.Focus();
            }
        }

        private void color_Btn_MouseEnter(object sender, EventArgs e)
        {
            if (!skinPanel.Visible)
            {
                Bmp = ResClass.GetResObj("allbtn_highlight");
                g = color_Btn.CreateGraphics();
                g.DrawImage(Bmp, new Rectangle(0, 0, 22, 22), 0, 0, 22, 22, GraphicsUnit.Pixel);
                Bmp.Dispose();
                g.Dispose();
            }
        }

        private void color_Btn_MouseLeave(object sender, EventArgs e)
        {
            if (!skinPanel.Visible)
            {
                color_Btn.Invalidate();
            }
        }

        private void skinPanel_Leave(object sender, EventArgs e)
        {
            if (skinPanel.Visible)
            {
                skinPanel.Hide();
                color_Btn_MouseLeave(null, null);
            }
        }

        private void skinPanel_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            Bmp = ResClass.GetResObj("ShadingBkg");
            g.DrawImage(Bmp, new Rectangle(9, 44, Bmp.Width, Bmp.Height), 0, 0, Bmp.Width, Bmp.Height, GraphicsUnit.Pixel);
        }

        private void color_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                g = color_Btn.CreateGraphics();
                g.Clear(Color.Transparent);
                Bmp = ResClass.GetResObj("allbtn_down");
                g.DrawImage(Bmp, new Rectangle(0, 0, 22, 22), 0, 0, 22, 22, GraphicsUnit.Pixel);
                g.DrawImage(color_Btn.Image, new Rectangle(2, 3, 18, 18), 0, 0, 18, 18, GraphicsUnit.Pixel);
                Bmp.Dispose();
                g.Dispose();
            }
        }

        private void color_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!skinPanel.Visible)
                {
                    color_Btn.Invalidate();
                }
            }
        }

        #endregion

        #region 控制按钮实现
        private void ButtonClose_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Application.Exit();
        }

        private void ButtonClose_MouseDown(object sender, MouseEventArgs e)
        {
            closeBmp = ResClass.GetResObj("btn_close_down");
            ButtonClose.Invalidate();
        }

        private void ButtonClose_MouseUp(object sender, MouseEventArgs e)
        {
            if (!ButtonClose.IsDisposed)
            {
                closeBmp = ResClass.GetResObj("btn_close_normal");
                ButtonClose.Invalidate();
            }
        }

        private void ButtonClose_MouseLeave(object sender, EventArgs e)
        {
            closeBmp = ResClass.GetResObj("btn_close_normal");
            ButtonClose.Invalidate();
        }

        private void ButtonClose_MouseEnter(object sender, EventArgs e)
        {
            closeBmp = ResClass.GetResObj("btn_close_highlight");
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
            minBmp = ResClass.GetResObj("btn_mini_highlight");
            toolTip1.SetToolTip(ButtonMin, "最小化");
            ButtonMin.Invalidate();
        }

        private void ButtonMin_MouseDown(object sender, MouseEventArgs e)
        {
            minBmp = ResClass.GetResObj("btn_mini_down");
            ButtonMin.Invalidate();
        }

        private void ButtonMin_MouseUp(object sender, MouseEventArgs e)
        {
            minBmp = ResClass.GetResObj("btn_close_normal");
            ButtonMin.Invalidate();
        }

        private void ButtonMin_MouseLeave(object sender, EventArgs e)
        {
            minBmp = ResClass.GetResObj("btn_mini_normal");
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
                    Win32.PostMessage(this.Handle, Win32.WM_SYSCOMMAND, Win32.SC_MINIMIZE, 0);
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
            maxBmp = ResClass.GetResObj("btn_max_down");
            if (this.WindowState == FormWindowState.Maximized)
            {
                maxBmp = ResClass.GetResObj("btn_restore_down");
            }
            g.DrawImage(maxBmp, new Rectangle(0, 0, maxBmp.Width, maxBmp.Height), 0, 0, maxBmp.Width, maxBmp.Height, GraphicsUnit.Pixel);
        }

        private void ButtonMax_MouseEnter(object sender, EventArgs e)
        {
            g = ButtonMax.CreateGraphics();
            maxBmp = ResClass.GetResObj("btn_max_highlight");
            toolTip1.SetToolTip(ButtonMax, "最大化");
            if (this.WindowState == FormWindowState.Maximized)
            {
                maxBmp = ResClass.GetResObj("btn_restore_highlight");
                toolTip1.SetToolTip(ButtonMax, "还原");
            }
            g.DrawImage(maxBmp, new Rectangle(0, 0, maxBmp.Width, maxBmp.Height), 0, 0, maxBmp.Width, maxBmp.Height, GraphicsUnit.Pixel);
        }

        private void ButtonMax_MouseLeave(object sender, EventArgs e)
        {
            maxBmp = ResClass.GetResObj("btn_max_normal");
            if (this.WindowState == FormWindowState.Maximized)
            {
                maxBmp = ResClass.GetResObj("btn_restore_normal");
            }
            ButtonMax.Invalidate();
        }

        private void ButtonMax_MouseUp(object sender, MouseEventArgs e)
        {
            maxBmp = ResClass.GetResObj("btn_max_normal");
            if (this.WindowState == FormWindowState.Maximized)
            {
                maxBmp = ResClass.GetResObj("btn_restore_normal");
            }
            ButtonMax.Invalidate();
        }

        private void ButtonMax_Paint(object sender, PaintEventArgs e)
        {
            if (this.MaximizeBox)
            {
                g = e.Graphics;
                maxBmp = ResClass.GetResObj("btn_max_normal");
                if (this.WindowState == FormWindowState.Maximized)
                {
                    maxBmp = ResClass.GetResObj("btn_restore_normal");
                }
                g.DrawImage(maxBmp, new Rectangle(0, 0, maxBmp.Width, maxBmp.Height), 0, 0, maxBmp.Width, maxBmp.Height, GraphicsUnit.Pixel);
            }
        }

        private void ButtonMax_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.WindowState == FormWindowState.Normal)
                    Win32.PostMessage(this.Handle, Win32.WM_SYSCOMMAND, Win32.SC_MAXIMIZE, 0);
                else
                    Win32.PostMessage(this.Handle, Win32.WM_SYSCOMMAND, Win32.SC_RESTORE, 0);
                this.Invalidate();
            }
        }
        #endregion

        #region 辅助函数
        private Bitmap GetImg(string ImgName)
        {
            Image srcImg = ResClass.GetPNG(ImgName);
            return GetImg(ImgName, srcImg.Width, srcImg.Height, 0, 0, srcImg.Width, srcImg.Height);
        }

        private Bitmap GetImg(string ImgName, int i)
        {
            Image srcImg = ResClass.GetPNG(ImgName);
            return GetImg(ImgName, srcImg.Width / 4, srcImg.Height, srcImg.Width / 4 * i, 0, srcImg.Width / 4, srcImg.Height);
        }

        private Bitmap GetImg(string ImgName, int width, int height, int sleft, int stop, int sWidth, int sHeight)
        {
            Image srcImg = ResClass.GetPNG(ImgName);

            Bitmap newImg = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(newImg);

            graphics.DrawImage(srcImg, new Rectangle(0, 0, width, height), (sleft < 0 ? srcImg.Width + sleft : sleft), (stop < 0 ? srcImg.Height + stop : stop), (sWidth < 0 ? srcImg.Width + sWidth : sWidth), (sHeight < 0 ? srcImg.Height + sHeight : sHeight), GraphicsUnit.Pixel);
            graphics.Dispose();
            srcImg.Dispose();
            return newImg;
        }

        private string GetRealFile(string pimg)
        {
            string s1 = pimg + ".PNG";
            if (!File.Exists(s1))
            {
                s1 = pimg + ".BMP";
                if (!File.Exists(s1))
                {
                    s1 = pimg + ".jpg";
                    if (!File.Exists(s1))
                    {
                        s1 = pimg + ".jpeg";
                    }
                }
            }
            return s1;
        }
        #endregion

        private void qzone16_btn_MouseClick(object sender, MouseEventArgs e)
        {
            if (QzoneMouseClick != null)
                QzoneMouseClick(sender, e);
            else
            {
                Process.Start("http://www.seezt.com");
            }
        }

        private void mail_btn_MouseClick(object sender, MouseEventArgs e)
        {
            if (MailMouseClick != null)
                MailMouseClick(sender, e);
            else
            {
                Process.Start("http://www.seezt.com");
            }
        }

        private void search_Btn_MouseClick(object sender, MouseEventArgs e)
        {
            if (SearchMouseClick != null)
                SearchMouseClick(sender, e);
            else
            {
                Process.Start("http://www.seezt.com");
            }
        }

        private void menu_Btn_MouseClick(object sender, MouseEventArgs e)
        {
            if (MenuMouseClick != null)
                MenuMouseClick(sender, e);
            else
            {
                Process.Start("http://www.seezt.com");
            }
        }

        private void tools_Btn_MouseClick(object sender, MouseEventArgs e)
        {
            if (ToolsMouseClick != null)
                ToolsMouseClick(sender, e);
            else
            {
                BasicForm bf = new BasicForm();
                bf.BackgroundImage = this.BackgroundImage;
                bf.Text = "设置";
                bf.Size = new Size(600,400);
                bf.Show();
                //Process.Start("http://www.seezt.com");
            }
        }

        private void message_Btn_MouseClick(object sender, MouseEventArgs e)
        {
            if (MessageMouseClick != null)
                MessageMouseClick(sender, e);
            else
            {
                BasicForm bf = new BasicForm();
                bf.BackgroundImage = this.BackgroundImage;
                bf.Text = "消息管理器";
                bf.ShowIcon = false;
                bf.AllowMove = false;
                bf.Size = new Size(500, 300);
                bf.Show();
                //Process.Start("http://www.seezt.com");
            }
        }

        private void find_Btn_MouseClick(object sender, MouseEventArgs e)
        {
            if (FindMouseClick != null)
                FindMouseClick(sender, e);
            else
            {
                BasicForm bf = new BasicForm();
                bf.BackgroundImage = this.BackgroundImage;
                bf.Text = "查找好友";
                bf.AllowMove = false;
                bf.AllowResize = false;
                bf.Size = new Size(400, 500);
                bf.Show();
                //Process.Start("http://www.seezt.com");
            }
        }

        private void userImg_MouseEnter(object sender, EventArgs e)
        {
            userImg.BackgroundImage = ResClass.GetResObj("Padding4Select");
        }

        private void userImg_MouseLeave(object sender, EventArgs e)
        {
            userImg.BackgroundImage = ResClass.GetResObj("Padding4Normal");
        }

        private void description_MouseClick(object sender, MouseEventArgs e)
        {
            QQtextBox tb = new QQtextBox();
            tb.BorderStyle = BorderStyle.Fixed3D;
            tb.Text = description.Text;
            tb.Location = new Point(description.Left, description.Top - 2);
            tb.Size = new Size(description.Width, description.Height + 4);
            tb.Leave += new EventHandler(tb_Leave);
            tb.KeyDown += new KeyEventHandler(tb_KeyDown);
            Controls.Add(tb);
            tb.BringToFront();
            tb.Focus();
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                description.Focus();
        }

        private void tb_Leave(object sender, EventArgs e)
        {
            QQtextBox tb = sender as QQtextBox;
            description.Text = tb.Text;
            tb.Dispose();
            Controls.Remove(tb);
        }

        public string NikeName
        {
            get
            {
                return _NikeName;
            }
            set
            {
                _NikeName = value;
                this.Invalidate(new Rectangle(90,34,60,20));
            }
        }
    }
}
