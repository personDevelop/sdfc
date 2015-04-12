using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using AuthorityEntity;
using AuthorityDataAccess;
using System.Data;
using IAuthorityService;
namespace AuthorityService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“MsgLogService”。
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class MsgLogService : IMsgLogService
    {

        MsgLogDataAccess da = new MsgLogDataAccess();

        public DataTable GetAllList()
        {
            return da.GetAllList();
        }
         
        public int Save(MsgLog p)
        {
            return da.Save(p);
        }

        public int Delete(string id)
        {
            return da.Delete(id);
        }

        public bool Exit(string id, string code, string name, ref string errorMsg)
        {
            return da.Exit(id, code, name, ref errorMsg);
        }


    }

}
