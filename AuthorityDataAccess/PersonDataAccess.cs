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

        public UserInfo LoginIM(string username, string userpwd, string Ip, string port, out string groupname, out string error)
        {
            groupname = error = string.Empty;
            UserInfo user = Dal.Find<UserInfo>(UserInfo._.Code == username);
            if (user.Pwd != userpwd)
            {
                error = "密码不正确";
                user = null;
            }
            else
            {
                //获取其部门
                OrganizationInfo org = new UserInfoDataAccess().GetDepartInfo(user.ID);
                groupname = org.Name;
                //更新sessionlog
                List<SystemSessionLog> logList = Dal.From<SystemSessionLog>().Where(SystemSessionLog._.UserID == user.ID
                        && SystemSessionLog._.OutDate == null).OrderBy(SystemSessionLog._.EntryDate.Desc).List<SystemSessionLog>();

                if (logList == null || logList.Count == 0)
                {
                    SystemSessionLog log = new SystemSessionLog();
                    log.ID = Guid.NewGuid().ToString();
                    log.UserID = user.ID;
                    log.UserCode = user.Code;
                    log.UserName = user.Name;
                    log.CompID = org.ID;
                    log.CompName = org.Name;
                    log.DepartID = org.ID;
                    log.DepartName = org.Name;
                    log.GroupID = org.ID;
                    log.GroupName = org.Name;
                    log.EntryDate = DateTime.Now;
                    log.EntryIP = Ip;
                    log.PortName = port;
                    log.EntryStats = "在线";
                    Dal.Submit(log);
                }
                else
                {
                    SystemSessionLog LastLog = logList[0];
                    //检测ip是否相等
                    if (LastLog.EntryIP != Ip)
                    {
                        //检测是否同一天，如果是同一天，则提示已经再其他地方登录，
                        if (LastLog.EntryDate.Value.Date == DateTime.Now.Date)
                        {
                            error = "该账户已在其他机器登录，不能重复登录";
                            user = null;
                        }
                        else
                        {
                            //否则则冲掉前一次登录，并重新设置登录日期
                            LastLog.EntryDate = DateTime.Now;
                            LastLog.EntryIP = Ip;
                            LastLog.PortName = port;
                            if (logList.Count > 1)
                            {
                                for (int i = 1; i < logList.Count; i++)
                                {
                                    logList[i].OutDate = DateTime.Now;
                                }
                            }
                            Dal.Submit(logList);
                        }

                    }
                    else
                    {
                        //ip相等
                        LastLog.PortName = port;
                        if (logList.Count > 1)
                        {
                            for (int i = 1; i < logList.Count; i++)
                            {
                                logList[i].OutDate = DateTime.Now;
                            }
                        }
                        Dal.Submit(logList);
                    }
                }
            }
            return user;
        }
    }
}
