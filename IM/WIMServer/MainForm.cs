using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using NetworkCommsDotNet;
using IMInterface;
using AuthorityEntity;

namespace WIMServer
{
    public partial class MainForm : Form
    {
        #region 私有成员
        /// <summary>
        /// 同步锁
        /// </summary>
        private object syncLocker = new object();

        //在线用户字典 
        Dictionary<string, ShortGuid> userManager = new Dictionary<string, ShortGuid>();
        static volatile bool windowClosing = false;

        //连接信息类
        private ConnectionInfo connnectionInfo;

        public ConnectionInfo ConnecitonInfo
        {
            get { return connnectionInfo; }
            set { connnectionInfo = value; }
        }

        //连接类
        private Connection connection;

        public Connection Connection
        {
            get { return connection; }
            set { connection = value; }
        }
        #endregion
        #region 构造函数 开始监听 界面更新 连接关闭

        public MainForm()
        {
            InitializeComponent();

            //开始监听
            StartListening();
        }


        //开始监听和设置
        private void StartListening()
        {
            //配置日志记录器
            //ILogger logger = new LiteLogger(LiteLogger.LogMode.ConsoleAndLogFile, "ServerLogFile_" + NetworkComms.NetworkIdentifier + ".txt");
            //NetworkComms.EnableLogging(logger); 
            //不启用日志记录

            NetworkComms.DisableLogging();
            //如果某客户端离线，触发此方法
            NetworkComms.AppendGlobalConnectionCloseHandler(HandleConnectionClosed);


            #region 用户登录和聊天相关

            //客户端发来的聊天信息  转发之 
            NetworkComms.AppendGlobalIncomingPacketHandler<MsgEntity>("ChatMessage", IncomingChatMessage);

            //客户端获取好友列表 
            NetworkComms.AppendGlobalIncomingPacketHandler<string>("GetFriends", IncomingGetFriends);

            //获取所有在线用户列表 

            NetworkComms.AppendGlobalIncomingPacketHandler<string>("GetOnlineUser", IncomingGetOnlineUser);

            //用户登录 
            NetworkComms.AppendGlobalIncomingPacketHandler<UserInfo>("UserLogin", IncomingLoginHandler);
            //更改密码 
            NetworkComms.AppendGlobalIncomingPacketHandler<UserPswEntity>("ChangePsw", IncomingChangePsw);

            //注册新用户
            //NetworkComms.AppendGlobalIncomingPacketHandler<RcUsers>("RegUser", IncomingRegisterUser);

            #endregion

            #region 用户和组相关
            //====================================================================================================
            //获取所有用户组
            NetworkComms.AppendGlobalIncomingPacketHandler<string>("GetGroup", IncomingGetGrooup);

            // 获取所有 (用户ID 以及 用户对应的组ID) 列表
            NetworkComms.AppendGlobalIncomingPacketHandler<string>("GetUserGroupID", IncomingGetUserGroupID);

            // 获取离线消息
            NetworkComms.AppendGlobalIncomingPacketHandler<UserInfo>("GetMyOffLineMsg", IncomingMyOffLineMsg);

            //获取所有在线用户的P2P信息
            NetworkComms.AppendGlobalIncomingPacketHandler<string>("GetP2PInfo", IncomingP2PInfo);

            #endregion

            //从配置文件获取IP和端口

            string strIP = System.Configuration.ConfigurationManager.AppSettings["IPAddress"];
            int port = int.Parse(System.Configuration.ConfigurationManager.AppSettings["Port"]);



            IPEndPoint thePoint = new IPEndPoint(IPAddress.Parse(strIP), port);

            TCPConnection.StartListening(thePoint, false);


            AddLineToLog("初始化完成，正在监听:");

            AddLineToLog("IP地址" + strIP + "--" + "端口" + port.ToString());

            label2.Text = "";


        }

        //处理某可客户端离线情况
        private void HandleConnectionClosed(Connection connection)
        {
            try
            {

                var tempUserID = "";

                lock (syncLocker)
                {
                    //在用户字典中找到网络连接相对应的用户ID
                    foreach (var kv in userManager)
                    {
                        //如果要关闭的网络连接，与某个用户的网络连接相同，则找出此用户
                        if (kv.Value == connection.ConnectionInfo.NetworkIdentifier)
                        {
                            tempUserID = kv.Key;
                            break;
                        }
                    }

                    if (tempUserID != "")
                    {
                        //如果找到的用户ID不为空，则从用户字典中删除此项
                        if (userManager.ContainsKey(tempUserID))
                        {
                            //连接关闭时，从用户管理器中删除该用户
                            userManager.Remove(tempUserID);
                        }
                    }
                }


                //发送通知给其他客户端，告知其某个用户下线 
                if (tempUserID != "")
                {

                    UserStateNotify(tempUserID, false);
                }
                //应该发送一个消息给所有在线的其他用户
            }
            catch (Exception ex)
            {
                LogTools.LogException(ex, "NetworkComms_ConnectionClosed");
            }
        }


