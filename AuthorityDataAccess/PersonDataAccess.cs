using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sharp.Data;
using AuthorityEntity;
using System.Data;

namespace AuthorityDataAccess
{
    public class PersonDataAccess : BaseManager
    {
        public UserInfo Login(string appcode, string userno)
        {
            return Dal.Find<UserInfo>(UserInfo._.Code == userno);
        }

        public System.Data.DataTable GetRoleInfo(string userID)
        {
            return Dal.From<Role>().Join<RoleAndUserRalation>(Role._.ID == RoleAndUserRalation._.RoleId && Role._.Enable == true)
                .Where(RoleAndUserRalation._.UserId == userID).Select(Role._.Enable.All, RoleAndUserRalation._.IsDefault)
                .ToDataTable();
        }

        public int Save(SystemSessionLog log)
        {
            //将之前的登录状态清空掉 

            SystemSessionLog oldLog = new SystemSessionLog();
            oldLog.RecordStatus = Sharp.Common.StatusType.update;
            oldLog.Where = SystemSessionLog._.UserID == log.UserID && SystemSessionLog._.EntryStats == "在线";
            oldLog.OutDate = Dal.SystemDateTime;
            int result = 0;
            SessionFactory dal = null;
            IDbTransaction tr = Dal.BeginTransaction(out dal);
            try
            {
                dal.Update(oldLog, null, tr);
                result = dal.SubmitNew(tr, ref dal, log);
                dal.CommitTransaction(tr);
            }
            catch (Exception)
            {
                dal.RollbackTransaction(tr);
                throw;
            }
            return result;
        }


        public DateTime GetDateTime()
        {
            return Dal.SystemDateTime;
        }

        public UserInfo LoginIM(string userno, string pwd, string ip, string portName, out string error)
        {
            error = string.Empty;
            UserInfo user = Dal.Find<UserInfo>(UserInfo._.Code == userno);
            if (user.Pwd != pwd)
            {
                error = "密码不正确";
                user = null;
            }
            else
            { 
            SystemSessionLog 
            
            }
            return user;
        }
    }
}
