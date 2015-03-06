//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections.Generic;
using System.Text;

namespace WIMClient
{
    public static class Extensions
    {
        public static void Raise<T>(this EventHandler<T> handler, object sender, T args) where T : EventArgs
        {
            if (handler != null)
                handler(sender, args);
        }

    }

  


}
namespace System.Runtime.CompilerServices
{
    public class ExtensionAttribute : Attribute { }
}

