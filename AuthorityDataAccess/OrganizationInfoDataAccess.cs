using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuthorityEntity;
using System.Data;

namespace AuthorityDataAccess
{
    public class OrganizationInfoDataAccess : Sharp.Data.BaseManager
    {
        public bool Exit(string id, string parentID, string code, string name, ref string errorMsg)
        {
            bool exist = Dal.Exists<OrganizationInfo>(OrganizationInfo._.ParentID == parentID &&
                OrganizationInfo._.ID != id && OrganizationInfo._.Code == code);
            if (exist)
            {
                errorMsg = "已存在相同编号";

            }
            else
            {
                exist = Dal.Exists<OrganizationInfo>(OrganizationInfo._.ParentID == parentID &&
                    OrganizationInfo._.ID != id && OrganizationInfo._.Name == name);
                if (exist)
                {
                    errorMsg = "已存在相同名称";
                }

            }
            return exist;
        }

        public int Delete(string classcode, ref string error)
        {
            string[] orgids = Dal.From<OrganizationInfo>().Where(OrganizationInfo._.ClassCode.StartsWith(classcode)).Select(OrganizationInfo._.ID).ToSinglePropertyArray();
            if (Dal.Exists < OrgUserRalation>(OrgUserRalation._.DepartID.In(orgids) || OrgUserRalation._.CompID.In(orgids)))
            {
                error="当前部门或其下属部门已被员工使用，不能删除";
                return -1;
            }
            return Dal.Delete<OrganizationInfo>(OrganizationInfo._.ClassCode.StartsWith(classcode));

        }

        public int Save(OrganizationInfo item)
        {
            if (item.RecordStatus == Sharp.Common.StatusType.add && item.ParentID != null)
            {
                //更新父亲节点的是否明细
                OrganizationInfo p = new OrganizationInfo();
                p.ID = item.ParentID;
                p.RecordStatus = Sharp.Common.StatusType.update;
                p.IsDetails = false;
                return Dal.Submit(p, item);


            }
            else
                return Dal.Submit(item);
        }

        public System.Data.DataTable GetAllList()
        {
            return Dal.From<OrganizationInfo>().OrderBy(OrganizationInfo._.Code).ToDataTable();

        }

        public UserInfo GetUserInfo(string UserID)
        {

            return Dal.Find<UserInfo>(UserID);

        }
        /// <summary>
        /// 根据用户ID,查找其部门负责人
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public UserInfo GetFzr(string UserID)
        {
            string departID = Dal.From<OrgUserRalation>().Where(OrgUserRalation._.IsDefault == true && OrgUserRalation._.UserID == UserID).Select(OrgUserRalation._.DepartID).ToScalar() as string;
            return Dal.From<UserInfo>().Join<OrganizationInfo>(OrganizationInfo._.ID == departID && UserInfo._.ID == OrganizationInfo._.LegalerID).Select(UserInfo._.ID.All).ToFirst<UserInfo>();

        }
        /// <summary>
        /// 根据用户ID,查找其上级部门负责人
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public UserInfo GetSjBmFzr(string UserID)
        {
            string departID = Dal.From<OrgUserRalation>().Where(OrgUserRalation._.IsDefault == true && OrgUserRalation._.UserID == UserID).Select(OrgUserRalation._.DepartID).ToScalar() as string;

            OrganizationInfo depart = Dal.Find<OrganizationInfo>(departID);
            OrganizationInfo parentDepart = Dal.Find<OrganizationInfo>(depart.ParentID);
            if (parentDepart != null)
            {
                return Dal.From<UserInfo>().Join<OrganizationInfo>(OrganizationInfo._.ID == parentDepart.ID && UserInfo._.ID == OrganizationInfo._.LegalerID).Select(UserInfo._.ID.All).ToFirst<UserInfo>();

            }
            else
            {
                return null;
            }


        }

