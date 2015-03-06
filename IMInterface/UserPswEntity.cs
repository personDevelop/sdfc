using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMInterface
{
    /// <summary>
    /// 修改密码的契约类
    /// </summary>

    public class UserPswEntity
    {
        /// <summary>
        /// 用户ID
        /// </summary>

        public string UserID;
        /// <summary>
        /// 用户旧密码
        /// </summary>

        public string OldPsw;
        /// <summary>
        /// 用户新密码
        /// </summary>

        public string NewPsw;

        public UserPswEntity() { }

        public UserPswEntity(string userID, string oldPsw, string newPsw)
        {
            this.UserID = userID;
            this.OldPsw = oldPsw;
            this.NewPsw = newPsw;
        }

    }
}
