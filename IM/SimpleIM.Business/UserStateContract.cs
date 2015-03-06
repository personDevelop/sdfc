
//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace SimpleIM.Business
{
    /// <summary>
    /// 契约类 获取用户是否在线
    /// </summary>
    [ProtoContract]
    public class UserStateContract
    {
        /// <summary>
        /// 用户ＩＤ
        /// </summary>
        [ProtoMember(1)]
        public string UserID;

        /// <summary>
        /// 在线信息
        /// </summary>
        [ProtoMember(2)]
        public bool OnLine;

        public UserStateContract() { }

        public UserStateContract(string userID, bool online)
        {
            this.UserID = userID;
            this.OnLine = online;
        }
    }
}
