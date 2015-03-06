//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace SimpleIM.Business
{
    /// <summary>
    /// 契约类  用于客户端发来用户名密码后，服务器进行判断，给Message赋值是否登录成功，如成功
    /// 从服务器根据客户端传来的用户ID获取用户相关信息，赋值给UserContract，然后一起返回给客户端
    /// </summary>
    [ProtoContract]
    public  class UserLoginContract
    {
        /// <summary>
        /// 用户名密码验证是否成功
        /// </summary>
        [ProtoMember(1)]
        public string Message { get; set; }
        /// <summary>
        /// 根据用户ID获取用户的具体信息
        /// </summary>
        [ProtoMember(2)]
        public UserContract UserContract { get; set; }

        public UserLoginContract() { }

        public UserLoginContract(string message, UserContract userContract)
        {
            this.Message = message;
            this.UserContract = userContract;
        }

    }
}
