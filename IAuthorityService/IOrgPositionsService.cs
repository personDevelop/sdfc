using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using AuthorityEntity;
namespace IAuthorityService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IOrgPositionsService”。
    [ServiceContract]
    
    public interface IOrgPositionsService
    {
        [OperationContract]
        DataTable GetAllList();
        [OperationContract]
        int Save(OrgPositions p);

        [OperationContract]
        int Delete(string id, ref string error);
        [OperationContract]
        bool Exit(string id, string code, string name, ref string errorMsg);
       
       
    }
}
