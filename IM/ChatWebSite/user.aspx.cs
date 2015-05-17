using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuthorityEntity.IM;
using NetworkCommsDotNet;
using System.Data;
using Sharp.Common;
using AuthorityEntity;

namespace SignalR
{
    public partial class user : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string linkurl = "consult.aspx?sid={0}&code={0}&name={1}";
                string offlinkurl = "javascript:void(0)";
                string tmpl = @" <td  align='right'  valign=middle   width='{3}%'>
                                <a href='{0}'>  <img src='image/chatlist_head_0{1}.png' /></a> </td><td   valign=middle   width='{3}%'><a href='{0}'>{2}</a>
                            </td>";
                string grouptmpl = @"<tr  style='background:#eee;font-weight:bold;'>
                            <td colspan={1}>
                                {0}
                            </td>
 
                        </tr>";

                Dictionary<string, string> data = new Dictionary<string, string>();
                data = codingChatHub.UserHandler.SeverIds;
                AuthorityClient.UserInfoClient client = new AuthorityClient.UserInfoClient();
                List<View_IMUser> list = client.GetIMUserList().ToList<View_IMUser>();

                int oneRowCount = 2;
                string group = "";
                string result = "";
                int groupCount = 0;
                int tdWidth = 100 /( oneRowCount * 2);
                for (int k = 0; k < list.Count; k++)
                {
                    View_IMUser item = list[k];
                    if (group != item.DepartCode)
                    {
                        group = item.DepartCode;
                        groupCount = 0;
                        if (string.IsNullOrWhiteSpace(item.DepartName))
                        {
                            item.DepartName = "未分组";
                        }
                        else
                        {
                            result += string.Format(grouptmpl, item.DepartName,oneRowCount*2);
                        }
                    }
                    else
                    { groupCount++; }
                    int currentBL = groupCount % oneRowCount;
                    if (currentBL == 0)
                    {
                        result += "<tr>";
                    }

                    if (item.IsOnLine)
                    {
                        result += string.Format(tmpl, string.Format(linkurl, item.ID, item.Name), 1, item.Name, tdWidth);
                    }
                    else
                    {
                        result += string.Format(tmpl, offlinkurl, 2, item.Name, tdWidth);
                    }
                    if (currentBL == oneRowCount - 1)
                    {
                        result += "</tr>";
                    }
                }


                result = "<table class='onlinelist' width='100%'>" + result + "</table>";
                userinfo.InnerHtml = result;
            }
        }
    }
}