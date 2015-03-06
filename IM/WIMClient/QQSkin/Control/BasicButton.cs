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
    [DefaultEvent("Click")]
    public partial class BasicButton : UserControl
    {
        private Graphics g = null;
        private Bitmap Bmp = null;
        private string m_buttonText = "Button";
        public BasicButton()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true); InitializeComponent();
            Bmp = ResClass.GetImgRes("btn_normal");
        }

        [Description("文本"), Category("Appearance")]
        public string Texts
        {
            get
            {
                return m_buttonText;
            }
            set
            {
                m_buttonText = value;
                this.Invalidate();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Environment.OSVersion.Version.Major >= 6)
            {
                this.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            }
            else
            {
                this.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point);
            }
        }

        private PointF GetPointF(string buttonText)
        {
            float x;
            int l = 0;
            char[] c = buttonText.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (Convert.ToInt32(c[i]) > Convert.ToInt32((char)128))
                {
                    l += 2;
                }
                else 
                {
                    l += 1;
                }
            }

            x = (float)(Width - l * (Font.Size - 1.5)) / 2;
            return new PointF(x, 2);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            g = e.Graphics;
            if (Bmp != null)
            {
                g.DrawImage(Bmp, new Rectangle(0, 0, this.Width, this.Height), 0, 0, Bmp.Width, Bmp.Height, GraphicsUnit.Pixel);

            }
            PointF point = GetPointF(this.m_buttonText);
            if (this.Enabled)
                g.DrawString(this.Texts, Font, Brushes.Black, point);
            else
                g.DrawString(this.Texts, new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Gray, point);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.Focus();
            Bmp = ResClass.GetImgRes("btn_down");
            this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            OnMouseLeave(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            Bmp = ResClass.GetImgRes("btn_highlight");
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if(Focused)
                Bmp = ResClass.GetImgRes("btn_focus");
            else
                Bmp = ResClass.GetImgRes("btn_normal");
            this.Invalidate();
        }

        protected override void OnEnter(EventArgs e)
        {
            Bmp = ResClass.GetImgRes("btn_focus");
            this.Invalidate();
        }

        protected override void OnLeave(EventArgs e)
        {
            Bmp = ResClass.GetImgRes("btn_normal");
            this.Invalidate();
        }
    }
}
