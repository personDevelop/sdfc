using System;
using System.Collections.Generic;
 
using System.Text;
using System.Threading;

namespace WIMClient
{
    public static class FileIDCreator
    {
        private static int FileID = 0;

        public static string GetNextFileID(string NetworkID)
        {
            Interlocked.Increment(ref FileID);
            return (NetworkID + FileID.ToString());
        }
    }
}
