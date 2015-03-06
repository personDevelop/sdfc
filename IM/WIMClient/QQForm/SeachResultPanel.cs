//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.ComponentModel;

namespace WIMClient
{
    [ToolboxItem(false)]
    internal class SeachResultPanel : Panel
    {
        internal SeachResultPanel()
        {

        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            e.Control.SetBounds(1, (this.Controls.Count - 1) * 34 + 1, this.Width - 2, 34);
            e.Control.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            e.Control.Click += delegate
            {
                (e.Control as User).ShowChatForm();
            };
        }

        internal void UpdateHeight()
        {
            this.Height = this.Controls.Count * 34 + 2;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawRectangle(Pens.SteelBlue, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
        }
    }
}
