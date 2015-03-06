using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AuthorityEntity;

namespace IAuthorityService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“ILoginService”。
    [ServiceContract]
    public interface ILoginService
    {
        [OperationContract]
        UserInfo Login(string appcode, string userno );
         [OperationContract]
        System.Data.DataTable GetRoleInfo(string userID);
         [OperationContract]
        int Save(SystemSessionLog log);
         [OperationContract]
        DateTime GetDateTime();
        [OperationContract]
         UserInfo LoginIM(string userno, string pwd, string ip, string portName, out string error);
    }
}
