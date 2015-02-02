using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuthorityClient.FunctionInfoSer;
using AuthorityEntity;
using System.Data;
using FrameCommonEntity;
using AuthorityService;
using Sharp.Common;


namespace AuthorityClient
{
    public class FunctionInfoClient : FrameBaseClient.BaseClient
    {

        public FunctionInfoClient()
        {

            if (IsLocation)
            {
                Client = new AuthorityService.FunctionInfoService();
            }
            else
            {
                Client = new FunctionInfoSer.FunctionInfoServiceClient();
            }


        }


        public bool Exit(string id, string parentID, string code, string name, ref string errorMsg)
        {
            if (IsLocation)
            {
                return (Client as FunctionInfoService).Exit(id, parentID, code, name, ref errorMsg);
            }
            else
                return (Client as FunctionInfoServiceClient).Exit(id, parentID, code, name, ref errorMsg);


        }
        public int Save(FunctionInfo item)
        {
            if (IsLocation)
            {
                return (Client as FunctionInfoService).Save(item);
            }
            else
                return (Client as FunctionInfoServiceClient).Save(item);



        }


        public int Delete(string classcode)
        {
            if (IsLocation)
            {
                return (Client as FunctionInfoService).Delete(classcode);
            }
            else
                return (Client as FunctionInfoServiceClient).Delete(classcode);



        }

        public DataTable GetAllDataTable()
        {
            if (IsLocation)
            {
                return (Client as FunctionInfoService).GetAllList();
            }
            else
                return (Client as FunctionInfoServiceClient).GetAllList();



        }

        public string[] GetGroupClass()
        {
            if (IsLocation)
            {
                return (Client as FunctionInfoService).GetGroupClass();
            }
            else
                return (Client as FunctionInfoServiceClient).GetGroupClass();



        }



        public int Save(List<FunctionInfo> list)
        {
            if (IsLocation)
            {
                return (Client as FunctionInfoService).SaveList(list);
            }
            else
                return (Client as FunctionInfoServiceClient).SaveList(list.ToArray());



        }

        public DataTable GetAllFunctByRole(string[] roleids)
        {
            if (IsLocation)
            {
                return (Client as FunctionInfoService).GetAllFunctByRole(roleids);
            }
            else
                return (Client as FunctionInfoServiceClient).GetAllFunctByRole(roleids);

        }

        public DataTable FindDefaultMenu()
        {
            if (IsLocation)
            {
                return (Client as FunctionInfoService).FindDefaultMenu();
            }
            else
                return (Client as FunctionInfoServiceClient).FindDefaultMenu();



        }

        public FunctionInfo GetEntityByName(string code, string name)
        {
            if (IsLocation)
            {
                return (Client as FunctionInfoService).GetEntityByName(code, name);
            }
            else
                return (Client as FunctionInfoServiceClient).GetEntityByName(code, name);



        }
        public FunctionInfo GetEntity(string id)
        {
            if (IsLocation)
            {
                return (Client as FunctionInfoService).GetEntity(id);
            }
            else
                return (Client as FunctionInfoServiceClient).GetEntity(id);



        }
        public List<FunctionInfo> GetCanSetPermissionFunc()
        {
            if (IsLocation)
            {
                return (Client as FunctionInfoService).GetCanSetPermissionFunc().ToList<FunctionInfo>();
            }
            else
                return (Client as FunctionInfoServiceClient).GetCanSetPermissionFunc().ToList<FunctionInfo>();

        }

        public List<MenuInfo> GetCanSetPermissionMenu()
        {
            if (IsLocation)
            {
                return (Client as FunctionInfoService).GetCanSetPermissionMenu().ToList<MenuInfo>();
            }
            else
                return (Client as FunctionInfoServiceClient).GetCanSetPermissionMenu().ToList<MenuInfo>();


        }

        public List<Permission> GetPermission()
        {
            if (IsLocation)
            {
                return (Client as FunctionInfoService).GetPermission().ToList<Permission>();
            }
            else
                return (Client as FunctionInfoServiceClient).GetPermission().ToList<Permission>();


        }


        public int SavePermission(List<Permission> AuthorityList, ref int version)
        {
            if (IsLocation)
            {
                return (Client as FunctionInfoService).SavePermission(AuthorityList, ref   version);
            }
            else
                return (Client as FunctionInfoServiceClient).SavePermission(AuthorityList.ToArray(), ref   version);


        }


    }
}
