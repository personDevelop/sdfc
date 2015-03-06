//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace SimpleIM.Business
{
    /// <summary>
    /// 用户信息类  主要登录时使用
    /// </summary>
    [ProtoContract]
    public  class UserInfo
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [ProtoMember(1)]
        public string UserID;
        /// <summary>
        /// 用户密码
        /// </summary>
        [ProtoMember(2)]
        public string Password;

        public UserInfo() { }

        public UserInfo(string userID, string password)
        {
            this.UserID = userID;
            this.Password = password;
        }

    }
}
