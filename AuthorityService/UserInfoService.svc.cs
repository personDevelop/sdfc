﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using AuthorityEntity;
using AuthorityDataAccess;
using System.Data;

namespace AuthorityService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“UserInfoService”。
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class UserInfoService : IUserInfoService
    {
        UserInfoDataAccess da = new UserInfoDataAccess();




        public bool Exists(string code, string email, string iD, ref string error)
        {
            return da.Exists(code, email, iD, ref   error);
        }

        public int Save(UserInfo DataObject, List<OrganizationInfo> Departlist, List<Role> Rolelist, ref string error)
        {
            return da.Save(DataObject, Departlist, Rolelist, ref   error);
        }

        public DataTable GetAllUser()
        {
            return da.GetAllUser();
        }

        public int ResetPwd(string userid, string newpwd)
        {
            return da.ResetPwd(userid, newpwd);
        }

        public int DeleteUser(string userid)
        {
            return da.DeleteUser(userid);
        }

        public int BatchSetOrg(string[] ids, string[] orgIds, string[] companyIDS, string positionID)
        {
            return da.BatchSetOrg(ids, orgIds, companyIDS, positionID);
            
        }

        public int BatchSetRole(string[] ids, string[] roleids)
        {
            return da.BatchSetRole(ids, roleids);
            
        }

        public OrganizationInfo GetDepartInfo(string userID)
        {
            return da.GetDepartInfo(userID);
        }
    }
}
