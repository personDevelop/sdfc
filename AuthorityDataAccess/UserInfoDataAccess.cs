using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuthorityEntity;
using System.Data;
using Sharp.Common;

namespace AuthorityDataAccess
{
    public class UserInfoDataAccess : Sharp.Data.BaseManager
    {


        public bool Exists(string code, string email, string agentid, string id, ref string error)
        {
            bool exist = Dal.Exists<UserInfo>(
              UserInfo._.ID != id && UserInfo._.Code == code);
            if (exist)
            {
                error = "已存在相同编号";

            }
            else
            {
                if (!string.IsNullOrWhiteSpace(email))
                {
                    exist = Dal.Exists<UserInfo>(
                               UserInfo._.ID != id && UserInfo._.Email == email);
                    if (exist)
                    {
                        error = "已存在相同邮箱";
                    }
                }
                if (!exist)
                {
                    if (!string.IsNullOrWhiteSpace(agentid))
                    {
                        exist = Dal.Exists<UserInfo>(
                                   UserInfo._.ID != id && UserInfo._.AgentID == agentid);
                        if (exist)
                        {
                            error = "当前坐席工号已被使用";
                        }
                        else
                        {

                            object o = Dal.FromCustomSql("SELECT count(1) FROM TTSUser  where code=@code").AddInputParameter("code", agentid).ToScalar();
                            if (!o.Equals(0))
                            {
                                exist = true;
                                error = "当前坐席工号已被TTS使用";
                            }
                        }
                    }
                }

            }

            return exist;
        }

        public int Save(UserInfo DataObject, List<OrganizationInfo> Departlist, List<Role> Rolelist, ref string error)
        {
            List<OrgUserRalation> list = new List<OrgUserRalation>();
            foreach (var item in Departlist)
            {
                OrgUserRalation orgUserR = new OrgUserRalation();
                orgUserR.ID = Guid.NewGuid().ToString();
                orgUserR.CompID = item.CompID;
                orgUserR.DepartID = item.ID;
                orgUserR.IsDefault = item.IsDefault;
                orgUserR.PositionID = item.PositionID;
                orgUserR.UserID = DataObject.ID;
                list.Add(orgUserR);
            }
            List<RoleAndUserRalation> rolelist = new List<RoleAndUserRalation>();
            foreach (var item in Rolelist)
            {
                RoleAndUserRalation rr = new RoleAndUserRalation();
                rr.ID = Guid.NewGuid().ToString();
                rr.IsDefault = item.IsDefault;
                rr.RoleId = item.ID;
                rr.UserId = DataObject.ID;
                rolelist.Add(rr);
            }
            Sharp.Data.SessionFactory dal = null;
            IDbTransaction tr = Dal.BeginTransaction(out dal);
            int i = 0;
            error = "";
            try
            {
                i = dal.SubmitNew(ref dal, DataObject);
                //删除原有组织关系
                dal.Delete<OrgUserRalation>(OrgUserRalation._.UserID == DataObject.ID, tr);
                dal.SubmitNew(tr, ref dal, list);
                //删除原有角色关系
                dal.Delete<RoleAndUserRalation>(RoleAndUserRalation._.UserId == DataObject.ID, tr);
                dal.SubmitNew(tr, ref dal, rolelist);
                dal.CommitTransaction(tr);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                i = 0;
                dal.RollbackTransaction(tr);
                throw;
            }
            return i;

        }

        public DataTable GetAllUser()
        {
            DataTable dt = Dal.From<UserInfo>().Join<OrgUserRalation>(UserInfo._.ID == OrgUserRalation._.UserID && OrgUserRalation._.IsDefault == true, Sharp.Common.JoinType.leftJoin)
                .Join<OrganizationInfo>(OrgUserRalation._.DepartID == OrganizationInfo._.ID, Sharp.Common.JoinType.leftJoin)
                .Join<RoleAndUserRalation>(UserInfo._.ID == RoleAndUserRalation._.UserId && RoleAndUserRalation._.IsDefault == true, Sharp.Common.JoinType.leftJoin)
                .Join<Role>(RoleAndUserRalation._.RoleId == Role._.ID, Sharp.Common.JoinType.leftJoin)

                .Select(UserInfo._.ID.All, OrganizationInfo._.ClassCode, OrganizationInfo._.Name.Alias("DeoartName"), Role._.Name.Alias("RoleName"))
                .OrderBy(UserInfo._.Code).ToDataTable();
            DataColumn dc = new DataColumn("IsSelected", typeof(bool));
            dc.DefaultValue = false;
            dt.Columns.Add(dc);
            return dt;
        }

