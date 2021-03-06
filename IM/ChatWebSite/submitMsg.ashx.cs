﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuthorityDataAccess;
using AuthorityEntity;

namespace SignalR
{
    /// <summary>
    /// Summary description for submitMsg
    /// </summary>
    public class submitMsg : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";

                string mes = context.Request.Form.Get("mes");
                string name = context.Request.Form.Get("name");
                string tel = context.Request.Form.Get("tel");
                string mail = context.Request.Form.Get("mail");
                string add = context.Request.Form.Get("add");
                string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                leavemsg model = new leavemsg();
                model.mes_id = Guid.NewGuid().ToString();
                model.mes_time = time;
                model.mes_op = "1";
                model.mes_content = mes;
                model.mes_address = add;
                model.mes_mail = mail;
                model.mes_tel = tel;
                model.mes_name = name;
                leavemsgDataAccess bll = new leavemsgDataAccess();
                bll.Save(model);
                context.Response.Write("{\"res\":true,\"mes\":\"提交留言成功！我们会尽快与您联系！\"}");
            }
            catch (Exception ex)
            {
                context.Response.Write("{\"res\":false,\"mes\":\"" + ex.Message + "\"}");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}