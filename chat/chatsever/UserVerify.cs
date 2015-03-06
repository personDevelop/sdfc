using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using AuthorityEntity;

namespace chat
{
    public class UserVerify
    {
        public static ClassResponse verifyUser(string username, string userpwd, string Ip, int Port)
        {
            ClassResponse user = new ClassResponse();
            DataIO dt = new DataIO();
            string error;
            string groupname;
            UserInfo userinfo = new AuthorityClient.LoginClient().Login(username, userpwd, Ip, Port.ToString(), out groupname, out error);
            if (string.IsNullOrWhiteSpace(error))
            {
                user.userid = userinfo.ID;
                user.username = userinfo.Name;
                user.userstate = 1;
                user.userdept = groupname;
                user.reponse = "登录成功！";
            }
            else
            {
                user.userstate = -1;
                user.reponse = "用户名或密码错误";
            }
            var e = dt.SelectAccount(username);
            if (e != null)
            {
                if (userpwd == e.GetAttribute("Password"))
                {
                    user.userid = e.GetAttribute("uid");
                    user.username = e.GetAttribute("uname");
                    user.userstate = 1;
                    user.userdept = e.GetAttribute("udept");
                    user.reponse = "登录成功！";
                }
                else
                {
                    user.userstate = -1;
                    user.reponse = "用户名或密码错误";
                }
            }
            //if (username == "liwl")
            //{
            //    user.userid = "0001";
            //    user.username = "李伟龙";
            //    user.userstate = 1;
            //    user.userdept = "0001";
            //    user.reponse = "登录成功！";
            //}
            //else if (username == "lyl")
            //{
            //    user.userid = "0002";
            //    user.username = "卢永列";
            //    user.userstate = 1;
            //    user.userdept = "0002";
            //    user.reponse = "登录成功！";
            //}
            else
            {
                user.userstate = -1;
                user.reponse = "用户名或密码错误";
            }

            return user;
        }




        static string[] depts = { "经理办公室", "IT部门", "开发部", "网服部" };
        static string[] deptid = { "0001", "0002", "0003", "0004" };
        public static List<ClassDept> getUserDept()
        {
            List<ClassDept> deptsinfo = new List<ClassDept>();
            DataIO dt = new DataIO();
            var list = dt.getFriend();
            for (int i = 0; i < deptid.Length; i++)
            {
                ClassDept model = new ClassDept();
                model.depid = deptid[i];
                model.depmc = depts[i];
                List<ClassResponse> userlst = new List<ClassResponse>();
                foreach (XmlElement e in list)
                {
                    if (e.GetAttribute("udept") == model.depid)
                    {
                        ClassResponse user = new ClassResponse();
                        user.userid = e.GetAttribute("uid");
                        user.username = e.GetAttribute("uname");
                        userlst.Add(user);
                    }
                    //e.Name
                }
                //for (int k = 0; k < userids.Length; k++)
                //{
                //    ClassResponse user = new ClassResponse();
                //    user.userid = userids[k];
                //    user.username = userinames[k];
                //    userlst.Add(user);
                //}

                model.userlist = userlst;
                deptsinfo.Add(model);
            }



            return deptsinfo;
        }




    }
}
