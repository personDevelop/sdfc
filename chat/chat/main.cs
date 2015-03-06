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

namespace chat
{
    public partial class main : CCSkinMain, ITwinkleNotifySupporter
    {

        private Image currentHeadImage;     //当前头像
        private UserInformationForm userInformationForm;//悬浮至头像时
        private SockUDP sockUDP1;//socket进程
        public ClassUserInfo selfInfo = new ClassUserInfo();
        private IPAddress ServerIP = IPAddress.Parse("39.78.69.94");//服务器IP
        public string userNickName;
        private int ServerPort = 3211;//服务器端口
        public bool IsWindowsExit = false;
        private System.Windows.Forms.Timer timerCheckOnlinState;//保存用户自己的信息
        public ClassUsers MyUsers = new ClassUsers();
        private int OnlineState = 1;//在线状态
        public Hashtable htgroup = new Hashtable();//用户组和list索引对应的hashtable
        public string userid = "";
        public string username = "";
        public List<ClassDept> deptinfo = new List<ClassDept>();


        #region 构造函数 初始化个人资料窗体设计器
        public main()
        {
            ClassFormMain formMain = new ClassFormMain();
            formMain.formMain = this;
            InitializeComponent();


        }
        #endregion

        #region 设置用户的缓存
        public void setDeptCache(List<ClassDept> depts)
        {
            this.deptinfo = depts;
        }
        #endregion

        #region 设置用户的个人姓名
        public void setNickName(string name)
        {
            this.username = name;
            // labelName.Text = name;
        }
        #endregion

        #region 检测自己的在线状态

        private void timerCheckOnlinState_Tick(object sender, System.EventArgs e)//检测自己的在线状态
        {
            CheckOnlineState();
        }


        private void CheckOnlineState()//检测自己的在线状态
        {
            if (selfInfo.State == 0)//如果没有登录，则登录
            {
                //Login();
            }
            else//如果已经登录在线，则将自己设为脱机状态，然后向服务器发送消息告之自已在线状态
            {
                OnlineState = selfInfo.State;
                //selfInfo.State = 0;
                ClassMsg msg = new ClassMsg(2, selfInfo.ID, System.Text.Encoding.Unicode.GetBytes(OnlineState.ToString()));
                sendMsgToServer(msg);
            }
        }
        #endregion

        #region 登录到服务器上
        private void Login()//用户登录
        {
            ClassMsg msg = new ClassMsg(1, selfInfo.ID, System.Text.Encoding.Unicode.GetBytes(selfInfo.AssemblyVersion));
            sendMsgToServer(msg);
        }
        #endregion

        #region 向服务器发送消息
        public void sendMsgToServer(ClassMsg msg)//发送消息到服务器
        {
            this.sockUDP1.Send(this.ServerIP, this.ServerPort, new ClassSerializers().SerializeBinary(msg).ToArray());
        }
        #endregion

        #region 向用户终端发送消息
        public void sendMsgToOneUser(ClassMsg msg, System.Net.IPAddress Ip, int Port)//发送消息到用户的一个联系人
        {
            msg.ID = selfInfo.ID;//标识本人的ID号
            this.sockUDP1.Send(Ip, Port, new ClassSerializers().SerializeBinary(msg).ToArray());
        }
        #endregion

        #region 接收数据方法
        private void sockUDP1_DataArrival(byte[] Data, System.Net.IPAddress Ip, int Port)
        {
            DataArrivaldelegate outdelegate = new DataArrivaldelegate(DataArrival);
            this.BeginInvoke(outdelegate, new object[] { Data, Ip, Port });
        }

        private delegate void DataArrivaldelegate(byte[] Data, System.Net.IPAddress Ip, int Port);

