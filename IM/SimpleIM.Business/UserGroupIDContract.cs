//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;


namespace SimpleIM.Business
{
    /// <summary>
    /// 用户ID组ID契约类
    /// </summary>
    [ProtoContract]
    public class UserGroupIDContract
    {
        //用户ＩＤ
          private string userID;
        [ProtoMember(1)]
        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        //对应的组ＩＤ
        private int groupID;
        [ProtoMember(2)]
        public int GroupID
        {
            get { return groupID; }
            set { groupID = value; }
        }


        public UserGroupIDContract() { }
        public UserGroupIDContract(string userID, int groupID)
        {

            this.userID = userID;
            this.groupID = groupID;
        }
    }
}


 