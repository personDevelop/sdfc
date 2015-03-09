using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Imaging;

using System.Text;
using System.Windows.Forms;
using CCWin.SkinControl;
using System.Threading;
using AuthorityEntity.IM;
namespace ChatClient
{
    public partial class ChatControl : UserControl
    {

        public ChatControl()
        {
            InitializeComponent();
            this.ctrlEnter = true;
        }
        bool ctrlEnter;
        public void SetSendType(bool CtrlEnter)
        {
            this.ctrlEnter = CtrlEnter;
        }

        //显示消息
        public void ReciveMessage(MsgEntity msg)// string From, DateTime Time, string Content, bool Self)
        {
            MsgType mt = (MsgType)msg.MsgType;
            switch (mt)
            {
                case MsgType.文字:
                    this.AppendMessage(msg.SenderName, RtfRichTextBox.RtfColor.Blue, msg.SendTime, msg.MsgContent, true);
                    break;
                case MsgType.震动:
                    this.AppendMessage(msg.SenderName, RtfRichTextBox.RtfColor.Blue, msg.SendTime, Environment.NewLine + msg.SenderName + "给您" + msg.MsgContent + Environment.NewLine, false);
                    Vibration();
                    break;
                case MsgType.文件:
                    break;
                case MsgType.语音:
                    break;
                case MsgType.视频:
                    break;
                default:
                    break;
            }

        }
        private void toolStripButton表情_Click(object sender, EventArgs e)
        {
            FaceForm.Instance.Show(this);

        }
        public void InsetBq(string faceID)
        {
            this.txtSendMsg.InsertImage((Image)Resource1.ResourceManager.GetObject(faceID));
        }
        public delegate void BeginToSendHandler(string content, MsgType msgType = MsgType.文字, MsgSendType sendType = MsgSendType.基本消息);
        public event BeginToSendHandler BeginToSend;

        private void toolStripButton聊天记录_Click(object sender, EventArgs e)
        {
            if (this.OnShowHistoryForm != null)
                this.OnShowHistoryForm();
        }

        public delegate void ShowHistoryFormHandler();
        public event ShowHistoryFormHandler OnShowHistoryForm;


        private void toolStripButton震动_Click(object sender, EventArgs e)
        {
            toolZD.Enabled = false;
            if (BeginToSend != null)
            {
                BeginToSend("发送了一个窗口抖动", MsgType.震动);
            }
            AppendMessage(Common.ClientUser.DisplayName, RtfRichTextBox.RtfColor.Green, DateTime.Now, "您发送了一个窗口抖动。", false);
            Vibration();
            toolZD.Enabled = true;
        }

        #region Vibration 震动
        //震动方法
        private void Vibration()
        {
            Form form = ParentForm;
            Point pOld = form.Location;//原来的位置
            int radius = 3;//半径
            for (int n = 0; n < 3; n++) //旋转圈数
            {
                //右半圆逆时针
                for (int i = -radius; i <= radius; i++)
                {
                    int x = Convert.ToInt32(Math.Sqrt(radius * radius - i * i));
                    int y = -i;

                    form.Location = new Point(pOld.X + x, pOld.Y + y);
                    Thread.Sleep(10);
                }
                //左半圆逆时针
                for (int j = radius; j >= -radius; j--)
                {
                    int x = -Convert.ToInt32(Math.Sqrt(radius * radius - j * j));
                    int y = -j;

                    form.Location = new Point(pOld.X + x, pOld.Y + y);
                    Thread.Sleep(10);
                }
            }
            //抖动完成，恢复原来位置
            form.Location = pOld;
        }


        #endregion

        private void InsertImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "图片文件|*.bmp;*.ico;*.gif;*.jpeg;*.jpg;*.png;";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtSendMsg.InsertImage(Image.FromFile(openFileDialog1.FileName)); 
            }
        }

        private void capture_Click(object sender, EventArgs e)
        {
            Screen_Capture.FrmCapture f = new Screen_Capture.FrmCapture();
            f.IsFromClipBoard = true;
            f.onCaptureFinished += new Screen_Capture.CaptureFinished(f_onCaptureFinished);

            f.Show();
        }

        void f_onCaptureFinished(Bitmap img)
        {
            txtSendMsg.InsertImage(img);
        }

        private void toolFont_Click(object sender, EventArgs e)
        {
            this.fontDialog1.Font = this.txtSendMsg.Font;
            this.fontDialog1.Color = this.txtSendMsg.ForeColor;
            if (DialogResult.OK == this.fontDialog1.ShowDialog())
            {
                this.txtSendMsg.Font = this.fontDialog1.Font;
                this.txtSendMsg.ForeColor = this.fontDialog1.Color;
            }
        }
        private void AppendMessage(string userName, RtfRichTextBox.RtfColor color, DateTime? originTime, string msg, bool isRtf)
        {
            if (string.IsNullOrWhiteSpace(msg))
            {
                return;
            }
            DateTime showTime = DateTime.Now;
            this.txtAllMsg.AppendTextAsRtf(string.Format("{0}  {1}\n", userName, showTime), new Font(this.Font, FontStyle.Regular), color);
            if (originTime != null)
            {
                this.txtAllMsg.AppendText(string.Format("[{0}] ", originTime.Value.ToLongTimeString()));
            }
            if (isRtf)
            {
                this.txtAllMsg.AppendRtf(msg);
            }
            else
            {
                this.txtAllMsg.AppendText(msg);
            }
            this.txtAllMsg.Select(this.txtAllMsg.Text.Length, 0);
            this.txtAllMsg.ScrollToCaret();


        }



        internal void SendMessage()
        {
            AppendMessage(Common.ClientUser.DisplayName, RtfRichTextBox.RtfColor.Green, null, txtSendMsg.Rtf, true);
            if (this.BeginToSend != null)
            {
                //this.richTextBoxEx_send.ClearGif();
                this.BeginToSend(this.txtSendMsg.Rtf);
                //清空输入框
                this.txtSendMsg.Text = string.Empty;
                this.txtSendMsg.Focus();

            }

        }
    }
}