        private void DataArrival(byte[] Data, System.Net.IPAddress Ip, int Port)
        {
            ClassMsg msg = new ClassSerializers().DeSerializeBinary((new System.IO.MemoryStream(Data))) as ClassMsg;
            switch (msg.MsgInfoClass)
            {
                case -1:
                    //MessageBox.Show(msg.MsgContent);
                    break;
                case 0://有用户离线
                    userSingnOut(msg.ID);//处理用户离线
                    break;
                case 1://服务器告诉自己已经登录,登录过程
                    SuccessLogin(msg);
                    break;
                case 2://服务器告诉用户自己目前在线
                    //updateSelfState();//更新当前用户在线状态
                    break;
                case 3://服务器告诉用户有新的联系人登录
                    NewUserLogin(new ClassSerializers().DeSerializeBinary((new System.IO.MemoryStream(msg.MsgContent))) as ClassUserInfo);//添加新登录的用户资料
                    break;
                case 4://收到用户部分联系人的资料
                    UsersDataArrival((new ClassSerializers().DeSerializeBinary((new System.IO.MemoryStream(msg.MsgContent))) as ClassUsers));//收到用户所有联系人的资料
                    break;
                case 5://收到用户联系人发送来的对话消息
                    //UserChatArrival(msg, Ip, Port);//处理对话消息
                    break;
                case 6://联系人返回已经收到刚才发送的对话消息
                    //returnChatArrival(msg.ID);//联系人返回已经收到刚才发送的对话消息
                    break;
                case 7:
                    //收到联系人发送来的群发通知消息
                    //noticeArrival(msg, Ip, Port);//处理联系人发送来的群发通知消息
                    break;
                case 10://收到联系人发出发送文件请求
                    //sendFileRequest(msg, Ip, Port);
                    break;
                case 11://收到联系人发送来的gif图片流
                    //UserGifArrival(msg, Ip, Port);//处理gif图片消息
                    break;
                case 12://收到用户发送来的文本消息
                    UserTextChatArrival(msg, Ip, Port);//处理用户发送来的文本消息
                    break;
            }

        }

        private void UsersDataArrival(ClassUsers users)//收到用户所有联系人的资料
        {
            ClassUserInfo UserInfo;
            foreach (ClassUserInfo userinfo in users)
            {
                UserInfo = findUser(userinfo.ID);
                if (userinfo.ID == selfInfo.ID)
                    break;//如果新登录的联系人是自己则退出
                if (UserInfo == null)
                {
                    this.MyUsers.add(userinfo);
                    ChatListSubItem subItem = new ChatListSubItem(userinfo.ID, userinfo.UserName, userinfo.AssemblyVersion, ChatListSubItem.UserStatus.Online);
                    this.chatListBox.Items[1].SubItems.AddAccordingToStatus(subItem);
                    //updateGroupInfo(userinfo);
                }
                else
                {
                    ClassUserInfo user = new ClassUserInfo();
                    user.ID = userinfo.ID;
                    user.IP = userinfo.IP;
                    user.Port = userinfo.Port;
                    user.AssemblyVersion = userinfo.AssemblyVersion;
                    this.UpdateUser(user);//更新用户状态

                    foreach (ChatListItem item in chatListBox.Items)
                    {
                        foreach (ChatListSubItem subItem in item.SubItems)
                        {
                            if (subItem.Tag.ToString().ToLower() == user.ID.ToLower())
                            {
                                subItem.Status = ChatListSubItem.UserStatus.Online;
                                break;
                            }

                        }
                    }
                }
            }
        }
        private void UserTextChatArrival(ClassMsg msg, System.Net.IPAddress Ip, int Port)//处理用户发送来的文本消息
        {

            ClassUserInfo userinfo = this.findUser(msg.ID);
            if (userinfo != null)
            {
                string title = userinfo.UserName + "(" + System.DateTime.Now.ToString() + ")";
                //MsgAddToDB(msgRtf,msg.ID,selfInfo.ID,msg.AssemblyVersion,System.DateTime.Now.ToString(),true);//将消息添加进数据库
                foreach (System.Windows.Forms.Form form in forms)
                    if (form.Tag.ToString() == userinfo.ID)
                    {
                        chat f = (form as chat);
                        f.newTextMsg(msg.MsgContent, title, new System.Drawing.Font("宋体", 10), Color.Blue);
                        f.Activate();
                        return;
                    }

                chat newf = new chat();
                newf.Tag = msg.ID;
                newf.Text = "与 " + userinfo.UserName + "(" + userinfo.ID + ") 对话";
                newf.setUserName(userinfo.UserName);
                newf.newTextMsg(msg.MsgContent, title, new System.Drawing.Font("宋体", 10), Color.Blue);
                forms.add(newf);
                //ShowNotifyIcon(1, "", "收到 " + userinfo.UserName + "(" + userinfo.ID + ") 发送给您的新消息。");
                newf.Show();

            }
        }
        #endregion

