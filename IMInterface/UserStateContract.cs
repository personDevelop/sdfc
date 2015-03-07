using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace IMInterface
{
    /// <summary>
    /// 契约类 获取用户是否在线
    /// </summary>
    [ProtoContract]
    public class UserStateContract
    {
        /// <summary>
        /// 用户ＩＤ
        /// </summary>
        [ProtoMember(1)]
        public string UserID;

        /// <summary>
        /// 在线信息
        /// </summary>
        [ProtoMember(2)]
        public OnlineState OnLine;

        public UserStateContract() { }

        public UserStateContract(string userID, OnlineState online)
        {
            this.UserID = userID;
            this.OnLine = online;
        }
    }
    public enum UserSex
    {
        Male,
        Female
    }
    public enum OnlineState
    {
        Offline,
        Online,//在线
        Busy,
        Away,
        Quiet,
        Hide//离线 
    }
}