        public int ResetPwd(string userid, string newpwd, string oldPwd = null)
        {
            UserInfo u = new UserInfo();
            u.ID = userid;
            u.RecordStatus = Sharp.Common.StatusType.update;
            u.Pwd = newpwd;
            return Dal.Submit(u);

        }

        public int DeleteUser(string userid)
        {
            UserInfo u = new UserInfo();
            u.ID = userid;
            u.RecordStatus = Sharp.Common.StatusType.delete;
            OrgUserRalation or = new OrgUserRalation();
            or.Where = OrgUserRalation._.UserID == userid;
            or.RecordStatus = Sharp.Common.StatusType.delete;
            RoleAndUserRalation rr = new RoleAndUserRalation();
            rr.Where = RoleAndUserRalation._.UserId == userid;
            rr.RecordStatus = Sharp.Common.StatusType.delete;
            Sharp.Data.SessionFactory dal = null;
            return Dal.SubmitNew(ref dal, u, or, rr);
        }

        public int BatchSetOrg(string[] ids, string[] orgIds, string[] companyIDS, string positionID)
        {
            int k = 0;
            List<OrgUserRalation> ORlist = new List<OrgUserRalation>();
            List<OrgUserRalation> DeleteORlist = new List<OrgUserRalation>();
            foreach (var userid in ids)
            {
                bool isDefalut = true;
                for (int i = 0; i < orgIds.Length; i++)
                {

                    OrgUserRalation or = new OrgUserRalation();
                    or.ID = Guid.NewGuid().ToString();
                    or.CompID = companyIDS[i];
                    or.DepartID = orgIds[i];
                    or.IsDefault = isDefalut;
                    or.UserID = userid;
                    or.PositionID = positionID;
                    isDefalut = false;
                    ORlist.Add(or);
                    OrgUserRalation deleor = new OrgUserRalation();
                    deleor.RecordStatus = Sharp.Common.StatusType.delete;
                    deleor.Where = OrgUserRalation._.UserID == userid && OrgUserRalation._.DepartID == or.DepartID;
                    DeleteORlist.Add(deleor);
                }
            }
            //先删后赠

            Sharp.Data.SessionFactory dal = null;
            IDbTransaction tr = Dal.BeginTransaction(out dal);
            try
            {
                //删
                k = dal.SubmitNew(tr, ref dal, DeleteORlist);
                //将原先默认排除掉
                OrgUserRalation r = new OrgUserRalation();
                r.Where = OrgUserRalation._.UserID.In(ids) && OrgUserRalation._.IsDefault == true;
                r.RecordStatus = Sharp.Common.StatusType.update;
                r.IsDefault = false;
                dal.Update(r, null, tr);
                //新增
                k = dal.SubmitNew(tr, ref dal, ORlist);
                dal.CommitTransaction(tr);

            }
            catch (Exception)
            {
                dal.RollbackTransaction(tr);

                throw;
            }
            return k;
        }

