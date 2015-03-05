using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using AuthorityEntity;

namespace IAuthorityService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IRoleService”。
    [ServiceContract]
    public interface IRoleService
    {
        [OperationContract]
        DataTable GetAllList();
         [OperationContract]
        DataTable GetAllEnableList();
        [OperationContract]
        int Save(Role p);

        [OperationContract]
        int Delete(string id, ref string error);
        [OperationContract]
        bool Exit(string id, string code, string name, ref string errorMsg);
        [OperationContract]
        string[] GetRoleClass();
        [OperationContract]
        DataTable GetUserList(string[] roleIDs);
    }
}
