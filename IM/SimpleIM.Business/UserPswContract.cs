//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace SimpleIM.Business
{
     
    /// <summary>
    /// 修改密码的契约类
    /// </summary>
    [ProtoContract]
    public class UserPswContract
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [ProtoMember(1)]
        public string UserID;
        /// <summary>
        /// 用户旧密码
        /// </summary>
        [ProtoMember(2)]
        public string OldPsw;
        /// <summary>
        /// 用户新密码
        /// </summary>
        [ProtoMember(3)]
        public string NewPsw;

        public UserPswContract() { }

        public UserPswContract(string userID, string oldPsw,string newPsw)
        {
            this.UserID = userID;
            this.OldPsw = oldPsw;
            this.NewPsw = newPsw;
        }

    }
}
