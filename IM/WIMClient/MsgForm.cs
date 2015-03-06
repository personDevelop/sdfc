//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
 
 
using NetworkCommsDotNet;
 
using System.Threading;
using System.IO;
using System.Xml;
using IMInterface;
using AuthorityEntity;

namespace WIMClient
{
    public partial class MsgForm : Form
    {
        //窗体管理器
        private FormManager<ChatForm> chatFormManager = new FormManager<ChatForm>();

        public FormManager<ChatForm> ChatFormManager
        {
            set
            {
                this.chatFormManager = value;
            }
        }

        //同步锁
        private object syncLocker = new object();

        public MsgForm()
        {
            InitializeComponent(); 
        } 
         

        public void Initialize()
        {
           //获取我的所有好友
           GetAllMyFriend();

           
           //进行UI显示
           ShowUserBar();

            //获取P2P信息并进行连接
           NowGetP2PInfo();

           userNameToolStripMenuItem.Text = "当前用户ID"+Common.UserID;
        }

        /// <summary>
        /// 获取我的好友
        /// </summary>
        public void GetAllMyFriend()
        {
            //获取之前先清空用户字典
            Common.AllUserDic.Clear();
            if (Common.AllUserDic.Count == 0)
            {
                //向服务器端发送信息并获取结果
                UserListContract userListContract = Common.TcpConn.SendReceiveObject<UserListContract>("GetFriends", "ResGetFriends", 5000, Common.UserID);

                //遍历加载好友
                foreach (UserInfo user in userListContract.UserList)
                {
                    //把用户添加到字典中
                    //根据性别 分别使用不同的图标
                    //if (user.IsMale)
                    //{
                    //    Common.AddDicUser(user.UserID, new User(user.UserID, user.Name, user.Declaring, user.IsMale == true ? UserSex.Male : UserSex.Female, Properties.Resources.q1, "电话", "电子邮件", user.OnLine == true ? OnlineState.Online : OnlineState.Offline));
                    //}
                    //else
                    //{
                    //    Common.AddDicUser(user.UserID, new User(user.UserID, user.Name, user.Declaring, user.IsMale == true ? UserSex.Male : UserSex.Female, Properties.Resources.q2, "电话", "电子邮件", user.OnLine == true ? OnlineState.Online : OnlineState.Offline));

                    //}
                }
            }
        }
       
        // Dictionary<组ID，列表<用户ID>>     
        // 存放每个组的组ID  以及本组对应的用户列表
        private Dictionary<int, List<string>> dicGroupUser = new Dictionary<int, List<string>>();

        //显示用户窗口
        private void ShowUserBar()
        {
            SlidingBar bar = new SlidingBar("微风IM");

           
            //IList<UserGroup> resGroups = Common.TcpConn.SendReceiveObject<IList<UserGroup>>("GetGroup", "ResGroup", 5000, "GetGroup");

            ////获取所有用户ID 以及用户对应的组的组ID   
            //IList<UserGroupIDContract> allUserGroupID = Common.TcpConn.SendReceiveObject<IList<UserGroupIDContract>>("GetUserGroupID", "ResUserGroupID", 5000, "100");

            ////根据用户组，初始化用户组字典
            //foreach (UserGroup group in resGroups)
            //{
            //    dicGroupUser.Add(group.Id, new List<string>());

            //}
            ////把用户，根据用户ID添加到字典中
            //foreach (UserGroupIDContract contract in allUserGroupID)
            //{
            //    if (dicGroupUser.ContainsKey(contract.GroupID))
            //    {
            //        dicGroupUser[contract.GroupID].Add(contract.SenderID);
            //    }
            //}
            ////实例化每一个用户组
            //foreach (UserGroup userGroup in resGroups)
            //{
            //    Group newGroup = new Group(userGroup.Id.ToString(), userGroup.GroupName);

            //    IList<string> lstUserID = dicGroupUser[userGroup.Id];


            //      foreach (string userID in lstUserID)
            //      {
            //          User currUser = Common.GetDicUser(userID);
            //          newGroup.Users.Add(currUser);
            //      }
            //      bar.AddGroup(newGroup);
            //}
             
            bar.Location = new System.Drawing.Point(0, 0);
            bar.Name = "slidingBarContainer1";
            bar.Size = new System.Drawing.Size(500, 500);
            bar.Dock = DockStyle.Fill;
            bar.TabIndex = 50;  

            this.Controls.Add(bar);
        }

        //获取所有在线用户  GetAllMyFriend已包含本方法  本方法不再使用  
        private void GetAllOnlineUser()
        {
            //UserIDContract contract = Common.TcpConn.SendReceiveObject<UserIDContract>("GetOnlineUser", "ResOnlineUser", 5000, "Get");

            //foreach (string theUserID in contract.UsersID)
            //{
            //    Common.GetDicUser(theUserID).State =  OnlineState.Online;

            //}
        }

        public delegate void Action();
        public void NowGetP2PInfo()
        {
            new Action(this.GetP2PInfo).BeginInvoke(null, null);
        }

