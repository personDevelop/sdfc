using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;
using System.Net;
using CCWin.Win32;
using CCWin.Win32.Const;

using NetworkCommsDotNet;
using AuthorityEntity.IM;
namespace ChatClient
{
    public partial class frmchatMain : CCSkinMain, IManagedForm
    {
        private ClassGifs SendGifs = new ClassGifs();
        private IMUserInfo friend;
        public frmchatMain()
        {
            InitializeComponent();
            chatControl1.OnShowHistoryForm += new ChatControl.ShowHistoryFormHandler(chatControl1_OnShowHistoryForm);
        }
        bool isShow = false;
        bool hasLoad = false;
        void chatControl1_OnShowHistoryForm()
        {

            if (isShow)
            {
                this.Width -= 200;
                skinTabControl1.SelectedIndex = 0;
                tabPageHis.Hide();
            }
            else
            {

                this.Width += 200;
                LoadMsgHis();
                tabPageHis.Show();
                skinTabControl1.SelectedIndex = 1;
                hasLoad = true;
            }
            isShow = !isShow;
        }

        private void LoadMsgHis()
        {
            if (!hasLoad)
            {
                //获取最近的聊天信息

            }
        }
        public frmchatMain(IMUserInfo friend)
            : this()
        {
            // TODO: Complete member initialization
            this.friend = friend;
            labelFriendName.Text = friend.DisplayName;
            labelFriendSignature.Text = friend.DisplaySignature;
            this.Text = "正在和" + labelFriendName.Text + "对话";
        }


        #region 关闭按钮
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


        private void btnSend_Click(object sender, EventArgs e)
        {
            chatControl1.SendMessage();

        }
        private MyPicture findPic(string ID, ClassGifs gifs)
        {
            foreach (MyPicture pic in gifs)
                if (Convert.ToString(pic.Tag) == ID)
                    return pic;
            return null;
        }
        private class ClassGifs : System.Collections.CollectionBase
        {
            public ClassGifs()
            {
                //
                // TODO: 在此处添加构造函数逻辑
                //
            }
            public void add(MyPicture tempGif)
            {
                base.InnerList.Add(tempGif);
            }

            public void Romove(MyPicture tempGif)
            {
                base.InnerList.Remove(tempGif);
            }
        }


        private int OutTime = 0;

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
                    chatControl1.ReciveMessage(msg);


                    IList<ImageWrapper> theImageList = msg.ImageList;

                    foreach (ImageWrapper imageWrapper in theImageList)
                    {
                        //显示图片
                        //chatControl1.ShowImage(imageWrapper.ImageName, imageWrapper.Image);

                    }


                }

            }
        }

        //控件中的图片字典
        public Dictionary<string, Image> imageDict = null;
        //图片包装类的列表
        IList<ImageWrapper> imageWrapperList = new List<ImageWrapper>();

        private void chatControl1_BeginToSend(string content, MsgType msgType = MsgType.文字, MsgSendType sendType = MsgSendType.基本消息)
        {
            Common.SendMsg(content, msgType, sendType, friend.ID, friend.DisplayName);
            this.chatControl1.Focus();
            imageWrapperList.Clear();
        }

        private void frmchatMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

    }
}
