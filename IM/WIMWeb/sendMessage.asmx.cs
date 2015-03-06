using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace chatweb
{
    /// <summary>
    /// Summary description for sendMessage
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class sendMessage : System.Web.Services.WebService
    {

        [WebMethod]
        public string send(string userid,string data,string form)
        {
            //接收 存盘 启动udp端口 发送 成功？存盘已读，失败 重试？再失败存未读
            //如果离线 则发送为未读消息
            return "Hello World";
        }

        [WebMethod]
        public string send(string userid, string data, string form,string ip)
        {
            //接收 存盘 启动udp端口 发送 成功？存盘已读，失败 重试？再失败存未读
            //如果离线 则发送为未读消息
            return "Hello World";
        }

    }
}
