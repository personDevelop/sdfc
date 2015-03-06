//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;
using System.ComponentModel;

namespace SimpleIM.Business
{
    /// <summary>
    /// 用户信息列表，比如可以传递我的所有好友信息
    /// </summary>
    [ProtoContract]
    public class UserListContract
    {
        [ProtoMember(1)]
        public IList<UserContract> UserList { get; set; }

        //下面这段代码主要是为了防止列表为空，如果列表为空，不加入下面这段代码，序列化会有问题
        [DefaultValue(false), ProtoMember(2)]
        private bool IsEmptyList
        {
            get { return UserList != null && UserList.Count == 0; }
            set { if (value) { UserList = new List<UserContract>(); } }
        }

        public UserListContract() { }

        public UserListContract(IList<UserContract> userList)
        {
            this.UserList = userList;
        }

  
    }
}
