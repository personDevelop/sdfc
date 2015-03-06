using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SignalR
{
    public partial class severPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
           
            foreach (dynamic row in dt.Rows)
            {
                row.get(0,1);
            }
        }
    }
}