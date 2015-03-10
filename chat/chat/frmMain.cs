using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;
using System.Net;
using CCWin.Win32;
using CCWin.Win32.Const;
using CCWin.SkinControl;
using System.Threading;

using AuthorityEntity;
using NetworkCommsDotNet;
using AuthorityEntity.IM;

namespace ChatClient
{
    public partial class frmMain : CCSkinMain, ITwinkleNotifySupporter
    {
        /*
         获取当前用户信息
         * 获取好友列表
         * 获取离线消息
         * 开启监听
         */
        //同步锁
        private object syncLocker = new object();
        private Image currentHeadImage;     //当前头像
        private UserInformationForm userInformationForm;//悬浮至头像时

        public bool IsWindowsExit = false;
        private System.Windows.Forms.Timer timerCheckOnlinState;//保存用户自己的信息

        private OnlineState OnlineState = OnlineState.Online;//在线状态

        #region 构造函数 初始化个人资料窗体设计器
        public frmMain()
        {
            FormManager.MainForm = this;
            InitializeComponent();
        }
        #endregion
        #region onload事件
        private void main_Load(object sender, EventArgs e)
        {
          
           this.Location = new Point(SystemInformation.PrimaryMonitorSize.Width - this.Width -50, 50);
            timerCheckOnlinState = new System.Windows.Forms.Timer();//打开一个计时器
            this.timerCheckOnlinState.Interval = 60000;//间隔为60000毫秒一分钟
            this.timerCheckOnlinState.Tick += new System.EventHandler(this.timerCheckOnlinState_Tick);//绑定监听事件

            #region 初始化端口信息

            GetAllMyFriend();
            NowGetP2PInfo();
            RegistEnvet();
            #endregion
            labelName.Text = Common.ClientUser.DisplayName;
            labelSignature.Text = Common.ClientUser.DisplaySignature;

            //this.notifyIcon1.Initialize(this, this);
            //this.notifyIcon1.ChangeMyStatus();
            //this.notifyIcon1.PushFriendMessage(null, null);
            //this.chatListBox.Items[1].SubItems[0].IsTwinkle = true;
        }

        private void RegistEnvet()
        {
            //用户状态改变通知<5>
            NetworkComms.AppendGlobalIncomingPacketHandler<UserStateContract>("UserStateNotify", IncomingUserStateNotify);

            //服务器通知客户断开 一般是由于有新连接进入<6> 
            NetworkComms.AppendGlobalIncomingPacketHandler<string>("CloseConnection", IncomingCloseConn);

            //收到服务器转发来的聊天消息
            NetworkComms.AppendGlobalIncomingPacketHandler<MsgEntity>("ServerChatMessage", IncomingChatMessage);

            NetworkComms.AppendGlobalIncomingPacketHandler<MsgEntity>("ClientChatMessage", IncomingClientChatMessage);

            NetworkComms.AppendGlobalIncomingPacketHandler<SetUpP2PContract>("SetupP2PMessage", IncomingSetupP2PMessage);
            GetMyOfflineMessage();
        }
        #endregion
        #region 处理方法

