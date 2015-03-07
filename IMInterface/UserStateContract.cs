using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMInterface
{
    /// <summary>
    /// 契约类 获取用户是否在线
    /// </summary>

    public class UserStateContract
    {
        /// <summary>
        /// 用户ＩＤ
        /// </summary>

        public string UserID;

        /// <summary>
        /// 在线信息
        /// </summary>

        public UserState OnLine;

        public UserStateContract() { }

        public UserStateContract(string userID, UserState online)
        {
            this.UserID = userID;
            this.OnLine = online;
        }
    }

    public enum UserState
    { 
        在线,
        离线,
        隐身
    }
}
