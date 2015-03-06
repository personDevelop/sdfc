using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;


namespace SimpleIM.Business
{
    //操作结果的返回信息，可通用
    [ProtoContract]
    public class ResMessage
    {

        [ProtoMember(1)]
        public string Message;

        public ResMessage() { }

        public ResMessage(string message)
        {
            this.Message = message;
        }
    }
}
