using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using WIMClient.Skin;

namespace WIMClient.Skin
{
    public class QQToolStripMenuItem : ToolStripMenuItem
    {
        private Graphics g = null;
        private Bitmap Bmp = null;

        protected override void OnPaint(PaintEventArgs e)
        {
            g = e.Graphics;
            if (Bmp != null)
            {
                g.DrawImage(Bmp, new Rectangle(3, 1, 3, this.Height - 2), 0, 0, 3, Bmp.Height, GraphicsUnit.Pixel);
                g.DrawImage(Bmp, new Rectangle(6, 1, this.Width - 11, this.Height - 2), 3, 0, Bmp.Width - 6, Bmp.Height, GraphicsUnit.Pixel);
                g.DrawImage(Bmp, new Rectangle(this.Width - 5, 1, 3, this.Height - 2), Bmp.Width - 3, 0, 3, Bmp.Height, GraphicsUnit.Pixel);
            }
            if (this.Image != null)
                g.DrawImage(this.Image, new Rectangle(8, (Height - Image.Height) / 2, Image.Width, Image.Height), 0, 0, Image.Width, Image.Height, GraphicsUnit.Pixel);
            Font f = new Font("微软雅黑", 9F);
            g.DrawString(this.Text, f, Brushes.Black, 30, 2);
            f.Dispose();
        }
        
        protected override void OnMouseEnter(EventArgs e)
        {
            Bmp = ResClass.GetImgRes("menu_highlight");
            this.Invalidate();
        }

        protected override void  OnMouseLeave(EventArgs e)
        {
            Bmp = null;
            this.Invalidate();
        }
    }
}
