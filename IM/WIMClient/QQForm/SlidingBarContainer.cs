//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WIMClient
{
    public class SlidingBarContainer : Panel
    {
        public SlidingBarContainer(params SlidingBar[] Bars)
        {
            //样式控制
            base.AutoScroll = false;
            base.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            base.BackColor = Color.White;
            this.DoubleBuffered = true;

            SlidingBars = new SlidingBars();
            SlidingBars.BarAdded += delegate(SlidingBar bar)
            {
                bar.Left = 0;
                bar.Width = this.Width;
                this.Controls.Add(bar);
            };

            if (Bars != null)
                for (int i = 0; i < Bars.Length; i++)
                    this.SlidingBars.Add(Bars[i]);
        }

        //样式控制
        public new bool AutoScroll { get { return false; } }
        public new AnchorStyles Anchor { get { return AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom; } }
        public new Color BackColor { get { return Color.White; } }

        public SlidingBars SlidingBars { get; set; }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            this.SlidingBars[0].Expanded = true;

            SlidingBar bar = e.Control as SlidingBar;
            if (bar == null)
                throw new Exception("只能添加 SlidingBar 控件");

            bar.OnExpanded += new SlidingBar.ExpandedHandler(bar_OnExpanded);

            this.bar_OnExpanded(this.SlidingBars[0]);
        }

        void bar_OnExpanded(SlidingBar sender)
        {
            sender.Height = this.Height - (this.Controls.Count - 1) * 21 - 2;
            int top = 2;
            for (int i = 0; i < this.Controls.Count; i++)
            {
                SlidingBar bar = this.Controls[i] as SlidingBar;

                bar.Top = top;

                if (!bar.Equals(sender))
                {
                    bar.Expanded = false;
                    top += 21;
                }
                else
                    top += sender.Height;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            SlidingBar bar = this.SlidingBars.Find(b => b.Expanded == true);
            if (bar != null)
                this.bar_OnExpanded(bar);
        }
    }

    public class SlidingBars : List<SlidingBar>
    {
        public new void Add(SlidingBar Bar)
        {
            base.Add(Bar);

            if (this.BarAdded != null)
                this.BarAdded(Bar);
        }

        public delegate void BarAddedHandler(SlidingBar bar);
        public event BarAddedHandler BarAdded;
    }
}
