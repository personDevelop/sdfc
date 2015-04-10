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

using AuthorityClient;
using System.Diagnostics;
using System.Net.NetworkInformation;
using AuthorityEntity;
using AuthorityEntity.IM;

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
        /// <summary>
        /// 连接信息类
        /// </summary>
        public ConnectionInfo ConnecitonInfo { get; set; }


        /// <summary>
        /// 连接类
        /// </summary>
        public Connection Connection
        { get; set; }
        #endregion
        #region 构造函数

        public MainForm()
        {
            InitializeComponent();
            //获取服务器IM服务器ip和端口号
            string[] ipAndPort = new FrameCommonClient.ParameterInfoClient().GetTwoValue("ecda7fbe-cf9d-4d89-b478-d31da5d0a7f8");
            if (ipAndPort != null && ipAndPort.Length == 2)
            {
                txtIP.Text = ipAndPort[0];
                txtPort.Text = ipAndPort[1];
            }
            txtLog.Text += Environment.NewLine;
        }

        #endregion

        #region  处理方法 用户和聊天相关
        /// <summary>
        /// 当有消息传递过来时调用
        /// </summary>
        /// <param name="header"></param>
        /// <param name="Connection"></param>
        /// <param name="chatContract"></param>
        private void IncomingChatMessage(PacketHeader header, Connection Connection, MsgEntity chatContract)
        {
            try
            {

                lock (syncLocker)
                {
                    bool isAddOffline = false;
                    if (chatContract.IsWebMsg)
                    {
                        foreach (Connection conn in NetworkComms.GetExistingConnection(userManager["SB_WEB_INFO"], ConnectionType.TCP))
                        {
                            conn.SendObject("ServerChatMessage", chatContract);
                        }
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(chatContract.Reciver))
                    {
                        //转发给所有的用户
                        List<IMUserInfo> myfriends = GetMyFriends(chatContract.SenderID);
                        foreach (var item in myfriends)
                        {
                            //如果用户在线，转发消息
                            if (userManager.ContainsKey(item.ID))
                            {
                                //userManager[chatContract.DestUserID].SendObject("ServerChatMessage", chatContract);
                                //应该只有一个返回的连接，但是由于返回的是列表，遍历一下也可
                                foreach (Connection conn in NetworkComms.GetExistingConnection(userManager[item.ID], ConnectionType.TCP))
                                {
                                    conn.SendObject("ServerChatMessage", chatContract);
                                }
                            }
                            //如果用户不在线,把数据加入到数据库中
                            //暂时不保存离线图片消息
                            else
                            {
                                if (!isAddOffline)
                                {
                                    isAddOffline = true;

                                    new MsgSendOrderClient().AddOfflineMsg(chatContract);
                                }

                            }
                        }
                    }
                    else
                    {
                        List<string> recivers = new List<string>();
                        if (chatContract.Reciver.Contains(";"))
                        {
                            recivers.AddRange(chatContract.Reciver.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries));
                        }
                        else
                        {
                            recivers.Add(chatContract.Reciver);
                        }

                        foreach (var item in recivers)
                        {
                            //如果用户在线，转发消息
                            if (userManager.ContainsKey(item))
                            {
                                //userManager[chatContract.DestUserID].SendObject("ServerChatMessage", chatContract);
                                //应该只有一个返回的连接，但是由于返回的是列表，遍历一下也可
                                foreach (Connection conn in NetworkComms.GetExistingConnection(userManager[item], ConnectionType.TCP))
                                {
                                    conn.SendObject("ServerChatMessage", chatContract);
                                }
                            }
                            //如果用户不在线,把数据加入到数据库中
                            //暂时不保存离线图片消息
                            else
                            {
                                if (!isAddOffline)
                                {
                                    isAddOffline = true;

                                    new MsgSendOrderClient().AddOfflineMsg(chatContract);
                                }
                            }
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                LogTools.LogException(ex, "IncomingChatMessage");
            }
        }

        /// <summary>
        /// 客户端获取某用户的好友列表 
        /// </summary>
        /// <param name="header"></param>
        /// <param name="Connection"></param>
        /// <param name="userID"></param>
        private void IncomingGetFriends(PacketHeader header, Connection Connection, string userID)
        {
            try
            {
                List<IMUserInfo> myfriends = GetMyFriends(userID);
                UserListContract ulc = new UserListContract(myfriends);
                Connection.SendObject("ResGetFriends", ulc);
            }
            catch (Exception ex)
            {
                LogTools.LogException(ex, "IncomingGetFriends");
            }
        }

        private List<IMUserInfo> GetMyFriends(string userID)
        {
            List<IMUserInfo> myfriends = new List<IMUserInfo>();


            lock (syncLocker)
            {
                List<IMUserInfo> list = null;
                string cachKey = "UserInfoDataAccess_GetIMUserList";

                object o = Sharp.Common.CacheContainer.GetCache(cachKey);
                if (o == null)
                {
                    list = new UserInfoClient().GetIMUserList().List();
                    Sharp.Common.CacheContainer.AddCache(cachKey, list, 60 * 60);//缓存1小时
                }
                else
                {
                    list = o as List<IMUserInfo>;
                }
                foreach (IMUserInfo theuser in list)
                {
                    if (theuser.ID == userID)
                    {
                        continue;
                    }
                    //判断其他好友是否在线 
                    IMUserInfo myfriend = theuser.Clone();
                    myfriend.IsOnline = userManager.ContainsKey(theuser.ID);
                    myfriends.Add(myfriend);
                }
            }
            return myfriends;
        }

        //获取所有在线用户
        private void IncomingGetOnlineUser(PacketHeader header, Connection Connection, string getUserID)
        {
            try
            {
                //此方法中对于客户端传来的参数getUserID并没有使用,内部通讯录，好友都是共同的。
                //为了简便直接把用户字典中所有用户ID发给客户端
                IList<string> onLineUser;

                lock (syncLocker)
                {

                    onLineUser = new List<string>(userManager.Keys);

                }

                UserIDListContract usersID = new UserIDListContract(onLineUser);
                Connection.SendObject("ResOnlineUser", usersID);
            }
            catch (Exception ex)
            {
                LogTools.LogException(ex, "IncomingGetOnlineUser");
            }
        }

        //处理用户登录 
        private void IncomingLoginHandler(PacketHeader header, Connection Connection, IMUserInfo loginInfo)
        {

            try
            {
                //从数据库中验证登录信息
                string ip = Connection.ConnectionInfo.LocalEndPoint.ToString();
                string port = Connection.ConnectionInfo.LocalEndPoint.Port.ToString();
                string error = string.Empty;
                View_IMUser userinfo = null;
                if (loginInfo.IsWebMsg)
                {
                    userinfo = new View_IMUser();
                    userinfo.ID = loginInfo.Code;
                    userinfo.Code = loginInfo.Code;
                    userinfo.Name = "网页用户";
                }
                else
                {
                    userinfo = new AuthorityClient.LoginClient().Login(loginInfo.Code, loginInfo.Pwd, ip, port, out error);
                }

                if (userinfo == null)
                {
                    UserLoginContract resContract = new UserLoginContract(error, null);
                    Connection.SendObject("ResUserLogin", resContract);
                }
                else
                {
                    UserLoginContract resContract = new UserLoginContract(error, userinfo.Clone());
                    Connection.SendObject("ResUserLogin", resContract);
                    if (string.IsNullOrWhiteSpace(error))
                    {
                        lock (syncLocker)
                        {

                            //同一账号登陆，先退出已经登陆的客户端
                            if (userManager.ContainsKey(userinfo.ID))
                            {

                                //通知相应的连接，关闭此连接
                                foreach (Connection conn in NetworkComms.GetExistingConnection(userManager[userinfo.ID], ConnectionType.TCP))
                                {
                                    conn.SendObject("CloseConnection", "msg");
                                }

                                userManager.Remove(userinfo.ID);
                            }
                            //注册新的用户
                            if (!userManager.ContainsKey(userinfo.ID))
                            {
                                userManager.Add(userinfo.ID, Connection.ConnectionInfo.NetworkIdentifier);
                            }
                        }

                        //用户上线后，通知其他用户
                        UserStateNotify(userinfo.ID, OnlineState.Online);

                    }
                }
            }
            catch (Exception ex)
            {
                LogTools.LogException(ex, "IncomingLoginHandler");
            }
        }

        //修改用户密码 
        private void IncomingChangePsw(PacketHeader header, Connection Connection, UserPswEntity contract)
        {
            try
            {
                //在数据库中修改用户密码
                int resMessage = new UserInfoClient().ResetPwd(contract.UserID, contract.NewPsw, contract.OldPsw);
                string msg = "密码修改成功";
                if (resMessage == -2)
                {
                    msg = "旧密码不正确";
                }
                else if (resMessage == -1)
                {
                    msg = "修改失败";
                }
                Connection.SendObject("ResChangePsw", msg);
            }
            catch (Exception ex)
            {
                LogTools.LogException(ex, "IncomingChangePsw");
            }
        }
        // 某客户端用户的状态改变后，通知其他用户
        private void UserStateNotify(string userID, OnlineState ustate)
        {
            try
            {
                //用户状态契约类
                UserStateContract userState = new UserStateContract();
                userState.UserID = userID;
                userState.OnLine = ustate;
                IList<ShortGuid> allUserID;

                lock (syncLocker)
                {
                    //获取所有用户字典中的用户链接标识
                    allUserID = new List<ShortGuid>(userManager.Values);
                }

                //给所有用户发送某用户的在线状态
                foreach (ShortGuid netID in allUserID)
                {
                    List<Connection> result = NetworkComms.GetExistingConnection(netID, ConnectionType.TCP);

                    if (result.Count > 0 && result[0].ConnectionInfo.NetworkIdentifier == netID)
                    {
                        result[0].SendObject("UserStateNotify", userState);
                    }
                }
            }
            catch (Exception ex)
            {
                LogTools.LogException(ex, "MainForm.UserStateNotify");
            }
        }

        #endregion

        #region 处理方法  用户组及组中用户,获取用户时已经获取组，不需要再获取一遍
        //获取所有用户组
        private void IncomingGetGrooup(PacketHeader header, Connection Connection, string param)
        {

            try
            {
                //IList<UserGroup> lstGroup = DoUserGroup.GetAll();

                //Connection.SendObject("ResGroup", lstGroup);
            }
            catch (Exception ex)
            {
                LogTools.LogException(ex, "IncomingGetGrooup");
            }
        }

        //客户端获取在线的所有用户的p2p在线信息
        private void IncomingP2PInfo(PacketHeader header, Connection Connection, string param)
        {
            lock (syncLocker)
            {
                IList<UserIDEndPoint> userInfoList = new List<UserIDEndPoint>();
                //在用户字典中找到网络连接相对应的用户ID
                foreach (var kv in userManager)
                {

                    foreach (Connection conn in NetworkComms.GetExistingConnection(userManager[kv.Key], ConnectionType.TCP))
                    {

                        UserIDEndPoint userIDEndPoint = new UserIDEndPoint();
                        userIDEndPoint.UserID = kv.Key;
                        userIDEndPoint.IPAddress = conn.ConnectionInfo.RemoteEndPoint.Address.ToString();
                        userIDEndPoint.Port = conn.ConnectionInfo.RemoteEndPoint.Port;
                        userInfoList.Add(userIDEndPoint);

                    }
                }

                Connection.SendObject("ResP2pInfo", userInfoList);

            }
        }



        // 获取离线消息,稍后实现

        private void IncomingMyOffLineMsg(PacketHeader header, Connection Connection, UserIDContract userInfo)
        {
            try
            {
                MsgSendOrderClient bll = new MsgSendOrderClient();
                IList<MsgEntity> msgList = bll.GetAllOffLineMsgByUserID(userInfo.UsersID);

                foreach (MsgEntity message in msgList)
                {

                    Connection.SendObject("ServerChatMessage", message);

                    bll.DeleteOffLineMsg(message.ID);
                }
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
                        //If true the remote end of the Connection responded to an alive/ping test
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

        private void button1_Click(object sender, EventArgs e)
        {
            //开始监听
            StartListening();
        }

        #region  开始监听 界面更新 连接关闭
        //开始监听和设置
        private void StartListening()
        {
            string strIP = txtIP.Text.Trim();
            string strport = txtPort.Text.Trim();
            if (string.IsNullOrWhiteSpace(strIP))
            {
                MessageBox.Show("服务器地址不能为空");
                return;
            }
            if (string.IsNullOrWhiteSpace(strport))
            {
                MessageBox.Show("端口号不能为空");
                return;
            }
            int port = 0;
            if (int.TryParse(strport, out port))
            {
                if (port < 2000)
                {
                    MessageBox.Show("端口号取值范围为2000到65535");
                    return;
                }
                if (port > 65535)
                {
                    MessageBox.Show("端口号取值范围为2000到65535");
                    return;
                }
                if (IsUse(port))
                {
                    MessageBox.Show("当前端口号已被占用");
                    return;
                }
            }
            else
            {
                MessageBox.Show("端口号必须是整数");
                return;
            }
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
            NetworkComms.AppendGlobalIncomingPacketHandler<IMUserInfo>("UserLogin", IncomingLoginHandler);
            //更改密码 
            NetworkComms.AppendGlobalIncomingPacketHandler<UserPswEntity>("ChangePsw", IncomingChangePsw);

            //注册新用户
            //NetworkComms.AppendGlobalIncomingPacketHandler<RcUsers>("RegUser", IncomingRegisterUser);

            #endregion

            #region 用户和组相关
            //====================================================================================================
            ////获取所有用户组
            //NetworkComms.AppendGlobalIncomingPacketHandler<string>("GetGroup", IncomingGetGrooup);



            // 获取离线消息
            NetworkComms.AppendGlobalIncomingPacketHandler<UserIDContract>("GetMyOffLineMsg", IncomingMyOffLineMsg);

            //获取所有在线用户的P2P信息
            NetworkComms.AppendGlobalIncomingPacketHandler<string>("GetP2PInfo", IncomingP2PInfo);

            #endregion
            IPEndPoint thePoint = new IPEndPoint(IPAddress.Parse(strIP), port);
            TCPConnection.StartListening(thePoint, false);
            AddLineToLog("初始化完成，正在监听:");
            AddLineToLog("IP地址" + strIP + "--" + "端口" + port.ToString());
        }
        //处理某可客户端离线情况
        private void HandleConnectionClosed(Connection Connection)
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
                        if (kv.Value == Connection.ConnectionInfo.NetworkIdentifier)
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

                    UserStateNotify(tempUserID, OnlineState.Offline);
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
                    txtLog.Text += "-" + DateTime.Now.ToShortTimeString() + " - " + logLine + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                LogTools.LogException(ex, "AddLineToLog");
            }
        }



        #endregion

        /// <summary>
        /// true 表示被占用
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public bool IsUse(int port)
        {
            bool flag = false;

            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipEndPoints = ipProperties.GetActiveTcpListeners();//获取所有的监听连接 
            foreach (IPEndPoint endPoint in ipEndPoints)
            {
                if (endPoint.Port == port)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }



    }

}
