using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SignalR
{
    public partial class clientnew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            target.Value = Request.QueryString.Get("code");
            uid.Value = System.Guid.NewGuid().ToString() + "_user";

        }
    }
}