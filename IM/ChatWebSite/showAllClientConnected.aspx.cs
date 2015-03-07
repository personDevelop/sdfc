using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SignalR
{
    public partial class showAllClientConnected : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                data = codingChatHub.UserHandler.ConnectedIds;
                string result = "";
                foreach (string k in data.Keys)
                {
                    result += k + "</br>";

                }
                onlinelist.InnerHtml = result;
            }
        }
    }
}