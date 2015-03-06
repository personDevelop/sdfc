using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace WIMClient.Skin
{
    public class QQPictureBox : PictureBox
    {
        private string text;
        [Description("文本"), Category("Appearance")]
        public string Texts
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
            }
        }
    }
}
