//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace WIMClient
{
    [ToolboxItem(false)]
    public class Recently : Label
    {
        public Recently(User User)
        {
            //样式控制
            base.AutoSize = false;
            base.Text = string.Empty;
            base.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            base.BackColor = Color.White;
            this.Height = 50;

            //屏闭系统绘制
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint, true);
            this.UpdateStyles();
            this.DoubleBuffered = true;

            this.user = User;
        }

        //样式控制
        public new bool AutoSize { get { return false; } }
        public new string Text { get { return string.Empty; } }
        public new AnchorStyles Anchor { get { return AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right; } }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (this.Height != 50)
                this.Height = 50;

            if (this.user != null)
            {
                this.textWidth = (int)this.CreateGraphics().MeasureString(this.user.Name, this.Font).Width;
                this.textLeft = Math.Max(2, (this.Width - this.textWidth) / 2);
            }
        }

        User user;
        public User User { get { return this.user; } }

        int textLeft, textWidth;//用于鼠标指中

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (this.user != null)
            {
                e.Graphics.DrawImage(this.user.Head, (this.Width - 32) / 2, 2, 32, 32);
                e.Graphics.DrawString(this.user.Name, this.Font, new Pen(Color.FromArgb(60, 60, 60)).Brush, this.textLeft, 38);

                //画框
                if (this.mouseOn)
                {
                    e.Graphics.DrawRectangle(new Pen(Color.FromArgb(160, 204, 241)), new Rectangle((this.Width - 32) / 2 - 2, 0, 36, 36));
                }
            }
        }

        #region 鼠标
        bool mouseOn;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Y <= 40)
            {
                if (e.X >= (this.Width - 32) / 2 - 2 && e.X <= (this.Width - 32) / 2 + 34)
                {
                    if (!this.mouseOn)
                    {
                        this.mouseOn = true;
                        this.Invalidate();
                    }
                }
                else
                {
                    if (this.mouseOn)
                    {
                        this.mouseOn = false;
                        this.Invalidate();
                    }
                }
            }
            else if (e.X >= this.textLeft && e.X <= this.textLeft + this.textWidth)
            {
                if (!this.mouseOn)
                {
                    this.mouseOn = true;
                    this.Invalidate();
                }
            }
            else
            {
                if (this.mouseOn)
                {
                    this.mouseOn = false;
                    this.Invalidate();
                }
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (this.mouseOn)
            {
                this.mouseOn = false;
                this.Invalidate();
            }
        }
        #endregion

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);

            //这里处理双击打开聊天窗口
        }
    }
}
