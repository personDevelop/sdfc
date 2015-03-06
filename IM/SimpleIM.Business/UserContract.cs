//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace SimpleIM.Business
{
    /// <summary>
    /// 用户信息契约类
    /// </summary>
    [ProtoContract]
    public class UserContract
    {
        //用户ＩＤ
        [ProtoMember(1)]
        public string UserID { get; set; }
        //用户名
        [ProtoMember(2)]
        public string Name { get; set; }
        //用户描述
        [ProtoMember(3)]
        public string Declaring { get; set; }
        //性别
        [ProtoMember(4)]
        public bool IsMale { get; set; }
        //初始在线状态
        [ProtoMember(5)]
        public bool OnLine { get; set; }

        public UserContract() { }

        public UserContract(string userID, string userName, string underWrite, bool male,bool onLine)
        {
            this.UserID = userID;
            this.Name = userName;
            this.Declaring = underWrite;
            this.IsMale = male; 
            this.OnLine = onLine;
        }
    }
}