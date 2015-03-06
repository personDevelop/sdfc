using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace WIMClient
{
    public partial class FaceForm : ChildForm
    {
        public FaceForm()
        {
            InitializeComponent();
        }

        void createBoxes()
        {
            int count = 134;
            int column = 11;
            for (int i = 0; i < count; i++)
            {
                 FaceBox box = new FaceBox(i);
                box.Location = new Point(i % column * 30, i / column * 30);
                this.Controls.Add(box);

                box.Selected += delegate(int faceID)
                {
                    if (this.AddFace != null)
                        this.AddFace("Face_"+faceID);

                    this.Hide();
                };
            }
            this.Width = 30 * column + 6;//6为两边框宽
            this.Height = (count / column + (count % column == 0 ? 0 : 1)) * 30 + 3 + 29;//29为标题栏高和上下两边框高
        }

        public delegate void AddFaceHnadler(string faceID);
        public event AddFaceHnadler AddFace;

        private void FaceForm_CloseBoxClick(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FaceForm_Load(object sender, EventArgs e)
        {
            createBoxes();
        }
    }
}
