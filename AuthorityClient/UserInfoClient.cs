using System.Collections.Generic;
using AuthorityService;
using AuthorityEntity;
using System.Data;
using FrameBaseClient;
using IAuthorityService;
using Sharp.Common;
namespace AuthorityClient
{

    public class UserInfoClient : FrameBaseClient.BaseClient
    {
        IUserInfoService currentClient;
        IUserInfoService CurrentClient
        {
            get
            {
                if (currentClient == null)
                {
                    if (IsLocation)
                    {
                        currentClient = new UserInfoService();
                    }
                    else
                    {
                        currentClient = WcfInvokeContext.CreateWCFService<IUserInfoService>("UserInfoService");
                    }
                }
                return currentClient;
            }
        }


        public bool Exists(string code, string email, string iD, ref string error)
        {

            return CurrentClient.Exists(code, email, iD, ref   error);

        }

        public int Save(UserInfo DataObject, List<OrganizationInfo> Departlist, List<Role> Rolelist, ref string error)
        {
            return CurrentClient.Save(DataObject, Departlist, Rolelist, ref   error);
        }

        public System.Data.DataTable GetAllUser()
        {
            return CurrentClient.GetAllUser();
        }

        public int ResetPwd(string userid, string newpwd, string oldPwd = null)
        {
            return CurrentClient.ResetPwd(userid, newpwd, oldPwd);
        }

        public int DeleteUser(string userid)
        {
            return CurrentClient.DeleteUser(userid);
        }

        public int BatchSetOrg(string[] ids, string[] orgIds, string[] companyIDS, string positionID)
        {
            return CurrentClient.BatchSetOrg(ids, orgIds, companyIDS, positionID);
        }

        public int BatchSetRole(string[] ids, string[] roleids)
        {
            return CurrentClient.BatchSetRole(ids, roleids);
        }



        public OrganizationInfo GetDepartInfo(string userID)
        {
            return CurrentClient.GetDepartInfo(userID);
        }

        public int SaveContacts(ref string error, Contacts contact)
        {
            return CurrentClient.SaveContacts(ref   error, contact);
        }

        public DataTable GetContacts()
        {
            return CurrentClient.GetContacts();
        }

        public object GetContactsWithNameOrTel(string nameOrTel)
        {
            return CurrentClient.GetContactsWithNameOrTel(nameOrTel);
        }

        public string[] GetContactGroup()
        {
            return CurrentClient.GetContactGroup();
        }

        public int DeleteUserTxl(string txlid)
        {
            return CurrentClient.DeleteUserTxl(txlid);
        }

        /// <summary>
        /// 获取所有在线网服 
        /// </summary>
        /// <returns></returns>
        public DataTable GetOnLineWf()
        {
            return CurrentClient.GetOnLineWf();
        }

        /// <summary>
        /// 获取即时通讯用户列表 
        /// </summary>
        /// <param name="myUserid"></param>
        /// <returns></returns>
        public DataTable GetIMUserList()
        {
            return CurrentClient.GetIMUserList();
        }


        public void DeleteUserRole(string p, string p_2)
        {
            throw new System.NotImplementedException();
        }
    }
}
