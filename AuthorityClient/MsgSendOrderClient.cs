using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuthorityService;
using System.Data;

namespace AuthorityClient
{
    public class MsgSendOrderClient : FrameBaseClient.BaseClient
    {
        public MsgSendOrderClient()
        {

            if (IsLocation)
            {
                Client = new MsgSendOrderService();
            }
            else
            {
                Client = new MsgSendOrderSer.MsgSendOrderServiceClient();
            }


        }
        public DataTable GetAllMsg()
        {
            if (IsLocation)
            {
                return (Client as MsgSendOrderService).GetAllMsg();
            }
            else
            {
                return (Client as MsgSendOrderSer.MsgSendOrderServiceClient).GetAllMsg();
            }

        }

        public DataTable GetAllMsgByStatus(string status)
        {
            if (IsLocation)
            {
                return (Client as MsgSendOrderService).GetAllMsgByStatus(status);
            }
            else
            {
                return (Client as MsgSendOrderSer.MsgSendOrderServiceClient).GetAllMsgByStatus(status);
            }

        }
        public DataTable GetMySenderMsg(string senderID)
        {
            if (IsLocation)
            {
                return (Client as MsgSendOrderService).GetMySenderMsg(senderID);
            }
            else
            {
                return (Client as MsgSendOrderSer.MsgSendOrderServiceClient).GetMySenderMsg(senderID);
            }
        }
        public DataTable GetMyReciveMsg(string reciverID)
        {
            if (IsLocation)
            {
                return (Client as MsgSendOrderService).GetMyReciveMsg(reciverID);
            }
            else
            {
                return (Client as MsgSendOrderSer.MsgSendOrderServiceClient).GetMyReciveMsg(reciverID);
            }
        }

        public int AddMsg(DataTable dt)
        {
            if (IsLocation)
            {
                return (Client as MsgSendOrderService).AddMsg(dt);
            }
            else
            {
                return (Client as MsgSendOrderSer.MsgSendOrderServiceClient).AddMsg(dt);
            }
        }

        public int AddOneMsgToMutilsPerson(string msg, string senderID, string senderName, string senderTel,
            string[] reciverIDS, string[] reciverNames, string[] reciverTelPhone)
        {
            if (IsLocation)
            {
                return (Client as MsgSendOrderService).AddOneMsgToMutilsPerson(msg, senderID, senderName, senderTel,
              reciverIDS, reciverNames, reciverTelPhone);
            }
            else
            {
                return (Client as MsgSendOrderSer.MsgSendOrderServiceClient).AddOneMsgToMutilsPerson(msg, senderID, senderName, senderTel,
              reciverIDS, reciverNames, reciverTelPhone);
            }
        }

        public int UpdateStatus(string[] msgID, string Status)
        {

            if (IsLocation)
            {
                return (Client as MsgSendOrderService).UpdateStatus(msgID, Status);
            }
            else
            {
                return (Client as MsgSendOrderSer.MsgSendOrderServiceClient).UpdateStatus(msgID, Status);
            }

        }
    }
}
