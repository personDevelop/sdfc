//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;
using System.ComponentModel;
namespace SimpleIM.Business
{
    /// <summary>
    /// 用户ＩＤ列表,比如可以从服务器获取所有在线用户的ＩＤ
    /// </summary>
    [ProtoContract]
    public  class UserIDContract
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

        public UserIDContract() { }

        public UserIDContract(IList<string> theUsersID)
        {
            this.UsersID = theUsersID;
        }
    }
}
