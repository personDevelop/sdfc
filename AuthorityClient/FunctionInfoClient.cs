using System.Collections.Generic;
using AuthorityEntity;
using System.Data;
using AuthorityService;
using Sharp.Common;
using Sharp.Common;
using IAuthorityService;


namespace AuthorityClient
{
    public class FunctionInfoClient : BaseClient
    {
        IFunctionInfoService currentClient;
        IFunctionInfoService CurrentClient
        {
            get
            {
                if (currentClient == null)
                {
                    if (IsLocation)
                    {
                        currentClient = new FunctionInfoService();
                    }
                    else
                    {
                        currentClient = WcfInvokeContext.CreateWCFService<IFunctionInfoService>("FunctionInfoService");
                    }
                }
                return currentClient;
            }
        }

         

        public bool Exit(string id, string parentID, string code, string name, ref string errorMsg)
        {
            
                 return CurrentClient.Exit(id, parentID, code, name, ref errorMsg);
           

        }
        public int Save(FunctionInfo item)
        {
            
                 return CurrentClient.Save(item);
            

        }


        public int Delete(string classcode)
        {
            
                 return CurrentClient.Delete(classcode);
            
        }

        public DataTable GetAllDataTable()
        {
            
                 return CurrentClient.GetAllList();
             
        }

        public string[] GetGroupClass()
        {
            
                 return CurrentClient.GetGroupClass();
            
        }



        public int Save(List<FunctionInfo> list)
        {
            
                 return CurrentClient.SaveList(list);
             
        }

        public DataTable GetAllFunctByRole(string[] roleids)
        {
            
                 return CurrentClient.GetAllFunctByRole(roleids);
            
        }

        public DataTable FindDefaultMenu()
        {
           
                 return CurrentClient.FindDefaultMenu();
            
        }

        public FunctionInfo GetEntityByName(string code, string name)
        {
            
                 return CurrentClient.GetEntityByName(code, name);
            
        }
        public FunctionInfo GetEntity(string id)
        {
             
                 return CurrentClient.GetEntity(id);
             
        }
        public List<FunctionInfo> GetCanSetPermissionFunc()
        {
            
                 return CurrentClient.GetCanSetPermissionFunc().ToList<FunctionInfo>();
             
        }

        public List<MenuInfo> GetCanSetPermissionMenu()
        {
              return CurrentClient.GetCanSetPermissionMenu().ToList<MenuInfo>();
            }
            

        public List<Permission> GetPermission()
        {
            
                 return CurrentClient.GetPermission().ToList<Permission>();
            
        }


        public int SavePermission(List<Permission> AuthorityList, ref int version)
        {
             
                 return CurrentClient.SavePermission(AuthorityList, ref   version);
           
        }


    }
}
