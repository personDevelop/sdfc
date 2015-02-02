using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AuthorityDataAccess;
using AuthorityEntity;
using System.ServiceModel.Activation;

namespace AuthorityService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“LoginService”。
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class LoginService : ILoginService
    {
        PersonDataAccess da = new PersonDataAccess();
        public UserInfo Login(string appcode, string userno)
        {
            return da.Login(appcode, userno);
        }


        public System.Data.DataTable GetRoleInfo(string userID)
        {

            return da.GetRoleInfo(userID);
        }

        public int Save(SystemSessionLog log)
        {
            return da.Save(log);
        }

        public DateTime GetDateTime()
        {
            return da.GetDateTime();
        }
    }
}
