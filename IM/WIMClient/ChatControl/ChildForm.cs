using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace WIMClient
{
    public partial class ChildForm : Form
    {
        public ChildForm()
        {
            InitializeComponent();

            base.ControlBox = false;
            base.BackColor = Color.FromArgb(190, 232, 255);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;

            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint, true);
            this.UpdateStyles();
            this.DoubleBuffered = true;

            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ControlBox = true;
        }

        public new bool ControlBox { get; set; }
        public new bool MinimizeBox { get; set; }
        public new bool MaximizeBox { get; set; }

        public bool IsNoticeForm { get; set; }


        [DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        const int WM_NCPAINT = 0x0085;
        const int WM_NCACTIVATE = 0x0086;
        const int WM_NCLBUTTONDOWN = 0x00A1;
        const int WM_NCMOUSEMOVE = 0x00A0;
        const int WM_NCLBUTTONDBLCLK = 0x00A3;

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg != WM_NCLBUTTONDBLCLK)//系统绘制无效，双击标题栏无效
                base.WndProc(ref m);

            switch (m.Msg)
            {
                case WM_NCPAINT:
                case WM_NCACTIVATE:
                    #region 绘制
                    IntPtr handle = GetWindowDC(m.HWnd);
                    Graphics graphics = Graphics.FromHdc(handle);
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    drawTop(graphics);
                    drawTitleBar(graphics);
                    drawText(graphics);
                    drawBorderRect(graphics);
                    drawBorderLine(graphics);
                    drawMinBox(graphics);
                    drawMaxBox(graphics);
                    drawCloseBox(graphics);

                    graphics.Dispose();
                    ReleaseDC(m.HWnd, handle);
                    #endregion
                    break;
                case WM_NCMOUSEMOVE:
                    #region 控制按扭的是否选中检测
                    if (!this.ControlBox)
                        return;

                    Point mouseP = PointToClient(MousePosition);
                    bool draw = false;
                    if (mouseP.X < this.Width - (this.MinimizeBox ? 99 : this.MaximizeBox ? 69 : 39) || mouseP.Y > -10)
                    {
                        if (boxselect != boxSelect.Null)
                        {
                            boxselect = boxSelect.Null;
                            draw = true;
                        }
                    }
                    else if (mouseP.X < this.Width - 69 && this.MinimizeBox && this.MaximizeBox && mouseP.X>= this.Width-99)
                    {
                        if (boxselect == boxSelect.Min) return;

                        boxselect = boxSelect.Min;
                        draw = true;
                    }
                    else if (mouseP.X < this.Width - 39 && mouseP.X >= this.Width - 69)
                    {
                        if (!this.MaximizeBox)
                        {
                            if (boxselect == boxSelect.Min) return;

                            boxselect = boxSelect.Min;
                            draw = true;
                        }
                        else
                        {
                            if (boxselect == boxSelect.Other) return;

                            boxselect = boxSelect.Other;
                            draw = true;
                        }
                    }
                    else if (mouseP.X < this.Width - 9 && this.ControlBox && mouseP.X >= this.Width - 39)
                    {
                        if (boxselect == boxSelect.Close) return;

                        boxselect = boxSelect.Close;
                        draw = true;
                    }
                    else if (boxselect != boxSelect.Null)
                    {
                        boxselect = boxSelect.Null;
                        draw = true;
                    }

                    if (draw)
                    {
                        IntPtr handle1 = GetWindowDC(m.HWnd);
                        Graphics graphics1 = Graphics.FromHdc(handle1);
                        graphics1.SmoothingMode = SmoothingMode.AntiAlias;

                        drawMinBox(graphics1);
                        drawMaxBox(graphics1);
                        drawCloseBox(graphics1);

                        graphics1.Dispose();
                        ReleaseDC(m.HWnd, handle1);
                    }
                    #endregion
                    break;
                case WM_NCLBUTTONDOWN:
                    #region 点击控制按扭
                    switch (boxselect)
                    {
                        case boxSelect.Null:
                            break;
                        case boxSelect.Min:
                            if (this.MinimizeBoxClick != null)
                                this.MinimizeBoxClick(this, new EventArgs());
                            break;
                        case boxSelect.Other:
                            if (this.MaximizeBoxClick != null)
                                this.MaximizeBoxClick(this, new EventArgs());
                            break;
                        case boxSelect.Close:
                            if (this.CloseBoxClick != null)
                                this.CloseBoxClick(this, new EventArgs());
                            break;
                        default:
                            break;
                    }
                    #endregion
                    break;
            }
        }

        #region 绘制

        void drawTop(Graphics g)
        {
            Rectangle rect = new Rectangle(0, 0, this.Width, 7);
            LinearGradientBrush lineBrush = new LinearGradientBrush(rect, Color.FromArgb(175, 235, 255), Color.FromArgb(70, 187, 255), LinearGradientMode.Vertical);
            g.FillRectangle(lineBrush, rect);
        }

        void drawTitleBar(Graphics g)
        {
            Rectangle rect = new Rectangle(0, 6, this.Width, this.FormBorderStyle == FormBorderStyle.Sizable ? 24 : 22);
            LinearGradientBrush lineBrush = new LinearGradientBrush(rect, Color.FromArgb(70, 187, 255), Color.FromArgb(113, 204, 255), LinearGradientMode.Vertical);
            g.FillRectangle(lineBrush, rect);
        }

        void drawText(Graphics g)
        {
            //if (this.IsNoticeForm)
            //    g.DrawImage(Properties.Resources.NoticeFormICO, 4, 3, 26, 26);

            int x = (this.IsNoticeForm ? 34 : 6), y = 10;
            g.DrawString(this.Text, this.Font, Brushes.White, x - 1, y);
            g.DrawString(this.Text, this.Font, Brushes.White, x - 1, y - 1);
            g.DrawString(this.Text, this.Font, Brushes.White, x, y - 1);
            g.DrawString(this.Text, this.Font, Brushes.White, x + 1, y - 1);
            g.DrawString(this.Text, this.Font, Brushes.White, x + 1, y);
            g.DrawString(this.Text, this.Font, Brushes.White, x + 1, y + 1);
            g.DrawString(this.Text, this.Font, Brushes.White, x, y + 1);
            g.DrawString(this.Text, this.Font, Brushes.White, x - 1, y + 1);
            g.DrawString(this.Text, this.Font, Brushes.SteelBlue, x, y);
        }

        void drawBorderRect(Graphics g)
        {
            Rectangle rectLeft = new Rectangle(0, 29, 3, this.Height - 29);
            Rectangle rectBottom = new Rectangle(0, this.Height - 4, this.Width, 3);
            Rectangle rectRight = new Rectangle(this.Width - 4, 29, 3, this.Height - 29);

            LinearGradientBrush brushV = new LinearGradientBrush(new Point(0, 28), new Point(0, this.Height), Color.FromArgb(113, 204, 255), Color.FromArgb(76, 193, 255));
            Brush brushH = new Pen(Color.FromArgb(76, 193, 255)).Brush;
            g.FillRectangle(brushV, rectLeft);
            g.FillRectangle(brushH, rectBottom);
            g.FillRectangle(brushV, rectRight);
        }

        void drawBorderLine(Graphics g)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(0, 0, 12, 12, 180, 90);
            gp.AddArc(this.Width - 13, 0, 12, 12, 270, 90);
            gp.AddLine(this.Width - 1, this.Height - 1, 0, this.Height - 1);
            gp.CloseFigure();

            Pen pen = new Pen(Color.FromArgb(55, 116, 168));
            pen.Width = 2;
            g.DrawPath(pen, gp);
        }

        void drawMinBox(Graphics g)
        {
            if (!this.ControlBox || !this.MinimizeBox)
                return;

            int left = this.MaximizeBox ? this.Width - 96 : this.Width - 66;

            Rectangle rect = new Rectangle(left, 1, 30, 6);
            LinearGradientBrush brushUp = new LinearGradientBrush(new Point(this.Width / 2, 0), new Point(this.Width / 2, 7), Color.FromArgb(189, 239, 255), Color.FromArgb(99, 203, 247));
            g.FillRectangle(brushUp, rect);

            rect = new Rectangle(left, 7, 30, 11);
            LinearGradientBrush brushDown = new LinearGradientBrush(new Point(this.Width / 2, 6), new Point(this.Width / 2, 19), Color.FromArgb(60, 171, 226), Color.FromArgb(91, 192, 255));
            g.FillRectangle(brushDown, rect);

            if (boxselect == boxSelect.Min)
            {
                rect = new Rectangle(left+2, 15, 26, 4);
                g.FillRectangle(new Pen(Color.FromArgb(8, 231, 255)).Brush, rect);
            }

            
            Point[] points=new Point[]{
                new Point(left, 1),
                new Point(left,15),
                new Point(left+4,19),
                new Point(left+30,19),
                new Point(left+30,1)};

            Pen pen = new Pen(Color.FromArgb(181, 230, 255));
            pen.Width = 3;
            g.DrawLines(pen, points);

            pen = new Pen(Color.FromArgb(82, 162, 239));
            g.DrawLines(pen, points);

            g.DrawImage(Properties.Resources.Min, left+10, 4, 12, 12);
        }

        void drawMaxBox(Graphics g)
        {
            if (!this.ControlBox || !this.MaximizeBox)
                return;

            int left = this.Width - 66;

            Rectangle rect = new Rectangle(left, 1, 30, 6);
            LinearGradientBrush brushUp = new LinearGradientBrush(new Point(this.Width / 2, 0), new Point(this.Width / 2, 7), Color.FromArgb(189, 239, 255), Color.FromArgb(99, 203, 247));
            g.FillRectangle(brushUp, rect);

            rect = new Rectangle(left, 7, 30, 11);
            LinearGradientBrush brushDown = new LinearGradientBrush(new Point(this.Width / 2, 6), new Point(this.Width / 2, 19), Color.FromArgb(60, 171, 226), Color.FromArgb(91, 192, 255));
            g.FillRectangle(brushDown, rect);

            if (boxselect == boxSelect.Other)
            {
                rect = new Rectangle(left+2, 15, 26, 4);
                g.FillRectangle(new Pen(Color.FromArgb(8, 231, 255)).Brush, rect);
            }


            Point[] points =
                this.MinimizeBox ?
                new Point[]{
                new Point(left, 1),
                new Point(left,19),
                new Point(left+30,19),
                new Point(left+30,1)}
                :
                new Point[]{
                new Point(left, 1),
                new Point(left,15),
                new Point(left+4,19),
                new Point(left+30,19),
                new Point(left+30,1)};


            Pen pen = new Pen(Color.FromArgb(181, 230, 255));
            pen.Width = 3;
            g.DrawLines(pen, points);

            pen = new Pen(Color.FromArgb(82, 162, 239));
            g.DrawLines(pen, points);

            g.DrawImage(Properties.Resources.Other, left+10, 4, 12, 12);
        }

        void drawCloseBox(Graphics g)
        {
            if (!this.ControlBox)
                return;

            int left = this.Width - 36;

            Rectangle rect = new Rectangle(left, 1, 30, 9);
            LinearGradientBrush brushUp = new LinearGradientBrush(new Point(this.Width / 2, 0), new Point(this.Width / 2, 11),
                (this.boxselect == boxSelect.Close ? Color.FromArgb(224, 104, 38) : Color.FromArgb(189, 239, 255)),
                (this.boxselect == boxSelect.Close ? Color.FromArgb(160, 29, 7) : Color.FromArgb(99, 203, 247)));
            g.FillRectangle(brushUp, rect);

            rect = new Rectangle(left, 8, 30, 10);
            LinearGradientBrush brushDown = new LinearGradientBrush(new Point(this.Width / 2, 7), new Point(this.Width / 2, 19),
                (this.boxselect == boxSelect.Close ? Color.FromArgb(160, 29, 7) : Color.FromArgb(60, 171, 226)),
                (this.boxselect == boxSelect.Close ? Color.FromArgb(224, 104, 38) : Color.FromArgb(91, 192, 255)));
            g.FillRectangle(brushDown, rect);


            Point[] points =
                this.MinimizeBox || this.MaximizeBox ?
                new Point[]{
                new Point(left, 1),
                new Point(left,19),
                new Point(left+26,19),
                new Point(left+30,15),
                new Point(left+30,1)}
                :
                new Point[]{
                new Point(left, 1),
                new Point(left,15),
                new Point(left+4,19),
                new Point(left+26,19),
                new Point(left+30,15),
                new Point(left+30,1)};


            Pen pen = new Pen(Color.FromArgb(181, 230, 255));
            pen.Width = 3;
            g.DrawLines(pen, points);

            pen = new Pen(Color.FromArgb(82, 162, 239));
            g.DrawLines(pen, points);

            g.DrawImage(Properties.Resources.Close, this.Width - 26, 4, 12, 12);
        }

        boxSelect boxselect;
        enum boxSelect
        {
            Null,
            Min,
            Other,
            Close
        }

        #endregion


        public event EventHandler MinimizeBoxClick;
        public event EventHandler MaximizeBoxClick;
        public event EventHandler CloseBoxClick;
    }
}
