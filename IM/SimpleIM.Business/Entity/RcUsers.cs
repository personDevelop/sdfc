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
    public class RcUsers
    {

        #region Constructors

        public RcUsers()
        { }


        #endregion

        #region Private Properties

        private int id = -1;
        private string userID = string.Empty;
        private string name = string.Empty;
        private string password = string.Empty;
        private string declaring = string.Empty;
        private int status = -1;
        private int groupID = -1;
        private bool isMale = false;
        private int userLevel = -1;
        private bool enabled = false;
        private DateTime registerTime = DateTime.UtcNow;
        private DateTime lastLoginTime = DateTime.UtcNow;

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
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [ProtoMember(4)]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        [ProtoMember(5)]
        public string Declaring
        {
            get { return declaring; }
            set { declaring = value; }
        }
        [ProtoMember(6)]
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        [ProtoMember(7)]
        public int GroupID
        {
            get { return groupID; }
            set { groupID = value; }
        }
        [ProtoMember(8)]
        public bool IsMale
        {
            get { return isMale; }
            set { isMale = value; }
        }
        [ProtoMember(9)]
        public int UserLevel
        {
            get { return userLevel; }
            set { userLevel = value; }
        }
        [ProtoMember(10)]
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }
        [ProtoMember(11)]
        public DateTime RegisterTime
        {
            get { return registerTime; }
            set { registerTime = value; }
        }
        [ProtoMember(12)]
        public DateTime LastLoginTime
        {
            get { return lastLoginTime; }
            set { lastLoginTime = value; }
        }

        #endregion




    }

}

