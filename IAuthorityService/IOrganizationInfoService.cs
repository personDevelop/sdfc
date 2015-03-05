using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using AuthorityEntity;

namespace IAuthorityService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IOrganizationInfoService”。
    [ServiceContract]
    public interface IOrganizationInfoService
    {
        [OperationContract]
        DataTable GetAllList();
         [OperationContract]
        DataTable GetDataTableWithSelect();
         [OperationContract]
         DataTable GetDataTableWithSelectTree();
        [OperationContract]
        int Save(OrganizationInfo p);

        [OperationContract]
        int Delete(string classcode, ref string error);
        [OperationContract]
        bool Exit(string id, string parentID, string code, string name, ref string errorMsg);
        [OperationContract]
        UserInfo GetFzr(string UserID);
        [OperationContract]
        UserInfo GetSjBmFzr(string UserID);
        [OperationContract]
        DataTable GetUserList(string[] departIDs);
        [OperationContract]
        DataTable GetUserListByUserIds(string[] userIDs);
        [OperationContract]
        DataTable GetOrgnizationByUserID(string userID);

        [OperationContract]
        int SaveOrgList(List<OrgUserRalation> orgList);
          [OperationContract]
        int RemoveUser(string departID, string[] userids);
        [OperationContract]
          UserInfo GetUserInfo(string UserID);
    }
}
