using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameSession;

namespace IMInterface
{
    public interface IMSend
    {

        bool Send(MsgEntity msg);

        /// <summary>
        /// 发送消息,此方法的发送者从session 获取当前登录人
        /// </summary>
        /// <param name="Reciverd"></param>
        /// <param name="msg"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        bool Send(string Reciverd, string msg, MsgSendType type = MsgSendType.基本消息);


    }
    public delegate void Sending(MsgCancleEventArgs args);
    public delegate void Sended(MsgEventArgs args);
    public class MsgEventArgs : EventArgs
    {
        public MsgEventArgs() { }
        public MsgEventArgs(MsgEntity msg) { Msg = msg; }
        public MsgEntity Msg { get; set; }
    }

    public class MsgCancleEventArgs : MsgEventArgs
    {
        public MsgCancleEventArgs() { }
        public MsgCancleEventArgs(MsgEntity msg) { Msg = msg; }
        /// <summary>
        /// 为true 则取消发送，例如检测到当前接受者不在线时，取消发送，并把消息进行存储
        /// </summary>
        public bool IsCancle { get; set; }

    }

    /// <summary>
    /// 例子
    /// </summary>
    public class MsgSend : IMSend
    {
        public event Sending OnSending;

        public event Sended OnSended;

        #region IMSend 成员



        public bool Send(MsgEntity msg)
        {
            if (OnSending != null)
            {
                MsgCancleEventArgs args = new MsgCancleEventArgs(msg);
                OnSending(args);
                if (args.IsCancle)
                {
                    return false;
                }
            }

            if (string.IsNullOrEmpty(msg.SenderID))
            {
                msg.SenderID = Session.Instance.CurrenterUser.ID;

            }
            msg.SenderTime = Session.Instance.ServerDateTime;


            #region 真正发送消息的代码

            #endregion

            if (OnSended != null)
            {
                OnSended(new MsgEventArgs(msg));
            }
            return true;
        }

        public bool Send(string Reciverd, string msg, MsgSendType type = MsgSendType.基本消息)
        {
            MsgEntity msgEntiy = new MsgEntity() { Reciver = Reciverd, MsgBody = msg, MsgSendType = type };

            return Send(msgEntiy);
        }

        #endregion
    }
}
