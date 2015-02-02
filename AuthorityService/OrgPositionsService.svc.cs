using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AuthorityDataAccess;
using System.ServiceModel.Activation;

namespace AuthorityService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“OrgPositionsService”。

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class OrgPositionsService : IOrgPositionsService
    {

        OrgPositionsDataAccess da = new OrgPositionsDataAccess();

        public System.Data.DataTable GetAllList()
        {
            return da.GetAllList();
        }

        public int Save(AuthorityEntity.OrgPositions p)
        {
            return da.Save(p);
        }

        public int Delete(string classcode, ref string error)
        {
            return da.Delete(classcode, ref error);
        }

        public bool Exit(string id, string code, string name, ref string errorMsg)
        {
            return da.Exit(id, code, name, ref errorMsg);
        }

    }
}
