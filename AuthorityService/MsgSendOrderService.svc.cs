using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using System.Data;
using AuthorityDataAccess;

namespace AuthorityService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“MsgSendOrderService”。
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class MsgSendOrderService : IMsgSendOrderService
    {
        MsgSendOrderDataAccess da = new MsgSendOrderDataAccess();
        public DataTable GetAllMsg()
        {
            return da.GetAllMsg();
        }

        public DataTable GetAllMsgByStatus(string status)
        {
            return da.GetAllMsgByStatus(status);
        }
        public DataTable GetMySenderMsg(string senderID)
        {
            return da.GetMySenderMsg(senderID);
        }
        public DataTable GetMyReciveMsg(string reciverID)
        {
            return da.GetMyReciveMsg(reciverID);
        }

        public int AddMsg(DataTable dt)
        {
            return da.AddMsg(dt);
        }

        public int AddOneMsgToMutilsPerson(string msg, string senderID, string senderName, string senderTel,
            string[] reciverIDS, string[] reciverNames, string[] reciverTelPhone)
        {
            return da.AddOneMsgToMutilsPerson(msg, senderID, senderName, senderTel,
              reciverIDS, reciverNames, reciverTelPhone);
        }

        public int UpdateStatus(string[] msgID, string Status)
        {

            return da.UpdateStatus(msgID, Status);
        }
    }
}
