using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using AuthorityEntity;
using FrameCommonEntity;

namespace IAuthorityService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IFunctionInfoService”。
    [ServiceContract]
    public interface IFunctionInfoService
    {
        [OperationContract]
        DataTable GetAllList();
        [OperationContract]
        int Save(FunctionInfo item);
        [OperationContract]
        int SaveList(List<FunctionInfo> list);
        [OperationContract]
        int Delete(string classcode);
        [OperationContract]
        bool Exit(string id, string parentID, string code, string name, ref string errorMsg);
        [OperationContract]
        string[] GetGroupClass();
        [OperationContract]
        DataTable FindDefaultMenu();
        [OperationContract]
        FunctionInfo GetEntityByName(string code, string name);
        [OperationContract]
        FunctionInfo GetEntity(string id);
        [OperationContract]
        DataTable GetCanSetPermissionFunc();
        [OperationContract]
        DataTable GetCanSetPermissionMenu();
        [OperationContract]
        DataTable GetPermission();
        [OperationContract]
        int SavePermission(List<Permission> AuthorityList, ref int version);

           [OperationContract]
        DataTable GetAllFunctByRole(string[] roleids);
    }
}