        #region 接收后信息的回调方法
        private void userSingnOut(string msgID)
        {


            //RemoveUser(msgID);
            foreach (ChatListSubItem subItem in this.chatListBox.Items[1].SubItems)
            {

                if (subItem.NicName == msgID)
                {
                    subItem.Status = ChatListSubItem.UserStatus.OffLine;
                    break;
                }
            }
            //this.chatListBox.Items[1].SubItems[0].Status = "";
        }

        private void SuccessLogin(ClassMsg msg)//服务器告诉用户已经成功登录的处理过程
        {
            //this.Text="成功登陆";
            ClassUserInfo self = (new ClassSerializers().DeSerializeBinary(new System.IO.MemoryStream(msg.MsgContent))) as ClassUserInfo;
            selfInfo.UserName = self.UserName;
            selfInfo.State = 1;

            //ShowNotifyIcon(1,"","LanMsg已经成功登录服务器。");
        }

        private void NewUserLogin(ClassUserInfo userinfo)//添加新登录的用户资料
        {


            if (userinfo.ID == selfInfo.ID)
                return;//如果新登录的联系人是自己则退出
            //this.Text="新用户"+ userinfo.ID;
            ClassUserInfo UserInfo;
            UserInfo = findUser(userinfo.ID);

            if (UserInfo == null)
            {
                this.MyUsers.add(userinfo);
                ChatListSubItem subItem = new ChatListSubItem(userinfo.ID, userinfo.UserName, userinfo.AssemblyVersion, ChatListSubItem.UserStatus.Online);
                this.chatListBox.Items[1].SubItems.AddAccordingToStatus(subItem);

                // 增加一个新用户
            }
            else
            {
                ClassUserInfo user = new ClassUserInfo();
                user.ID = userinfo.ID;
                user.IP = userinfo.IP;
                user.Port = userinfo.Port;
                user.AssemblyVersion = userinfo.AssemblyVersion;
                this.UpdateUser(user);//更新用户状态

                foreach (ChatListItem item in chatListBox.Items)
                {
                    foreach (ChatListSubItem subItem in item.SubItems)
                    {
                        if (subItem.Tag.ToString().ToLower() == user.ID.ToLower())
                        {
                            subItem.Status = ChatListSubItem.UserStatus.Online;
                            break;
                        }

                    }
                }
                //更改新用户的状态
            }
            // MessageBox.Show("1");

        }
        #endregion

        #region 操作当前用户的方法
        public ClassUserInfo findUser(string ID)//在我的用户列表中查找用户ID
        {
            foreach (ClassUserInfo userinfo in this.MyUsers)
                if (userinfo.ID.ToLower() == ID.ToLower())
                    return userinfo;
            return null;
        }

        /// <summary>
        /// 更新用户状态 IP 和端口信息
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUser(ClassUserInfo user)
        {
            //更新用户状态 IP 和端口信息
            foreach (ClassUserInfo userinfo in this.MyUsers)
            {
                if (userinfo.ID.ToLower() == user.ID.ToLower())
                {
                    userinfo.State = user.State;
                    userinfo.IP = user.IP;
                    userinfo.Port = user.Port;
                    break;
                }
            }
        }

        public void RemoveUser(string ID)
        {
            foreach (ClassUserInfo userinfo in this.MyUsers)
            {
                if (userinfo.ID.ToLower() == ID.ToLower())
                {
                    this.MyUsers.Romove(userinfo);
                    break;
                }
            }

        }

        #endregion

        #region 设置一些用户菜单事件


