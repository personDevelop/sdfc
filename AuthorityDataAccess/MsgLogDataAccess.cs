using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuthorityEntity;
using FrameCommonDataAccess;
using FrameCommonEntity;
using System.Data;
using Sharp.Common;
using Sharp.Data;

namespace AuthorityDataAccess
{
    public class MsgLogDataAccess : BaseManager
    {
        public DataTable GetAllList()
        {
            return Dal.From<MsgLog>().OrderBy(MsgLog._.msg_time).ToDataTable();
        }

        public int Save(MsgLog item)
        {
            return Dal.Submit(item);
        }

        public int Delete(string id)
        {

            return Dal.Delete<MsgLog>(id);

        }

        public bool Exit(string id, string code, string name, ref string errorMsg)
        {

            return false;
        }


    }

}
