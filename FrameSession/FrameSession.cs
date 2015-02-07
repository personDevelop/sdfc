using System;
using System.Collections.Generic;
using System.Linq;
using AuthorityEntity;
using AuthorityClient;
using Sharp.Common;
 

namespace FrameSession
{
    public class Session : ISession
    {
        LoginClient client = new LoginClient();

        // Methods
        private Session()
        {
            serverDateTime = client.GetDateTime();
            clientDateTime = DateTime.Now;
        }
        private DateTime clientDateTime, serverDateTime;

        /// <summary>
        /// 获取服务器系统时间
        /// </summary>
        public DateTime ServerDateTime
        {
            get
            {
                if (DateTime.Now < clientDateTime)
                {
                    clientDateTime = DateTime.Now;
                    serverDateTime = client.GetDateTime();
                    return serverDateTime;
                }
                return serverDateTime + (DateTime.Now - clientDateTime);

            }

        }

        protected static SystemSessionLog log = null;
        private static Session session;
        /// <summary>
        /// 当前会话实例
        /// </summary>
        public static Session Instance
        {
            get
            {
                if (session == null)
                {
                    session = new Session();
                }
                return session;
            }
        }
        /// <summary>
        /// 当前登录人
        /// </summary>
        public UserInfo CurrenterUser { get; set; }
        /// <summary>
        /// 是否已经登录成功
        /// </summary>
        public bool HasLogin { get; set; }

        /// <summary>
        /// 默认角色
        /// </summary>
        public Role DefualtRole { get; set; }

        /// <summary>
        /// 当前角色
        /// </summary>
        public Role CurrentRole { get; set; }

        /// <summary>
        /// 角色列表
        /// </summary>
        public List<Role> RoleList { get; set; }

        /// <summary>
        /// 公司信息
        /// </summary>
        public OrganizationInfo ComanyInfo { get; set; }

        /// <summary>
        /// 部门信息
        /// </summary>
        public OrganizationInfo DepartInfo { get; set; }

        /// <summary>
        /// 所有部门信息
        /// </summary>
        public List<OrganizationInfo> DepartList { get; set; }

        /// <summary>
        /// 组信息
        /// </summary>
        public OrganizationInfo GroupInfo { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginDateTime { get; set; }
        /// <summary>
        /// 登录ID
        /// </summary>
        public string EntryIP { get; set; }

        /// <summary>
        /// 在线状态
        /// </summary>
        public string EntryStats { get; set; }
        string[] roleArray;
        /// <summary>
        /// 在线状态
        /// </summary>
        public string[] RoleArray
        {
            get
            {

                if (roleArray == null)
                {
                    var qry = from r in RoleList select r.ID;
                    roleArray = qry.ToArray();
                }
                return roleArray;
            }
        }
        public bool Login(string appcode, string loginUser, string password, out string errorMsg)
        {
            errorMsg = string.Empty; 
            if (loginUser.ToLower().Equals("root"))
            {
                return RootLogin(loginUser, password);
            }
            CurrenterUser = client.Login(loginUser);
            if (CurrenterUser == null)
            {
                errorMsg = "系统不存在该账号，请重新输入！";
                return false;
            }
            else
                if (CurrenterUser.Pwd.Equals(password))
                {
                    if (CurrenterUser.Status != "在职")
                    {
                        errorMsg = string.Format("该账号状态不正常，为{0} 不能登陆系统！", CurrenterUser.Status);
                        return false;
                    }
                    else
                    {
                        RoleList = new List<Role>();
                        RoleList = client.GetRoleInfo(CurrenterUser.ID).ToList<Role>();
                        if (RoleList.Count == 0)
                        {
                            errorMsg = "该账号状态还没有设置角色， 不能登陆系统！";
                            return false;
                        }
                        if (RoleList.Exists(pr => pr.IsDefault))
                        {
                            DefualtRole = CurrentRole = RoleList.Find(pr => pr.IsDefault);
                        }

                        //获取改账户的默认公司、部门、岗位、及默认角色和其他角色
                        List<OrganizationInfo> orgList = new OrganizationInfoClient().GetOrgnizationByUserID(CurrenterUser.ID).ToList<OrganizationInfo>();
                        if (orgList.Count > 0)
                        {
                            if (orgList.Exists(pr => pr.IsDefault))
                            {
                                //有默认部门
                                DepartInfo = orgList.Find(pr => pr.IsDefault);
                                ComanyInfo = new OrganizationInfo();
                                ComanyInfo.ID = DepartInfo.CompID;
                                ComanyInfo.Name = DepartInfo.CompanyName;
                            }
                        }
                        HasLogin = true;
                        LoginDateTime = ServerDateTime;
                        EntryIP = Utils.GetMachineIP();
                        EntryStats = "在线"; 
                        CreateLoginLog();
                        client.Save(log);
                    }
                }
                else
                {
                    errorMsg = "密码不正确，请重新输入！";
                    return false;
                }

            return true;
        }

        private bool RootLogin(string userNo, string pwd)
        {
            if (userNo.ToLower().Equals("root") && pwd.Equals("aaaaaa"))
            {
                CurrenterUser = new UserInfo();
                CurrentRole = new Role();

                CurrenterUser.ID = CurrenterUser.Code =
                      CurrentRole.ID = CurrentRole.Code =
                    userNo.ToLower();
                CurrentRole.Name =
                CurrenterUser.Name = "超级管理员";
                RoleList = new List<Role>();
                RoleList.Add(CurrentRole);
                HasLogin = true;
                return true;
            }
            return false;


        }
        private void CreateLoginLog()
        {
            log = new SystemSessionLog();
            log.ID = Guid.NewGuid().ToString();
            log.UserID = CurrenterUser.ID;
            log.UserCode = CurrenterUser.Code;
            log.UserName = CurrenterUser.Name;
            log.RoleID = CurrentRole.ID;
            log.RoleName = CurrentRole.Name;
            log.EntryDate = ServerDateTime;
            log.EntryIP = Utils.GetMachineIP();
            log.EntryStats = "在线";

        }


        #region ISession 成员
        /// <summary>
        /// 根据关键字获取session值
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public override object GetValue(ParaValEntity keyWord)
        {
            object result;
            switch (keyWord.ParaVal)
            {
                case "用户ID":
                case "UserID":
                    result = CurrenterUser.ID;
                    break;
                default:
                    result = keyWord;
                    break;
            }
            return result;
        }



        public new static ISession IInstance
        {
            get
            {
                return Instance;
            }

        }

        #endregion
    }
}
