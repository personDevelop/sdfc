using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuthorityEntity;
using System.Data;

namespace AuthorityDataAccess
{
    public class OrgPositionsDataAccess : Sharp.Data.BaseManager
    {
        public bool Exit(string id, string code, string name, ref string errorMsg)
        {
            bool exist = Dal.Exists<OrgPositions>(
                OrgPositions._.ID != id && OrgPositions._.Code == code);
            if (exist)
            {
                errorMsg = "已存在相同编号";

            }
            else
            {
                exist = Dal.Exists<OrgPositions>(
                    OrgPositions._.ID != id && OrgPositions._.Name == name);
                if (exist)
                {
                    errorMsg = "已存在相同名称";
                }

            }
            return exist;
        }

        public int Delete(string id, ref string error)
        {
            if (Dal.Exists<OrgUserRalation>(OrgUserRalation._.PositionID == id))
            {
                error = "当前组织岗位已被员工使用，不能删除！";
                return -1;
            }
            return Dal.Delete<OrgPositions>(id);

        }

        public int Save(OrgPositions item)
        {

            return Dal.Submit(item);
        }

        public System.Data.DataTable GetAllList()
        {
            return Dal.From<OrgPositions>().OrderBy(OrgPositions._.Code).ToDataTable();

        }


    }
}
