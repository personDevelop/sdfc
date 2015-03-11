using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuthorityEntity.IM;
using NetworkCommsDotNet;

namespace SignalR
{
    public class SendClientMes
    {


        public static Connection newTcpConnection;
        public static void SendMess(string userid,string mes,string toid)
        {

            try
            {
                ConnectionInfo connInfo;
                 
                string[] ipAndPort = new FrameCommonClient.ParameterInfoClient().GetTwoValue("ecda7fbe-cf9d-4d89-b478-d31da5d0a7f8");
                int port = int.Parse(ipAndPort[1]);
                connInfo = new ConnectionInfo(ipAndPort[0], port);
                if (newTcpConnection == null)
                {
                    newTcpConnection = TCPConnection.GetConnection(connInfo);


                    TCPConnection.StartListening(connInfo.LocalEndPoint);
                }
                MsgEntity chatContract = new MsgEntity();
                chatContract.SenderID = userid;
                chatContract.Reciver = toid;

                chatContract.MsgContent = mes;
                chatContract.SendTime = DateTime.Now;
                //chatContract.ImageList = imageWrapperList;
                newTcpConnection.SendObject("ChatMessage", chatContract);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}