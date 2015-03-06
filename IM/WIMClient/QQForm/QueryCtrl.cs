//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WIMClient
{
    public class QueryCtrl : UserControl
    {
        public QueryCtrl()
        {
            //样式控制
            base.AutoSize = false;
            base.Text = string.Empty;
            base.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            base.BackColor = Color.Transparent;
            this.Height = 21;

            //屏闭系统绘制
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint, true);
            this.UpdateStyles();
            this.DoubleBuffered = true;

            #region 输入框
            TextBox textbox = new TextBox();
            textbox.Text = "搜索我的好友";
            textbox.ForeColor = Color.Gray;
            textbox.BorderStyle = BorderStyle.None;
            textbox.Location = new Point(23, 4);
            textbox.Width = this.Width - 33;
            textbox.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            textbox.GotFocus += delegate
            {
                if (textbox.Text == "搜索我的好友")
                {
                    textbox.Text = "";
                    textbox.ForeColor = Color.Black;
                }
                else
                    textbox.SelectAll();
            };
            textbox.LostFocus += delegate
            {
                if (this.Text.Trim().Length == 0)
                {
                    textbox.Text = "搜索我的好友";
                    textbox.ForeColor = Color.Gray;
                    this.resultPanel.Visible = false;
                }
            };
            textbox.TextChanged += delegate
            {
                if (textbox.Text == "搜索我的好友" || textbox.Text.Trim().Length == 0)
                {
                    this.resultPanel.Visible = false;
                    return;
                }

                List<User> userList = Common.AllUsers.FindAll(u => u.UserID.Contains(textbox.Text) || u.UserName.Contains(textbox.Text));
                if (userList == null || userList.Count == 0)
                    this.resultPanel.Visible = false;
                else
                {
                    this.resultPanel.Controls.Clear();
                    for (int i = 0; i < userList.Count && i < 5; i++)
                    {
                        this.resultPanel.Controls.Add(userList[i].Clone());
                    }
                    this.resultPanel.UpdateHeight();
                    this.resultPanel.Visible = true;
                }
            };
            this.Controls.Add(textbox);

            textbox.KeyDown += delegate(object sender, KeyEventArgs e)
            {
                if (e.KeyCode != Keys.Enter)
                    return;


            };
            #endregion
        }

        //样式控制
        public new bool AutoSize { get { return false; } }
        public new string Text { get { return string.Empty; } }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (this.Height != 21)
                this.Height = 21;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //外框
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(0, 0, 20, 20, 90, 180);
            gp.AddArc(this.Width - 21, 0, 20, 20, 270, 180);
            gp.CloseFigure();

            e.Graphics.FillPath(Brushes.White, gp);
            e.Graphics.DrawPath(new Pen(Color.FromArgb(25, 101, 165)), gp);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(63, 139, 196)), 7, 0, this.Width - 8, 0);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(63, 139, 196)), 7, 20, this.Width - 8, 20);

            gp = new GraphicsPath();
            gp.AddArc(1, 1, 18, 18, 90, 180);
            gp.AddArc(this.Width - 20, 1, 18, 18, 270, 180);
            gp.CloseFigure();
            e.Graphics.DrawPath(new Pen(Color.FromArgb(210, 210, 210)), gp);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(220, 220, 220)), 9, 1, this.Width - 10, 1);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(220, 220, 220)), 9, 19, this.Width - 10, 19);

            //图标
            e.Graphics.DrawImage(Properties.Resources.QueryCtrl, 8, 4, 12, 12);
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            if (this.Parent != null)
            {
                this.resultPanel = new SeachResultPanel();
                this.resultPanel.Visible = false;
                this.Parent.Controls.Add(this.resultPanel);
                this.resultPanel.Location = new Point(this.Left + 12, this.Bottom + 1);
                this.resultPanel.Width = this.Width - 24;
            }
        }

        SeachResultPanel resultPanel;
    }
}
