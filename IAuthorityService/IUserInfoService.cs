using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AuthorityEntity;
using System.Data;

namespace IAuthorityService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IUserInfoService”。
    [ServiceContract]
    public interface IUserInfoService
    {
        [OperationContract]
        DataTable GetAllUser();
        [OperationContract]
        int Save(UserInfo DataObject, List<OrganizationInfo> Departlist, List<Role> Rolelist, ref string error);
        [OperationContract]
        bool Exists(string code, string email, string iD, ref string error);
        [OperationContract]
        int ResetPwd(string userid, string newpwd);
        [OperationContract]
        int DeleteUser(string userid);
        [OperationContract]
        int BatchSetOrg(string[] ids, string[] orgIds, string[] companyIDS, string positionID);
        [OperationContract]
        int BatchSetRole(string[] ids, string[] roleids);
        [OperationContract]
        OrganizationInfo GetDepartInfo(string userID);
        [OperationContract]
        int SaveContacts(ref string error, Contacts contact);
        [OperationContract]
        DataTable GetContacts();
        [OperationContract]
        DataTable GetContactsWithNameOrTel(string nameOrTel);
          [OperationContract]
        string[] GetContactGroup();
               [OperationContract]
          int DeleteUserTxl(string txlid);
              [OperationContract]
               DataTable GetWf();
    }
}
