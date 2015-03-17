using AuthorityEntity;
using AuthorityService;
using Sharp.Common;
using System.Data;
using IAuthorityService;

namespace AuthorityClient
{
    public class RoleClient : BaseClient
    {
        IRoleService currentClient;
        IRoleService CurrentClient
        {
            get
            {
                if (currentClient == null)
                {
                    if (IsLocation)
                    {
                        currentClient = new RoleService();
                    }
                    else
                    {
                        currentClient = WcfInvokeContext.CreateWCFService<IRoleService>("RoleService");
                    }
                }
                return currentClient;
            }
        }



        public System.Data.DataTable GetAllList()
        {
            return CurrentClient.GetAllList();

        }

        public int Save(Role p)
        {

            return CurrentClient.Save(p);

        }

        public int Delete(string id, ref string error)
        {
            return CurrentClient.Delete(id, ref error);

        }

        public bool Exit(string id, string code, string name, ref string errorMsg)
        {

            return CurrentClient.Exit(id, code, name, ref errorMsg);

        }

        public string[] GetRoleClass()
        {
            return CurrentClient.GetRoleClass();

        }

        public DataTable GetUserList(string[] roleIDs)
        {
            return CurrentClient.GetUserList(roleIDs);

        }



        public int DeleteRoleUser(string roleid, string userid, out string error)
        {
            return CurrentClient.DeleteRoleUser(roleid, userid, out error);
        }

        public int SaveListRolePerson(System.Collections.Generic.List<RoleAndUserRalation> rulist, out string error)
        {
            return CurrentClient.SaveListRolePerson(rulist, out error);
        }
    }
}
