using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;
using System.ComponentModel;

namespace AuthorityEntity.IM
{

    /// <summary>
    /// 用户ＩＤ ,当只需要传递用户id时可以使用
    /// </summary>
    [ProtoContract]
    public class UserIDContract
    {
        [ProtoMember(1)]
        public string UsersID { get; set; }
        public UserIDContract() { }
        public UserIDContract(string userid)
        { UsersID = userid; }
    }
    /// <summary>
    /// 用户ＩＤ列表,比如可以从服务器获取所有在线用户的ＩＤ
    /// </summary>
    [ProtoContract]
    public class UserIDListContract
    {
        [ProtoMember(1)]
        public IList<string> UsersID;
         

        //下面这段代码主要是为了防止列表为空，如果列表为空，不加入下面这段代码，序列化会有问题
        [DefaultValue(false), ProtoMember(2)]
        private bool IsEmptyList
        {
            get { return UsersID != null && UsersID.Count == 0; }
            set { if (value) { UsersID = new List<string>(); } }
        }

        public UserIDListContract() { }

        public UserIDListContract(IList<string> theUsersID)
        {
            this.UsersID = theUsersID;
        }
    }
}
