using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WIMClient
{
    internal class MyGIF
    {
        string name;
        Image data;
        PictureBox box;
        uint index;

        internal MyGIF(string Name, Image Data)
        {
            this.name = Name;
            this.data = Data;
            this.index = (uint)new Random().Next(200, 2147483627);

            this.box = new PictureBox();
            this.box.Image = Data;
            this.box.BackColor = Color.White;
            if (Data.Width > 350)
            {
                this.box.SizeMode = PictureBoxSizeMode.StretchImage;
                this.box.Width = 350;
                this.box.Height = 215;
            }
            else
            {
                this.box.SizeMode = PictureBoxSizeMode.AutoSize;
                this.box.Width = Data.Width;
                this.box.Height = Data.Height;


            }



        }

        internal string Name { get { return this.name; } }
        internal Image Data { get { return this.data; } }
        internal PictureBox Box { get { return this.box; } }
        internal uint Index { get { return this.index; } }
    }
}
