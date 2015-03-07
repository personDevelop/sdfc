using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;


namespace SignalR
{
    public class codingChatHub : Hub
    {

        //宣告靜態類別，來儲存上線清單
        public static class UserHandler
        {
            public static Microsoft.AspNet.SignalR.Hubs.HubConnectionContext context = null;
            public static Dictionary<string, string> ConnectedIds = new Dictionary<string, string>();
            public static Dictionary<string, string> SeverIds = new Dictionary<string, string>();


        }

        //當使用者斷線時呼叫
        public override Task OnDisconnected()
        {

            //當使用者離開時，移除在清單內的 ConnectionId
            Clients.All.removeList(Context.ConnectionId);
            UserHandler.ConnectedIds.Remove(Context.ConnectionId);

            foreach (KeyValuePair<string, string> kvp in UserHandler.SeverIds)
            {
                if (kvp.Value == Context.ConnectionId)
                {
                    UserHandler.SeverIds.Remove(kvp.Key);
                    break;
                }
            }
            return base.OnDisconnected();
        }

        //使用者連現時呼叫
        public void userConnected(string name)
        {
            //进行编码，防止XSS攻擊
            name = HttpUtility.HtmlEncode(name);
            string message = "歡迎使用者 " + name + " 加入聊天室";

            //發送訊息給除了自己的其他
            Clients.Others.addList(Context.ConnectionId, name);

            if (UserHandler.context == null)
            {
                UserHandler.context = Clients;
            }
            if (name == "lwl" || name == "lyl")
            {
                UserHandler.SeverIds.Add(name, Context.ConnectionId);
            }
            Clients.Others.hello(message);

            //發送訊息至自己，並且取得上線清單
            Clients.Caller.getList(UserHandler.ConnectedIds.Select(p => new { id = p.Key, name = p.Value }).ToList());

            //新增目前使用者至上線清單

            UserHandler.ConnectedIds.Add(Context.ConnectionId, name);

        }

        //发送消息给所有人 暂时用不到
        public void sendAllMessage(string message)
        {
            message = HttpUtility.HtmlEncode(message);
            var name = UserHandler.ConnectedIds.Where(p => p.Key == Context.ConnectionId).FirstOrDefault().Value;
            message = name + "說：" + message;
            Clients.All.sendAllMessge(message);
        }


        //根据clientID 发送消息
        public void sendMessage(string ToId, string message)
        {
            message = HttpUtility.HtmlEncode(message);
            var fromName = UserHandler.ConnectedIds.Where(p => p.Key == Context.ConnectionId).FirstOrDefault().Value;
            //<span style='color:red'>悄悄的對你說</span>
            //message = fromName + "：" + message;
            Clients.Client(ToId).sendMessage(message, "：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));//发送给终端消息
            //Clients.Client(Context.ConnectionId).sendMessage(message);//发送给自己消息
        }
        //根据clientID 发送消息
        public void sendMessageEx(string ToId, string message)
        {
            message = HttpUtility.HtmlEncode(message);
            dynamic member=UserHandler.context.Client(ToId).sendMessage(message, "：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));//发送给终端消息

        }



        //根据客服编号发送消息
        public void sendMessageSever(string Severcode, string message)
        {
            message = HttpUtility.HtmlEncode(message);
            var fromName = UserHandler.ConnectedIds.Where(p => p.Key == Context.ConnectionId).FirstOrDefault().Value;
            var ToId = UserHandler.SeverIds[Severcode].ToString();

            //<span style='color:red'>悄悄的對你說</span>
            //message = fromName + "说：" + message;
            Clients.Client(ToId).sendMessage(message, Context.ConnectionId, "客户：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));//终端发给服务器端并告诉服务器端自己的clientID

            //Clients.Client(Context.ConnectionId).sendMessage(message);//自己的消息发给自己
        }
        // 连接客服事件 第一次进来连接客服
        public void sendMessageConnect(string Severcode, string message)
        {
            message = HttpUtility.HtmlEncode(message);
            var fromName = UserHandler.ConnectedIds.Where(p => p.Key == Context.ConnectionId).FirstOrDefault().Value;
            var ToId = UserHandler.SeverIds[Severcode].ToString();

            //<span style='color:red'>悄悄的對你說</span>
            message = fromName + "说：" + message;
            Clients.Client(ToId).Connect(message, Context.ConnectionId);

            //Clients.Client(Context.ConnectionId).sendMessage(message);
        }
    }
}