        //获取所有在线用户的信息
        private void GetP2PInfo()
        {
            //IList<UserIDEndPoint> userInfoList = Common.TcpConn.SendReceiveObject<IList<UserIDEndPoint>>("GetP2PInfo", "ResP2pInfo", 5000, "GetP2P");

            //foreach (UserIDEndPoint userInfo in userInfoList)
            //{
            //    try
            //    {
            //        if (userInfo.UserID != Common.UserID)
            //        {
            //            LogInfo.LogMessage("准备建立" + userInfo.UserID + ":" + userInfo.IPAddress + ":" + userInfo.Port.ToString(), "P2PInfo");

            //            ConnectionInfo connInfo = new ConnectionInfo(userInfo.IPAddress, userInfo.Port);
            //            Connection newTcpConnection = TCPConnection.GetConnection(connInfo);
            //            Common.AddUserConn(userInfo.UserID, newTcpConnection);


            //            SetUpP2PContract contract = new SetUpP2PContract();
            //            contract.SenderID = Common.UserID;

            //            //P2p通道打通后，发送一个消息给对方用户，以便于对方用户收到消息后，建立P2P通道
            //            newTcpConnection.SendObject("SetupP2PMessage", contract);



            //            LogInfo.LogMessage("已经建立" + userInfo.UserID + ":" + userInfo.IPAddress + ":" + userInfo.Port.ToString(), "P2PInfo");
            //        }
                   
            //    }
            //    catch 
            //    {
            //    }
              
            //}

        }

        private void MsgForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            NetworkComms.Shutdown();
            this.Dispose();
            this.Close();
        }

        private void MsgForm_Load(object sender, EventArgs e)
        {
            //不启用日志记录

            NetworkComms.DisableLogging();

            //用户状态改变通知<5>
            //NetworkComms.AppendGlobalIncomingPacketHandler<UserStateContract>("UserStateNotify", IncomingUserStateNotify);


            //服务器通知客户断开 一般是由于有新连接进入<6>

            NetworkComms.AppendGlobalIncomingPacketHandler<string>("CloseConnection", IncomingCloseConn);

            //收到服务器转发来的聊天消息
            NetworkComms.AppendGlobalIncomingPacketHandler<MsgEntity>("ServerChatMessage", IncomingChatMessage);

            NetworkComms.AppendGlobalIncomingPacketHandler<MsgEntity>("ClientChatMessage", IncomingClientChatMessage);

            //NetworkComms.AppendGlobalIncomingPacketHandler<SetUpP2PContract>("SetupP2PMessage", IncomingSetupP2PMessage);
            GetMyOfflineMessage();
        }

        #region 处理方法

        //用户状态改变通知<5>
        private void IncomingUserStateNotify(PacketHeader header, Connection connection, UserStateContract userStateContract)
        {
            if (userStateContract.OnLine)
            {
                lock (syncLocker)
                {
                    //Common.GetDicUser(userStatecontract.SenderID).State = OnlineState.Online;
                }
            }
            else
            {
                lock (syncLocker)
                {
                    //Common.GetDicUser(userStatecontract.SenderID).State = OnlineState.Offline;
                    ////当某用户下线后，删除此用户相关的p2p 通道
                    //Common.RemoveUserConn(userStatecontract.SenderID);
                }
            }
        }

        //服务器通知连接断开 <6>

        private void IncomingCloseConn(PacketHeader header, Connection connection, string msg)
        {
            //服务器通知关闭程序  
            this.Close();


        }

        //获取离线消息

        private void GetMyOfflineMessage()
        {
            //UserInfo info = new UserInfo(Common.UserID, "password");
       
            //Common.TcpConn.SendObject("GetMyOffLineMsg", info);
        }


        //处理服务器转发来的聊天消息
        private void IncomingChatMessage(PacketHeader header, Connection connection, MsgEntity chatContract)
        {
            HandleTextChat(chatContract);
        }

        //处理客户端发来的聊天消息
        private void IncomingClientChatMessage(PacketHeader header, Connection connection, MsgEntity chatContract)
        {
            //如果是P2P消息，则直接把连接添加到Common静态类中

            //if (!Common.ContainsUserConn(chatcontract.SenderID))
            //{
            //    Common.AddUserConn(chatcontract.SenderID, connection);
            //}

            LogInfo.LogMessage( "当前用户:"+Common.UserID+"收到P2P消息"+"本地端口是："+connection.ConnectionInfo.LocalEndPoint.Port.ToString (), "P2PInfo");


            HandleTextChat(chatContract);

            
        }

        //收到创建P2P通道的消息
        private void IncomingSetupP2PMessage(PacketHeader header, Connection connection, SetUpP2PContract contract)
        {
            //如果还没有P2P通道，则创建之
            if (!Common.ContainsUserConn(contract.UserID))
            {
                Common.AddUserConn(contract.UserID, connection);
                 
            }
            LogInfo.LogMessage("收到P2P创建连接消息" + "本地端口是：" + connection.ConnectionInfo.LocalEndPoint.Port.ToString(), "P2PInfo");
        }


