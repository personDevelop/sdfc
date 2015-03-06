//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace WIMClient
{
    [ToolboxItem(false)]
    public class Tab : Label
    {
        public Tab(Image Image, string ToolTip)
        {
            this.init(Image, ToolTip);
        }

        public Tab(Image Image, string ToolTip, SlidingBarContainer SlidingBarContainer)
        {
            this.init(Image, ToolTip);
            this.slidingBarContainer = SlidingBarContainer;
        }

        void init(Image Image, string ToolTip)
        {
            //样式控制
            base.AutoSize = false;
            base.BackColor = Color.Transparent;
            base.Size = new Size(34, 34);

            //关闭系统绘制
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint, true);
            this.UpdateStyles();
            this.DoubleBuffered = true;

            //设置传参属性
            this.Image = Image;
            this.ToolTipText = ToolTip;

            //提示
            this.toolTip = new ToolTip();
        }

        //样式控制
        public new bool AutoSize { get { return false; } }
        public new Color BackColor { get { return Color.Transparent; } }
        public new Size Size { get { return new Size(32, 34); } }

        //关联 SlidingBars 控件
        SlidingBarContainer slidingBarContainer;
        public SlidingBarContainer SlidingBarContainer { get { return this.slidingBarContainer; } }

        ToolTip toolTip;
        public new Image Image { get; set; }
        public string ToolTipText { get; set; }
        bool selected;
        public bool Selected
        {
            get { return this.selected; }
            set
            {
                if (this.selected != value)
                {
                    this.selected = value;
                    this.Invalidate();
                    if (this.selected && this.SlidingBarContainer != null)
                    {
                        this.SlidingBarContainer.BringToFront();

                        if (this.OnSelected != null)
                            this.OnSelected(this);
                    }
                }
            }
        }
        public delegate void SelectedHandler(Tab tab);
        public event SelectedHandler OnSelected;

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.Button == MouseButtons.Left && !this.selected && this.SlidingBarContainer != null)
                this.Selected = true;
        }

        #region 提示
        bool mouseIn = false;
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            this.mouseIn = true;
            this.Invalidate();

            this.toolTip.Show(this.ToolTipText, this, this.Left, this.Height + 3);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            this.mouseIn = false;
            this.Invalidate();
            this.toolTip.Hide(this);
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (this.selected)
            {
                Rectangle rectUp = new Rectangle(1, 1, 33, 16);
                e.Graphics.FillRectangle(new Pen(Color.FromArgb(214, 240, 255)).Brush, rectUp);

                GraphicsPath gp = new GraphicsPath();
                gp.AddArc(0, 15, 17, 17, 90, 90);
                gp.AddLine(0, 15, 33, 15);
                gp.AddLine(33, 15, 33, 33);
                gp.CloseFigure();
                LinearGradientBrush lineBrush = new LinearGradientBrush(new Point(15, 15), new Point(15, 32), Color.FromArgb(168, 220, 248), Color.FromArgb(187, 230, 252));
                e.Graphics.FillPath(lineBrush, gp);

                GraphicsPath whiteGP = new GraphicsPath();
                whiteGP.AddLine(33, 32, 19, 32);
                whiteGP.AddArc(1, 14, 18, 18, 90, 90);
                whiteGP.AddLine(1, 14, 1, 1);
                whiteGP.AddLine(1, 1, 33, 1);
                e.Graphics.DrawPath(Pens.White, whiteGP);

                GraphicsPath gpBorder = new GraphicsPath();
                gpBorder.AddLine(33, 33, 18, 33);
                gpBorder.AddArc(0, 15, 18, 18, 90, 90);
                gpBorder.AddLine(0, 15, 0, 4);
                gpBorder.AddArc(0, 0, 4, 4, 180, 90);
                gpBorder.AddLine(4, 0, 33, 0);
                e.Graphics.DrawPath(new Pen(Color.FromArgb(76, 183, 240)), gpBorder);
            }
            else if (this.mouseIn)
            {
                GraphicsPath gpBorder = new GraphicsPath();
                gpBorder.AddLine(33, 33, 18, 33);
                gpBorder.AddArc(0, 15, 18, 18, 90, 90);
                gpBorder.AddLine(0, 15, 0, 4);
                gpBorder.AddArc(0, 0, 4, 4, 180, 90);
                gpBorder.AddLine(4, 0, 33, 0);
                Pen pen = new Pen(Color.FromArgb(120, Color.WhiteSmoke));
                e.Graphics.FillPath(pen.Brush, gpBorder);
            }

            if (this.Image != null)
                e.Graphics.DrawImage(this.Image, 6, 5, 20, 22);
        }
    }
}
