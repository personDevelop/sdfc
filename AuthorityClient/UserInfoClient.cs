using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuthorityService;
using AuthorityClient.UserInfoSer;
using AuthorityEntity;
using System.Data;

namespace AuthorityClient
{

    public class UserInfoClient : FrameBaseClient.BaseClient
    {

        public UserInfoClient()
        {

            if (IsLocation)
            {
                Client = new UserInfoService();
            }
            else
            {
                Client = new UserInfoServiceClient();
            }


        }


        public bool Exists(string code, string email, string iD, ref string error)
        {
            if (IsLocation)
            {
                return (Client as UserInfoService).Exists(code, email, iD, ref   error);
            }
            else
                return (Client as UserInfoServiceClient).Exists(code, email, iD, ref   error);

        }

        public int Save(UserInfo DataObject, List<OrganizationInfo> Departlist, List<Role> Rolelist, ref string error)
        {
            if (IsLocation)
            {
                return (Client as UserInfoService).Save(DataObject, Departlist, Rolelist, ref   error);
            }
            else
                return (Client as UserInfoServiceClient).Save(DataObject, Departlist.ToArray(), Rolelist.ToArray(), ref   error);
        }

        public System.Data.DataTable GetAllUser()
        {
            if (IsLocation)
            {
                return (Client as UserInfoService).GetAllUser();
            }
            else
                return (Client as UserInfoServiceClient).GetAllUser();
        }

        public int ResetPwd(string userid, string newpwd)
        {
            if (IsLocation)
            {
                return (Client as UserInfoService).ResetPwd(userid, newpwd);
            }
            else
                return (Client as UserInfoServiceClient).ResetPwd(userid, newpwd);
        }

        public int DeleteUser(string userid)
        {
            if (IsLocation)
            {
                return (Client as UserInfoService).DeleteUser(userid);
            }
            else
                return (Client as UserInfoServiceClient).DeleteUser(userid);
        }

        public int BatchSetOrg(string[] ids, string[] orgIds, string[] companyIDS, string positionID)
        {
            if (IsLocation)
            {
                return (Client as UserInfoService).BatchSetOrg(ids, orgIds, companyIDS, positionID);
            }
            else
                return (Client as UserInfoServiceClient).BatchSetOrg(ids, orgIds, companyIDS, positionID);

        }

        public int BatchSetRole(string[] ids, string[] roleids)
        {
            if (IsLocation)
            {
                return (Client as UserInfoService).BatchSetRole(ids, roleids);
            }
            else
                return (Client as UserInfoServiceClient).BatchSetRole(ids, roleids);

        }



        public OrganizationInfo GetDepartInfo(string userID)
        {
            if (IsLocation)
            {
                return (Client as UserInfoService).GetDepartInfo(userID);
            }
            else
                return (Client as UserInfoServiceClient).GetDepartInfo(userID);
        }

        public int SaveContacts(ref string error, Contacts contact)
        {
            if (IsLocation)
            {
                return (Client as UserInfoService).SaveContacts(ref   error, contact);
            }
            else
                return (Client as UserInfoServiceClient).SaveContacts(ref   error, contact);
        }

        public DataTable GetContacts()
        {
            if (IsLocation)
            {
                return (Client as UserInfoService).GetContacts();
            }
            else
                return (Client as UserInfoServiceClient).GetContacts();
        }

        public object GetContactsWithNameOrTel(string nameOrTel)
        {
            if (IsLocation)
            {
                return (Client as UserInfoService).GetContactsWithNameOrTel(nameOrTel);
            }
            else
                return (Client as UserInfoServiceClient).GetContactsWithNameOrTel(nameOrTel);
        }

        public string[] GetContactGroup()
        {
            if (IsLocation)
            {
                return (Client as UserInfoService).GetContactGroup( );
            }
            else
                return (Client as UserInfoServiceClient).GetContactGroup( );
        }
    }
}
