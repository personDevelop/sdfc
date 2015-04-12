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
    public class leavemsgDataAccess : BaseManager
    {
        public DataTable GetAllList()
        {
            return Dal.From<leavemsg>().OrderBy(leavemsg._.mes_id).ToDataTable();
        }

        public int Save(leavemsg item)
        {
            return Dal.Submit(item);
        }

        public int Delete(string id)
        {

            return Dal.Delete<leavemsg>(id);

        }

        public bool Exit(string id, string code, string name, ref string errorMsg)
        {

            return true;
        }


    }

}
