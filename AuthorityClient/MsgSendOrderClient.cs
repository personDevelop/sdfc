using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuthorityService;
using System.Data;
using FrameBaseClient;
using IAuthorityService;

namespace AuthorityClient
{
    public class MsgSendOrderClient : FrameBaseClient.BaseClient
    {
        IMsgSendOrderService currentClient;
        IMsgSendOrderService CurrentClient
        {
            get
            {
                if (currentClient == null)
                {
                    if (IsLocation)
                    {
                        currentClient = new MsgSendOrderService();
                    }
                    else
                    {
                        currentClient = WcfInvokeContext.CreateWCFService<IMsgSendOrderService>("MsgSendOrderService");
                    }
                }
                return currentClient;
            }
        }
       
       
        public DataTable GetAllMsg()
        {
            
                 return CurrentClient.GetAllMsg();
            

        }

        public DataTable GetAllMsgByStatus(string status)
        {
            
                 return CurrentClient.GetAllMsgByStatus(status);
            

        }
        public DataTable GetMySenderMsg(string senderID)
        {
            
                 return CurrentClient.GetMySenderMsg(senderID);
            
        }
        public DataTable GetMyReciveMsg(string reciverID)
        {
          
                 return CurrentClient.GetMyReciveMsg(reciverID);
            
        }

        public int AddMsg(DataTable dt)
        {
           
                 return CurrentClient.AddMsg(dt);
            
        }

        public int AddOneMsgToMutilsPerson(string msg, string senderID, string senderName, string senderTel,
            string[] reciverIDS, string[] reciverNames, string[] reciverTelPhone)
        {
            
                 return CurrentClient.AddOneMsgToMutilsPerson(msg, senderID, senderName, senderTel,
              reciverIDS, reciverNames, reciverTelPhone);
            
        }

        public int UpdateStatus(string[] msgID, string Status)
        {

           
                 return CurrentClient.UpdateStatus(msgID, Status);
            

        }
    }
}
