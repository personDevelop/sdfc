using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AuthorityEntity;
using System.Data;

namespace IAuthorityService
{
    [ServiceContract]
    public interface IMsgLogService
    {
        [OperationContract]
        DataTable GetAllList();
   
        [OperationContract]
        int Save(MsgLog p);

        [OperationContract]
        int Delete(string id);
        [OperationContract]
        bool Exit(string id, string code, string name, ref string errorMsg);

    }

}
