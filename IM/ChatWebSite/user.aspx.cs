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
                            <td width='100'>
                                {1}
                            </td>
                            <td width='35'>
                                <img src='image/chatlist_head_01.png' />
                            </td>
                            <td>
                                <a target='_blank' href='consult.aspx?sid={0}&code={0}&name={1}'>{1}</a>
                            </td>
                        </tr>";
                string grouptmpl = @"<tr  style='background:#eee;font-weight:bold;'>
                            <td colspan=3>
                                {0}
                            </td>
 
                        </tr>";
                string tmploffline = @"<tr>
                            <td width='100'>
                                {1}
                            </td>
                            <td width='35'>
                                <img src='image/chatlist_head_02.png' />
                            </td>
                            <td>
                                <a href='javascript:void(0)'>{1}</a>
                            </td>
                        </tr>";
                Dictionary<string, string> data = new Dictionary<string, string>();
                data = codingChatHub.UserHandler.SeverIds;
                AuthorityClient.UserInfoClient client = new AuthorityClient.UserInfoClient();
                DataTable dt = client.GetIMUserList();
                DataRow[] rowcol = dt.Select("", "imgroupname asc");
                string result = "";
                string group = "";
                int i = 0;
                foreach (DataRow row in rowcol)
                {//IsOnLine

                    if (i == 0 || group != row["imgroupname"].ToString())
                    {
                        group = row["imgroupname"].ToString();
                        if (row["imgroupname"].ToString() == "")
                        {
                            result += string.Format(grouptmpl, "未分组");
                        }
                        else
                        {
                            result += string.Format(grouptmpl, row["imgroupname"].ToString());
                        }
                    }
                    i++;


                    if (row["isonline"].ToString() == "0" || row["isonline"].ToString() == "")
                    {
                        result += string.Format(tmploffline, row["ID"].ToString(), row["Name"].ToString());
                    }
                    else
                    {
                        result += string.Format(tmpl, row["ID"].ToString(), row["Name"].ToString());
                    }
                    //result += "<a href='consult.aspx?sid=" + row["userid"].ToString() + "&code=" + row["userid"].ToString() + "&name=" + row["NAME"].ToString() + "' target='_blank'  style='color:red;'>在线" + row["NAME"].ToString() + "</a>";
                }
                result = "<table class='onlinelist' width='100%'>" + result + "</table>";
                userinfo.InnerHtml = result;
            }
        }
    }
}