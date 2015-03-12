using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuthorityEntity.IM;
using NetworkCommsDotNet;
using System.Data;

namespace SignalR
{
    public partial class UserAvailable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //codingChatHub cc = new codingChatHub();
            Dictionary<string, string> data = new Dictionary<string, string>();
            data = codingChatHub.UserHandler.SeverIds;
            AuthorityClient.UserInfoClient client=new AuthorityClient.UserInfoClient();
            DataTable dt=client.GetOnLineWf();
            string result = "";
            foreach (DataRow row in dt.Rows)
            {
                result += "<a href='consult.aspx?sid=" + row["userid"].ToString() + "&code=" + row["userid"].ToString() + "&name=" + row["NAME"].ToString() + "' target='_blank'  style='color:red;'>在线" + row["NAME"].ToString() + "</a>";
            }

           
            //foreach (string str in UserList.getUserId())
            //{
            //   if(data.ContainsKey(str))
            //    {

            //        result += "<a href='consult.aspx?sid=" + data[str].ToString() + "&code=" + str + "' target='_blank'  style='color:red;'>在线" + str + "</a>";
            //    }
            //    else {
            //        result += "<a href='#' target='_blank' style='color:blue;'>离线" + str + "</a>";
            //    }
            //}
             

            Response.Write(result);

        }
    }
}