using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuthorityClient.MenuInfoSer;
using System.Data;
using AuthorityService;
using AuthorityEntity;
using Sharp.Common;

namespace AuthorityClient
{
    public class MenuInfoClient:FrameBaseClient.BaseClient
    {
         
        public   MenuInfoClient()
        {
             
                
                if (IsLocation)
                {
                    Client = new MenuInfoService();
                }
                else
                {
                    Client = new MenuInfoServiceClient();
                }
               
             

        }
         

        public DataTable GetMenuList(string funcid, string parentID)
        {
            if (IsLocation)
            {
                return (Client as MenuInfoService).GetAllList(funcid, parentID);
            }
            else
                return (Client as MenuInfoServiceClient).GetAllList(funcid, parentID);
           
        }

        public int Save(List<AuthorityEntity.MenuInfo> list)
        {
            if (IsLocation)
            {
                return (Client as MenuInfoService).SaveList(list );
            }
            else
                return (Client as MenuInfoServiceClient).SaveList(list.ToArray());
           
            
        }

        public bool Exist(string parentId, string id, string code)
        {
            if (IsLocation)
            {
                return (Client as MenuInfoService).Exit(parentId, id, code);
            }
            else
                return (Client as MenuInfoServiceClient).Exit(parentId, id, code);
           
            
        }

        public int Delete(string classcode)
        {
            if (IsLocation)
            {
                return (Client as MenuInfoService).Delete(classcode);
            }
            else
                return (Client as MenuInfoServiceClient).Delete(classcode);
           
            
        }

        public DataTable GetMenuListByFuncID(string funcid)
        {
            if (IsLocation)
            {
                return (Client as MenuInfoService).GetMenuListByFuncID(funcid);
            }
            else
                return (Client as MenuInfoServiceClient).GetMenuListByFuncID(funcid);
           
           
        }

        public List<AuthorityEntity.Permission> GetMenuListByRole(string funcID, string[] roleid)
        {
            if (IsLocation)
            {
                return (Client as MenuInfoService).GetMenuListByRole(funcID, roleid).ToList<Permission>();
            }
            else
                return (Client as MenuInfoServiceClient).GetMenuListByRole(funcID, roleid).ToList<Permission>();
           
        }

        public MenuInfo GetMenu(string menuID)
        {
            if (IsLocation)
            {
                return (Client as MenuInfoService).GetMenu(menuID);
            }
            else
                return (Client as MenuInfoServiceClient).GetMenu(menuID);
        }

        public List<MenuInfo> GetRootMenu(string fucnID)
        {

            if (IsLocation)
            {
                return (Client as MenuInfoService).GetRootMenu(fucnID).ToList<MenuInfo>();
            }
            else
                return (Client as MenuInfoServiceClient).GetRootMenu(fucnID).ToList<MenuInfo>();
        }
    }
}