        public DataTable GetUserList(string[] departIDs)
        {

            DataTable dt = Dal.From<UserInfo>().
                Join<OrgUserRalation>(UserInfo._.ID == OrgUserRalation._.UserID
                && UserInfo._.Status == "在职" &&
                OrgUserRalation._.DepartID.In(departIDs))
                .Join<OrgPositions>(OrgPositions._.ID == OrgUserRalation._.PositionID)

                .Distinct().OrderBy(UserInfo._.Code).Select(UserInfo._.ID.All, OrgUserRalation._.ID.Alias("orgRalationID"), OrgUserRalation._.PositionID, OrgPositions._.Name.Alias("PositionName")).ToDataTable();
            DataColumn dc = new DataColumn("IsSelected", typeof(bool));
            dc.DefaultValue = false;
            dt.Columns.Add(dc);
            return dt;

        }

        public DataTable GetUserListByUserIds(string[] userIDs)
        {
            return Dal.From<UserInfo>().Where(UserInfo._.ID.In(userIDs)).OrderBy(UserInfo._.Code).ToDataTable();
        }

        public DataTable GetOrgnizationByUserID(string userID)
        {

            string sql = @"SELECT     OrganizationInfo.ID, OrganizationInfo.Code, OrganizationInfo.Name, OrganizationInfo.FullName, ParameterInfo.Name AS OrgTypeName, 
                      OrgUserRalation.IsDefault, OrgPositions.Name AS PositionName, OrgPositions.ID AS PositionID, OrganizationInfo_1.Name AS CompanyName, 
                      OrganizationInfo.CompID
FROM         OrganizationInfo INNER JOIN
                      OrgUserRalation ON OrganizationInfo.ID = OrgUserRalation.DepartID INNER JOIN
                      OrgPositions ON OrgUserRalation.PositionID = OrgPositions.ID INNER JOIN
                      OrganizationInfo AS OrganizationInfo_1 ON OrganizationInfo.CompID = OrganizationInfo_1.ID INNER JOIN
                      ParameterInfo ON OrganizationInfo.OrgType = ParameterInfo.ID
where OrgUserRalation.UserID=@userid

Order  by OrganizationInfo_1.code,OrganizationInfo.Code";

            return Dal.FromCustomSql(sql).AddInputParameter("userid", userID).ToDataTable();
            //return Dal.From<OrganizationInfo>().
            //    Join<OrgUserRalation>(OrgUserRalation._.UserID == userID &&
            //    OrgUserRalation._.DepartID == OrganizationInfo._.ID)
            //    .Join<OrgPositions>(OrgPositions._.ID == OrgUserRalation._.PositionID)
            //    .Select(OrganizationInfo._.ID.All,OrgUserRalation._.IsDefault, OrgUserRalation._.PositionID, OrgPositions._.Name.Alias("PositionName")).OrderBy(UserInfo._.Code).ToDataTable();
        }

        /// <summary>
        /// 查询专用
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableWithSelect()
        {
            string sql = @"SELECT     OrganizationInfo.ID, OrganizationInfo.Code, OrganizationInfo.Name, OrganizationInfo.FullName, ParameterInfo.Name AS OrgTypeName, 
                      OrganizationInfo_1.Name AS CompanyName, OrganizationInfo.CompID, OrganizationInfo.ParentID, OrganizationInfo.Enable, 
                      OrganizationInfo.ComType
FROM         OrganizationInfo INNER JOIN
                      OrganizationInfo AS OrganizationInfo_1 ON OrganizationInfo.CompID = OrganizationInfo_1.ID INNER JOIN
                      ParameterInfo ON OrganizationInfo.OrgType = ParameterInfo.ID
WHERE     (OrganizationInfo.Enable = 1) 
Order  by  OrganizationInfo.Code";
            return Dal.FromCustomSql(sql).ToDataTable();
        }

        public DataTable GetDataTableWithSelectTree()
        {
            return Dal.From<OrganizationInfo>().Select(OrganizationInfo._.ID, OrganizationInfo._.ParentID, OrganizationInfo._.Code, OrganizationInfo._.Name, OrganizationInfo._.ClassCode).Where
                (OrganizationInfo._.Enable == true).OrderBy(OrganizationInfo._.Code).ToDataTable();
        }

        public int SaveOrgList(List<OrgUserRalation> orgList)
        {
            Sharp.Data.SessionFactory dal = null;
            return Dal.SubmitNew(orgList, ref dal);
        }

        public int RemoveUser(string departID, string[] orgUrids)
        {

            return Dal.Delete<OrgUserRalation>(OrgUserRalation._.DepartID == departID && OrgUserRalation._.ID.In(orgUrids));
        }


    }
}