        public void HandleTextChat(MsgEntity contract)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<MsgEntity>(this.HandleTextChat), contract);
            }
            else
            {
                ChatForm form = Common.ChatFormManager.GetForm(contract.SenderID);
                if (form == null)
                {
                    //if (chatUserId.Contains(contract.SenderID))
                    if (Common.ContainsUserID(contract.SenderID))
                    {
                        Common.AddUserMsg(contract);
                    }
                    //如果chatUserId中没有此用户ID,那么添加相应的id和消息。并触发FormNotOpen事件
                    else
                    {
                        //chatUserId.Add(contract.SenderID);
                        Common.AddUserID(contract.SenderID);

                        List<MsgEntity> list = new List<MsgEntity>();
                        list.Add(contract);


                        Common.AddNewUserMsg(contract.SenderID, list);
                        //让托盘图标开始跳动
                        this.timeMessage.Enabled = true;

                        //让好友面板开始跳动

                        Common.GetDicUser(contract.SenderID).Messages.Add(contract);
                    }
                }
                else
                {
                    List<MsgEntity> list = new List<MsgEntity>();
                    list.Add(contract);
                    form.ShowOtherTextChat(contract.SenderID, list);
                    form.Activate();


                }

            }
        }
         

        #endregion




        #region  启动Timer  启动托盘栏上的消息跳动  从第一开始。
        int displayId = 0;
        private void timeMessage_Tick(object sender, EventArgs e)
        {

            if (Common.UserIDCount() > 0)
            {

                //取得chatUserID数组中第一个用户ID
                string destUserID = Common.FirstUserID();
                //判断当前用户的性别
                bool isMale = Common.GetDicUser(destUserID).Sex == UserSex.Male ? true : false;

                Icon i1;
                if (isMale)
                {

                    i1 = Properties.Resources.Male;
                }
                else
                {
                    i1 = Properties.Resources.FeMale;
                }

                Icon i2 = Properties.Resources.KongBai;

                if (displayId == 0)
                {
                    notifyIcon1.Icon = i2;
                    //面板上的消息跳动
                    //tsmiMessage.Image = ImageSmallFace.Images[102];
                    displayId++;
                }
                else
                {
                    notifyIcon1.Icon = i1;
                    //tsmiMessage.Image = ImageSmallFace.Images[103];
                    displayId--;
                }
            }
            else
            {


                //做了一个判断，如果chatUserID与chatMsg不能对应，则清空他们。

                Common.ClearUserID();
                Common.ClearUserMsg();
              
                this.timeMessage.Enabled = false;
            }


        }
        #endregion



        //打开聊天窗口  并显示消息
        private void showAddMsg()
        {
            //if (chatMsgDic.Count > 0 && chatUserId.Count > 0)

            if (Common.UserMsgCount() > 0 && Common.UserIDCount() > 0)
            {
                //string destUserID = chatUserId[0];
                string msgUserID = Common.FirstUserID();

                if (msgUserID != "")
                {

                    ChatForm form = Common.ChatFormManager.GetForm(msgUserID);

                    if (form == null)
                    {

                        form = new ChatForm(Common.UserID, msgUserID);
                        Common.ChatFormManager.Add(form);
                        form.Show();

                    }
                    form.Focus();
                    //显示聊天信息
                    //this.chatFormManagerControl1.ShowChatMsg(chatMsg[destUserID],destUserID);

                    //form.ShowOtherTextChat(destUserID, chatMsgDic[destUserID]);

                    if (Common.ContainsUserID(msgUserID))
                    {
                        form.ShowOtherTextChat(msgUserID, Common.MsgContractList(msgUserID));
                    }
                    //从相关字典中删除相应信息.
                    //chatUserId.Remove(destUserID);
                    //chatMsgDic.Remove(destUserID);
                    Common.RemoveID(msgUserID);
                    Common.RemoveMsg(msgUserID);

                    Common.GetDicUser(msgUserID).Messages.Clear();

                    //如果字典中的消息为空，停止跳动，停止timeMessage
                    //if (chatUserId.Count == 0)
                    if (Common.UserIDCount() == 0)
                    {
                        //tsmiMessage.Image = ImageSmallFace.Images[103];
                  
                        this.timeMessage.Enabled = false;
                    }
                }

            }
            else
            {
                //tsmiMessage.Image = ImageSmallFace.Images[103];

                //做了一个判断，如果chatUserID与chatMsg不能对应，则清空他们。
                //chatUserId.Clear();
                //chatMsgDic.Clear();
                Common.ClearUserID();
                Common.ClearUserMsg();
               
                this.timeMessage.Enabled = false;
            }
        }
        //双击托盘图标    显示当前窗口 
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            showAddMsg();
            this.Show();
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Maximized;
                this.ShowInTaskbar = true;
            }
            this.Activate();
        }



        private bool toExit = false;

      

        private void display_Click(object sender, EventArgs e)
        {
            this.Show();
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Maximized;
            this.Activate();
        }

        private void 查看P2P通道信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            P2PUserForm form = new P2PUserForm();
            form.Show();
        }

    }
}
