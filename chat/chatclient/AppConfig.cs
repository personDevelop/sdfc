using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chatclient
{
    public class AppConfig
    {
        public static string  getBaseConfig()
        {
           chatclient.userverify.userverifySoapClient client = new userverify.userverifySoapClient();
           return client.HelloWorld();
        }
    }
}
