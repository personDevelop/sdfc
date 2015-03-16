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
    public partial class user : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string tmpl = @"<tr>
                            <td width='55'>
                                {1}
                            </td>
                            <td width='35'>
                                <img src='image/chatlist_head_01.png' />
                            </td>
                            <td>
                                <a target='_blank' href='consult.aspx?sid={0}&code={0}&name={1}'>{1}</a>
                            </td>
                        </tr>";
                Dictionary<string, string> data = new Dictionary<string, string>();
                data = codingChatHub.UserHandler.SeverIds;
                AuthorityClient.UserInfoClient client = new AuthorityClient.UserInfoClient();
                DataTable dt = client.GetIMUserList();
                string result = "";
                foreach (DataRow row in dt.Rows)
                {
                    result += string.Format(tmpl,row["ID"].ToString(),row["Name"].ToString());
                    //result += "<a href='consult.aspx?sid=" + row["userid"].ToString() + "&code=" + row["userid"].ToString() + "&name=" + row["NAME"].ToString() + "' target='_blank'  style='color:red;'>在线" + row["NAME"].ToString() + "</a>";
                }
                result = "<table class='onlinelist' width='100%'>"+result+"</table>";
                userinfo.InnerHtml = result;
            }
        }
    }
}