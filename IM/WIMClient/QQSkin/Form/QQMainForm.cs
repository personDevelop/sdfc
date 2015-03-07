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
using System.IO;
using System.Threading;
using WIMClient;


using NetworkCommsDotNet;

using System.Threading;
using System.IO;
using System.Xml;
using IMInterface;
using AuthorityEntity;

namespace WIMClient.Skin
{
    public partial class QQMainForm : Form
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
        private List<string> shadlist = null;
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
        private string _NikeName = "UI作者：翱翔的雄鹰";
        #endregion

        #region 初始化

        public QQMainForm()
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
            closeBmp = ResClass.GetImgRes("btn_close_normal");
            minBmp = ResClass.GetImgRes("btn_mini_normal");
            maxBmp = ResClass.GetImgRes("btn_max_normal");
            if (this.WindowState == FormWindowState.Maximized)
            {
                maxBmp = ResClass.GetImgRes("btn_restore_normal");
            }


            userImg.BackgroundImage = ResClass.GetImgRes("Padding4Normal");
            userImg.Image = ResClass.GetHead("big194");

            qzone16_btn.Image = ResClass.GetImgRes("qzone16");
            mail_btn.Image = ResClass.GetImgRes("mail");
            color_Btn.Image = ResClass.GetImgRes("colour");
            tools_Btn.Image = ResClass.GetImgRes("Tools");
            message_Btn.Image = ResClass.GetImgRes("message");
            find_Btn.Image = ResClass.GetImgRes("find");
            menu_Btn.Image = ResClass.GetImgRes("menu_btn_normal");

            skinPanel.BackgroundImage = ResClass.GetImgRes("MainBkg");
            select_shad.Image = ResClass.GetImgRes("TbShadingNormal");
            select_color.Image = ResClass.GetImgRes("TbAdjustColorNormal");
            skinPanel.BackgroundImage = ResClass.GetImgRes("MainBkg");
            colorPanel.BackgroundImage = ResClass.GetImgRes("RecentColorBkg");
            shadPanel.BackgroundImage = ResClass.GetImgRes("ShadingBkg");
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

            shadlist = new List<string>(14);
            shadlist.Add("pic_defaultcolor_normal");
            if (Directory.Exists(Application.StartupPath + "\\skins"))
            {
                string[] sd = Directory.GetDirectories(Application.StartupPath + "\\skins");
                for (int i = 0; i < sd.Length; i++)
                {
                    string[] sf = Directory.GetFiles(sd[i], "main*");
                    if (sf.Length > 0)
                    {
                        shadlist.Add(sd[i]);
                    }
                }
            }
            LoadShadList();
            LoadColorList();


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
            Bmp = ResClass.GetImgRes("main_png_bkg");
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
            g.DrawString(NikeName, new Font(Font.FontFamily, 10F, FontStyle.Bold), titleColor, 90, 34);

            Bmp = ResClass.GetImgRes("main_search_bkg");
            g.DrawImage(Bmp, new Rectangle(2, 99, 9, Bmp.Height), 0, 0, 9, Bmp.Height, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(11, 99, this.Width - 22, Bmp.Height), 9, 0, Bmp.Width - 18, Bmp.Height, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(this.Width - 11, 99, 9, Bmp.Height), Bmp.Width - 9, 0, 9, Bmp.Height, GraphicsUnit.Pixel);
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

            search_Btn.Left = Width - search_Btn.Width - 3;

