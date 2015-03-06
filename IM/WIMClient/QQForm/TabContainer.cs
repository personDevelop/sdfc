//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WIMClient
{
    public class TabContainer : Panel
    {
        public TabContainer()
        {
            //样式控制
            base.AutoScroll = false;

            //关闭系统绘制
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint, true);
            this.UpdateStyles();
            this.DoubleBuffered = true;

            this.Tabs = new Tabs();
            this.Tabs.TabAdded += delegate(Tab tab)
            {
                this.Controls.Add(tab);

                if (tab.SlidingBarContainer != null)
                    this.Controls.Add(tab.SlidingBarContainer);

                this.Tabs[0].Selected = true;

                tab.OnSelected += delegate(Tab selectedTab)
                {
                    Tab old = this.Tabs.Find(t => t.Selected == true && !t.Equals(selectedTab));
                    if (old == null || old.Equals(selectedTab))
                        return;

                    old.Selected = false;
                };
            };
        }

        //样式控制
        public new bool AutoScroll { get { return false; } }

        public Tabs Tabs { get; set; }


        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            if (e.Control is Tab)
            {
                e.Control.Location = new Point(0, (this.Tabs.Count - 1) * 36);
            }
            else if (e.Control is SlidingBarContainer)
            {
                e.Control.SetBounds(33, 1, this.Width - 34, this.Height - 2);
            }
            else
                throw new Exception("添加的控件不正确");
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(32, 0, this.Width - 33, this.Height - 1);
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(76, 183, 240)), rect);
        }
    }

    public class Tabs : List<Tab>
    {
        public new void Add(Tab Tab)
        {
            base.Add(Tab);

            if (this.TabAdded != null)
                this.TabAdded(Tab);
        }

        public delegate void TabAddedHandler(Tab tab);
        public event TabAddedHandler TabAdded;
    }
}
