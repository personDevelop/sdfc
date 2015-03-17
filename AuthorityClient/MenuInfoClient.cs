using System.Collections.Generic;
using System.Data;
using AuthorityService;
using AuthorityEntity;
using Sharp.Common;
using IAuthorityService;

namespace AuthorityClient
{
    public class MenuInfoClient: BaseClient
    {
        IMenuInfoService currentClient;
        IMenuInfoService CurrentClient
        {
            get
            {
                if (currentClient == null)
                {
                    if (IsLocation)
                    {
                        currentClient = new MenuInfoService();
                    }
                    else
                    {
                        currentClient = WcfInvokeContext.CreateWCFService<IMenuInfoService>("MenuInfoService");
                    }
                }
                return currentClient;
            }
        }
       

        public DataTable GetMenuList(string funcid, string parentID)
        {
              return CurrentClient.GetAllList(funcid, parentID);
            
        }

        public int Save(List<AuthorityEntity.MenuInfo> list)
        {
             
                 return CurrentClient.SaveList(list );
            
        }

        public bool Exist(string parentId, string id, string code)
        {
              return CurrentClient.Exit(parentId, id, code);
             
        }

        public int Delete(string classcode)
        {
             
                 return CurrentClient.Delete(classcode);
             
        }

        public DataTable GetMenuListByFuncID(string funcid)
        {
            
                 return CurrentClient.GetMenuListByFuncID(funcid);
           
        }

        public List<AuthorityEntity.Permission> GetMenuListByRole(string funcID, string[] roleid)
        {
            
                 return CurrentClient.GetMenuListByRole(funcID, roleid).ToList<Permission>();
            
        }

        public MenuInfo GetMenu(string menuID)
        {
            
                 return CurrentClient.GetMenu(menuID);
            
        }

        public List<MenuInfo> GetRootMenu(string fucnID)
        {

          
                 return CurrentClient.GetRootMenu(fucnID).ToList<MenuInfo>();
          
        }
    }
}
