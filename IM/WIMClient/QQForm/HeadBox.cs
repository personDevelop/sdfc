
 
//www.networkcomms.cn  www.networkcomms.net  
 

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using AuthorityEntity.IM;

namespace WIMClient
{
    public class HeadBox : Label
    {
        
        public HeadBox()
        {
            //样式控制
            base.AutoSize = false;
            base.Text = string.Empty;
            base.BackColor = Color.Transparent;
            this.Size = new Size(52, 52);

            //屏闭系统绘制
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint, true);
            this.UpdateStyles();
            this.DoubleBuffered = true;

            if (Common.ClientUser != null)
                Common.ClientUser.OnlineStateChanged += delegate { this.Invalidate(); };
        }

        //样式控制
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (this.Size != new Size(52, 52))
                this.Size = new Size(52, 52);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //上变色
            GraphicsPath gpUp = new GraphicsPath();
            gpUp.AddArc(0, 0, 4, 4, 180, 90);
            gpUp.AddArc(this.Width - 5, 0, 4, 4, 270, 90);
            gpUp.AddLine(this.Width - 1, this.Height / 2 + 4, 0, this.Height / 2 + 4);
            gpUp.CloseFigure();
            LinearGradientBrush brushUp = new LinearGradientBrush(new Point(this.Width / 2, 0), new Point(this.Width / 2, this.Height / 2 + 4), Color.FromArgb(156, 221, 248), Color.FromArgb(113, 198, 238));
            e.Graphics.FillPath(brushUp, gpUp);

            //下变色
            GraphicsPath gpDown = new GraphicsPath();
            gpDown.AddArc(this.Width - 5, this.Height - 5, 4, 4, 0, 90);
            gpDown.AddArc(0, this.Height - 5, 4, 4, 90, 90);
            gpDown.AddLine(0, this.Height / 2 + 4, this.Width - 1, this.Height / 2 - 6);
            gpDown.CloseFigure();
            LinearGradientBrush brushDown = new LinearGradientBrush(new Point(this.Width / 2, this.Height / 2 - 6), new Point(this.Width / 2, this.Height - 1), Color.FromArgb(41, 173, 234), Color.FromArgb(116, 210, 253));
            e.Graphics.FillPath(brushDown, gpDown);

            if (Common.ClientUser != null)
            {
                //图标
                e.Graphics.DrawImage(Common.ClientUser.Head, 6, 6, 40, 40);
                //状态
                if (Common.ClientUser.State == OnlineState.Away)
                    e.Graphics.DrawImage(Properties.Resources.State_Away, 33, 33, 16, 16);
                else if (Common.ClientUser.State == OnlineState.Busy)
                    e.Graphics.DrawImage(Properties.Resources.State_Busy, 33, 33, 16, 16);
                else if (Common.ClientUser.State == OnlineState.Hide)
                    e.Graphics.DrawImage(Properties.Resources.State_Hide, 33, 33, 16, 16);
                else if (Common.ClientUser.State == OnlineState.Quiet)
                    e.Graphics.DrawImage(Properties.Resources.State_Quiet, 33, 33, 16, 16);
            }

            //白边
            Pen pen = new Pen(Color.White);
            pen.Width = 2;
            e.Graphics.DrawLine(pen, 0, 2, 0, this.Height - 4);
            e.Graphics.DrawLine(pen, 2, this.Height - 1, this.Width - 4, this.Height - 1);
            e.Graphics.DrawLine(pen, this.Width - 1, 2, this.Width - 1, this.Height - 4);
            e.Graphics.DrawLine(pen, 2, 0, this.Width - 4, 0);

            //外框
            GraphicsPath gpBorder = new GraphicsPath();
            gpBorder.AddArc(0, 0, 4, 4, 180, 90);
            gpBorder.AddArc(this.Width - 5, 0, 4, 4, 270, 90);
            gpBorder.AddArc(this.Width - 5, this.Height - 5, 4, 4, 0, 90);
            gpBorder.AddArc(0, this.Height - 5, 4, 4, 90, 90);
            gpBorder.CloseFigure();
            e.Graphics.DrawPath(new Pen(Color.FromArgb(76, 135, 183)), gpBorder);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            this.Focus();
        }
    }
}
