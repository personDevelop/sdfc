//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using ProtoBuf;
using SimpleIM.Data;
namespace SimpleIM.Business
{
    [ProtoContract]
    public class OffLineMessage
    {

        #region Constructors

        public OffLineMessage()
        { }


        #endregion

        #region Private Properties

        private int id = -1;
        private string userID = string.Empty;
        private string userName = string.Empty;
        private string destUserID = string.Empty;
        private string destUerName = string.Empty;
        private string chatContent = string.Empty;
        private DateTime sendTime = DateTime.UtcNow;

        #endregion

        #region Public Properties

        [ProtoMember(1)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [ProtoMember(2)]
        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        [ProtoMember(3)]
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        [ProtoMember(4)]
        public string DestUserID
        {
            get { return destUserID; }
            set { destUserID = value; }
        }
        [ProtoMember(5)]
        public string DestUerName
        {
            get { return destUerName; }
            set { destUerName = value; }
        }
        [ProtoMember(6)]
        public string ChatContent
        {
            get { return chatContent; }
            set { chatContent = value; }
        }
        [ProtoMember(7)]
        public DateTime SendTime
        {
            get { return sendTime; }
            set { sendTime = value; }
        }

        #endregion




    }
}
