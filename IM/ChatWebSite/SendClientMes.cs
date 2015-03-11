using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuthorityEntity.IM;
using NetworkCommsDotNet;
using System.Net;

namespace SignalR
{
    public class SendClientMes
    {


        public static Connection newTcpConnection;

        private static void IncomingChatMessage(PacketHeader header, Connection Connection, MsgEntity chatContract)
        {
            codingChatHub code = new codingChatHub();
            code.sendMessageEx(chatContract.Reciver, chatContract.MsgContent);
        }
        public static void SendMess(string userid, string mes, string toid)
        {

            try
            {
                ConnectionInfo connInfo;

                string[] ipAndPort = new FrameCommonClient.ParameterInfoClient().GetTwoValue("ecda7fbe-cf9d-4d89-b478-d31da5d0a7f8");
                int port = int.Parse(ipAndPort[1]);
                connInfo = new ConnectionInfo(ipAndPort[0], port);
                if (newTcpConnection == null)
                {
                    //InitConnection();
                    newTcpConnection = TCPConnection.GetConnection(connInfo);
                    TCPConnection.StartListening(connInfo.LocalEndPoint);
                    AuthorityEntity.IM.IMUserInfo userinfo = new IMUserInfo();
                    userinfo.ID = "SB_WEB_INFO";
                    userinfo.Code = "SB_WEB_INFO";
                    userinfo.IsWebMsg = true;
                    UserLoginContract loginContract = newTcpConnection.
                        SendReceiveObject<UserLoginContract>("UserLogin", "ResUserLogin", 80000, userinfo);
                    NetworkComms.AppendGlobalIncomingPacketHandler<MsgEntity>("ServerChatMessage", IncomingChatMessage);
                }
                MsgEntity chatContract = new MsgEntity();
                chatContract.SenderID = userid;
                chatContract.Reciver = toid;

                chatContract.MsgContent = mes;
                chatContract.SendTime = DateTime.Now;
                chatContract.MsgSendType = 4;
                //chatContract.IsWebMsg = true;
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