            menu_Btn.Top = Height - menu_Btn.Height - 2;
            tools_Btn.Top = Height - tools_Btn.Height - 5;
            message_Btn.Top = Height - message_Btn.Height - 5;
            find_Btn.Top = Height - find_Btn.Height - 6;
        }

        private void LoadShadList()
        {
            for (int i = 0; i < shadlist.Count; i++)
            {
                QQPictureBox pic = new QQPictureBox();
                pic.Texts = shadlist[i];
                pic.SizeMode = PictureBoxSizeMode.AutoSize;
                if (Directory.Exists(shadlist[i]))
                    pic.Image = Image.FromFile(shadlist[i] + "\\preview.png");
                else
                    pic.Image = ResClass.GetImgRes(shadlist[i]);
                if (i < 7)
                {
                    pic.Left = i * 30 + 1 + i;
                    pic.Top = 1;
                }
                else
                {
                    pic.Left = (i - 7) * 30 + 1 + (i - 7);
                    pic.Top = 43;
                }
                pic.MouseEnter += new EventHandler(pic_MouseEnter);
                pic.MouseLeave += new EventHandler(pic_MouseLeave);
                pic.MouseClick += new MouseEventHandler(pic_MouseClick);
                shadPanel.Controls.Add(pic);
            }
        }

        private void LoadColorList()
        {
            //for (int i = 0; i < shadlist.Count; i++)
            //{
            //    QQPictureBox pic = new QQPictureBox();
            //    pic.Texts = shadlist[i];
            //    pic.SizeMode = PictureBoxSizeMode.AutoSize;
            //    if (Directory.Exists(shadlist[i]))
            //        pic.Image = Image.FromFile(shadlist[i] + "\\preview.png");
            //    else
            //        pic.Image = ResClass.GetResObj(shadlist[i]);
            //    if (i < 7)
            //    {
            //        pic.Left = i * 30 + 1 + i;
            //        pic.Top = 1;
            //    }
            //    else
            //    {
            //        pic.Left = (i - 7) * 30 + 1 + (i - 7);
            //        pic.Top = 43;
            //    }
            //    pic.MouseEnter += new EventHandler(pic_MouseEnter);
            //    pic.MouseLeave += new EventHandler(pic_MouseLeave);
            //    pic.MouseClick += new MouseEventHandler(pic_MouseClick);
            //    shadPanel.Controls.Add(pic);
            //}
        }

        private void pic_MouseClick(object sender, MouseEventArgs e)
        {
            QQPictureBox pic = sender as QQPictureBox;
            if (pic.Texts != currentSkin)
            {
                if (Directory.Exists(pic.Texts))
                {

                    this.BackgroundImage = Image.FromFile(GetRealFile(pic.Texts + "\\main"));
                }
                else
                {

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
                if (f.Name != this.Name)
                    f.BackgroundImage = (Image)obj;
            }
            GC.Collect();
        }

        private void pic_MouseLeave(object sender, EventArgs e)
        {
            (sender as QQPictureBox).Invalidate();
            //toolTip1.Hide((sender as QQPictureBox));
        }

        private void pic_MouseEnter(object sender, EventArgs e)
        {
            QQPictureBox qp = sender as QQPictureBox;
            Bmp = ResClass.GetImgRes("shading_highlight");
            g = qp.CreateGraphics();
            g.DrawImage(Bmp, new Rectangle(0, 0, 30, 41), 0, 0, 30, 41, GraphicsUnit.Pixel);
            Bmp.Dispose();
            g.Dispose();
            //toolTip1.Show(qp.Texts, qp);
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
            p.BackgroundImage = ResClass.GetImgRes("main_tab_highlight");
        }

        private void tab_MouseLeave(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            if (SelectTab == p.Name)
                p.BackgroundImage = ResClass.GetImgRes("main_tab_check");
            else
                p.BackgroundImage = ResClass.GetImgRes("main_tab_bkg");
        }

        private void tab_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            if (p.Name != SelectTab)
            {
                p.BackgroundImage = ResClass.GetImgRes("main_tab_check");
                (Controls[SelectTab] as PictureBox).BackgroundImage = ResClass.GetImgRes("main_tab_bkg");
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
                        (Controls[name] as PictureBox).Image = ResClass.GetImgRes("MainPanel_ContactMainTabButton_texture");
                    else
                        (Controls[name] as PictureBox).Image = ResClass.GetImgRes("MainPanel_ContactMainTabButton_texture2");
                    break;
                case "gp_btn":
                    if (select)
                        (Controls[name] as PictureBox).Image = ResClass.GetImgRes("MainPanel_GroupMainTabButton_texture");
                    else
                        (Controls[name] as PictureBox).Image = ResClass.GetImgRes("MainPanel_GroupMainTabButton_texture2");
                    break;
                case "nt_btn":
                    if (select)
                        (Controls[name] as PictureBox).Image = ResClass.GetImgRes("WBlog_TabBtn_Focus");
                    else
                        (Controls[name] as PictureBox).Image = ResClass.GetImgRes("WBlog_TabBtn_Normal");
                    break;
                case "lt_btn":
                    if (select)
                        (Controls[name] as PictureBox).Image = ResClass.GetImgRes("MainPanel_RecentMainTabButton_texture");
                    else
                        (Controls[name] as PictureBox).Image = ResClass.GetImgRes("MainPanel_RecentMainTabButton_texture2");
                    break;
            }
        }

        private void ShowTab(string selectTab)
        {
            switch (SelectTab)
            {

                case "gp_btn":

                    switch (selectTab)
                    {

                        case "lt_btn":
                            userPanel.Show();
                            break;
                    }
                    break;
                case "nt_btn":

                    switch (selectTab)
                    {

                        case "gp_btn":
                            userPanel.Show();
                            break;
                        case "lt_btn":
                            userPanel.Show();
                            break;
                    }
                    break;
                case "lt_btn":
                    userPanel.Show();
                    switch (selectTab)
                    {

                        case "gp_btn":

                            break;
                    }
                    break;
            }
            SelectTab = selectTab;
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackgroundImage = ResClass.GetImgRes("allbtn_highlight");
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackgroundImage = null;
        }

        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ((PictureBox)sender).BackgroundImage = ResClass.GetImgRes("allbtn_down");
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
            Bmp = ResClass.GetImgRes("allbtn_highlight");
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
            menu_Btn.Image = ResClass.GetImgRes("menu_btn_highlight");
        }

        private void menu_Btn_MouseLeave(object sender, EventArgs e)
        {
            menu_Btn.Image = ResClass.GetImgRes("menu_btn_normal");
        }

        private void color_Btn_Click(object sender, EventArgs e)
        {
            if (skinPanel.Width == 0)
            {
                skinPanel.Left = this.Width - 238;
                skinPanel.Height = 140;
                skinPanel.Width = 236;
                skinPanel.BringToFront();
                skinPanel.Focus();
            }
            else
            {
                skinPanel.Width = 0;
            }
        }

        private void color_Btn_MouseEnter(object sender, EventArgs e)
        {
            if (skinPanel.Width == 0)
            {
                Bmp = ResClass.GetImgRes("allbtn_highlight");
                g = color_Btn.CreateGraphics();
                g.DrawImage(Bmp, new Rectangle(0, 0, 22, 22), 0, 0, 22, 22, GraphicsUnit.Pixel);
                Bmp.Dispose();
                g.Dispose();
            }
        }

        private void color_Btn_MouseLeave(object sender, EventArgs e)
        {
            if (skinPanel.Width == 0)
            {
                color_Btn.Invalidate();
            }
        }

        private void skinPanel_Leave(object sender, EventArgs e)
        {
            if (skinPanel.Width != 0)
            {
                skinPanel.Width = 0;
                color_Btn_MouseLeave(null, null);
            }
        }

        private void color_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                g = color_Btn.CreateGraphics();
                g.Clear(Color.Transparent);
                Bmp = ResClass.GetImgRes("allbtn_down");
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
                if (skinPanel.Width == 0)
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

        #region 微风 IM

        //窗体管理器
        private FormManager<ChatForm> chatFormManager = new FormManager<ChatForm>();

        public FormManager<ChatForm> ChatFormManager
        {
            set
            {
                this.chatFormManager = value;
            }
        }

        //同步锁
        private object syncLocker = new object();


        public void Initialize()
        {
            //获取我的所有好友
            GetAllMyFriend();


            //进行UI显示
            ShowUserBar();

            //获取P2P信息并进行连接
            NowGetP2PInfo();

            LinkUser.Text = "当前用户ID" + Common.UserID;
        }

        /// <summary>
        /// 获取我的好友
        /// </summary>
        public void GetAllMyFriend()
        {
            //获取之前先清空用户字典
            Common.AllUserDic.Clear();
            if (Common.AllUserDic.Count == 0)
            {
                //向服务器端发送信息并获取结果
                UserListContract userListContract = Common.TcpConn.SendReceiveObject<UserListContract>("GetFriends", "ResGetFriends", 5000, Common.UserID);

                //遍历加载好友
                foreach (IMUserInfo user in userListContract.UserList)
                {
                    //把用户添加到字典中
                    //根据性别 分别使用不同的图标
                    //if (user.IsMale)
                    //{
                    //    //Common.AddDicUser(user.ID, new User(user.ID, user.Name, user.Declaring, user.IsMale == true ? UserSex.Male : UserSex.Female, Properties.Resources.q1, "电话", "电子邮件", user.OnLine == true ? OnlineState.Online : OnlineState.Offline));
                    //}
                    //else
                    //{
                    //    //Common.AddDicUser(user.UserID, new User(user.UserID, user.Name, user.Declaring, user.IsMale == true ? UserSex.Male : UserSex.Female, Properties.Resources.q2, "电话", "电子邮件", user.OnLine == true ? OnlineState.Online : OnlineState.Offline));

                    //}
                }
            }
        }

        // Dictionary<组ID，列表<用户ID>>     
        // 存放每个组的组ID  以及本组对应的用户列表
        private Dictionary<int, List<string>> dicGroupUser = new Dictionary<int, List<string>>();

        //显示用户窗口
        private void ShowUserBar()
        {
            //SlidingBar bar = new SlidingBar("微风IM");


            //IList<UserGroup> resGroups = Common.TcpConn.SendReceiveObject<IList<UserGroup>>("GetGroup", "ResGroup", 5000, "GetGroup");

            ////获取所有用户ID 以及用户对应的组的组ID   
            //IList<UserGroupIDContract> allUserGroupID = Common.TcpConn.SendReceiveObject<IList<UserGroupIDContract>>("GetUserGroupID", "ResUserGroupID", 5000, "100");

            ////根据用户组，初始化用户组字典
            //foreach (UserGroup group in resGroups)
            //{
            //    dicGroupUser.Add(group.Id, new List<string>());

            //}
            ////把用户，根据用户ID添加到字典中
            //foreach (UserGroupIDContract contract in allUserGroupID)
            //{
            //    if (dicGroupUser.ContainsKey(contract.GroupID))
            //    {
            //        dicGroupUser[contract.GroupID].Add(contract.SenderID);
            //    }
            //}
            ////实例化每一个用户组
            //foreach (UserGroup userGroup in resGroups)
            //{
            //    Group newGroup = new Group(userGroup.Id.ToString(), userGroup.GroupName);

            //    IList<string> lstUserID = dicGroupUser[userGroup.Id];


            //    foreach (string userID in lstUserID)
            //    {
            //        User currUser = Common.GetDicUser(userID);
            //        newGroup.Users.Add(currUser);
            //    }
            //    bar.AddGroup(newGroup);
            //}

            //bar.Location = new System.Drawing.Point(0, 0);
            //bar.Name = "slidingBarContainer1";
            //bar.Size = new System.Drawing.Size(500, 500);
            //bar.Dock = DockStyle.Fill;
            //bar.TabIndex = 50;
            //this.userPanel.Controls.Add(bar);
            ////this.Controls.Add(bar);
            //this.userPanel.BringToFront();
        }

        //获取所有在线用户  GetAllMyFriend已包含本方法  本方法不再使用  
        private void GetAllOnlineUser()
        {
            //UserIDContract contract = Common.TcpConn.SendReceiveObject<UserIDContract>("GetOnlineUser", "ResOnlineUser", 5000, "Get");

            //foreach (string theUserID in contract.UsersID)
            //{
            //    Common.GetDicUser(theUserID).State = OnlineState.Online;

            //}
        }

        public delegate void Action();
        public void NowGetP2PInfo()
        {
            new Action(this.GetP2PInfo).BeginInvoke(null, null);
        }

        //获取所有在线用户的信息
        private void GetP2PInfo()
        {
            //IList<UserIDEndPoint> userInfoList = Common.TcpConn.SendReceiveObject<IList<UserIDEndPoint>>("GetP2PInfo", "ResP2pInfo", 5000, "GetP2P");

            //foreach (UserIDEndPoint userInfo in userInfoList)
            //{
            //    try
            //    {
            //        if (userInfo.UserID != Common.UserID)
            //        {
            //            LogInfo.LogMessage("准备建立" + userInfo.UserID + ":" + userInfo.IPAddress + ":" + userInfo.Port.ToString(), "P2PInfo");

            //            ConnectionInfo connInfo = new ConnectionInfo(userInfo.IPAddress, userInfo.Port);
            //            Connection newTcpConnection = TCPConnection.GetConnection(connInfo);
            //            Common.AddUserConn(userInfo.UserID, newTcpConnection);


            //            SetUpP2PContract contract = new SetUpP2PContract();
            //            contract.SenderID = Common.UserID;

            //            //P2p通道打通后，发送一个消息给对方用户，以便于对方用户收到消息后，建立P2P通道
            //            newTcpConnection.SendObject("SetupP2PMessage", contract);



            //            LogInfo.LogMessage("已经建立" + userInfo.UserID + ":" + userInfo.IPAddress + ":" + userInfo.Port.ToString(), "P2PInfo");
            //        }

            //    }
            //    catch
            //    {
            //    }

            //}

        }
        #endregion

        private void qzone16_btn_MouseClick(object sender, MouseEventArgs e)
        {
            if (QzoneMouseClick != null)
                QzoneMouseClick(sender, e);
            else
            {
                Process.Start("http://www.networkcomms.cn");
            }
        }

        private void mail_btn_MouseClick(object sender, MouseEventArgs e)
        {
            if (MailMouseClick != null)
                MailMouseClick(sender, e);
            else
            {
                Process.Start("http://www.networkcomms.cn");
            }
        }

        private void search_Btn_MouseClick(object sender, MouseEventArgs e)
        {
            if (SearchMouseClick != null)
                SearchMouseClick(sender, e);
            else
            {
                Process.Start("http://www.networkcomms.cn");
            }
        }

        private void menu_Btn_MouseClick(object sender, MouseEventArgs e)
        {
            if (MenuMouseClick != null)
                MenuMouseClick(sender, e);
            else
            {
                Process.Start("http://www.networkcomms.cn");
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
                bf.Size = new Size(600, 400);
                bf.Show();
                //Process.Start("http://www.networkcomms.cn");
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
                //Process.Start("http://www.networkcomms.cn");
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
                //Process.Start("http://www.networkcomms.cn");
            }
        }

        private void userImg_MouseEnter(object sender, EventArgs e)
        {
            userImg.BackgroundImage = ResClass.GetImgRes("Padding4Select");
        }

        private void userImg_MouseLeave(object sender, EventArgs e)
        {
            userImg.BackgroundImage = ResClass.GetImgRes("Padding4Normal");
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
                this.Invalidate(new Rectangle(90, 34, 60, 20));
            }
        }

        private void select_shad_Click(object sender, EventArgs e)
        {
            if (!shadPanel.Visible)
            {
                colorPanel.Hide();
                shadPanel.Show();
            }
        }

        private void select_color_Click(object sender, EventArgs e)
        {
            if (!colorPanel.Visible)
            {
                shadPanel.Hide();
                colorPanel.Show();
            }
        }

        private void QQMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            NetworkComms.Shutdown();
            this.Dispose();
        }

        private void QQMainForm_Load(object sender, EventArgs e)
        {
            //不启用日志记录

            NetworkComms.DisableLogging();

            //用户状态改变通知<5>
            NetworkComms.AppendGlobalIncomingPacketHandler<UserStateContract>("UserStateNotify", IncomingUserStateNotify);


            //服务器通知客户断开 一般是由于有新连接进入<6>

            NetworkComms.AppendGlobalIncomingPacketHandler<string>("CloseConnection", IncomingCloseConn);

            //收到服务器转发来的聊天消息
            NetworkComms.AppendGlobalIncomingPacketHandler<MsgEntity>("ServerChatMessage", IncomingChatMessage);

            NetworkComms.AppendGlobalIncomingPacketHandler<MsgEntity>("ClientChatMessage", IncomingClientChatMessage);

            NetworkComms.AppendGlobalIncomingPacketHandler<SetUpP2PContract>("SetupP2PMessage", IncomingSetupP2PMessage);
            GetMyOfflineMessage();
        }

        #region 处理方法

        //用户状态改变通知<5>
        private void IncomingUserStateNotify(PacketHeader header, Connection connection, UserStateContract userStateContract)
        {
            if (userStateContract.OnLine == IMInterface.OnlineState.Online)
            {
                lock (syncLocker)
                {
                    Common.GetDicUser(userStateContract.UserID).State = OnlineState.Online;
                }
            }
            else
            {
                lock (syncLocker)
                {
                    //Common.GetDicUser(userStatecontract.SenderID).State = OnlineState.Offline;
                    ////当某用户下线后，删除此用户相关的p2p 通道
                    //Common.RemoveUserConn(userStatecontract.SenderID);
                }
            }
        }

        //服务器通知连接断开 <6>

        private void IncomingCloseConn(PacketHeader header, Connection connection, string msg)
        {
            //服务器通知关闭程序  
            this.Close();


        }

        //获取离线消息

        private void GetMyOfflineMessage()
        {
            //UserInfo info = new UserInfo(Common.UserID, "password");

            //Common.TcpConn.SendObject("GetMyOffLineMsg", info);
        }


        //处理服务器转发来的聊天消息
        private void IncomingChatMessage(PacketHeader header, Connection connection, MsgEntity chatContract)
        {
            HandleTextChat(chatContract);
        }

        //处理客户端发来的聊天消息
        private void IncomingClientChatMessage(PacketHeader header, Connection connection, MsgEntity chatContract)
        {
            //如果是P2P消息，则直接把连接添加到Common静态类中

            if (!Common.ContainsUserConn(chatContract.SenderID))
            {
                Common.AddUserConn(chatContract.SenderID, connection);
            }

            LogInfo.LogMessage("当前用户:" + Common.UserID + "收到P2P消息" + "本地端口是：" + connection.ConnectionInfo.LocalEndPoint.Port.ToString(), "P2PInfo");


            HandleTextChat(chatContract);


        }

        //收到创建P2P通道的消息
        private void IncomingSetupP2PMessage(PacketHeader header, Connection connection, SetUpP2PContract contract)
        {
            //如果还没有P2P通道，则创建之
            if (!Common.ContainsUserConn(contract.UserID))
            {
                Common.AddUserConn(contract.UserID, connection);

            }
            LogInfo.LogMessage("收到P2P创建连接消息" + "本地端口是：" + connection.ConnectionInfo.LocalEndPoint.Port.ToString(), "P2PInfo");
        }


        public void HandleTextChat(MsgEntity contract)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<MsgEntity>(this.HandleTextChat), contract);
            }
            else
            {
                ChatForm form = Common.ChatFormManager.GetForm(contract.SenderID);
                if (form == null)
                {
                    //if (chatUserId.Contains(contract.SenderID))
                    if (Common.ContainsUserID(contract.SenderID))
                    {
                        Common.AddUserMsg(contract);
                    }
                    //如果chatUserId中没有此用户ID,那么添加相应的id和消息。并触发FormNotOpen事件
                    else
                    {
                        //chatUserId.Add(contract.SenderID);
                        Common.AddUserID(contract.SenderID);

                        List<MsgEntity> list = new List<MsgEntity>();
                        list.Add(contract);


                        Common.AddNewUserMsg(contract.SenderID, list);
                        //让托盘图标开始跳动
                        this.timeMessage.Enabled = true;

                        //让好友面板开始跳动

                        Common.GetDicUser(contract.SenderID).Messages.Add(contract);
                    }
                }
                else
                {
                    List<MsgEntity> list = new List<MsgEntity>();
                    list.Add(contract);
                    form.ShowOtherTextChat(contract.SenderID, list);
                    form.Activate();


                }

            }
        }


        #endregion


        #region  启动Timer  启动托盘栏上的消息跳动  从第一开始。
        int displayId = 0;
        private void timeMessage_Tick(object sender, EventArgs e)
        {

            if (Common.UserIDCount() > 0)
            {

                //取得chatUserID数组中第一个用户ID
                string destUserID = Common.FirstUserID();
                //判断当前用户的性别
                bool isMale = Common.GetDicUser(destUserID).Sex == UserSex.Male ? true : false;

                Icon i1;
                if (isMale)
                {

                    i1 = Properties.Resources.Male;
                }
                else
                {
                    i1 = Properties.Resources.FeMale;
                }

                Icon i2 = Properties.Resources.KongBai;

                if (displayId == 0)
                {
                    notifyIcon1.Icon = i2;
                    //面板上的消息跳动
                    //tsmiMessage.Image = ImageSmallFace.Images[102];
                    displayId++;
                }
                else
                {
                    notifyIcon1.Icon = i1;
                    //tsmiMessage.Image = ImageSmallFace.Images[103];
                    displayId--;
                }
            }
            else
            {


                //做了一个判断，如果chatUserID与chatMsg不能对应，则清空他们。

                Common.ClearUserID();
                Common.ClearUserMsg();

                this.timeMessage.Enabled = false;
            }


        }
        #endregion



        //打开聊天窗口  并显示消息
        private void showAddMsg()
        {
            //if (chatMsgDic.Count > 0 && chatUserId.Count > 0)

            if (Common.UserMsgCount() > 0 && Common.UserIDCount() > 0)
            {
                //string destUserID = chatUserId[0];
                string msgUserID = Common.FirstUserID();

                if (msgUserID != "")
                {

                    ChatForm form = Common.ChatFormManager.GetForm(msgUserID);

                    if (form == null)
                    {

                        form = new ChatForm(Common.UserID, msgUserID);
                        Common.ChatFormManager.Add(form);
                        form.Show();

                    }
                    form.Focus();
                    //显示聊天信息
                    //this.chatFormManagerControl1.ShowChatMsg(chatMsg[destUserID],destUserID);

                    //form.ShowOtherTextChat(destUserID, chatMsgDic[destUserID]);

                    if (Common.ContainsUserID(msgUserID))
                    {
                        form.ShowOtherTextChat(msgUserID, Common.MsgContractList(msgUserID));
                    }
                    //从相关字典中删除相应信息.
                    //chatUserId.Remove(destUserID);
                    //chatMsgDic.Remove(destUserID);
                    Common.RemoveID(msgUserID);
                    Common.RemoveMsg(msgUserID);

                    Common.GetDicUser(msgUserID).Messages.Clear();

                    //如果字典中的消息为空，停止跳动，停止timeMessage
                    //if (chatUserId.Count == 0)
                    if (Common.UserIDCount() == 0)
                    {
                        //tsmiMessage.Image = ImageSmallFace.Images[103];

                        this.timeMessage.Enabled = false;
                    }
                }

            }
            else
            {
                //tsmiMessage.Image = ImageSmallFace.Images[103];

                //做了一个判断，如果chatUserID与chatMsg不能对应，则清空他们。
                //chatUserId.Clear();
                //chatMsgDic.Clear();
                Common.ClearUserID();
                Common.ClearUserMsg();

                this.timeMessage.Enabled = false;
            }
        }
        //双击托盘图标    显示当前窗口 
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            showAddMsg();
            this.Show();
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Maximized;
                this.ShowInTaskbar = true;
            }
            this.Activate();
        }



        private bool toExit = false;



        private void display_Click(object sender, EventArgs e)
        {
            this.Show();
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Maximized;
            this.Activate();
        }

        private void 查看P2P通道信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            P2PUserForm form = new P2PUserForm();
            form.Show();
        }

        private void LinkP2P_Click(object sender, EventArgs e)
        {
            P2PUserForm form = new P2PUserForm();
            form.Show();
        }
    }
}
