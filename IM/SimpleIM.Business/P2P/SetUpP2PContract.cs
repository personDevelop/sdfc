//www.networkcomms.cn  www.networkcomms.net
using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SimpleIM.Business
{
    /// <summary>
    /// 此契约类存放聊天对话消息
    /// </summary>
    [ProtoContract]
    public class SetUpP2PContract
    { 
        //用户ＩＤ
        [ProtoMember(1)]
        public string UserID { get; set; }
         
        public  SetUpP2PContract()
        { }

        public SetUpP2PContract(string userID)
        {
            this.UserID = userID;
         
        }
     

    }
}
