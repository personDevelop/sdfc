using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AuthorityEntity;
using AuthorityDataAccess;
using System.ServiceModel.Activation;
using FrameCommonEntity;
using System.Data;
using IAuthorityService;

namespace AuthorityService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“FunctionInfoService”。
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class FunctionInfoService : IFunctionInfoService
    {
        FunctionInfoDataAccess da = new FunctionInfoDataAccess();

        public System.Data.DataTable GetAllList()
        {
            return da.GetAllList();
        }

        public int SaveList(List<FunctionInfo> list)
        {
            return da.Save(list);
        }
        public int Save(FunctionInfo item)
        {
            return da.Save(item);
        }
        public int Delete(string classcode)
        {
            return da.Delete(classcode);
        }

        public bool Exit(string id, string parentID, string code, string name, ref string errorMsg)
        {
            return da.Exit(id, parentID, code, name, ref errorMsg);
        }

        public string[] GetGroupClass()
        {
            return da.GetGroupClass();
        }


        public System.Data.DataTable FindDefaultMenu()
        {
            return da.FindDefaultMenu();
        }


        public FunctionInfo GetEntityByName(string code, string name)
        {
            return da.GetEntityByName(code, name);
        }

        public DataTable GetCanSetPermissionFunc()
        {

            return da.GetCanSetPermissionFunc();
        }

        public DataTable GetCanSetPermissionMenu()
        {
            return da.GetCanSetPermissionMenu();

        }

        public DataTable GetPermission()
        {
            return da.GetPermission();

        }

        public int SavePermission(List<Permission> AuthorityList, ref int version)
        {
            return da.SavePermission(AuthorityList, ref   version);
        }

        public DataTable GetAllFunctByRole(string[] roleids)
        {
            return da.GetAllFunctByRole(roleids );
         
        }



        public FunctionInfo GetEntity(string id)
        {
            return da.GetEntity(id);
        }
    }
}
