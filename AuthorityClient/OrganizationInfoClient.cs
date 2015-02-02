using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sharp.Common;
using System.Runtime.Serialization;
using System.Data;
using AuthorityEntity;
using AuthorityService;
using AuthorityClient.OrganizationInfoSer;

namespace AuthorityClient
{
    public class OrganizationInfoClient : FrameBaseClient.BaseClient
    {
        public OrganizationInfoClient()
        {

            if (IsLocation)
            {
                Client = new OrganizationInfoService();
            }
            else
            {
                Client = new OrganizationInfoServiceClient();
            }

        }


        public bool Exit(string id, string parentID, string code, string name, ref string errorMsg)
        {
            if (IsLocation)
            {
                return (Client as OrganizationInfoService).Exit(id, parentID, code, name, ref errorMsg);
            }
            else
                return (Client as OrganizationInfoServiceClient).Exit(id, parentID, code, name, ref errorMsg);


        }

        public int Save(OrganizationInfo item)
        {
            if (IsLocation)
            {
                return (Client as OrganizationInfoService).Save(item);
            }
            else
                return (Client as OrganizationInfoServiceClient).Save(item);


        }

        public int Delete(string classcode, ref string error)
        {
            if (IsLocation)
            {
                return (Client as OrganizationInfoService).Delete(classcode, ref error);
            }
            else
                return (Client as OrganizationInfoServiceClient).Delete(classcode, ref error);


        }

        public DataTable GetAllDataTable()
        {
            if (IsLocation)
            {
                return (Client as OrganizationInfoService).GetAllList();
            }
            else
                return (Client as OrganizationInfoServiceClient).GetAllList();


        }
        public DataTable GetDataTableWithSelect()
        {
            if (IsLocation)
            {
                return (Client as OrganizationInfoService).GetDataTableWithSelect();
            }
            else
                return (Client as OrganizationInfoServiceClient).GetDataTableWithSelect();


        }
        /// <summary>
        /// 根据用户ID,查找其部门负责人
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public UserInfo GetFzr(string UserID)
        {
            if (IsLocation)
            {
                return (Client as OrganizationInfoService).GetFzr(UserID);
            }
            else
                return (Client as OrganizationInfoServiceClient).GetFzr(UserID);

        }
        public UserInfo GetUserInfo(string UserID)
        {

            if (IsLocation)
            {
                return (Client as OrganizationInfoService).GetUserInfo(UserID);
            }
            else
                return (Client as OrganizationInfoServiceClient).GetUserInfo(UserID);

        }
        /// <summary>
        /// 根据用户ID,查找其上级部门负责人
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public UserInfo GetSjBmFzr(string UserID)
        {
            if (IsLocation)
            {
                return (Client as OrganizationInfoService).GetSjBmFzr(UserID);
            }
            else
                return (Client as OrganizationInfoServiceClient).GetSjBmFzr(UserID);

        }

        public DataTable GetUserList(string[] departIDs)
        {
            if (IsLocation)
            {
                return (Client as OrganizationInfoService).GetUserList(departIDs);
            }
            else
                return (Client as OrganizationInfoServiceClient).GetUserList(departIDs);
        }

        public DataTable GetUserListByUserIds(string[] userIDs)
        {
            if (IsLocation)
            {
                return (Client as OrganizationInfoService).GetUserListByUserIds(userIDs);
            }
            else
                return (Client as OrganizationInfoServiceClient).GetUserListByUserIds(userIDs);
        }

        /// <summary>
        /// 根据用户ID,查找其所属部门
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataTable GetOrgnizationByUserID(string userID)
        {
            if (IsLocation)
            {
                return (Client as OrganizationInfoService).GetOrgnizationByUserID(userID);
            }
            else
                return (Client as OrganizationInfoServiceClient).GetOrgnizationByUserID(userID);
        }

        public DataTable GetDataTableWithSelectTree()
        {
            if (IsLocation)
            {
                return (Client as OrganizationInfoService).GetDataTableWithSelectTree();
            }
            else
                return (Client as OrganizationInfoServiceClient).GetDataTableWithSelectTree();
        }

        public int SaveOrgList(List<OrgUserRalation> orgList)
        {
            if (IsLocation)
            {
                return (Client as OrganizationInfoService).SaveOrgList(orgList);
            }
            else
                return (Client as OrganizationInfoServiceClient).SaveOrgList(orgList.ToArray());
        }

        public int RemoveUser(string departID, string[] userids)
        {
            if (IsLocation)
            {
                return (Client as OrganizationInfoService).RemoveUser(departID, userids);
            }
            else
                return (Client as OrganizationInfoServiceClient).RemoveUser(departID, userids);
        }

        
    }
}
