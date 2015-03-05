using AuthorityEntity;
using System.Data;
using AuthorityService;
using FrameBaseClient;
using IAuthorityService;

namespace AuthorityClient
{

    public class OrgPositionsClient : FrameBaseClient.BaseClient
    {
        IOrgPositionsService currentClient;
        IOrgPositionsService CurrentClient
        {
            get
            {
                if (currentClient == null)
                {
                    if (IsLocation)
                    {
                        currentClient = new OrgPositionsService();
                    }
                    else
                    {
                        currentClient = WcfInvokeContext.CreateWCFService<IOrgPositionsService>("OrgPositionsService");
                    }
                }
                return currentClient;
            }
        }
       
        


        public bool Exit(string id, string code, string name, ref string errorMsg)
        {
            
                 return CurrentClient.Exit(id, code, name, ref errorMsg);
            
        }

        public int Save(OrgPositions item)
        {     return CurrentClient.Save(item);
            
        }


        public int Delete(string classcode, ref string error)
        {
           
                 return CurrentClient.Delete(classcode, ref error);
            
        }

        public DataTable GetAllDataTable()
        {
           
                 return CurrentClient.GetAllList();
            
        }


    }
}
