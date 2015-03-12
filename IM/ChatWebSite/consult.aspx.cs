using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrameCommonEntity;

namespace SignalR
{ 
    public partial class consult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                target.Value = Request.QueryString.Get("code");
               // HttpUtility.ParseQueryString(Request.Url.Query, Encoding.GetEncoding("UTF-8"));
                uid.Value = System.Guid.NewGuid().ToString() + "_user";
                List<ParameterInfo> list = new FrameCommonClient.ParameterInfoClient().GetListByParentId("bdcf2650-c738-4b25-852a-79a615456441");
                //userinfo.InnerHtml = HttpUtility.ParseQueryString(Request.Url.Query, Encoding.GetEncoding("UTF-8"))["name"].ToString();
                //uname.Value = Request.QueryString.Get("name");
                string html = "";
                foreach (ParameterInfo item in list)
                {

                    html += " <a style='display: block; line-height: 20px;' onclick='requestData(this);' req='" + item.Value2 + "' href='javascript:void(0);'>" + item.Value + "</a>";

                }



                AuthorityClient.UserInfoClient client = new AuthorityClient.UserInfoClient();
                //client.GetIMUserList();
                commonQues.InnerHtml = html;
            }
        }
    }
}