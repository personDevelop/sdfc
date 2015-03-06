using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chat
{
    [Serializable]
    public class ClassDept
    {
        public string depid { get; set; }//部门ID
        public string depbh { get; set; }//部门编号
        public string depmc { get; set; }//名称

        public List<ClassResponse> userlist { get; set; }//部门下所属员工
    }
}
