using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using AuthorityEntity;
using AuthorityClient;

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
        public static List<ClassDept> getUserDept(string myid)
        {
            string cachKey = "UserInfoDataAccess_GetIMUserList";
            List<View_IMUser> list = null;
            object o = Sharp.Common.CacheContainer.GetCache(cachKey);
            if (o == null)
            {
                list = new UserInfoClient().GetIMUserList();
                Sharp.Common.CacheContainer.AddCache(cachKey, list, 60 * 60);//缓存1小时
            }
            else
            {
                list = o as List<View_IMUser>;
            }
            DataIO dt = new DataIO();
            List<ClassDept> deptsinfo = new List<ClassDept>();
            IEnumerable<IGrouping<string, View_IMUser>> groupUserList = list.GroupBy(p => p.IMGroupName);

            foreach (var group in groupUserList)
            {
                ClassDept model = new ClassDept();
                model.depmc = group.Key;
                List<View_IMUser> userlst = new List<View_IMUser>();
                // 输出组内成员 
                foreach (var user in group)
                {
                    if (user.ID == myid)
                    {
                        continue;
                    }
                    model.depid = user.DepartID;
                    userlst.Add(user);
                }

                model.userlist = userlst;
                deptsinfo.Add(model);
            }
            return deptsinfo;
        }






    }
}
