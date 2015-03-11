using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuthorityEntity;
using NetworkCommsDotNet;
using AuthorityEntity.IM;


namespace ChatClient
{
    /// <summary>
    /// 用于存放一些静态信息
    /// </summary>
    public static class Common
    {
        static object dictLocker = new object();
        private static string serverIP;
        public static string ServerIP
        {
            get
            {
                if (string.IsNullOrWhiteSpace(serverIP))
                {
                    SetServerIpAndPort();
                }
                return serverIP;
            }
        }
        public static int Port;
        public static void SetServerIpAndPort()
        {
            string[] ipAndPort = new FrameCommonClient.ParameterInfoClient().GetTwoValue("ecda7fbe-cf9d-4d89-b478-d31da5d0a7f8");
            if (ipAndPort != null && ipAndPort.Length == 2)
            {
                serverIP = ipAndPort[0];
                int.TryParse(ipAndPort[1], out Port);
            }
        }

        public static NetworkCommsDotNet.Connection TcpConn { get; set; }


        public static ConnectionInfo ConnInfo { get; set; }

        //当前用户
        public static IMUserInfo CurrentUser { get; set; }

        /// <summary>
        /// 存放好友链接
        /// </summary>
        public static Dictionary<string, Connection> UserConnList = new Dictionary<string, Connection>();

        public static Dictionary<String, IMUserInfo> AllUserDic = new Dictionary<string, IMUserInfo>();

        //尝试使用静态类的字典

        //接收到聊天信息但未打开的信息 key值是发送人id
        public static Dictionary<string, List<MsgEntity>> chatMsgDic = new Dictionary<string, List<MsgEntity>>();

        //添加一个好友链接
        #region 链接
        public static void AddUserConn(string userID, Connection conn)
        {
            lock (dictLocker)
            {
                if (UserConnList.ContainsKey(userID))
                {
                    UserConnList.Remove(userID);
                }
                UserConnList.Add(userID, conn);
            }
        }
        /// <summary>
        /// 是否存在好友链接
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static bool ContainsUserConn(string userID)
        {
            lock (dictLocker)
            {
                return UserConnList.ContainsKey(userID);
            }
        }
        /// <summary>
        /// 获取好友的链接
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static Connection GetUserConn(string userID)
        {
            lock (dictLocker)
            {
                if (UserConnList.ContainsKey(userID))
                {
                    return UserConnList[userID];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 移除好友链接
        /// </summary>
        /// <param name="userID"></param>
        public static void RemoveUserConn(string userID)
        {
            lock (dictLocker)
            {
                if (UserConnList.ContainsKey(userID))
                {
                    UserConnList.Remove(userID);
                }

            }
        }
        #endregion

        #region 所有好友

        public static void AddFriend(string userID, IMUserInfo theUser)
        {
            lock (dictLocker)
            {
                if (AllUserDic.ContainsKey(userID))
                {
                    AllUserDic.Remove(userID);
                }
                AllUserDic.Add(userID, theUser);
            }
        }

        public static IMUserInfo GetFriend(string userID)
        {
            lock (dictLocker)
            {
                if (AllUserDic.ContainsKey(userID))
                {
                    return AllUserDic[userID];
                }
                else
                {
                    return null;
                }
            }
        }


        #endregion

        #region 聊天信息  用户

        public static void AddUserMsg(MsgEntity contract)
        {
            if (!chatMsgDic.ContainsKey(contract.SenderID))
            {
                chatMsgDic.Add(contract.SenderID, new List<MsgEntity>());
            }
            chatMsgDic[contract.SenderID].Add(contract);
        }

        public static void AddNewUserMsg(string userID, List<MsgEntity> listContract)
        {
            if (!chatMsgDic.ContainsKey(userID))
            {
                chatMsgDic.Add(userID, new List<MsgEntity>());
            }

            chatMsgDic[userID].AddRange(listContract);
        }

        public static void ClearUserMsg()
        {
            chatMsgDic.Clear();
        }

        public static int UserMsgCount
        {
            get
            {
                return chatMsgDic.Count;
            }
        }
        public static bool ContainsMsg(string theUserID)
        {
            return chatMsgDic.ContainsKey(theUserID);

        }
        public static MsgEntity GetFirstMsg()
        {
            if (chatMsgDic.Count > 0)
            {
                return chatMsgDic.First().Value[0];
            }
            return null;
        }
        public static List<MsgEntity> GetMsgContractList(string theUserID)
        {
            if (chatMsgDic.ContainsKey(theUserID))
            {
                return chatMsgDic[theUserID];
            }
            else
            {
                return null;
            }
        }

        public static void RemoveMsg(string theUserID)
        {
            chatMsgDic.Remove(theUserID);
        }

        #endregion

        public static void SendMsg(string content, MsgType msgType, MsgSendType sendType, string reciverid, string reciverName, IList<ImageWrapper> imageWrapperList = null)
        {
            try
            {

                MsgEntity chatContract = new MsgEntity();
                chatContract.SenderID = Common.CurrentUser.ID;
                chatContract.SenderName = Common.CurrentUser.DisplayName;
                chatContract.Reciver = reciverid;
                chatContract.ReciverName = reciverName;
                chatContract.MsgContent = content;
                chatContract.SendTime = DateTime.Now;
                chatContract.ImageList = imageWrapperList;
                chatContract.MsgSendType = (int)sendType;
                chatContract.MsgType = (int)msgType;

                //从客户端 Common中获取相应连接
                Connection p2pConnection = Common.GetUserConn(reciverid);
                if (p2pConnection != null)
                {
                    p2pConnection.SendObject("ClientChatMessage", chatContract);
                }
                else
                {
                    if (Common.TcpConn != null)
                    {
                        Common.TcpConn.SendObject("ChatMessage", chatContract);
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }


}
