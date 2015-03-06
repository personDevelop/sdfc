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
    public class RoleGroup
    {

        #region Constructors

        public RoleGroup()
        { }


        #endregion

        #region Private Properties

        private int id = -1;
        private string groupName = string.Empty;
        private int groupId = -1;
        private int orderId = -1;

        #endregion

        #region Public Properties

        [ProtoMember(1)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [ProtoMember(2)]
        public string GroupName
        {
            get { return groupName; }
            set { groupName = value; }
        }
        [ProtoMember(3)]
        public int GroupId
        {
            get { return groupId; }
            set { groupId = value; }
        }
        [ProtoMember(4)]
        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }

        #endregion




    }
}
