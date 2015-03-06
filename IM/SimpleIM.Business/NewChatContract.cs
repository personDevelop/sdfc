 
//www.networkcomms.cn  www.networkcomms.net
using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;

namespace SimpleIM.Business
{
    /// <summary>
    /// 此契约类存放聊天对话消息
    /// </summary>
    [ProtoContract]
    public class NewChatContract
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

         [ProtoMember(7)]
        public IList<ImageWrapper> ImageList { get; set; }

        //下面这段代码主要是为了防止列表为空，如果列表为空，不加入下面这段代码，序列化会有问题
        [DefaultValue(false), ProtoMember(8)]
        private bool IsEmptyList
        {
            get { return ImageList != null && ImageList.Count == 0; }
            set { if (value) { ImageList = new List<ImageWrapper>(); } }
        }

        
       

        public  NewChatContract()
        { }

        public NewChatContract(string userID, string userName, string destUserID, string destUserName, string content, IList<ImageWrapper> imageList, DateTime sendTime)
        {
            this.UserID = userID;
            this.UserName = userName;
            this.DestUserID = destUserID;
            this.DestUserName = destUserName;
            this.Content = content;
            this.ImageList = imageList;
            this.SendTime = sendTime;
        }
     

    }
}
