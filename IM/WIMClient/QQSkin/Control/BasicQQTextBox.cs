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
    public partial class BasicQQTextBox : UserControl
    {
        private Graphics g = null;
        private Bitmap Bmp = null;
        private Color borderColor = Color.FromArgb(84, 165, 213);
        private Bitmap _icon;
        
        public BasicQQTextBox()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            Bmp = ResClass.GetImgRes("frameBorderEffect_normalDraw");
            Icon = ResClass.GetImgRes("keyboard");
            InitializeComponent();
        }

        [Description("文本"), Category("Appearance")]
        public string Texts
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
                this.Invalidate();
            }
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

        [Description("密码框"), Category("Appearance")]
        public bool IsPass
        {
            get
            {
                return textBox1.UseSystemPasswordChar;
            }
            set
            {
                textBox1.UseSystemPasswordChar = value;
                if(value)
                    Icon = ResClass.GetImgRes("keyboard");
            }
        }

        [Description("只读"), Category("Appearance")]
        public bool ReadOn
        {
            get
            {
                return textBox1.ReadOnly;
            }
            set
            {
                textBox1.ReadOnly = value;
                if (value)
                    textBox1.BackColor = Color.Gray;
                else
                    textBox1.BackColor = Color.White;
            }
        }

        public System.Windows.Forms.TextBox textBox
        {
            get
            {
                return textBox1;
            }
            set
            {
                textBox1 = value;
            }
        }

        [Description("右键菜单"), Category("Appearance")]
        public override ContextMenuStrip ContextMenuStrip
        {
            get
            {
                return textBox1.ContextMenuStrip;
            }
            set
            {
                textBox1.ContextMenuStrip = value;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            g = e.Graphics;
            if(Bmp==null)
                Bmp = ResClass.GetImgRes("frameBorderEffect_normalDraw");
            if (Bmp != null)
            {
                g.DrawImage(Bmp, new Rectangle(0, 0, 4, 4), 0, 0, 4, 4, GraphicsUnit.Pixel);
                g.DrawImage(Bmp, new Rectangle(4, 0, this.Width - 8, 4), 4, 0, Bmp.Width - 8, 4, GraphicsUnit.Pixel);
                g.DrawImage(Bmp, new Rectangle(this.Width - 4, 0, 4, 4), Bmp.Width - 4, 0, 4, 4, GraphicsUnit.Pixel);

                g.DrawImage(Bmp, new Rectangle(0, 4, 4, this.Height - 6), 0, 4, 4, Bmp.Height - 8, GraphicsUnit.Pixel);
                g.DrawImage(Bmp, new Rectangle(this.Width - 4, 4, 4, this.Height - 6), Bmp.Width - 4, 4, 4, Bmp.Height - 6, GraphicsUnit.Pixel);

                g.DrawImage(Bmp, new Rectangle(0, this.Height - 2, 2, 2), 0, Bmp.Height - 2, 2, 2, GraphicsUnit.Pixel);
                g.DrawImage(Bmp, new Rectangle(2, this.Height - 2, this.Width - 2, 2), 2, Bmp.Height - 2, Bmp.Width - 4, 2, GraphicsUnit.Pixel);
                g.DrawImage(Bmp, new Rectangle(this.Width - 2, this.Height - 2, 2, 2), Bmp.Width - 2, Bmp.Height - 2, 2, 2, GraphicsUnit.Pixel);
            }
                if (Icon != null)
                g.DrawImage(Icon, new Rectangle(1, 1, Bmp.Width, Bmp.Height), 0, 0, Bmp.Width, Bmp.Height, GraphicsUnit.Pixel);
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            Bmp = ResClass.GetImgRes("frameBorderEffect_mouseDownDraw");
            this.Invalidate();
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            Bmp = ResClass.GetImgRes("frameBorderEffect_normalDraw");
            this.Invalidate();
        }

        protected override void OnParentFontChanged(EventArgs e)
        {
            base.OnParentFontChanged(e);
            textBox1.Font = this.Font;
        }

        protected override void OnParentForeColorChanged(EventArgs e)
        {
            base.OnParentForeColorChanged(e);
            textBox1.ForeColor = this.ForeColor;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (!textBox1.UseSystemPasswordChar)
            {
                if (textBox1.Text.Equals("<请输入帐号>"))
                {
                    textBox1.Text = "";
                    textBox1.ForeColor = Color.Black;
                }
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (!textBox1.UseSystemPasswordChar)
            {
                if (textBox1.Text.Equals(""))
                {
                    textBox1.Text = "<请输入帐号>";
                    textBox1.ForeColor = Color.DarkGray;
                }
            }
        }
    }
}
