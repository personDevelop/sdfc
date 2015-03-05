using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using AuthorityDataAccess;
using AuthorityEntity;
using System.Data;
using IAuthorityService;
namespace AuthorityService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“OrganizationInfoService”。
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class OrganizationInfoService : IOrganizationInfoService
    {
        OrganizationInfoDataAccess da = new OrganizationInfoDataAccess();

        public System.Data.DataTable GetAllList()
        {
            return da.GetAllList();
        }
        public DataTable GetDataTableWithSelect()
        {
            return da.GetDataTableWithSelect();
        }
        public int Save(AuthorityEntity.OrganizationInfo p)
        {
            return da.Save(p);
        }

        public int Delete(string classcode, ref string error)
        {
            return da.Delete(classcode, ref    error);
        }

        public bool Exit(string id, string parentID, string code, string name, ref string errorMsg)
        {
            return da.Exit(id, parentID, code, name, ref errorMsg);
        }
        public UserInfo GetUserInfo(string UserID)
        {

            return da.GetUserInfo(UserID);

        }
        /// <summary>
        /// 根据用户ID,查找其部门负责人
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public UserInfo GetFzr(string UserID)
        {
            return da.GetFzr(UserID);

        }
        /// <summary>
        /// 根据用户ID,查找其上级部门负责人
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public UserInfo GetSjBmFzr(string UserID)
        {
            return da.GetSjBmFzr(UserID);

        }

        public DataTable GetUserList(string[] departIDs)
        {
            return da.GetUserList(departIDs);
        }

        public DataTable GetUserListByUserIds(string[] userIDs)
        {
            return da.GetUserListByUserIds(userIDs);
        }

        public DataTable GetOrgnizationByUserID(string userID)
        {
            return da.GetOrgnizationByUserID(userID);
        }

        public DataTable GetDataTableWithSelectTree()
        {
            return da.GetDataTableWithSelectTree();
        }

        public int SaveOrgList(List<OrgUserRalation> orgList)
        {
            return da.SaveOrgList(orgList);
        }

        public int RemoveUser(string departID, string[] userids)
        {
            return da.RemoveUser(departID, userids);
        }


    }
}