        //用户状态改变通知<5>
        private void IncomingUserStateNotify(PacketHeader header, Connection connection, UserStateContract userStateContract)
        {
            if (userStateContract.OnLine == OnlineState.Online)
            {
                lock (syncLocker)
                {
                    Common.GetDicUser(userStateContract.UserID).UserState = (int)OnlineState.Online;
                    userItem[userStateContract.UserID].Status = ChatListSubItem.UserStatus.Online;
                }
            }
            else
            {
                lock (syncLocker)
                {
                    Common.GetDicUser(userStateContract.UserID).UserState = (int)OnlineState.Offline;
                    userItem[userStateContract.UserID].Status = ChatListSubItem.UserStatus.OffLine;
                    //当某用户下线后，删除此用户相关的p2p 通道
                    Common.RemoveUserConn(userStateContract.UserID);
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

            UserIDContract info = new UserIDContract(Common.ClientUser.ID);

            Common.TcpConn.SendObject("GetMyOffLineMsg", info);
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

            if (!Common.ContainsUserConn(chatContract.SenderID))
            {
                Common.AddUserConn(chatContract.SenderID, connection);
            }
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
        }


        public void HandleTextChat(MsgEntity contract)
        {
            MessageBox.Show("1");
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<MsgEntity>(this.HandleTextChat), contract);
            }
            else
            {

                frmchatMain form = FormManager.Instance.GetForm(contract.SenderID) as frmchatMain;
                if (form == null)
                {

                    if (Common.ContainsUserID(contract.SenderID))
                    {
                        userItem[contract.SenderID].IsTwinkle = true;
                        Common.AddUserMsg(contract);
                    }
                    //如果chatUserId中没有此用户ID,那么添加相应的id和消息。并触发FormNotOpen事件
                    else
                    {

                        ChatListSubItem subItem = new ChatListSubItem("网页用户", "网页用户", "网页用户", ChatListSubItem.UserStatus.Online);
                        subItem.Tag = contract.SenderID;


                        // Image.FromFile("Resources/q1.jpg");
                        userItem.Add(contract.SenderID, subItem);
                        chatListBox.Items[0].SubItems.Add(subItem);
                        userItem[contract.SenderID].IsTwinkle = true;


                        Common.AddUserID(contract.SenderID);
                        List<MsgEntity> list = new List<MsgEntity>();
                        list.Add(contract);
                        Common.AddNewUserMsg(contract.SenderID, list);
                        //让托盘图标开始跳动
                        //this.timeMessage.Enabled = true;

                        //让好友面板开始跳动

                        //Common.GetDicUser(contract.SenderID).Messages.Add(contract);
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
        Dictionary<string, ChatListSubItem> userItem = new Dictionary<string, ChatListSubItem>();
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
                UserListContract userListContract = Common.TcpConn
                    .SendReceiveObject<UserListContract>("GetFriends", "ResGetFriends", 50000, Common.ClientUser.ID);

                //遍历加载好友
                IEnumerable<IGrouping<string, IMUserInfo>> groupUserList = userListContract.UserList.GroupBy(p => p.IMGroupName);

                foreach (var group in groupUserList)
                {
                    ChatListItem chatListItem = new ChatListItem();
                    chatListItem.Text = group.Key;
                    chatListBox.Items.Add(chatListItem);
                    foreach (var user in group)
                    {

                        ChatListSubItem subItem = new ChatListSubItem(user.DisplayName, user.Name, user.DisplaySignature, ChatListSubItem.UserStatus.Online);
                        subItem.Tag = user;
                        if (user.IsOnline)
                        {
                            subItem.Status = ChatListSubItem.UserStatus.Online;
                        }
                        else
                        {
                            subItem.Status = ChatListSubItem.UserStatus.OffLine;
                        }
                        if (user.Sex == "女")
                        {
                            subItem.HeadImage = Resource1.big45;
                        }
                        else
                        {
                            subItem.HeadImage = Resource1.big28;
                        }
                        Common.AddDicUser(user.ID, user);
                        // Image.FromFile("Resources/q1.jpg");
                        userItem.Add(user.ID, subItem);
                        chatListItem.SubItems.Add(subItem);
                    }
                }
            }
        }
        public void NowGetP2PInfo()
        {
            new Action(this.GetP2PInfo).BeginInvoke(null, null);
        }
        //获取所有在线用户的信息
        private void GetP2PInfo()
        {
            IList<UserIDEndPoint> userInfoList = Common.TcpConn.SendReceiveObject<IList<UserIDEndPoint>>("GetP2PInfo", "ResP2pInfo", 5000, "GetP2P");

            foreach (UserIDEndPoint userInfo in userInfoList)
            {
                try
                {
                    if (userInfo.UserID != Common.ClientUser.ID)
                    {


                        ConnectionInfo connInfo = new ConnectionInfo(userInfo.IPAddress, userInfo.Port);
                        Connection newTcpConnection = TCPConnection.GetConnection(connInfo);
                        Common.AddUserConn(userInfo.UserID, newTcpConnection);


                        SetUpP2PContract contract = new SetUpP2PContract();
                        contract.UserID = Common.ClientUser.ID;
                        //P2p通道打通后，发送一个消息给对方用户，以便于对方用户收到消息后，建立P2P通道
                        newTcpConnection.SendObject("SetupP2PMessage", contract);
                    }

                }
                catch
                {
                }

            }

        }
        #region 检测自己的在线状态

        private void timerCheckOnlinState_Tick(object sender, System.EventArgs e)//检测自己的在线状态
        {
            CheckOnlineState();
        }


        private void CheckOnlineState()//检测自己的在线状态
        {
            //if (selfInfo.State == 0)//如果没有登录，则登录
            //{
            //    //Login();
            //}
            //else//如果已经登录在线，则将自己设为脱机状态，然后向服务器发送消息告之自已在线状态
            //{
            //    OnlineState = selfInfo.State;
            //    //selfInfo.State = 0;
            //    ClassMsg msg = new ClassMsg(2, selfInfo.ID, System.Text.Encoding.Unicode.GetBytes(OnlineState.ToString()));
            //    sendMsgToServer(msg);
            //}
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

                    frmchatMain form = FormManager.Instance.GetForm(msgUserID) as frmchatMain;

                    if (form == null)
                    {

                        //form = new frmchatMain(Common.ClientUser.ID, msgUserID);
                        //FormManager.Instance.Add(form);
                        //form.Show();
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

                    //Common.GetDicUser(msgUserID).Messages.Clear();

                    //如果字典中的消息为空，停止跳动，停止timeMessage
                    //if (chatUserId.Count == 0)
                    if (Common.UserIDCount() == 0)
                    {
                        //tsmiMessage.Image = ImageSmallFace.Images[103];

                        //this.timeMessage.Enabled = false;
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

                //this.timeMessage.Enabled = false;
            }
        }


        //#region 向用户终端发送消息
        ////public void sendMsgToOneUser(ClassMsg msg, System.Net.IPAddress Ip, int Port)//发送消息到用户的一个联系人
        ////{
        ////    msg.ID = selfInfo.ID;//标识本人的ID号
        ////    this.sockUDP1.Send(Ip, Port, new ClassSerializers().SerializeBinary(msg).ToArray());
        ////}
        //#endregion

        //#region 接收数据方法
        //private void sockUDP1_DataArrival(byte[] Data, System.Net.IPAddress Ip, int Port)
        //{
        //    //DataArrivaldelegate outdelegate = new DataArrivaldelegate(DataArrival);
        //    //this.BeginInvoke(outdelegate, new object[] { Data, Ip, Port });
        //}

        //private delegate void DataArrivaldelegate(byte[] Data, System.Net.IPAddress Ip, int Port);

        ////private void DataArrival(byte[] Data, System.Net.IPAddress Ip, int Port)
        ////{
        ////    ClassMsg msg = new ClassSerializers().DeSerializeBinary((new System.IO.MemoryStream(Data))) as ClassMsg;
        ////    switch (msg.MsgInfoClass)
        ////    {
        ////        case -1:
        ////            //MessageBox.Show(msg.MsgContent);
        ////            break;
        ////        case 0://有用户离线
        ////            userSingnOut(msg.ID);//处理用户离线
        ////            break;
        ////        case 1://服务器告诉自己已经登录,登录过程
        ////            SuccessLogin(msg);
        ////            break;
        ////        case 2://服务器告诉用户自己目前在线
        ////            //updateSelfState();//更新当前用户在线状态
        ////            break;
        ////        case 3://服务器告诉用户有新的联系人登录
        ////            NewUserLogin(new ClassSerializers().DeSerializeBinary((new System.IO.MemoryStream(msg.MsgContent))) as ClassUserInfo);//添加新登录的用户资料
        ////            break;
        ////        case 4://收到用户部分联系人的资料
        ////            UsersDataArrival((new ClassSerializers().DeSerializeBinary((new System.IO.MemoryStream(msg.MsgContent))) as ClassUsers));//收到用户所有联系人的资料
        ////            break;
        ////        case 5://收到用户联系人发送来的对话消息
        ////            //UserChatArrival(msg, Ip, Port);//处理对话消息
        ////            break;
        ////        case 6://联系人返回已经收到刚才发送的对话消息
        ////            //returnChatArrival(msg.ID);//联系人返回已经收到刚才发送的对话消息
        ////            break;
        ////        case 7:
        ////            //收到联系人发送来的群发通知消息
        ////            //noticeArrival(msg, Ip, Port);//处理联系人发送来的群发通知消息
        ////            break;
        ////        case 10://收到联系人发出发送文件请求
        ////            //sendFileRequest(msg, Ip, Port);
        ////            break;
        ////        case 11://收到联系人发送来的gif图片流
        ////            //UserGifArrival(msg, Ip, Port);//处理gif图片消息
        ////            break;
        ////        case 12://收到用户发送来的文本消息
        ////            UserTextChatArrival(msg, Ip, Port);//处理用户发送来的文本消息
        ////            break;
        ////    }

        ////}

        ////private void UsersDataArrival(ClassUsers users)//收到用户所有联系人的资料
        ////{
        ////    ClassUserInfo UserInfo;
        ////    foreach (ClassUserInfo userinfo in users)
        ////    {
        ////        UserInfo = findUser(userinfo.ID);
        ////        if (userinfo.ID == selfInfo.ID)
        ////            break;//如果新登录的联系人是自己则退出
        ////        if (UserInfo == null)
        ////        {
        ////            this.MyUsers.add(userinfo);
        ////            ChatListSubItem subItem = new ChatListSubItem(userinfo.ID, userinfo.UserName, userinfo.AssemblyVersion, 
        //ChatListSubItem.UserStatus.Online);
        ////            this.chatListBox.Items[1].SubItems.AddAccordingToStatus(subItem);
        ////            //updateGroupInfo(userinfo);


        ////        }
        ////        else
        ////        {
        ////            ClassUserInfo user = new ClassUserInfo();
        ////            user.ID = userinfo.ID;
        ////            user.IP = userinfo.IP;
        ////            user.Port = userinfo.Port;
        ////            user.AssemblyVersion = userinfo.AssemblyVersion;
        ////            this.UpdateUser(user);//更新用户状态

        ////            foreach (ChatListItem item in chatListBox.Items)
        ////            {
        ////                foreach (ChatListSubItem subItem in item.SubItems)
        ////                {
        ////                    if (subItem.Tag.ToString().ToLower() == user.ID.ToLower())
        ////                    {
        ////                        subItem.Status = ChatListSubItem.UserStatus.Online;
        ////                        break;
        ////                    }

        ////                }
        ////            }
        ////        }
        ////    }
        ////}
        ////private void UserTextChatArrival(ClassMsg msg, System.Net.IPAddress Ip, int Port)//处理用户发送来的文本消息
        ////{

        ////    ClassUserInfo userinfo = this.findUser(msg.ID);
        ////    if (userinfo != null)
        ////    {
        ////        string title = userinfo.UserName + "(" + System.DateTime.Now.ToString() + ")";
        ////        //MsgAddToDB(msgRtf,msg.ID,selfInfo.ID,msg.AssemblyVersion,System.DateTime.Now.ToString(),true);//将消息添加进数据库
        ////    //    foreach (System.Windows.Forms.Form form in forms)
        ////    //        if (form.Tag.ToString() == userinfo.ID)
        ////    //        {
        ////    //            frmchatMain f = (form as frmchatMain);
        ////    //            f.newTextMsg(msg.MsgContent, title, new System.Drawing.Font("宋体", 10), Color.Blue);
        ////    //            f.Activate();
        ////    //            return;
        ////    //        }

        ////    //    frmchatMain newf = new frmchatMain();
        ////    //    newf.Tag = msg.ID;
        ////    //    newf.Text = "与 " + userinfo.UserName + "(" + userinfo.ID + ") 对话";
        ////    //    newf.setUserName(userinfo.UserName);
        ////    //    newf.newTextMsg(msg.MsgContent, title, new System.Drawing.Font("宋体", 10), Color.Blue);
        ////    //    forms.add(newf);
        ////    //    //ShowNotifyIcon(1, "", "收到 " + userinfo.UserName + "(" + userinfo.ID + ") 发送给您的新消息。");
        ////    //    newf.Show();

        ////     }
        ////}
        //#endregion

        //#region 接收后信息的回调方法
        //private void userSingnOut(string msgID)
        //{


        //    //RemoveUser(msgID);
        //    foreach (ChatListSubItem subItem in this.chatListBox.Items[1].SubItems)
        //    {

        //        if (subItem.NicName == msgID)
        //        {
        //            subItem.Status = ChatListSubItem.UserStatus.OffLine;
        //            break;
        //        }
        //    }
        //    //this.chatListBox.Items[1].SubItems[0].Status = "";
        //}

        ////private void SuccessLogin(ClassMsg msg)//服务器告诉用户已经成功登录的处理过程
        ////{
        ////this.Text="成功登陆";
        ////ClassUserInfo self = (new ClassSerializers().DeSerializeBinary(new System.IO.MemoryStream(msg.MsgContent))) as ClassUserInfo;
        ////selfInfo.UserName = self.UserName;
        ////selfInfo.State = 1;

        ////ShowNotifyIcon(1,"","LanMsg已经成功登录服务器。");
        ////}

        ////private void NewUserLogin(ClassUserInfo userinfo)//添加新登录的用户资料
        ////{


        ////    if (userinfo.ID == selfInfo.ID)
        ////        return;//如果新登录的联系人是自己则退出
        ////    //this.Text="新用户"+ userinfo.ID;
        ////    ClassUserInfo UserInfo;
        ////    UserInfo = findUser(userinfo.ID);

        ////    if (UserInfo == null)
        ////    {
        ////        this.MyUsers.add(userinfo);
        ////        ChatListSubItem subItem = new ChatListSubItem(userinfo.ID, userinfo.UserName, userinfo.AssemblyVersion, ChatListSubItem.UserStatus.Online);
        ////        this.chatListBox.Items[1].SubItems.AddAccordingToStatus(subItem);

        ////        // 增加一个新用户
        ////    }
        ////    else
        ////    {
        ////        ClassUserInfo user = new ClassUserInfo();
        ////        user.ID = userinfo.ID;
        ////        user.IP = userinfo.IP;
        ////        user.Port = userinfo.Port;
        ////        user.AssemblyVersion = userinfo.AssemblyVersion;
        ////        this.UpdateUser(user);//更新用户状态

        ////        foreach (ChatListItem item in chatListBox.Items)
        ////        {
        ////            foreach (ChatListSubItem subItem in item.SubItems)
        ////            {
        ////                if (subItem.Tag.ToString().ToLower() == user.ID.ToLower())
        ////                {
        ////                    subItem.Status = ChatListSubItem.UserStatus.Online;
        ////                    break;
        ////                }

        ////            }
        ////        }
        ////        //更改新用户的状态
        ////    }
        ////    // MessageBox.Show("1");

        ////}
        //#endregion

        //#region 操作当前用户的方法
        ////public ClassUserInfo findUser(string ID)//在我的用户列表中查找用户ID
        ////{
        ////    foreach (ClassUserInfo userinfo in this.MyUsers)
        ////        if (userinfo.ID.ToLower() == ID.ToLower())
        ////            return userinfo;
        ////    return null;
        ////}

        /////// <summary>
        /////// 更新用户状态 IP 和端口信息
        /////// </summary>
        /////// <param name="user"></param>
        ////public void UpdateUser(ClassUserInfo user)
        ////{
        ////    //更新用户状态 IP 和端口信息
        ////    foreach (ClassUserInfo userinfo in this.MyUsers)
        ////    {
        ////        if (userinfo.ID.ToLower() == user.ID.ToLower())
        ////        {
        ////            userinfo.State = user.State;
        ////            userinfo.IP = user.IP;
        ////            userinfo.Port = user.Port;
        ////            break;
        ////        }
        ////    }
        ////}

        ////public void RemoveUser(string ID)
        ////{
        ////    foreach (ClassUserInfo userinfo in this.MyUsers)
        ////    {
        ////        if (userinfo.ID.ToLower() == ID.ToLower())
        ////        {
        ////            this.MyUsers.Romove(userinfo);
        ////            break;
        ////        }
        ////    }

        ////}

        //#endregion

        //#region 设置一些用户菜单事件


        //private void skinButton_State_Click(object sender, EventArgs e)
        //{
        //    this.skinContextMenuStrip_State.Show(skinButton_State, new Point(0, skinButton_State.Height), ToolStripDropDownDirection.Right);
        //}

        //private void toolStripMenuItem20_Click(object sender, EventArgs e)
        //{
        //    ToolStripMenuItem Item = (ToolStripMenuItem)sender;
        //    skinButton_State.Image = Item.Image;
        //    skinButton_State.Tag = Item.Tag;
        //    // this.myselfChatListSubItem.Status = (ChatListSubItem.UserStatus)Convert.ToInt32(skinButton_State.Tag);

        //}

        //private void toolStripMenuItem30_Click(object sender, EventArgs e)
        //{
        //    ToolStripMenuItem Item = (ToolStripMenuItem)sender;
        //    skinButton_State.Image = Item.Image;
        //    skinButton_State.Tag = Item.Tag;
        //}

        //private void toolStripMenuItem31_Click(object sender, EventArgs e)
        //{
        //    ToolStripMenuItem Item = (ToolStripMenuItem)sender;
        //    skinButton_State.Image = Item.Image;
        //    skinButton_State.Tag = Item.Tag;
        //}

        //private void toolStripMenuItem32_Click(object sender, EventArgs e)
        //{
        //    ToolStripMenuItem Item = (ToolStripMenuItem)sender;
        //    skinButton_State.Image = Item.Image;
        //    skinButton_State.Tag = Item.Tag;
        //}

        //private void toolStripMenuItem33_Click(object sender, EventArgs e)
        //{
        //    ToolStripMenuItem Item = (ToolStripMenuItem)sender;
        //    skinButton_State.Image = Item.Image;
        //    skinButton_State.Tag = Item.Tag;
        //}

        //#endregion

        #region 双击打开用户列表
        private void chatListBox_DoubleClickSubItem(object sender, ChatListEventArgs e)
        {

            ChatListSubItem item = e.SelectSubItem;
            IMUserInfo chatuser = item.Tag as IMUserInfo;
            item.IsTwinkle = false;//不闪烁 
            FormManager.Instance.ActivateOrCreateFormSend(chatuser);

        }

        //#endregion

        //#region 鼠标在用户上显示用户名片
        //private void chatListBox_MouseEnterHead(object sender, ChatListEventArgs e)
        //{

        //    int top = this.Top + this.chatListBox.Top + (e.MouseOnSubItem.HeadRect.Y - this.chatListBox.chatVScroll.Value);
        //    int left = this.Left - 279 - 5;
        //    int ph = Screen.GetWorkingArea(this).Height;

        //    if (top + 181 > ph)
        //    {
        //        top = ph - 181 - 5;
        //    }

        //    if (left < 0)
        //    {
        //        left = this.Right + 5;
        //    }

        //    if (userInformationForm != null)
        //    {
        //        this.userInformationForm.Item = e.MouseOnSubItem;
        //        this.userInformationForm.Location = new Point(left, top);
        //        this.userInformationForm.Show();
        //    }
        //    else
        //    {
        //        this.userInformationForm = new UserInformationForm(e.MouseOnSubItem, new Point(left, top));
        //        this.userInformationForm.Show();
        //    }
        //}

        //private void chatListBox_MouseLeave(object sender, EventArgs e)
        //{
        //    Thread.Sleep(100);
        //    if (this.userInformationForm != null && !this.userInformationForm.Bounds.Contains(Cursor.Position))
        //    {
        //        this.userInformationForm.Hide();
        //    }
        //}
        //#endregion

        //#region 用户关闭窗体事件
        //private void main_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    AppExit();
        //}
        //private void AppExit()//关闭Sock，退出程序
        //{
        //    //ClassMsg msg = new ClassMsg(2, selfInfo.ID, System.Text.Encoding.Unicode.GetBytes("0"));
        //    //sendMsgToServer(msg);
        //    //this.sockUDP1.CloseSock();
        //    //Application.Exit();
        //}
        //#endregion

        //#region 任务栏图标双击事件
        //private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    this.notifyIcon1.Stop();
        //    //this.notifyIcon1.co
        //    this.Show();
        //    this.Activate();
        //}
        //#endregion






        //#region ITwinkleNotifySupporter接口实现

        //public string GetFriendName(string friendID)
        //{

        //    return "haha";
        //}




        //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmchatMain));//加载资源

        //public Icon GetHeadIcon(string userID)
        //{


        //    return Icon.FromHandle(global::ChatClient.Properties.Resources.normal_group_40.GetHicon());
        //}

        //public Icon GetIcon()
        //{

        //    return Icon.FromHandle(global::ChatClient.Properties.Resources.normal_group_40.GetHicon());
        //}
        //public Icon Icon64
        //{
        //    get { return Icon.FromHandle(global::ChatClient.Properties.Resources.normal_group_40.GetHicon()); }
        //}

        //public Icon NoneIcon64
        //{
        //    get { return Icon.FromHandle(global::ChatClient.Properties.Resources.None64.GetHicon()); }
        //}


        //IChatForm ITwinkleNotifySupporter.GetChatForm(string friendID)
        //{
        //    return null;
        //}

        //IChatForm ITwinkleNotifySupporter.GetExistedChatForm(string friendID)
        //{
        //    return null;
        //}



        #endregion

        public IChatForm GetChatForm(string friendID)
        {
            return FormManager.Instance.GetForm(friendID) as IChatForm;
        }

        public IChatForm GetExistedChatForm(string friendID)
        {
            return FormManager.Instance.GetForm(friendID) as IChatForm;
        }

        public string GetFriendName(string friendID)
        {
            return Common.GetDicUser(friendID).DisplayName;
        }

        public Icon GetHeadIcon(string userID)
        {
            return null;// Image.FromFile(Common.GetDicUser(userID).Photo) as Icon;
        }

        public Icon GetIcon()
        {
            throw new NotImplementedException();
        }

        public Icon Icon64
        {
            get { throw new NotImplementedException(); }
        }

        public Icon NoneIcon64
        {
            get { throw new NotImplementedException(); }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出即时通和话务中心系统？","确定退出", MessageBoxButtons.YesNo)== System.Windows.Forms.DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            
        }

        private void notifyIcon2_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

         


    }
}