        private void skinButton_State_Click(object sender, EventArgs e)
        {
            this.skinContextMenuStrip_State.Show(skinButton_State, new Point(0, skinButton_State.Height), ToolStripDropDownDirection.Right);
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem Item = (ToolStripMenuItem)sender;
            skinButton_State.Image = Item.Image;
            skinButton_State.Tag = Item.Tag;
            // this.myselfChatListSubItem.Status = (ChatListSubItem.UserStatus)Convert.ToInt32(skinButton_State.Tag);

        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem Item = (ToolStripMenuItem)sender;
            skinButton_State.Image = Item.Image;
            skinButton_State.Tag = Item.Tag;
        }

        private void toolStripMenuItem31_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem Item = (ToolStripMenuItem)sender;
            skinButton_State.Image = Item.Image;
            skinButton_State.Tag = Item.Tag;
        }

        private void toolStripMenuItem32_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem Item = (ToolStripMenuItem)sender;
            skinButton_State.Image = Item.Image;
            skinButton_State.Tag = Item.Tag;
        }

        private void toolStripMenuItem33_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem Item = (ToolStripMenuItem)sender;
            skinButton_State.Image = Item.Image;
            skinButton_State.Tag = Item.Tag;
        }

        #endregion

        #region 双击打开用户列表
        private void chatListBox_DoubleClickSubItem(object sender, ChatListEventArgs e)
        {

            ChatListSubItem item = e.SelectSubItem;
            item.IsTwinkle = false;//不闪烁

            string friendID = item.NicName;


            ActivateOrCreateFormSend(friendID);
            //chat form = new chat();
            //form.Show();
            //form.Focus();

        }
        public ClassForms forms = new ClassForms();
        private void ActivateOrCreateFormSend(string uid)//激活或创建新的消息发送窗体
        {

            foreach (System.Windows.Forms.Form fo in forms)
                if (fo.Tag == uid)
                {
                    fo.Activate(); return;
                }
            chat f = new chat();

            forms.add(f);

            ClassUserInfo userinfo = this.findUser(uid);
            if (userinfo != null)
            {
                f.Text = "与 " + userinfo.UserName + "(" + userinfo.ID + ") 对话";
                f.setUserName(userinfo.UserName);
            }
            f.Tag = uid;
            f.Show();
        }

        #endregion

        #region 鼠标在用户上显示用户名片
        private void chatListBox_MouseEnterHead(object sender, ChatListEventArgs e)
        {

            int top = this.Top + this.chatListBox.Top + (e.MouseOnSubItem.HeadRect.Y - this.chatListBox.chatVScroll.Value);
            int left = this.Left - 279 - 5;
            int ph = Screen.GetWorkingArea(this).Height;

            if (top + 181 > ph)
            {
                top = ph - 181 - 5;
            }

            if (left < 0)
            {
                left = this.Right + 5;
            }

            if (userInformationForm != null)
            {
                this.userInformationForm.Item = e.MouseOnSubItem;
                this.userInformationForm.Location = new Point(left, top);
                this.userInformationForm.Show();
            }
            else
            {
                this.userInformationForm = new UserInformationForm(e.MouseOnSubItem, new Point(left, top));
                this.userInformationForm.Show();
            }
        }

        private void chatListBox_MouseLeave(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            if (this.userInformationForm != null && !this.userInformationForm.Bounds.Contains(Cursor.Position))
            {
                this.userInformationForm.Hide();
            }
        }
        #endregion

        #region 用户关闭窗体事件
        private void main_FormClosed(object sender, FormClosedEventArgs e)
        {
            AppExit();
        }
        private void AppExit()//关闭Sock，退出程序
        {
            ClassMsg msg = new ClassMsg(2, selfInfo.ID, System.Text.Encoding.Unicode.GetBytes("0"));
            sendMsgToServer(msg);
            this.sockUDP1.CloseSock();
            Application.Exit();
        }
        #endregion

        #region 任务栏图标双击事件
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.notifyIcon1.Stop();
            //this.notifyIcon1.co
            this.Show();
            this.Activate();
        }
        #endregion

        #region onload事件
        private void main_Load(object sender, EventArgs e)
        {


            this.sockUDP1 = new SockUDP();//启动socket信息
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(chat));//加载资源
            timerCheckOnlinState = new System.Windows.Forms.Timer();//打开一个计时器
            this.timerCheckOnlinState.Interval = 10000;//间隔为60000毫秒一分钟
            this.timerCheckOnlinState.Tick += new System.EventHandler(this.timerCheckOnlinState_Tick);//绑定监听事件

            #region 初始化端口信息
            System.Random i = new Random();
            int j = i.Next(2000, 6000); //初始化端口
            this.sockUDP1.Listen(j);//UDP开始侦听来自外部的消息.
            selfInfo.Port = j;//端口
            selfInfo.ID = userid;//System.Net.Dns.GetHostName() + j.ToString();//userid
            System.Reflection.AssemblyName assName = System.Reflection.Assembly.GetExecutingAssembly().GetName();//程序集名称
            selfInfo.AssemblyVersion = assName.Version.ToString();//程序集版本
            System.Threading.Thread.Sleep(3000);//延迟3秒


            //ChatListSubItem subItem = new ChatListSubItem("liwl", this.username, this.username, ChatListSubItem.UserStatus.Online);
            //subItem.Tag = userid;
            //subItem.HeadImage = Image.FromFile("head/image.jpg");
            //this.chatListBox.Items[1].SubItems.AddAccordingToStatus(subItem);
            int startindex = 1;
            foreach (ClassDept dept in this.deptinfo)
            {
                ChatListItem item = new ChatListItem();
                item.Text = dept.depmc;
                this.chatListBox.Items.Add(item);
                foreach (ClassResponse user in dept.userlist)
                {
                    ClassUserInfo UserInfo = new ClassUserInfo();
                    UserInfo.ID = user.userid;
                    UserInfo.State = 1;
                    UserInfo.UserName = user.username;
                    this.MyUsers.add(UserInfo);
                    ChatListSubItem useritem;
                    if (UserInfo.ID == userid)
                    {
                        useritem = new ChatListSubItem(user.userid, user.username, user.userid, ChatListSubItem.UserStatus.Online);
                    }
                    else
                    {
                        useritem = new ChatListSubItem(user.userid, user.username, user.userid, ChatListSubItem.UserStatus.OffLine);
                    }
                    useritem.Tag = user.userid;
                    this.chatListBox.Items[startindex].SubItems.AddAccordingToStatus(useritem);
                }
                startindex++;
            }


            #endregion
            Login();//开始登陆
            this.timerCheckOnlinState.Enabled = true;//启动心跳检测
            this.sockUDP1.Server = ((System.Net.IPEndPoint)(resources.GetObject("sockUDP1.Server")));//启动服务器
            this.sockUDP1.DataArrival += new SockUDP.DataArrivalEventHandler(this.sockUDP1_DataArrival);//绑定socket数据到达的方法
            labelName.Text = this.username;

            this.notifyIcon1.Initialize(this, this);
            this.notifyIcon1.ChangeMyStatus();
            this.notifyIcon1.PushFriendMessage(null, null);
            this.chatListBox.Items[1].SubItems[0].IsTwinkle = true;
        }
        #endregion




        #region ITwinkleNotifySupporter接口实现

        public string GetFriendName(string friendID)
        {

            return "haha";
        }




        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(chat));//加载资源

        public Icon GetHeadIcon(string userID)
        {


            return Icon.FromHandle(global::chat.Properties.Resources.normal_group_40.GetHicon());
        }

        public Icon GetIcon()
        {

            return Icon.FromHandle(global::chat.Properties.Resources.normal_group_40.GetHicon());
        }
        public Icon Icon64
        {
            get { return Icon.FromHandle(global::chat.Properties.Resources.normal_group_40.GetHicon()); }
        }

        public Icon NoneIcon64
        {
            get { return Icon.FromHandle(global::chat.Properties.Resources.None64.GetHicon()); }
        }


        IChatForm ITwinkleNotifySupporter.GetChatForm(string friendID)
        {
            return null;
        }

        IChatForm ITwinkleNotifySupporter.GetExistedChatForm(string friendID)
        {
            return null;
        }



        #endregion
    }
}
