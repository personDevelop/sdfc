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
using CCWin.SkinControl;
using NetworkCommsDotNet;
using AuthorityEntity.IM;
namespace ChatClient
{
    public partial class chatMain : CCSkinMain, IManagedForm
    {
        private IMUserInfo friend;
        public chatMain()
        {

            InitializeComponent();
        }
        public chatMain(IMUserInfo friend)
            : this()
        {

            // TODO: Complete member initialization
            this.friend = friend;
            //labelFriendName.Text = friend.DisplayName;
            //labelFriendSignature.Text = friend.DisplaySignature;
            //this.Text = "正在和" + labelFriendName.Text + "对话";
        }

        private void FocusCurrent(object sender, EventArgs e)
        {

        }

        #region 关闭按钮
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        public string FormID
        {
            get { return friend.ID; }
        }




        public Form CurrentForm
        {
            get
            {
                return this;
            }
            set
            {

            }
        }
        public void ShowOtherTextChat(string userID, List<MsgEntity> msgList)
        {
            if (msgList.Count > 0)
            {

                foreach (MsgEntity msg in msgList)
                {
                    this.ReciveMessage(msg);

                }

            }
        }
        //追加消息
        private void AppendMessage(string userName, RtfRichTextBox.RtfColor color, DateTime? originTime, string msg, bool isRtf)
        {
            if (string.IsNullOrWhiteSpace(msg))
            {
                return;
            }
            DateTime showTime = DateTime.Now;
            this.rtfRichTextBox_history.AppendTextAsRtf(string.Format("{0}  {1}\n", "网页用户", showTime), new Font(this.Font, FontStyle.Regular), color);

            //this.rtfRichTextBox_history.AppendText("adsfasdf");
            this.rtfRichTextBox_history.AppendText(msg);
            this.rtfRichTextBox_history.AppendText("\n");



        }

        //接收消息
        public void ReciveMessage(MsgEntity msg)// string From, DateTime Time, string Content, bool Self)
        {
            MsgType mt = (MsgType)msg.MsgType;
            switch (mt)
            {
                case MsgType.文字:
                    this.AppendMessage("网页用户的消息", RtfRichTextBox.RtfColor.Blue, DateTime.Now, msg.MsgContent, true);
                    break;
                case MsgType.震动:
                    this.AppendMessage(msg.SenderName, RtfRichTextBox.RtfColor.Blue, msg.SendTime, Environment.NewLine + msg.SenderName + "给您" + msg.MsgContent + Environment.NewLine, false);
                    //Vibration();
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

        private void toolFont_Click(object sender, EventArgs e)
        {

        }

        private void skinButton_send_Click(object sender, EventArgs e)
        {

            if (this.textBoxSend.Text.Trim() == "")
            {
                return;
            }
            MsgEntity chatContract = new MsgEntity();
            chatContract.SenderID = Common.CurrentUser.ID;
            chatContract.Reciver = this.friend.ID;
            chatContract.MsgContent = this.textBoxSend.Text;
            chatContract.SendTime = DateTime.Now;
            chatContract.IsWebMsg = true;
            Common.TcpConn.SendObject("ChatMessage", chatContract);
          
            DateTime showTime = DateTime.Now;

            this.rtfRichTextBox_history.AppendTextAsRtf(string.Format("{0}  {1}\n", "我", showTime), new Font(this.Font, FontStyle.Regular), RtfRichTextBox.RtfColor.Blue);

            //this.rtfRichTextBox_history.AppendText(string.Format("{0}  {1}\n", "我", showTime));

            //this.rtfRichTextBox_history.AppendText("adsfasdf");
            this.rtfRichTextBox_history.AppendText(textBoxSend.Text);
            this.rtfRichTextBox_history.AppendText("\n");
            this.rtfRichTextBox_history.ScrollToCaret();
            this.textBoxSend.Clear();
            this.textBoxSend.Focus();
        }

        private void frmchatMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            FormManager.Instance.CloseForm(this);
            
        }

    }
}
