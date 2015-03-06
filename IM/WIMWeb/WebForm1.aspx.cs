using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 

namespace chatweb
{

    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            
            //ClassTextMsg textMsg = new ClassTextMsg();

            //textMsg.MsgContent = @"{\rtf1\ansi\ansicpg936\deff0\deflang1033\deflangfe2052{\fonttbl{\f0\fswiss\fcharset0 Arial;}{\f1\fnil\fcharset134 \'cb\'ce\'cc\'e5;}}\viewkind4\uc1\pard\lang2052\f0\fs18 qewr\f1\par}";
            //ClassMsg msg = new ClassMsg(12, "", new ClassSerializers().SerializeBinary(textMsg).ToArray());
            //msg.ID = "0002";
            //int port = int.Parse(Request.QueryString.Get("port"));
            //string ipaddress = Request.QueryString.Get("ip");
            //System.IO.MemoryStream stream = new ClassSerializers().SerializeBinary(msg);
            //System.Net.IPAddress ip = System.Net.IPAddress.Parse(ipaddress);
            //SockUDP.Send(ip, port, stream.ToArray());

        }
    }
}