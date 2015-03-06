//www.networkcomms.cn  www.networkcomms.net
using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SimpleIM.Business
{
    /// <summary>
    /// 此契约类存放聊天对话消息
    /// </summary>
    [ProtoContract]
    public class ChatContract
    { 
        //用户ＩＤ
        [ProtoMember(1)]
        public string UserID { get; set; }
        //用户名
        [ProtoMember(2)]
        public string UserName { get; set; }
        //目标用户ＩＤ
        [ProtoMember(3)]
        public string DestUserID { get; set; }
        //目标用户名
        [ProtoMember(4)]
        public string DestUserName { get; set; }
        //聊天的内容，主要是文本消息
        [ProtoMember(5)]
        public string Content { get; set; }
        //发送的时间
        [ProtoMember(6)]
        public DateTime SendTime { get; set; }
       

        public  ChatContract()
        { }

        public ChatContract(string userID, string userName, string destUserID, string destUserName, string  content,DateTime sendTime)
        {
            this.UserID = userID;
            this.UserName = userName;
            this.DestUserID = destUserID;
            this.DestUserName = destUserName;
            this.Content = content;
            this.SendTime = sendTime;
        }
     

    }
}
