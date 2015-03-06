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

namespace WIMClient.Skin
{
    public partial class QQChatForm : Form
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
        private Font f = null;

        #endregion

        #region 初始化

        public QQChatForm()
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
            g.DrawImage(Bmp, new Rectangle(0, 0, 5, 81), 5, 5, 5, 81, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(5, 0, this.Width - 10, 81), 10, 5, Bmp.Width - 20, 81, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(this.Width - 5, 0, 5, 81), Bmp.Width - 10, 5, 5, 81, GraphicsUnit.Pixel);

            g.DrawImage(Bmp, new Rectangle(0, 81, 2, this.Height - 86), 5, 81, 2, Bmp.Height - 71, GraphicsUnit.Pixel);
            //g.FillRectangle(Brushes.White, 2, 81, this.Width - 4, this.Height - 86);
            //g.DrawImage(Bmp, new Rectangle(2, 121, this.Width - 4, this.Height - 182), 7, 126, Bmp.Width - 14, Bmp.Height - 192, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(this.Width - 2, 81, 2, this.Height - 86), Bmp.Width - 7, 81, 2, Bmp.Height - 71, GraphicsUnit.Pixel);

            //g.DrawImage(Bmp, new Rectangle(0, this.Height - 61, 5, 61), 5, Bmp.Height - 66, 5, 61, GraphicsUnit.Pixel);
            //g.DrawImage(Bmp, new Rectangle(5, this.Height - 61, this.Width - 10, 61), 10, Bmp.Height - 66, Bmp.Width - 20, 61, GraphicsUnit.Pixel);
            //g.DrawImage(Bmp, new Rectangle(this.Width - 5, this.Height - 61, 5, 61), Bmp.Width - 10, Bmp.Height - 66, 5, 61, GraphicsUnit.Pixel);

            g.DrawString(this.Text, f, titleColor, 10, 3);
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
                    base.WndProc(ref m);
                    break;
                case Win32.WM_LBUTTONDOWN:
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
    }
}
