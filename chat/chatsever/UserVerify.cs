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
        public static View_IMUser verifyUser(string username, string userpwd, string Ip, int Port)
        {
            View_IMUser user = new View_IMUser();
             
            string error;
            string groupname;
            View_IMUser userinfo = new AuthorityClient.LoginClient().Login(username, userpwd, Ip, Port.ToString(), out groupname, out error);
            if (string.IsNullOrWhiteSpace(error))
            {

                user.UserState = 1;
                user.Response = "登录成功！";
            }
            else
            {
                user.UserState = -1;
                user.Response = error;
            } 
            return user;
        } 
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
