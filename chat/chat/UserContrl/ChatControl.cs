using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Imaging;

using System.Text;
using System.Windows.Forms;


namespace ChatClient
{
    public partial class ChatControl : UserControl
    {

        public ChatControl()
        {
            InitializeComponent();


            //List<Image> emotionList = new List<Image>();
            //foreach (Image emotion in this.imageList1.Images)
            //{
            //    emotionList.Add(emotion);
            //}
            //emotionForm.Initialize(emotionList);
            //emotionForm.Load += new EventHandler(emotionForm_Load);
            //this.emotionForm.EmotionClicked += new EmotioinHandler(emotionForm_Clicked);
            //this.emotionForm.Visible = false;

            this.ctrlEnter = true;

            this.richTextBoxEx_send.KeyDown += delegate(object sender, KeyEventArgs e)
            {
                if (
                    (this.ctrlEnter && e.Control && e.KeyCode == Keys.Enter)
                    ||
                    (!this.ctrlEnter && e.KeyCode == Keys.Enter)
                    )
                {
                    this.SendMessage();

                    e.Handled = true;
                }
            };

            this.shakeTime = new Timer();
            this.shakeTime.Interval = 10000;
            this.shakeTime.Tick += delegate
            {
                this.shakeTime.Enabled = false;
                this.toolZD.Enabled = true;
            };
        }

        void emotionForm_Load(object sender, EventArgs e)
        {
            //设置窗口位置
        }
        void emotionForm_Clicked(Image img)
        {
            //this.emotionForm.Visible = false;

        }
        bool ctrlEnter;
        public void SetSendType(bool CtrlEnter)
        {
            this.ctrlEnter = CtrlEnter;
        }

        //显示消息
        public void ShowMessage(string From, DateTime Time, string Content, bool Self)
        {

            this.richTextBoxEx_read.AppentMessage(From, Time, Self, Content);


            foreach (KeyValuePair<string, Image> sv in imageDict)
            {
                this.richTextBoxEx_read.InsertGIF(sv.Key, sv.Value);

            }

            this.richTextBoxEx_read.ScrollToCaret();
        }

        public void ScrollToCaret()
        {
            this.richTextBoxEx_read.ScrollToCaret();
        }

        public void ShowImage(string key, Image image)
        {

            this.richTextBoxEx_read.InsertGIF(key, image);

            this.richTextBoxEx_read.ScrollToCaret();
        }


        public void ClearImageDic()
        {
            imageDict.Clear();
        }
        public void InsetBq(string faceID)
        {
            this.richTextBoxEx_send.InsertGIF(faceID, (Image)Resource1.ResourceManager.GetObject(faceID));
        }
        public delegate void BeginToSendHandler(string content);
        public event BeginToSendHandler BeginToSend;
        private void toolStripButton表情_Click(object sender, EventArgs e)
        {
            FaceForm.Instance.Show(this);

        }

        public void SendMessage()
        {
            if (this.richTextBoxEx_send.Text.Trim().Length == 0 && this.richTextBoxEx_send.GetGIFInfo().Trim().Length == 0)
                return;

            if (this.BeginToSend != null)
            {
                this.richTextBoxEx_send.ClearGif();
                this.BeginToSend(this.richTextBoxEx_send.GetTextToSend());

                this.richTextBoxEx_send.Clear();
                this.richTextBoxEx_send.Focus();
            }
        }

        private void toolStripButton聊天记录_Click(object sender, EventArgs e)
        {
            if (this.OnShowHistoryForm != null)
                this.OnShowHistoryForm();
        }

        public delegate void ShowHistoryFormHandler();
        public event ShowHistoryFormHandler OnShowHistoryForm;

        Timer shakeTime;
        private void toolStripButton震动_Click(object sender, EventArgs e)
        {
            if (this.ShakeForm != null)
                this.ShakeForm();

            this.toolZD.Enabled = false;
            this.shakeTime.Enabled = true;
        }

        public delegate void ShakeFormHandler();
        public event ShakeFormHandler ShakeForm;

        private void richTextBoxEx_send_TextChanged(object sender, EventArgs e)
        {
            if (this.BeginSendInTimeChat != null)
                this.BeginSendInTimeChat(this.richTextBoxEx_send.Text);
        }

        public delegate void BeginSendInTimeChatHandler(string text);
        public event BeginSendInTimeChatHandler BeginSendInTimeChat;

        public void ClearOldMessage()
        {
            this.richTextBoxEx_read.Clear();
        }

        public Dictionary<string, Image> imageDict = new Dictionary<string, Image>();




        private void InsertImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "图片文件|*.jpg|所有文件|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //string imageID = FileIDCreator.GetNextFileID("abc");
                //this.richTextBoxEx_send.InsertGIF(imageID, Image.FromFile(openFileDialog1.FileName));


                ////添加图片到字典中
                //imageDict.Add(imageID, Image.FromFile(openFileDialog1.FileName));
            }
        }

        private void capture_Click(object sender, EventArgs e)
        {


            //System.Threading.Thread.Sleep(30);

            //CaptureImageTool capture = new CaptureImageTool(); 

            //if (capture.ShowDialog() == DialogResult.OK)
            //{
            //    Image image = capture.Image;



            //    string imageID = FileIDCreator.GetNextFileID("abc");
            //    this.richTextBoxEx_send.InsertGIF(imageID, image);

            //    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            //    {


            //        image.Save(saveFileDialog1.FileName, ImageFormat.Bmp);
            //    }


            //    //添加图片到字典中
            //    imageDict.Add(imageID, Image.FromFile(saveFileDialog1.FileName));


            //}

            //if (!Visible)
            //{
            //    Show();
            //}
        }

        private void toolFont_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                richTextBoxEx_send.Font = fd.Font;
        }


    }
}
