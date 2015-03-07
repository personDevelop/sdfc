using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace IMInterface
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

        public SetUpP2PContract()
        { }

        public SetUpP2PContract(string userID)
        {
            this.UserID = userID;

        }


    }
}
