using System.Collections.Generic;
using System.Data;
using AuthorityEntity;
using AuthorityService;
using FrameBaseClient;
using IAuthorityService;

namespace AuthorityClient
{
    public class OrganizationInfoClient : FrameBaseClient.BaseClient
    {
        IOrganizationInfoService currentClient;
        IOrganizationInfoService CurrentClient
        {
            get
            {
                if (currentClient == null)
                {
                    if (IsLocation)
                    {
                        currentClient = new OrganizationInfoService();
                    }
                    else
                    {
                        currentClient = WcfInvokeContext.CreateWCFService<IOrganizationInfoService>("OrganizationInfoService");
                    }
                }
                return currentClient;
            }
        }



        public bool Exit(string id, string parentID, string code, string name, ref string errorMsg)
        {

            return CurrentClient.Exit(id, parentID, code, name, ref errorMsg);

        }

        public int Save(OrganizationInfo item)
        {

            return CurrentClient.Save(item);

        }

        public int Delete(string classcode, ref string error)
        {

            return CurrentClient.Delete(classcode, ref error);


        }

        public DataTable GetAllDataTable()
        {

            return CurrentClient.GetAllList();


        }
        public DataTable GetDataTableWithSelect()
        {

            return CurrentClient.GetDataTableWithSelect();

        }
        /// <summary>
        /// 根据用户ID,查找其部门负责人
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public UserInfo GetFzr(string UserID)
        {

            return CurrentClient.GetFzr(UserID);

        }
        public UserInfo GetUserInfo(string UserID)
        {


            return CurrentClient.GetUserInfo(UserID);

        }
        /// <summary>
        /// 根据用户ID,查找其上级部门负责人
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public UserInfo GetSjBmFzr(string UserID)
        {

            return CurrentClient.GetSjBmFzr(UserID);

        }

        public DataTable GetUserList(string[] departIDs)
        {

            return CurrentClient.GetUserList(departIDs);


        }

        public DataTable GetUserListByUserIds(string[] userIDs)
        {

            return CurrentClient.GetUserListByUserIds(userIDs);

        }

        /// <summary>
        /// 根据用户ID,查找其所属部门
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataTable GetOrgnizationByUserID(string userID)
        {

            return CurrentClient.GetOrgnizationByUserID(userID);
        }

        public DataTable GetDataTableWithSelectTree()
        {

            return CurrentClient.GetDataTableWithSelectTree();
        }

        public int SaveOrgList(List<OrgUserRalation> orgList)
        {
            return CurrentClient.SaveOrgList(orgList);
        }

        public int RemoveUser(string departID, string[] userids)
        {

            return CurrentClient.RemoveUser(departID, userids);
        }


    }
}
