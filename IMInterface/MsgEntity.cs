using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace IMInterface
{
    [ProtoContract]
    public class MsgEntity
    {
        public MsgEntity()
        { ImageList = new List<ImageWrapper>(); }
        /// <summary>
        /// 为空时，是系统消息
        /// </summary>
        [ProtoMember(1)]
        public string SenderID { get; set; }
        [ProtoMember(2)]
        public MsgSendType MsgSendType { get; set; }
        [ProtoMember(3)]
        public MsgType MsgType { get; set; }
        [ProtoMember(4)]
        public DateTime SendTime { get; set; }
        /// <summary>
        /// 消息标题，可以为空
        /// </summary>
        [ProtoMember(5)]
        public string MsgTitle { get; set; }

        /// <summary>
        /// 可以为空，为空发送给所以人，一般是广播消息
        /// </summary>
        [ProtoMember(6)]
        public string Reciver { get; set; }

        /// <summary>
        /// 是否发送成功，广播和提醒类的消息，不用管是否发送成功
        /// </summary>
        [ProtoMember(7)]
        public bool IsSendScucess { get; set; }


        /// <summary>
        /// 是否已读，广播类消息不用关是否已读，只管发，而且只发一次
        /// </summary>
        [ProtoMember(8)]
        public bool IsRead { get; set; }

        /// <summary>
        /// 消息主体
        /// </summary>
        [ProtoMember(9)]
        public string MsgBody { get; set; }


        [ProtoMember(10)]
        public IList<ImageWrapper> ImageList { get; set; }
    }

    public enum MsgSendType
    {
        /// <summary>
        /// 一对一会话
        /// </summary>
        基本消息,

        /// <summary>
        /// 群聊天模式的消息
        /// </summary>
        群消息,

        /// <summary>
        /// 发送给所有人的消息，以弹窗的形式提醒，发送者一般为系统
        /// </summary>
        广播消息,

        /// <summary>
        /// 真的单个人活某一部分的人的消息，以弹窗的形式提醒，发送者一般为系统
        /// </summary>
        提示信息,


    }

    public enum MsgType
    {
        文字,
        文件,
        语音,//保留
        视频//保留


    }
}
