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

namespace AuthorityService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“MenuInfoService”。
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class MenuInfoService : IMenuInfoService
    {

        MenuInfoDataAccess da = new MenuInfoDataAccess();

        public System.Data.DataTable GetAllList(string funcid, string parentid)
        {
            return da.GetAllList(funcid, parentid);
        }
        public DataTable GetMenuListByFuncID(string funcid)
        {
            return da.GetMenuListByFuncID(funcid);
        }
        public int SaveList(List<MenuInfo> list)
        {
            return da.Save(list);
        }

        public int Delete(string classcode)
        {
            return da.Delete(classcode);
        }

        public bool Exit(string parentID, string id, string code)
        {
            return da.Exit(parentID, id, code);
        }


        public DataTable GetMenuListByRole(string funcID, string[] roleid)
        {
            return da.GetMenuListByRole(funcID, roleid);

        }

        public MenuInfo GetMenu(string menuID)
        {
            return da.GetMenu(menuID);
        }

        public DataTable GetRootMenu(string fucnID)
        {
            return da.GetRootMenu(fucnID);
        }
    }
}
