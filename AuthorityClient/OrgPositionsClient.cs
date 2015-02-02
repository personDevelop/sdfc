using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuthorityEntity;
using System.Data;
using AuthorityService;
using AuthorityClient.OrgPositionsSer;

namespace AuthorityClient
{
   
     public class OrgPositionsClient : FrameBaseClient.BaseClient
    {
         public OrgPositionsClient()
        {

            if (IsLocation)
            {
                Client = new OrgPositionsService();
            }
            else
            {
                Client = new  OrganizationInfoClient();
            }

        }


        public bool Exit(string id,   string code, string name, ref string errorMsg)
        {
            if (IsLocation)
            {
                return (Client as OrgPositionsService).Exit(id,   code, name, ref errorMsg);
            }
            else
                return (Client as  OrgPositionsServiceClient).Exit(id, code, name, ref errorMsg);


        }

        public int Save(OrgPositions item)
        {
            if (IsLocation)
            {
                return (Client as OrgPositionsService).Save(item);
            }
            else
                return (Client as OrgPositionsServiceClient).Save(item);


        }

        
        public int Delete(string classcode, ref string  error)
        {
            if (IsLocation)
            {
                return (Client as OrgPositionsService).Delete(classcode, ref error);
            }
            else
                return (Client as OrgPositionsServiceClient).Delete(classcode, ref error);


        }

        public DataTable GetAllDataTable()
        {
            if (IsLocation)
            {
                return (Client as OrgPositionsService).GetAllList();
            }
            else
                return (Client as OrgPositionsServiceClient).GetAllList();


        }

        
    }
}
