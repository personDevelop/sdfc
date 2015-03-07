using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;
using CCWin.Win32;
using CCWin.Win32.Const;

namespace ChatClient
{
    public partial class chatMainOld : CCSkinMain
    {
        public EmotionForm emotionForm;
        public chatMainOld()
        {
            InitializeComponent();
            List<Image> emotionList = new List<Image>();
            foreach (Image emotion in this.imageList1.Images)
            {
                emotionList.Add(emotion);
            }
            this.emotionForm = new EmotionForm();
            this.emotionForm.Load += new EventHandler(emotionForm_Load);
            this.emotionForm.Initialize(emotionList);
            this.emotionForm.EmotionClicked += new EmotionForm.EmotioinHandler(emotionForm_Clicked);
            this.emotionForm.Visible = false;
        }
        void emotionForm_Load(object sender, EventArgs e)
        {
            this.emotionForm.Location = new Point((this.Left + 30) - (this.emotionForm.Width / 2), this.Top +skToolMenu.Top - this.emotionForm.Height);
        }
        void emotionForm_Clicked(Image img)
        {
            this.emotionForm.Visible = false;
            
        } 

        private void FocusCurrent(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem34_Click(object sender, EventArgs e)
        {

        }

        private void 发送离线文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem33_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_fileTransfer_Click(object sender, EventArgs e)
        {

        }

        private void toolStripDropDownButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void buttonCapture_Click(object sender, EventArgs e)
        {

        }

        private void toolVibration_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonEmotion_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void toolFont_Click(object sender, EventArgs e)
        {

        }

        private void labelFriendName_MouseEnter(object sender, EventArgs e)
        {

        }

        private void labelFriendName_MouseLeave(object sender, EventArgs e)
        {

        }

        private void toolStripButtonEmotion_Click(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {

        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void imgyy2_Click(object sender, EventArgs e)
        {

        }

        private void panelFriendHeadImage_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelFriendSignature_Click(object sender, EventArgs e)
        {

        }

        private void skinPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void skinPanel_right_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButtonEmotion_Click_1(object sender, EventArgs e)
        {
            this.emotionForm.Location = new Point((this.Left + 30) - (this.emotionForm.Width / 2), this.Top +  skToolMenu.Top - this.emotionForm.Height);
            this.emotionForm.Visible = !this.emotionForm.Visible;
        }
    }
}
