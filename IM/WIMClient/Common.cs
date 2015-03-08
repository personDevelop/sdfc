//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections.Generic;
using System.Text;
 
using NetworkCommsDotNet;

 

namespace WIMClient
{
    /// <summary>
    /// 用于存放一些静态信息
    /// </summary>
    public static class Common
    {
       
        //
        public static Dictionary<string, Connection> UserConnList = new Dictionary<string, Connection>();

        public static void AddUserConn(string userID, Connection conn)
        {
            lock (dictLocker)
            {
                if (UserConnList.ContainsKey(userID))
                {
                    UserConnList.Remove(userID);
                }
                UserConnList.Add(userID,conn);
            }
        }

        public static bool ContainsUserConn(string userID)
        {
            lock (dictLocker)
            {
                if (UserConnList.ContainsKey(userID))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static Connection  GetUserConn(string userID)
        {
            lock(dictLocker)
            {
                if(UserConnList.ContainsKey(userID))
                {
                    return UserConnList[userID];
                }
                else
                {
                    return null;
                }
            }
        }

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

        internal static object dictLocker = new object();
        //当前用户ID
        public static String UserID { get; set; } 
        public static string UserName { get; set; }

        public static string PassWord { get; set; }

        //当前用户
        public static User ClientUser { get; set; }

        //当前单位
        public static string DepName { get; set; }

        #region 所有好友

        public static  Dictionary<String, User> AllUserDic = new Dictionary<string, User>();

        public static void AddDicUser(string userID, User theUser)
        {
            lock (dictLocker)
            {
                if(AllUserDic.ContainsKey(userID))
                {
                    AllUserDic.Remove(userID);
                }
                AllUserDic.Add(userID, theUser);
            }
        }

        public static User GetDicUser(string userID)
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

        //尝试使用静态类的字典
        public static List<string> chatUserId = new List<string>();   


        
        //接收到聊天信息但未打开信息的发送人
        public static Dictionary<string, List<MsgEntity>> chatMsgDic = new Dictionary<string, List<MsgEntity>>();  //聊天的信息 //聊天的信息



        public static bool ContainsUserID(string theUserID)
        {
            return chatUserId.Contains(theUserID);
        }

        public static void AddUserID(string theUserID)
        {
            chatUserId.Add(theUserID);
        }

        public static int UserIDCount()
        {
            return chatUserId.Count;
        }

        public static void ClearUserID()
        {
            chatUserId.Clear();
        }

        public static string FirstUserID()
        {
            if (chatUserId.Count > 0)
            {
                return chatUserId[0];
            }
            else
            {
                return "";
            }
        }

        public static void RemoveID(string theUserID)
        {
            chatUserId.Remove(theUserID);
        }

        public static void AddUserMsg(MsgEntity contract)
        {
             chatMsgDic[contract.SenderID].Add(contract);
        }

        public static void AddNewUserMsg(string userID, List<MsgEntity> listContract)
        {
            chatMsgDic.Add(userID, listContract);
        }

        public static void ClearUserMsg()
        {
            chatMsgDic.Clear();
        }

        public static int UserMsgCount()
        {
            return chatMsgDic.Count;
        }

        public static bool ContainsMsg(string theUserID)
        {
            return chatMsgDic.ContainsKey(theUserID);
        }

        public static List<MsgEntity> MsgContractList(string theUserID)
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


        #region 只显示在线
        static bool showOnlineOnly = false;
        public static bool ShowOnlineOnly
        {
            get { return showOnlineOnly; }
            set
            {
                if (showOnlineOnly != value)
                {
                    showOnlineOnly = value;

                    if (ShowOnlineOnlyChanged != null)
                        ShowOnlineOnlyChanged(showOnlineOnly);
                }
            }
        }
        public delegate void ShowOnlineOnlyChangedHandler(bool showOnlineOnly);
        public static event ShowOnlineOnlyChangedHandler ShowOnlineOnlyChanged;
        #endregion

        //拖动换组
        public delegate void DragDropUserHandler(User user, Group newGroup);
        public static event DragDropUserHandler DragDropUser;
        public static void ToDragDropUser(User User, Group NewGroup)
        {
            if (DragDropUser != null)
                DragDropUser(User, NewGroup);
        }

        static AllUsers allUsers = new AllUsers();
        public static AllUsers AllUsers
        {
            get { return allUsers; }
            set { allUsers = value; }
        }

        public static FormManager<ChatForm> ChatFormManager = new FormManager<ChatForm>();

        public static NetworkCommsDotNet.Connection TcpConn = null;

        public static void SetConnection(NetworkCommsDotNet.Connection connecton)
        {
            TcpConn = connecton;
        }


        public static NetworkCommsDotNet.Connection GetConn()
        {
            return TcpConn;
        }

        public static NetworkCommsDotNet.ConnectionInfo ConnInfo = null;
        public static void SetConnInfo(NetworkCommsDotNet.ConnectionInfo connInfo)
        {
            ConnInfo = connInfo;
        }

        public static NetworkCommsDotNet.ConnectionInfo GetConnInfo()
        {
            return ConnInfo;
        }

    }

    public static class IPHelper
    {
        public static string GetIPAddress()
        {

            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();

            System.Net.NetworkInformation.PingOptions options = new System.Net.NetworkInformation.PingOptions();

            options.DontFragment = true;

            byte[] buffer = new byte[0];

            int timeout = 300; // Timeout 时间，单位：毫秒

            string strIP = System.Configuration.ConfigurationManager.AppSettings["IPAddress"];
            string strWebIP = System.Configuration.ConfigurationManager.AppSettings["WebIPAddress"];

            System.Net.NetworkInformation.PingReply reply = p.Send(strIP, timeout, buffer, options);

            if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)

                return strIP;

            else

                return strWebIP;

        }

    }

 

    public class AllUsers : List<User>
    {
        public User this[string UserID]
        {
            get
            {
                User user = this.Find(u => u != null && u.UserID.Trim().ToLower() == UserID.Trim().ToLower());
                return user;
            }
        }
    }

    public static class Encry
    {
        public static string encode(string str)
        {
            string htext = ""; 

            for ( int i = 0; i < str.Length; i++)
            {
                htext = htext + (char) (str[i] + 10 - 1 * 2);
            }
            return htext;
        }

        public  static string decode(string str)
        {
            string dtext = "";

            for (int i = 0; i < str.Length; i++)
            {
                dtext = dtext + (char)(str[i] - 10 + 1 * 2);
            }
            return dtext;
        }
    }


  

}
