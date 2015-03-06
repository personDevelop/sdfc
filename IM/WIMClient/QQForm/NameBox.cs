//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WIMClient
{
    public class NameBox : Panel
    {
        public NameBox()
        {
            //样式控制
            base.BackColor = Color.Transparent;
            this.Height = 38;

            //屏闭系统绘制
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint, true);
            this.UpdateStyles();
            this.DoubleBuffered = true;


            if (Common.ClientUser != null)
                Common.ClientUser.OnlineStateChanged += delegate { this.Invalidate(); };


            this.menu = new ContextMenuStrip();
            this.menu.Items.Add("在线", Properties.Resources.State_Online, delegate
            {
                //通讯部份没加进来，所以下面的代码就注释掉了。
                //可以看出，如果现在的状态是离线，那么选择在线，就是发送登陆
                //          如果现在的状态是其它状态，那么选择在线，就是改变状态了

                //if (Common.ClientUser.State == OnlineState.Offline)
                //    Common.ToCallLogin();
                //else
                //    Common.ToCallStateChanged(OnlineState.Online);
            });
            this.menu.Items.Add("忙碌", Properties.Resources.State_Busy, delegate
            {
                //if (IMLib.Common.ClientUser.State == OnlineState.Offline)
                //    IMLib.Common.ToCallLogin();

                //IMLib.Common.ToCallStateChanged(OnlineState.Busy);
            });
            this.menu.Items.Add("离开", Properties.Resources.State_Away, delegate
            {
                //if (IMLib.Common.ClientUser.State == OnlineState.Offline)
                //    IMLib.Common.ToCallLogin();

                //IMLib.Common.ToCallStateChanged(OnlineState.Away);
            });
            this.menu.Items.Add("静音", Properties.Resources.State_Quiet, delegate
            {
                //if (IMLib.Common.ClientUser.State == OnlineState.Offline)
                //    IMLib.Common.ToCallLogin();

                //IMLib.Common.ToCallStateChanged(OnlineState.Quiet);
            });
            this.menu.Items.Add(new ToolStripSeparator());
            this.menu.Items.Add("隐身", Properties.Resources.State_Hide, delegate
            {
                //if (IMLib.Common.ClientUser.State == OnlineState.Offline)
                //    IMLib.Common.ToCallLogin();

                //IMLib.Common.ToCallStateChanged(OnlineState.Hide);
            });
            this.menu.Items.Add("离线", Properties.Resources.State_Offline, delegate
            {
                //if (IMLib.Common.ClientUser.State != OnlineState.Offline)
                //    IMLib.Common.ToCallLogout();
            });
            this.menu.Items.Add(new ToolStripSeparator());
            this.menu.Items.Add("更改签名   ", null, delegate
            {
                this.BeginEdit();
            });
            this.menu.Items.Add("更换头像   ", null, delegate
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.AddExtension = true;
                ofd.Filter = "PNG 文件|*.png|JPG 文件|*.jpg|BMP 文件|*.bmp";
                ofd.FilterIndex = 0;
                ofd.Multiselect = false;
                ofd.Title = "选择头像文件";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Image img = Image.FromFile(ofd.FileName);
                    if (img.Width > 100 || img.Height > 100)
                    {
                        MessageBox.Show("头像大小请控制在 100*100 。", "提示", MessageBoxButtons.OK);
                        return;
                    }
                    Common.ClientUser.Head = (Bitmap)img;

                    //更新。如果头像是存在数据库，就更新数据库，如果是放在服务器，就通知服务器
                }
            });

            this.menu.Opened += delegate { this.mouseDown = true; this.Invalidate(); };
            this.menu.Closed += delegate { this.mouseOn = false; this.mouseDown = false; this.Invalidate(); };

            //设置签名
            this.textbox = new TextBox();
            this.textbox.BorderStyle = BorderStyle.None;
            this.textbox.Location = new Point(4, 23);
            this.textbox.Width = this.Width - 8;
            this.textbox.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            this.textbox.Visible = false;
            this.textbox.MaxLength = 20;
            this.textbox.LostFocus += delegate { this.EndEdit(); };
            this.textbox.KeyDown += delegate(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                    this.EndEdit();
            };
            this.Controls.Add(textbox);
        }
        TextBox textbox;

        public void BeginEdit()
        {
            this.textbox.Visible = true;
            this.textbox.Text = Common.ClientUser.Underwrite.Substring(1, Common.ClientUser.Underwrite.Length - 2);
        }

        public void EndEdit()
        {
            Common.ClientUser.Underwrite = "(" + this.textbox.Text + ")";
            this.textbox.Visible = false;
            //更新数据库
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            if (this.Parent != null && Common.ClientUser != null)
            {
                Graphics g = this.CreateGraphics();
                int length = (int)g.MeasureString(Common.ClientUser.Name + stateToText(), this.Font).Width + 26;
                length = Math.Min(length, this.Parent.Width - this.Left - 10);
                this.Width = length;
            }
        }

        //样式控制
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (this.Height != 38)
                this.Height = 38;

            if (Common.ClientUser != null && this.Parent != null)
            {
                Graphics g = this.CreateGraphics();
                int length = (int)g.MeasureString(Common.ClientUser.UserName + stateToText(), this.Font).Width + 26;
                length = Math.Min(length, this.Parent.Width - this.Left - 10);
                this.Width = length;
            }
        }

        ContextMenuStrip menu;

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(0, 0, 4, 4, 180, 90);
            gp.AddArc(this.Width - 5, 0, 4, 4, 270, 90);
            gp.AddArc(this.Width - 5, this.Height - 18 - 5, 4, 4, 0, 90);
            gp.AddArc(0, this.Height - 18 - 5, 4, 4, 90, 90);
            gp.CloseFigure();

            if (this.mouseDown)
            {
                LinearGradientBrush lineBrush = new LinearGradientBrush(new Point(this.Width / 2, 0), new Point(this.Width / 2, this.Height - 18), Color.FromArgb(25, 149, 205), Color.FromArgb(74, 184, 243));
                e.Graphics.FillPath(lineBrush, gp);

                //边框
                e.Graphics.DrawPath(new Pen(Color.FromArgb(19, 137, 191)), gp);
            }
            else if (this.mouseOn)
            {
                LinearGradientBrush lineBrush = new LinearGradientBrush(new Point(this.Width / 2, 0), new Point(this.Width / 2, this.Height - 18), Color.FromArgb(74, 184, 243), Color.FromArgb(25, 149, 205));
                e.Graphics.FillPath(lineBrush, gp);

                //边框
                e.Graphics.DrawPath(new Pen(Color.FromArgb(19, 137, 191)), gp);
            }

            if (Common.ClientUser != null)
            {
                //名字
                e.Graphics.DrawString(Common.ClientUser.UserName + stateToText(), this.Font, new Pen(Color.FromArgb(7, 30, 129)).Brush, 4, 4);

                //个性签名
                StringFormat sf = new StringFormat();
                sf.FormatFlags = StringFormatFlags.LineLimit;
                sf.Trimming = StringTrimming.EllipsisWord;
                e.Graphics.DrawString(Common.ClientUser.Underwrite, this.Font, new Pen(Color.FromArgb(26, 117, 192)).Brush, new RectangleF(4, 23, this.Width - 5, this.Height - 24), sf);
            }

            //三角
            int left = this.Width - 14;
            int top = this.mouseDown || this.mouseOn ? 8 : 7;

            GraphicsPath gpTriangle = new GraphicsPath();
            gpTriangle.AddLines(new Point[]{
                new Point(left,top),
                new Point(left+4,top+4),
                new Point(left+8,top)});
            gpTriangle.CloseFigure();
            e.Graphics.FillPath(new Pen(Color.FromArgb(7, 30, 129)).Brush, gpTriangle);
        }

        string stateToText()
        {
            switch (Common.ClientUser.State)
            {
                case OnlineState.Online:
                    return "[在线]";
                case OnlineState.Busy:
                    return "[忙碌]";
                case OnlineState.Away:
                    return "[离开]";
                case OnlineState.Quiet:
                    return "[静音]";
                case OnlineState.Hide:
                    return "[隐身]";
                case OnlineState.Offline:
                    return "[离线]";
                default:
                    return "[离线]";
            }
        }

        bool mouseOn, mouseDown;

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Y <= 19)
            {
                if (!this.mouseOn && !this.mouseDown)
                {
                    this.mouseOn = true;
                    this.Invalidate();
                }
            }
            else
            {
                this.mouseOn = false;
                this.mouseDown = false;
                this.Invalidate();
            }

        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (!this.menu.Visible)
            {
                this.mouseDown = false;
                this.mouseOn = false;
                this.Invalidate();
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            this.Focus();

            if (e.Button == MouseButtons.Left && e.Y <= 19)
                this.menu.Show(this, 0, 19);
            else if (e.Button == MouseButtons.Left && e.X > 4 && e.X < this.Width - 4 && e.Y > 23)
                this.BeginEdit();
        }
    }
}
