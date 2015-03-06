//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
 
using NetworkCommsDotNet;
using System.Collections.Generic;
using IMInterface;


namespace WIMClient
{
    public partial class ChatForm : Form, IManagedForm
    {
        private string friendID;
        private string currentUserID; 
      
        public ChatForm(string _currentUserID,  string _friendID )
        {
            InitializeComponent();
            this.currentUserID = _currentUserID;
            this.friendID = _friendID;

            User FriendUser = Common.GetDicUser(_friendID);
           
            this.Width = 500;

            this.Text = "当前用户:" + Common.UserName + "  好友用户:" + FriendUser.UserName;
            
        }

        private Form OwnerForm = null;

        public string FormID
        {
            get { return this.friendID; }
        }
       
        public void ShowOtherTextChat(string userID, List<MsgEntity> msgList)
        {
            if (msgList.Count > 0)
            {

                foreach (MsgEntity msg in msgList)
                { 
                     //chatControl1.ShowMessage(msg.UserName, msg.SendTime, msg.Content, false);


                     //IList<ImageWrapper> theImageList = msg.ImageList;

                     //foreach (ImageWrapper imageWrapper in theImageList)
                     //{
                     //    //显示图片
                     //    chatControl1.ShowImage(imageWrapper.ImageName, imageWrapper.Image);

                        
                     //}

                     
                }
                
            }
        } 
         
        private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
      

        } 
       
        private void button1_Click(object sender, EventArgs e)
        {
            
            chatControl1.SendMessage();
              
        }
        //控件中的图片字典
        public Dictionary<string, Image> imageDict = null;
        //图片包装类的列表
        IList<ImageWrapper> imageWrapperList = new List<ImageWrapper>();

        private void chatControl1_BeginToSend(string content)
        {
            this.chatControl1.ShowMessage(Common.UserName, DateTime.Now, content, true);

            imageDict = this.chatControl1.imageDict;

             //把控件中的图片字典，添加到图片包装类列表中
            foreach (KeyValuePair<string, Image> kv in imageDict)
            {
                ImageWrapper newWrapper = new ImageWrapper(kv.Key, kv.Value);

                imageWrapperList.Add(newWrapper);
                 
            }
          
            //清除控件中图片字典的内容
            this.chatControl1.ClearImageDic();

            //从客户端 Common中获取相应连接
            Connection p2pConnection = Common.GetUserConn(this.friendID);

            if (p2pConnection != null)
            {
                MsgEntity chatContract = new MsgEntity();
                chatContract.SenderID = Common.UserID;
               
                chatContract.Reciver = this.friendID;
                
                chatContract.MsgBody = content;
                chatContract.SendTime = DateTime.Now;
                //chatContract.ImageList = imageWrapperList;
                p2pConnection.SendObject("ClientChatMessage", chatContract);
                this.chatControl1.Focus();

                imageWrapperList.Clear();

                LogInfo.LogMessage("通过p2p通道发送消息,当前用户ID为"+Common.UserID+"当前Tcp连接端口号"+p2pConnection.ConnectionInfo.LocalEndPoint.Port.ToString (), "P2PINFO");

             
            }
            else
            {
                MsgEntity chatContract = new MsgEntity();
                chatContract.SenderID = Common.UserID;
                
                chatContract.Reciver = this.friendID;

                chatContract.MsgBody = content;
                chatContract.SendTime = DateTime.Now;
                //chatContract.ImageList = imageWrapperList;
                Common.TcpConn.SendObject("ChatMessage", chatContract);
                this.chatControl1.Focus();
                imageWrapperList.Clear();

                LogInfo.LogMessage("服务器转发消息", "P2PINFO");
            }

        }

   

 
         
    }
}
