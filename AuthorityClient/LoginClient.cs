using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuthorityEntity;
using AuthorityClient.LoginSer;
using AuthorityService;

namespace AuthorityClient
{
    public class LoginClient : FrameBaseClient.BaseClient
    {

        public LoginClient()
        {

            if (IsLocation)
            {
                Client = new LoginService();
            }
            else
            {
                Client = new LoginServiceClient();
            }


        }


        public UserInfo Login(string userno)
        {

            return Login(null, userno);


        }
        public UserInfo Login(string appcode, string userno)
        {
            if (IsLocation)
            {
                return (Client as LoginService).Login(appcode, userno);
            }
            else
                return (Client as LoginServiceClient).Login(appcode, userno);



        }

        public void SetConfigInfo(string appcode, string userno, out string msg)
        {
            msg = string.Empty;

        }


        public System.Data.DataTable GetRoleInfo(string userID)
        {
            if (IsLocation)
            {
                return (Client as LoginService).GetRoleInfo(userID);
            }
            else
                return (Client as LoginServiceClient).GetRoleInfo(userID);



        }

        public int Save(SystemSessionLog log)
        {
            if (IsLocation)
            {
                return (Client as LoginService).Save(log);
            }
            else
                return (Client as LoginServiceClient).Save(log);



        }

        public DateTime GetDateTime()
        {
            if (IsLocation)
            {
                return (Client as LoginService).GetDateTime();
            }
            else
                return (Client as LoginServiceClient).GetDateTime();



        }
    }
}
