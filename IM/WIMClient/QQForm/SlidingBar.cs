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
    [ToolboxItem(true)]
    public class SlidingBar : Panel
    {
        public SlidingBar(string Title)
        {

            //样式控制
            base.AutoScroll = false;
            base.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            base.BackColor = Color.White;
            base.Height = 20;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            this.Paint += new PaintEventHandler(SlidingBar_Paint);

            this.innerPanel = new Panel();
            this.innerPanel.AutoScroll = true;
            this.innerPanel.SetBounds(2, 20, this.Width - 4, this.Height - 20);
            this.innerPanel.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            this.Controls.Add(this.innerPanel);
            this.innerPanel.MouseClick += delegate { this.innerPanel.Focus(); };
            this.innerPanel.ControlAdded += delegate(object sender, ControlEventArgs e)
            {
                if (e.Control is Group)
                {
                    e.Control.SetBounds(0, (this.innerPanel.Controls.Count - 1) * 21, this.innerPanel.Width, 21);
                    (e.Control as Group).Expanded = false;
                }
                else if (e.Control is Recently)
                {
                    e.Control.SetBounds(0, (this.innerPanel.Controls.Count - 1) * 50, this.innerPanel.Width, 50);
                }
            };
            this.innerPanel.ControlRemoved += delegate
            {
                int top = 0;
                for (int i = 0; i < this.innerPanel.Controls.Count; i++)
                {
                    this.innerPanel.Controls[i].Top = top;
                    top += this.innerPanel.Controls[i].Height;
                }
            };

            this.Title = Title + string.Empty;

            this.callingUsers = new List<User>();
            this.drawUserHeadTimer = new System.Timers.Timer();
            this.drawUserHeadTimer.Interval = 300;
            this.drawUserHeadTimer.Elapsed += delegate
            {
                this.drawUserHead = !this.drawUserHead;
                this.Invalidate(new Rectangle(0, 0, 21, 21));

                if (this.callingUsers.Count == 0)
                    this.drawUserHeadTimer.Enabled = false;
            };

            this.soundPlayer = new System.Media.SoundPlayer(Properties.Resources.Sound_Folder);
        }

        #region 绘制
        bool _mouseIn;
        bool mouseIn
        {
            get { return this._mouseIn; }
            set
            {
                if (this._mouseIn != value)
                {
                    this._mouseIn = value;
                    this.Invalidate(new Rectangle(4, 12, this.Width - 9, 7));

                    this.Cursor = this._mouseIn ? Cursors.Hand : Cursors.Default;
                }
            }
        }

        void SlidingBar_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Pen pen = new Pen(Color.FromArgb(215, 240, 255));

            //上变色
            Brush brushUp = pen.Brush;
            Rectangle rect = new Rectangle(3, 1, this.Width - 7, 10);
            e.Graphics.FillRectangle(brushUp, rect);

            //下变色
            pen.Color = Color.FromArgb(194, 233, 255);
            Brush brushDown = pen.Brush;
            rect.Offset(0, 9);
            e.Graphics.FillRectangle(brushDown, rect);
            //鼠标指中时
            if (this.mouseIn)
            {
                rect = new Rectangle(3, 11, this.Width - 7, 8);
                LinearGradientBrush lineBrush = new LinearGradientBrush(rect, Color.FromArgb(179, 238, 254), Color.FromArgb(164, 244, 255), LinearGradientMode.Vertical);
                e.Graphics.FillRectangle(lineBrush, rect);

                lineBrush.Dispose();
            }

            //画有消息的用户头像
            if (this.callingUsers != null && this.callingUsers.Count > 0 && this.drawUserHead)
            {
                e.Graphics.DrawImage(this.callingUsers[0].Head, 5, 2, 16, 16);
            }

            //边框
            pen.Color = Color.FromArgb(102, 188, 230);
            e.Graphics.DrawLines(pen,
                new Point[]{
                    new Point(2,1),
                    new Point(2,18),
                    new Point(3,19),
                    new Point(this.Width-4,19),
                    new Point(this.Width-3,18),
                    new Point(this.Width-3,1),
                    new Point(this.Width-4,0),
                    new Point(3,0)});

            //标题
            float left = (this.Width - e.Graphics.MeasureString(this.Title, this.Font).Width) / 2 + 1;
            e.Graphics.DrawString(this.Title, this.Font, Brushes.SteelBlue, left, 5);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            Rectangle rect = new Rectangle(3, 0, this.Width - 7, 20);
            if (rect.Contains(e.Location))
                this.mouseIn = true;
            else
                this.mouseIn = false;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            this.mouseIn = false;
        }
        #endregion

        //样式控制
        public new bool AutoScroll { get { return false; } }
        public new AnchorStyles Anchor { get { return AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right; } }
        public new Color BackColor { get { return Color.White; } }


        Panel innerPanel { get; set; }
        public string Title { get; set; }
        System.Media.SoundPlayer soundPlayer;

        public void AddGroup(Group Group)
        {
            this.innerPanel.Controls.Add(Group);

            Group.UserCalling += delegate(User sender)
            {
                if (sender.Messages.Count > 0)
                {
                    this.callingUsers.Remove(sender);
                    this.callingUsers.Insert(0, sender);
                    this.drawUserHeadTimer.Enabled = true;
                }
                else
                {
                    this.callingUsers.Remove(sender);
                }
            };

            Group.SizeChanged += delegate
            {
                int top = this.innerPanel.VerticalScroll.Visible ? -this.innerPanel.VerticalScroll.Value : 0;
                for (int i = 0; i < this.innerPanel.Controls.Count; i++)
                {
                    Group group = this.innerPanel.Controls[i] as Group;
                    if (group == null)
                        continue;

                    group.Top = top;
                    top += group.Height;
                }
            };
        }
        public void RemoveGroup(Group Group)
        {
            this.innerPanel.Controls.Remove(Group);
        }       

        public void AddRecentlyCtrl(Recently Recently)
        {
            this.innerPanel.Controls.Add(Recently);
        }


        bool expanded = false;
        public bool Expanded
        {
            get { return this.expanded; }
            set
            {
                if (this.expanded != value)
                {
                    this.expanded = value;

                    if (this.expanded && this.OnExpanded != null)
                    {
                        if (Common.ClientUser.State != OnlineState.Quiet)
                            this.soundPlayer.Play();

                        this.OnExpanded(this);
                    }

                    if (!this.expanded)
                        this.Height = 20;
                }
            }
        }

        public delegate void ExpandedHandler(SlidingBar sender);
        public event ExpandedHandler OnExpanded;

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.Button == MouseButtons.Left)
            {
                Rectangle rect = new Rectangle(3, 0, this.Width - 7, 20);
                if (rect.Contains(e.Location) && !this.expanded)
                    this.Expanded = true;
            }

            this.Focus();
        }

        List<User> callingUsers;//记录有消息的用户，把最后的用户的头像画在SlidingBar上面。
        System.Timers.Timer drawUserHeadTimer;//画用户头像用的Timer
        bool drawUserHead;//要不要画，用于闪烁
    }
}
