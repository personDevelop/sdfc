using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkCommsDotNet;
using AuthorityEntity.IM;

namespace ChatClient
{
    public class AutoLogin
    {
        public static event Action OnLoginSucced;
        public static string AutoLog(string userNo, string Pwd)
        {
            string error = string.Empty;
            ConnectionInfo connInfo;
            Connection newTcpConnection;
            try
            {
                connInfo = new ConnectionInfo(Common.ServerIP, Common.Port);
                newTcpConnection = TCPConnection.GetConnection(connInfo);
                Common.TcpConn = newTcpConnection;

                TCPConnection.StartListening(connInfo.LocalEndPoint);
                 

                //在契约类中保存用户名和密码
                IMUserInfo userinfo = new IMUserInfo();
                userinfo.Code = userNo;
                userinfo.Pwd = Pwd;

                //发送契约类给服务器端，并获取返回的结果
                UserLoginContract loginContract = newTcpConnection.
                    SendReceiveObject<UserLoginContract>("UserLogin", "ResUserLogin", 80000, userinfo);
                //如果登陆成功
                if (string.IsNullOrWhiteSpace(loginContract.Message))
                {

                    //为简便，在此处使用了静态类保存用户相关信息  
                    Common.CurrentUser = loginContract.UserContract;
                    Common.ConnInfo = connInfo;
                    if (OnLoginSucced != null)
                    {
                        OnLoginSucced();
                    } 
                }
                else
                {
                    error = loginContract.Message;
                } 
            }
            catch (Exception ex)
            {


                error = ex.Message;

            }

            return error;
        }
    }
}
