using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace IMInterface
{
    /// <summary>
    /// 
    /// </summary>
    [ProtoContract]
    public class UserIDEndPoint
    {

        [ProtoMember(1)]
        public string UserID;

        [ProtoMember(2)]
        public string IPAddress;

        [ProtoMember(3)]
        public int Port;

        public UserIDEndPoint() { }

        public UserIDEndPoint(string userID, string ipaddress, int port)
        {
            this.UserID = userID;
            this.IPAddress = ipaddress;
            this.Port = port;
        }

    }
}
