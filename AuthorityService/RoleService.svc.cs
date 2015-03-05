using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AuthorityDataAccess;
using AuthorityEntity;
using System.ServiceModel.Activation;
using System.Data;
using IAuthorityService;
namespace AuthorityService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“RoleService”。
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class RoleService : IRoleService
    {

        RoleDataAccess da = new RoleDataAccess();

        public System.Data.DataTable GetAllList()
        {
            return da.GetAllList();
        }
        public System.Data.DataTable GetAllEnableList()
        {
            return da.GetAllEnableList();
        }
        public int Save(Role p)
        {
            return da.Save(p);
        }

        public int Delete(string id, ref string error)
        {
            return da.Delete(id, ref   error);
        }

        public bool Exit(string id, string code, string name, ref string errorMsg)
        {
            return da.Exit(id, code, name, ref errorMsg);
        }

        public string[] GetRoleClass()
        {
            return da.GetRoleClass();
        }

        public DataTable GetUserList(string[] roleIDs)
        {
            return da.GetUserList(roleIDs);
        }
    }
}
