using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using AuthorityEntity;

namespace AuthorityService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IMenuInfoService”。
    [ServiceContract]
    public interface IMenuInfoService
    {
        [OperationContract]
        DataTable GetAllList(string funcid, string parentid);
        [OperationContract]
        DataTable GetMenuListByFuncID(string funcid);
        [OperationContract]
        int SaveList(List<MenuInfo> list);
        [OperationContract]
        int Delete(string classcode);
        [OperationContract]
        bool Exit(string parentID, string id, string code);
        [OperationContract]
        DataTable GetMenuListByRole(string funcID, string[] roleid);
         [OperationContract]
        MenuInfo GetMenu(string menuID);
         [OperationContract]
         DataTable GetRootMenu(string fucnID);
    }
}
