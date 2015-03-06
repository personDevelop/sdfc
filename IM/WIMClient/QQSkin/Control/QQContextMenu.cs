using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using WIMClient.Skin;

namespace WIMClient.Skin
{
    public partial class QQContextMenu : ContextMenuStrip
    {
        private Graphics g = null;
        private Bitmap Bmp = null;

        public QQContextMenu()
        {
            this.BackColor = Color.White;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            int Rgn = Win32.CreateRoundRectRgn(0, 0, this.Width + 1, this.Height + 1, 2, 2);
            Win32.SetWindowRgn(this.Handle, Rgn, true);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            g = e.Graphics;
            Bmp = ResClass.GetImgRes("menu_bkg");
            g.DrawImage(Bmp, new Rectangle(0, 0, 28, 5), 5, 5, 28, 5, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(28, 0, this.Width - 33, 5), 33, 5, Bmp.Width - 43, 5, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(this.Width - 5, 0, 5, 5), Bmp.Width - 10, 5, 5, 5, GraphicsUnit.Pixel);
            
            g.DrawImage(Bmp, new Rectangle(0, 5, 28, this.Height - 10), 5, 10, 28, Bmp.Height - 20, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(28, 5, this.Width - 33, this.Height - 10), 33, 10, Bmp.Width - 43, Bmp.Height - 20, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(this.Width - 5, 5, 5, this.Height - 10), Bmp.Width - 10, 10, 5, Bmp.Height - 20, GraphicsUnit.Pixel);
            
            g.DrawImage(Bmp, new Rectangle(0, this.Height - 5, 28, 5), 5, Bmp.Height - 10, 28, 5, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(28, this.Height - 5, this.Width - 33, 5), 33, Bmp.Height - 10, Bmp.Width - 43, 5, GraphicsUnit.Pixel);
            g.DrawImage(Bmp, new Rectangle(this.Width - 5, this.Height - 5, 5, 5), Bmp.Width - 10, Bmp.Height - 10, 5, 5, GraphicsUnit.Pixel);
        }
    }
}
