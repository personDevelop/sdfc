using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WIMClient.Skin;

namespace WIMClient.Skin
{
    public partial class LoginButton : UserControl
    {
        private Graphics g = null;
        private Bitmap Bmp = null;

        public LoginButton()
        {
            Bmp = ResClass.GetImgRes("login_btn_normal");
            if (this.Focused)
                Bmp = ResClass.GetImgRes("login_btn_focus");
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.BackColor = Color.Transparent;
            this.Size = new Size(74,27);
        }

        [Description("文本"), Category("Appearance")]
        public string Texts
        {
            get
            {
                return Text;
            }
            set
            {
                Text = value;
                this.Invalidate();
            }
        }

        private PointF GetPointF(string text)
        {
            float x, y;

            switch (text.Length)
            {
                case 1:
                    x = (float)(this.Width - 12.5 * 1) / 2;
                    y = 4;
                    break;
                case 2:
                    x = (float)(this.Width - 12.5 * 2) / 2;
                    y = 4;
                    break;
                case 3:
                    x = (float)(this.Width - 12.5 * 3) / 2;
                    y = 4;
                    break;
                case 4:
                    x = (float)(this.Width - 12.5 * 4) / 2;
                    y = 4;
                    break;
                case 5:
                    x = (float)(this.Width - 12.3 * 5) / 2;
                    y = 4;
                    break;
                case 6:
                    x = (float)(this.Width - 12.3 * 6) / 2;
                    y = 4;
                    break;
                default:
                    x = (float)(this.Width - 12.3 * 4) / 2;
                    y = 4;
                    break;
            }
            return new PointF(x, y);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            g = e.Graphics;
            if (Bmp != null)
            {
                g.DrawImage(Bmp, new Rectangle(0, 0, this.Width, this.Height), 0, 0, Bmp.Width, Bmp.Height, GraphicsUnit.Pixel);
            }
                PointF point = GetPointF(this.Text);
            if (this.Enabled)
                g.DrawString(this.Texts, new Font("微软雅黑", 9F), Brushes.Black, point);
            else
                g.DrawString(this.Texts, new Font("微软雅黑", 9F), Brushes.Gray, point);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Bmp = ResClass.GetImgRes("login_btn_highlight");
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Bmp = ResClass.GetImgRes("login_btn_normal");
            if (this.Focused)
                Bmp = ResClass.GetImgRes("login_btn_focus");
            this.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Bmp = ResClass.GetImgRes("login_btn_down");
            this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Bmp = ResClass.GetImgRes("login_btn_normal");
            if (this.Focused)
                Bmp = ResClass.GetImgRes("login_btn_focus");
            this.Invalidate();
        }
    }
}
