using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;

namespace IAuthorityService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IMsgSendOrderService”。
    [ServiceContract]
    public interface IMsgSendOrderService
    {
        [OperationContract]
        DataTable GetAllMsg();
        [OperationContract]
        DataTable GetAllMsgByStatus(string status);
        [OperationContract]
        DataTable GetMySenderMsg(string senderID);
        [OperationContract]
        DataTable GetMyReciveMsg(string reciverID);
        [OperationContract]

        int AddMsg(DataTable dt);
        [OperationContract]
        int AddOneMsgToMutilsPerson(string msg, string senderID, string senderName, string senderTel,
          string[] reciverIDS, string[] reciverNames, string[] reciverTelPhone);
        [OperationContract]

        int UpdateStatus(string[] msgID, string Status);

        [OperationContract]
        int AddOfflineMsg(AuthorityEntity.MsgInfo msg);
         [OperationContract]
        int DeleteOffLineMsg(string msgid);
         [OperationContract]
         DataTable GetAllOffLineMsgByUserID(string reciveuserID);
    }
}