        public int BatchSetRole(string[] ids, string[] roleids)
        {
            int k = 0;
            List<RoleAndUserRalation> ORlist = new List<RoleAndUserRalation>();
            List<RoleAndUserRalation> DeleteORlist = new List<RoleAndUserRalation>();
            foreach (var userid in ids)
            {
                bool isDefalut = true;
                for (int i = 0; i < roleids.Length; i++)
                {

                    RoleAndUserRalation or = new RoleAndUserRalation();
                    or.ID = Guid.NewGuid().ToString();
                    or.RoleId = roleids[i];
                    or.IsDefault = isDefalut;
                    or.UserId = userid;
                    ORlist.Add(or);
                    isDefalut = false;

                    RoleAndUserRalation deleor = new RoleAndUserRalation();
                    deleor.RecordStatus = Sharp.Common.StatusType.delete;
                    deleor.Where = RoleAndUserRalation._.UserId == userid && RoleAndUserRalation._.RoleId == or.RoleId;
                    DeleteORlist.Add(deleor);
                }
            }
            //先删后赠

            Sharp.Data.SessionFactory dal = null;
            IDbTransaction tr = Dal.BeginTransaction(out dal);
            try
            {
                //删
                k = dal.SubmitNew(tr, ref dal, DeleteORlist);
                //将原先默认排除掉
                RoleAndUserRalation r = new RoleAndUserRalation();
                r.Where = RoleAndUserRalation._.UserId.In(ids) && RoleAndUserRalation._.IsDefault == true;
                r.RecordStatus = Sharp.Common.StatusType.update;
                r.IsDefault = false;
                dal.Update(r, null, tr);
                //新增
                k = dal.SubmitNew(tr, ref dal, ORlist);
                dal.CommitTransaction(tr);

            }
            catch (Exception)
            {
                dal.RollbackTransaction(tr);

                throw;
            }
            return k;
        }

        public OrganizationInfo GetDepartInfo(string userID)
        {
            OrgUserRalation orgUserR = new OrgUserRalation();
            DataTable dt = Dal.From<OrgUserRalation>().Join<OrganizationInfo>(OrgUserRalation._.DepartID == OrganizationInfo._.ID)
                .Where(OrgUserRalation._.UserID == userID).Select(OrganizationInfo._.ID, OrgUserRalation._.IsDefault, OrganizationInfo._.Name).ToDataTable();
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            else
                if (dt.Rows.Count == 1)
                {
                    return dt.Rows[0].ToFirst<OrganizationInfo>();
                }
                else
                {
                    DataRow[] defaultRow = dt.Select("IsDefault='1'");
                    if (defaultRow != null && defaultRow.Length == 1)
                    {
                        return defaultRow[0].ToFirst<OrganizationInfo>();
                    }
                    else
                    {

                        return dt.ToFirst<OrganizationInfo>();
                    }
                }

        }

        public int SaveContacts(ref string error, Contacts contact)
        {
            //将之前的登录状态清空掉 

            if (Dal.Exists<Contacts>(Contacts._.TelNo == contact.TelNo && Contacts._.ID != contact.ID))
            {
                error = "已存在相同电话号码";
                return -1;
            }

            return Dal.Submit(contact);
        }

        public DataTable GetContacts()
        {
            DataTable dt = Dal.From<Contacts>().ToDataTable();
            DataColumn dc = new DataColumn("IsSelected", typeof(bool));
            dc.DefaultValue = false;
            dt.Columns.Add(dc);
            return dt;
        }

        public DataTable GetContactsWithNameOrTel(string nameOrTel)
        {
            DataTable dt = Dal.From<Contacts>().Where(Contacts._.Name.Contains(nameOrTel) || Contacts._.TelNo.Contains(nameOrTel)).ToDataTable();
            DataColumn dc = new DataColumn("IsSelected", typeof(bool));
            dc.DefaultValue = false;
            dt.Columns.Add(dc);
            return dt;

        }

        public string[] GetContactGroup()
        {
            return Dal.From<Contacts>().Where(Contacts._.GroupName != null && Contacts._.GroupName != string.Empty).Select(Contacts._.GroupName).Distinct().ToSinglePropertyArray();
        }

        public int DeleteUserTxl(string txlid)
        {
            return Dal.Delete<Contacts>(txlid);
        }

        public DataTable GetOnLineWf()
        {
            return Dal.From<SystemSessionLog>()
                .Join<UserInfo>(SystemSessionLog._.UserID == UserInfo._.ID)
                .Where(
                UserInfo._.IsWebPerson == true
                && SystemSessionLog._.OutDate == null)
                .ToDataTable();
        }

        public DataTable GetIMUserList()
        {
            return Dal.From<View_IMUser>()
                .ToDataTable();
        }
    }
}
