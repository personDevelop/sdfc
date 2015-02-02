using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuthorityEntity;
using FrameCommonDataAccess;
using FrameCommonEntity;
using System.Data;
using Sharp.Data;

namespace AuthorityDataAccess
{
    public class RoleDataAccess : Sharp.Data.BaseManager
    {
        public System.Data.DataTable GetAllList()
        {
            return Dal.From<Role>().OrderBy(Role._.Code).ToDataTable();
        }

        public int Save(AuthorityEntity.Role item)
        {
            ParameterInfoDataAccess paraClient = new ParameterInfoDataAccess();
            ParameterInfo version = paraClient.GetEntity("478d3892-df2d-4f2b-b1f7-43d4398fcafc");//权限版本 
            if (string.IsNullOrEmpty(version.Value))
            {
                version.Value = "0";
            }
            version.Value = (int.Parse(version.Value) + 1).ToString();

            return Dal.Submit(item, version);
        }

        public int Delete(string id, ref string error)
        {
            if (Dal.Exists<RoleAndUserRalation>(RoleAndUserRalation._.RoleId == id))
            {
                error = "当前角色已被使用，不能删除";
                return -1;
            }
            ParameterInfoDataAccess paraClient = new ParameterInfoDataAccess();
            ParameterInfo version = paraClient.GetEntity("478d3892-df2d-4f2b-b1f7-43d4398fcafc");//权限版本 
            version.Value = (int.Parse(version.Value) + 1).ToString();
            SessionFactory dal;
            IDbTransaction tr = Dal.BeginTransaction(out dal);
            int i = 0;
            try
            {
                dal.SubmitNew(tr, ref dal, version);
                dal.Delete<Role>(tr, id);
                i = dal.Delete<Permission>(Permission._.RoleID == id, tr);
                dal.CommitTransaction(tr);
                return i;
            }
            catch (Exception ex)
            {
                dal.RollbackTransaction(tr);
                error = ex.Message;
                return -1;
                throw;
            }


        }

        public bool Exit(string id, string code, string name, ref string errorMsg)
        {
            bool exist = Dal.Exists<Role>(Role._.ID != id && Role._.Code == code);
            if (exist)
            {
                errorMsg = "已存在相同编号";

            }
            else
            {
                exist = Dal.Exists<Role>(Role._.ID != id && Role._.Name == name);
                if (exist)
                {
                    errorMsg = "已存在相同名称";
                }

            }
            return exist;
        }

        public string[] GetRoleClass()
        {
            return Dal.From<Role>().OrderBy(Role._.RoleClass).Distinct().Select(Role._.RoleClass).ToSinglePropertyArray();

        }

        public DataTable GetUserList(string[] roleIDs)
        {
            return Dal.From<UserInfo>().
                    Join<RoleAndUserRalation>(RoleAndUserRalation._.ID.In(roleIDs) && RoleAndUserRalation._.UserId == UserInfo._.ID)
                    .Select(UserInfo._.ID.All).ToDataTable();
        }

        public DataTable GetAllEnableList()
        {
            return Dal.From<Role>().Where(Role._.Enable == true).OrderBy(Role._.Code)

                   .Select(Role._.ID, Role._.Code, Role._.Name, Role._.RoleClass).ToDataTable();
        }
    }
}