        /// <summary>
        /// 显示日志信息到窗口
        /// </summary>
        /// <param name="logLine"></param>
        private void AddLineToLog(string logLine)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    object[] args = { logLine };
                    this.Invoke(new Action<string>(this.AddLineToLog), args);
                }
                else
                {


                    txtLog.Text += "-" + DateTime.Now.ToShortTimeString() + " - " + logLine + "\n";

                }
            }
            catch (Exception ex)
            {
                LogTools.LogException(ex, "AddLineToLog");
            }
        }


        #endregion



        #region  处理方法 用户和聊天相关
        //<1>
        private void IncomingChatMessage(PacketHeader header, Connection connection, MsgEntity chatContract)
        {
            try
            {

                lock (syncLocker)
                {
                    //如果用户在线，转发消息
                    if (userManager.ContainsKey(chatContract.Reciver))
                    {
                        //userManager[chatContract.DestUserID].SendObject("ServerChatMessage", chatContract);
                        //应该只有一个返回的连接，但是由于返回的是列表，遍历一下也可
                        foreach (Connection conn in NetworkComms.GetExistingConnection(userManager[chatContract.Reciver], ConnectionType.TCP))
                        {
                            conn.SendObject("ServerChatMessage", chatContract);

                        }
                    }
                    //如果用户不在线,把数据加入到数据库中
                    //暂时不保存离线图片消息
                    else
                    {
                        //OffLineMessage msg = new OffLineMessage();
                        //msg.UserID = chatContract.UserID;
                        //msg.UserName = chatContract.UserName;
                        //msg.DestUserID = chatContract.DestUserID;
                        //msg.DestUerName = chatContract.DestUserName;
                        //msg.ChatContent = chatContract.Content;
                        //msg.SendTime = chatContract.SendTime;

                        //DoOffLineMessage.Save(msg);

                    }
                }
            }
            catch (Exception ex)
            {
                LogTools.LogException(ex, "IncomingChatMessage");
            }
        }

        //客户端获取某用户的好友列表 
        private void IncomingGetFriends(PacketHeader header, Connection connection, string userID)
        {
            try
            {
                //IList<UserContract> userContractList = DoRcUsers.GetAllMyFriends();

                //UserListContract listContract = new UserListContract(userContractList);

                //lock (syncLocker)
                //{
                //    foreach (UserContract theuser in userContractList)
                //    {
                //        //判断其他好友是否在线
                //        if (userManager.ContainsKey(theuser.UserID))
                //        {
                //            theuser.OnLine = true;
                //        }
                //    }
                //}

                //connection.SendObject("ResGetFriends", listContract);
            }
            catch (Exception ex)
            {
                LogTools.LogException(ex, "IncomingGetFriends");
            }
        }

        //获取所有在线用户
        private void IncomingGetOnlineUser(PacketHeader header, Connection connection, string getUserID)
        {
            try
            {
                //此方法中对于客户端传来的参数getUserID并没有使用。
                //为了简便直接把用户字典中所有用户ID发给客户端
                IList<string> onLineUser;

                lock (syncLocker)
                {

                    onLineUser = new List<string>(userManager.Keys);

                }

                //UserIDContract usersID = new UserIDContract(onLineUser);

                //connection.SendObject("ResOnlineUser", usersID);

            }
            catch (Exception ex)
            {
                LogTools.LogException(ex, "IncomingGetOnlineUser");
            }
        }

        //处理用户登录 
        private void IncomingLoginHandler(PacketHeader header, Connection connection, UserInfo userInfo)
        {

            try
            {
                //从数据库中验证登录信息
                //UserLoginContract resContract = DoRcUsers.Login(userInfo.UserID, userInfo.Password);
                //connection.SendObject("ResUserLogin", resContract);
                //if (resContract.Message == "success")
                //{
                //    lock (syncLocker)
                //    {

                //        //同一账号登陆，先退出已经登陆的客户端
                //        if (userManager.ContainsKey(userInfo.UserID))
                //        {
                //            //userManager.Add(userInfo.UserID, connection);
                //            //通知相应的连接，关闭此连接
                //            foreach (Connection conn in NetworkComms.GetExistingConnection(userManager[userInfo.UserID], ConnectionType.TCP))
                //            {
                //                conn.SendObject("CloseConnection", "msg");

                //            }

                //            userManager.Remove(userInfo.UserID);

                //        }
                //        //注册新的用户
                //        if (!userManager.ContainsKey(userInfo.UserID))
                //        {
                //            userManager.Add(userInfo.UserID, connection.ConnectionInfo.NetworkIdentifier);
                //        }


                //    }

                //    //用户上线后，通知其他用户
                //    UserStateNotify(userInfo.UserID, true);

                //}
            }
            catch (Exception ex)
            {
                LogTools.LogException(ex, "IncomingLoginHandler");
            }
        }

        //修改用户密码 
        private void IncomingChangePsw(PacketHeader header, Connection connection, UserPswEntity contract)
        {
            try
            {
                //在数据库中修改用户密码
                //string resMessage = DoRcUsers.ChangePassword(contract.UserID, contract.OldPsw, contract.NewPsw);

                //connection.SendObject("ResChangePsw", resMessage);
            }
            catch (Exception ex)
            {
                LogTools.LogException(ex, "IncomingChangePsw");
            }
        }


        //注册新用户
        private void IncomingRegisterUser(PacketHeader header, Connection connection, UserInfo contract)
        {
            try
            {

                //声明一个契约类  用于返回数据给客户端
                //ResMessage resMessage = new ResMessage();

                ////判断用户是否存在
                //RcUsers user = DoRcUsers.GetByUserID(contract.UserID);

                //if (user.Id > -1)
                //{
                //    //如果存在，在不进行数据库操作，直接返回信息给客户端
                //    resMessage.Message = "用户ID已经存在";
                //}
                //else
                //{
                //    //如果不存在，则添加用户到数据库中
                //    contract.Declaring = "春暖花开";
                //    contract.Status = -1;
                //    contract.IsMale = true;
                //    contract.UserLevel = 1;
                //    contract.Enabled = false;
                //    contract.RegisterTime = DateTime.Now;
                //    contract.LastLoginTime = DateTime.Now;
                //    contract.GroupID = 115;
                //    //添加用户到数据库中
                //    DoRcUsers.Save(contract);

                //    resMessage.Message = "注册成功";
                //}
                ////返回信息给客户端端
                //connection.SendObject("ResRegUser", resMessage);

            }
            catch (Exception ex)
            {
                LogTools.LogException(ex, "IncomingChangePsw");
            }
        }

        // 某客户端用户的状态改变后，通知其他用户
        private void UserStateNotify(string userID, bool onLine)
        {
            try
            {
                //用户状态契约类
                //UserStateContract userState = new UserStateContract();
                //userState.UserID = userID;
                //userState.OnLine = onLine;


                //IList<ShortGuid> allUserID;

                //lock (syncLocker)
                //{
                //    //获取所有用户字典中的用户ID
                //    allUserID = new List<ShortGuid>(userManager.Values);
                //}

                ////给所有用户发送某用户的在线状态
                //foreach (ShortGuid netID in allUserID)
                //{
                //    List<Connection> result = NetworkComms.GetExistingConnection(netID, ConnectionType.TCP);

                //    if (result.Count > 0 && result[0].ConnectionInfo.NetworkIdentifier == netID)
                //    {
                //        result[0].SendObject("UserStateNotify", userState);
                //    }
                //}
            }
            catch (Exception ex)
            {
                LogTools.LogException(ex, "MainForm.UserStateNotify");
            }
        }

        #endregion

        #region 处理方法  用户组及组中用户
        //获取所有用户组
        private void IncomingGetGrooup(PacketHeader header, Connection connection, string param)
        {

            try
            {
                //IList<UserGroup> lstGroup = DoUserGroup.GetAll();

                //connection.SendObject("ResGroup", lstGroup);
            }
            catch (Exception ex)
            {
                LogTools.LogException(ex, "IncomingGetGrooup");
            }
        }

        //客户端获取在线的所有用户的在线信息
        private void IncomingP2PInfo(PacketHeader header, Connection connection, string param)
        {
            lock (syncLocker)
            {
                //IList<UserIDEndPoint> userInfoList = new List<UserIDEndPoint>();
                ////在用户字典中找到网络连接相对应的用户ID
                //foreach (var kv in userManager)
                //{

                //    foreach (Connection conn in NetworkComms.GetExistingConnection(userManager[kv.Key], ConnectionType.TCP))
                //    {

                //        UserIDEndPoint userIDEndPoint = new UserIDEndPoint();
                //        userIDEndPoint.UserID = kv.Key;
                //        userIDEndPoint.IPAddress = conn.ConnectionInfo.RemoteEndPoint.Address.ToString();
                //        userIDEndPoint.Port = conn.ConnectionInfo.RemoteEndPoint.Port;

                //        userInfoList.Add(userIDEndPoint);

                //    }
                //}

                //connection.SendObject("ResP2pInfo", userInfoList);

            }
        }
        ////<2>获取某用户组中的用户  没有使用

        //private void IncomingGetUsersByGroup(PacketHeader header, Connection connecton, string groupID)
        //{
        //    IList<string> usersID = DoRcUsers.GetUsersIDByGroup(int.Parse(groupID));

        //    UserIDContract contract = new UserIDContract(usersID);

        //    connection.SendObject<UserIDContract>("ResMyGroupUsers", contract);


        //}

        //获取所有用户的用户ID 及 用户对应的组ID 的 列表
        private void IncomingGetUserGroupID(PacketHeader header, Connection connection, string param)
        {
            try
            {
                //IList<UserGroupIDContract> allUserGroupID = DoRcUsers.GetAllUserGroupID();

                //connection.SendObject("ResUserGroupID", allUserGroupID);
            }
            catch (Exception ex)
            {
                LogTools.LogException(ex, "IncomingGetUserGroupID");
            }
        }

        // 获取离线消息

        private void IncomingMyOffLineMsg(PacketHeader header, Connection connection, UserInfo userInfo)
        {
            try
            {
                //IList<OffLineMessage> msgList = DoOffLineMessage.GetAllByUserID(userInfo.UserID);

                //foreach (OffLineMessage message in msgList)
                //{
                //    ChatContract contract = new ChatContract();
                //    contract.UserID = message.UserID;
                //    contract.UserName = message.UserName;
                //    contract.DestUserID = message.DestUserID;
                //    contract.DestUserName = message.DestUerName;
                //    contract.Content = message.ChatContent;
                //    contract.SendTime = message.SendTime;

                //    connection.SendObject("ServerChatMessage", contract);

                //    DoOffLineMessage.Delete(message.Id);
                //}
            }
            catch (Exception ex)
            {
                LogTools.LogException(ex, "IncomingMyOffLineMsg");
            }
        }

        #endregion







        #region 按钮点击事件




        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                lock (syncLocker)
                {
                    LogInfo.LogMessage(DateTime.Now.ToString(), "查看连接数");
                    foreach (Connection conn in NetworkComms.GetExistingConnection())
                    {
                        //If true the remote end of the connection responded to an alive/ping test
                        if (conn.ConnectionAlive())
                        {

                            LogInfo.LogMessage(conn.ConnectionInfo.RemoteEndPoint.ToString(), "查看连接数");
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                LogTools.LogException(ex, "button4_Click");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                lock (syncLocker)
                {
                    LogInfo.LogMessage(DateTime.Now.ToString(), "查看连接信息");
                    foreach (Connection conn in NetworkComms.GetExistingConnection())
                    {

                        LogInfo.LogMessage("本地端点" + conn.ConnectionInfo.LocalEndPoint + "远程端点" + conn.ConnectionInfo.RemoteEndPoint, "查看连接信息");

                    }
                }
            }
            catch (Exception ex)
            {
                LogTools.LogException(ex, "button5_Click");
            }
        }



        private void button8_Click(object sender, EventArgs e)
        {
            try
            {

                LogInfo.LogMessage(DateTime.Now.ToString(), "查看在线用户");
                lock (syncLocker)
                {
                    foreach (KeyValuePair<string, ShortGuid> userInfo in userManager)
                    {

                        LogInfo.LogMessage(userInfo.Key, "查看在线用户");
                    }
                }
            }
            catch (Exception ex)
            {
                LogTools.LogException(ex, "button8_Click");
            }
        }



        private bool toExit = false;
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!this.toExit)
                {

                    if ((e.CloseReason == CloseReason.ApplicationExitCall) || (e.CloseReason == CloseReason.WindowsShutDown))
                    {
                        NetworkComms.Shutdown();
                        this.toExit = true;

                        this.Dispose();
                        this.Close();

                    }

                    else
                    {
                        this.Visible = false;
                        e.Cancel = true;
                    }

                }
            }
            catch (Exception ex)
            {
                LogTools.LogException(ex, "MainForm_FormClosing");
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GotoExit();
            }
            catch (Exception ex)
            {
                LogTools.LogException(ex, "退出ToolStripMenuItem_Click");
            }
        }

        private void GotoExit()
        {
            try
            {
                if (MessageBox.Show("您确认要退出吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.toExit = true;


                    this.Dispose();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                LogTools.LogException(ex, "GotoExit");
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.Show();
                if (this.WindowState == FormWindowState.Minimized)
                    this.WindowState = FormWindowState.Maximized;
                this.Activate();
            }
            catch (Exception ex)
            {
                LogTools.LogException(ex, "notifyIcon1_MouseDoubleClick");
            }
        }

        private void 显示系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Show();
                if (this.WindowState == FormWindowState.Minimized)
                    this.WindowState = FormWindowState.Maximized;
                this.Activate();
            }
            catch (Exception ex)
            {
                LogTools.LogException(ex, "显示系统ToolStripMenuItem_Click");
            }
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GotoExit();
            }
            catch (Exception ex)
            {
                LogTools.LogException(ex, "退出系统ToolStripMenuItem_Click");
            }
        }



        #endregion



    }

}
