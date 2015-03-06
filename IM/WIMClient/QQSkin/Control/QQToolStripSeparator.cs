using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using WIMClient.Skin;

namespace WIMClient.Skin
{
    public class QQToolStripSeparator : ToolStripSeparator
    {
        private Graphics g = null;

        protected override void OnPaint(PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawImage(ResClass.GetImgRes("menu_cutling"), new Rectangle(25, 2, this.Width - 25, 2), 0, 0, 50, 3, GraphicsUnit.Pixel);
        }
    }
}
