using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SignalR
{
    public partial class UserAvailable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //codingChatHub cc = new codingChatHub();
            Dictionary<string, string> data = new Dictionary<string, string>();
            data = codingChatHub.UserHandler.SeverIds;
            string result = "";
            foreach (string str in UserList.getUserId())
            {
               if(data.ContainsKey(str))
                {

                    result += "<a href='consult.aspx?sid=" + data[str].ToString() + "&code=" + str + "' target='_blank'  style='color:red;'>在线" + str + "</a>";
                }
                else {
                    result += "<a href='#' target='_blank' style='color:blue;'>离线" + str + "</a>";
                }
            }
             

            Response.Write(result);

        }
    }
}