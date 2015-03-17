using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text; 
using System.ServiceModel.Activation;
using Sharp.Common;

namespace LogService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“LogWriteToDbService”。
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]

    public class LogWriteToDbService : ILog
    {

        Sharp.Data.LogDal da = new Sharp.Data.LogDal();
        /// <summary>
        /// public enum MsgAlertType
        ///{
        ///    消息,
        ///    错误,
        ///    成功,
        ///   致命错误  会记录到数据库的 
        /// }
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="msgOrder"></param>
        /// <param name="modleName"></param>
        /// <param name="funName"></param>
        /// <param name="?"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public int Write(T_Log log)
        {

            return da.Write(log);
        }

        public int Delete(string id)
        {
            return da.Delete(id);
        }

        public int DeleteByIds(List<string> idlist)
        {
            return da.DeleteByIds(idlist);
        }






        public int DeleteAll()
        {
            return da.DeleteAll();
        }
    }
}
