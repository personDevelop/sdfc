using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SignalR
{
    /// <summary>
    /// Summary description for sendMes
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class sendMes : System.Web.Services.WebService
    {

        [WebMethod]
        public string sendMess(string clientid, string mes)
        {
            codingChatHub code = new codingChatHub();
            code.sendMessageEx(clientid, mes);
            return "Hello World";
        }

        [WebMethod]
        public void sendClientMess(string clientid, string mes)
        {
            //SendClientMes.SendMess(clientid,mes,rec);
        }
    }
}
