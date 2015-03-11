using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace AuthorityEntity.IM
{
    [ProtoContract]
    public class MsgEntity
    {
        [ProtoMember(1)]
        public string ID { get; set; }
        [ProtoMember(2)]
        public string SenderID { get; set; }
        [ProtoMember(3)]
        public string SenderName { get; set; }
        [ProtoMember(4)]
        public string MsgTitle { get; set; }
        [ProtoMember(5)]
        public string MsgContent { get; set; }
        [ProtoMember(6)]
        public DateTime SendTime { get; set; }
        [ProtoMember(7)]
        public int MsgSendType { get; set; }
        [ProtoMember(8)]
        public int MsgType { get; set; }
        [ProtoMember(9)]
        public string Reciver { get; set; }
        [ProtoMember(10)]
        public string ReciverName { get; set; }
        [ProtoMember(11)]
        public bool IsWebMsg { get; set; }
        public MsgEntity()
        {
            ImageList = new List<ImageWrapper>();
        }
        /// <summary>
        /// 离线不支持，必须在线才能发送图片
        /// </summary>
        [ProtoMember(11)]
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
        /// 针对单个人或某一部分的人的消息，以弹窗的形式提醒，发送者一般为系统
        /// </summary>
        提示信息,

        /// <summary>
        /// 消息类型为网页的消息
        /// </summary>
        网服消息,
    }

    public enum MsgType
    {
        文字,
        震动,
        文件,
        语音,//保留
        视频//保留


    }
}
