using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuthorityEntity;
using ProtoBuf;

namespace IMInterface
{
    /// <summary>
    /// 用户信息列表，比如可以传递我的所有好友信息
    /// </summary>
    [ProtoContract]
    public class UserListContract
    {
         [ProtoMember(1)]
        public IList<IMUserInfo> UserList { get; set; }

        //下面这段代码主要是为了防止列表为空，如果列表为空，不加入下面这段代码，序列化会有问题


        public UserListContract()
        {

            UserList = new List<IMUserInfo>();
        }

        public UserListContract(IList<IMUserInfo> userList)
        {
            this.UserList = userList;
            if (UserList == null)
            {
                UserList = new List<IMUserInfo>();
            }
        }


    }
}
