using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chat
{
    [Serializable]
    public class ClassResponse
    {
        public string userid {get;set;}//用户id
        public string username {get;set;}//用户名称
        public string userpwd { get; set; }//用户
        public int userstate { get; set; }//获取用户状态
        public string reponse { get; set; }//登录结果
        public string userdescript { get;set;}
        public string userdept { get; set;}
    }

}
