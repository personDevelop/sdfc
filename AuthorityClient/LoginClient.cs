using System;
using AuthorityEntity;
using AuthorityService;
using Sharp.Common;
using IAuthorityService;

namespace AuthorityClient
{
    public class LoginClient :  BaseClient
    {
        ILoginService currentClient;
        ILoginService CurrentClient
        {
            get
            {
                if (currentClient == null)
                {
                    if (IsLocation)
                    {
                        currentClient = new LoginService();
                    }
                    else
                    {
                        currentClient = WcfInvokeContext.CreateWCFService<ILoginService>("LoginService");
                    }
                }
                return currentClient;
            }
        }

        public UserInfo Login(string userno)
        {

            return Login(null, userno);


        }
      
        public UserInfo Login(string appcode, string userno)
        {

            return CurrentClient.Login(appcode, userno);

        }

        public void SetConfigInfo(string appcode, string userno, out string msg)
        {
            msg = string.Empty;

        }


        public System.Data.DataTable GetRoleInfo(string userID)
        {
            return CurrentClient.GetRoleInfo(userID);

        }

        public int Save(SystemSessionLog log)
        {
            return CurrentClient.Save(log);


        }

        public DateTime GetDateTime()
        {

            return CurrentClient.GetDateTime();

        }

        public View_IMUser Login(string username, string userpwd, string Ip, string port,   out string error)
        {
            return CurrentClient.LoginIM(username, userpwd, Ip, port, out   error);
        }
    }
}
