using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMInterface
{
    public class MsgEntity
    {
        /// <summary>
        /// 为空时，是系统消息
        /// </summary>
        public string SenderID { get; set; }

        public MsgSendType MsgSendType { get; set; }

        public MsgType MsgType { get; set; }

        public DateTime SendTime { get; set; }
        /// <summary>
        /// 消息标题，可以为空
        /// </summary>
        public string MsgTitle { get; set; }

        /// <summary>
        /// 可以为空，为空发送给所以人，一般是广播消息
        /// </summary>
        public string Reciver { get; set; }

        /// <summary>
        /// 是否发送成功，广播和提醒类的消息，不用管是否发送成功
        /// </summary>
        public bool IsSendScucess { get; set; }


        /// <summary>
        /// 是否已读，广播类消息不用关是否已读，只管发，而且只发一次
        /// </summary>
        public bool IsRead { get; set; }

        /// <summary>
        /// 消息主体
        /// </summary>
        public string MsgBody { get; set; }

        
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
