using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WIMClient.Skin
{
    public partial class QQtextBox : TextBox
    {
        private Bitmap Bmp;
        private Graphics g;
        private Bitmap _icon;
        public QQtextBox()
        {
            this.BackColor = Color.White;
        }

        [Description("图标"), Category("Appearance")]
        public Bitmap Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                this.Invalidate();
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case Win32.WM_NCPAINT:
                    break;
                case Win32.WM_NCCALCSIZE:
                    Rectangle r = new Rectangle();
                    Win32.GetClientRect(this.Handle,ref r);
                    r = new Rectangle(30, r.Top, r.Width, r.Height);
                    base.WndProc(ref m);
                    break;
                case Win32.WM_PAINT:
                    IntPtr ptr = Win32.GetWindowDC(this.Handle);
                    g = Graphics.FromHdc(ptr);
                    g.DrawRectangle(new Pen(Brushes.White, 4F), 0, 0, Width, Height);
                    if (Bmp == null)
                        Bmp = ResClass.GetImgRes("frameBorderEffect_normalDraw");
                    g.DrawImage(Bmp, new Rectangle(0, 0, 4, 4), 0, 0, 4, 4, GraphicsUnit.Pixel);
                    g.DrawImage(Bmp, new Rectangle(4, 0, this.Width - 8, 4), 4, 0, Bmp.Width - 8, 4, GraphicsUnit.Pixel);
                    g.DrawImage(Bmp, new Rectangle(this.Width - 4, 0, 4, 4), Bmp.Width - 4, 0, 4, 4, GraphicsUnit.Pixel);

                    g.DrawImage(Bmp, new Rectangle(0, 4, 4, this.Height - 6), 0, 4, 4, Bmp.Height - 8, GraphicsUnit.Pixel);
                    g.DrawImage(Bmp, new Rectangle(this.Width - 4, 4, 4, this.Height - 6), Bmp.Width - 4, 4, 4, Bmp.Height - 6, GraphicsUnit.Pixel);

                    g.DrawImage(Bmp, new Rectangle(0, this.Height - 2, 2, 2), 0, Bmp.Height - 2, 2, 2, GraphicsUnit.Pixel);
                    g.DrawImage(Bmp, new Rectangle(2, this.Height - 2, this.Width - 2, 2), 2, Bmp.Height - 2, Bmp.Width - 4, 2, GraphicsUnit.Pixel);
                    g.DrawImage(Bmp, new Rectangle(this.Width - 2, this.Height - 2, 2, 2), Bmp.Width - 2, Bmp.Height - 2, 2, 2, GraphicsUnit.Pixel);
                    g.Dispose();
                    Win32.ReleaseDC(this.Handle, ptr);
                    base.WndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            Bmp = ResClass.GetImgRes("frameBorderEffect_mouseDownDraw");
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            Bmp = ResClass.GetImgRes("frameBorderEffect_normalDraw");
            this.Invalidate();
        }
    }
}
