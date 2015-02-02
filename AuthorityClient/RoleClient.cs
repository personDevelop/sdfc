using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuthorityEntity;
using AuthorityClient.RoleSer;
using AuthorityService;
using FrameBaseClient;
using System.Data;

namespace AuthorityClient
{
    public class RoleClient : BaseClient
    {

        public RoleClient()
        {
           

            if (IsLocation)
            {
                Client = new RoleService();
            }
            else
            {
                Client = new RoleServiceClient();
            }


        }


        public System.Data.DataTable GetAllList()
        {
            if (IsLocation)
            {
                return (Client as RoleService).GetAllList();
            }
            else
                return (Client as RoleServiceClient).GetAllList();


        }

        public int Save(Role p)
        {
            if (IsLocation)
            {
                return (Client as RoleService).Save(p);
            }
            else
                return (Client as RoleServiceClient).Save(p);

        }

        public int Delete(string id, ref string error)
        {
            if (IsLocation)
            {
                return (Client as RoleService).Delete(id, ref error);
            }
            else
                return (Client as RoleServiceClient).Delete(id, ref error);


        }

        public bool Exit(string id, string code, string name, ref string errorMsg)
        {
            if (IsLocation)
            {
                return (Client as RoleService).Exit(id, code, name, ref errorMsg);
            }
            else
                return (Client as RoleServiceClient).Exit(id, code, name, ref errorMsg);


        }

        public string[] GetRoleClass()
        {
            if (IsLocation)
            {
                return (Client as RoleService).GetRoleClass();
            }
            else
                return (Client as RoleServiceClient).GetRoleClass();


        }

        public DataTable GetUserList(string[] roleIDs)
        {
            if (IsLocation)
            {
                return (Client as RoleService).GetUserList(roleIDs);
            }
            else
                return (Client as RoleServiceClient).GetUserList(roleIDs);
        }

        
    }
}
