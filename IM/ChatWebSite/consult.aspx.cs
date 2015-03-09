using System;
using System.Collections.Generic;
using System.Linq;
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
            target.Value = Request.QueryString.Get("code");
            uid.Value = System.Guid.NewGuid().ToString() + "_user";
            List<ParameterInfo> list = new FrameCommonClient.ParameterInfoClient().GetListByParentId("bdcf2650-c738-4b25-852a-79a615456441");


            string html = "";
            foreach (ParameterInfo item in list)
            {
                string type = item.V1Type;
            }
        }
    }
}