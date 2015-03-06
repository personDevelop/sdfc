using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sharp.Common;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace AuthorityEntity
{
    /// <summary>
    /// <summary>
    /// 登录日志
    /// </summary> 
    [DataContract]
    public partial class SystemSessionLog : BaseEntity
    {
        public static Column _ = new Column("SystemSessionLog");

        public SystemSessionLog()
        {
            this.TableName = "SystemSessionLog";
        }
        [OnDeserialized]
        public new void OnDeserializing(StreamingContext context)
        {
            this.TableName = "SystemSessionLog";
        }

        #region 私有变量
        private string _ID;
        private string _UserID;
        private string _UserCode;
        private string _UserName;
        private string _CompID;
        private string _CompName;
        private string _DepartID;
        private string _DepartName;
        private string _GroupID;
        private string _GroupName;
        private string _RoleID;
        private string _RoleName;
        private string _EntryIP;
        private string _PortName;
        private DateTime? _EntryDate;
        private DateTime? _OutDate;
        private string _EntryStats;
        private string _Note;

        #endregion

        #region 属性
        /// <summary>
        ///  主键,
        /// </summary>
        [PrimaryKey]
        [DbProperty(MapingColumnName = "ID", DbTypeString = "char", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string ID
        {
            get
            {
                return this._ID;
            }
            set
            {

                this.OnPropertyChanged("ID", this._ID, value);
                this._ID = value;
            }
        }

        /// <summary>
        ///  员工ID,
        /// </summary>
        [DbProperty(MapingColumnName = "UserID", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string UserID
        {
            get
            {
                return this._UserID;
            }
            set
            {

                this.OnPropertyChanged("UserID", this._UserID, value);
                this._UserID = value;
            }
        }

        /// <summary>
        ///  员工工号,
        /// </summary>
        [DbProperty(MapingColumnName = "UserCode", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string UserCode
        {
            get
            {
                return this._UserCode;
            }
            set
            {

                this.OnPropertyChanged("UserCode", this._UserCode, value);
                this._UserCode = value;
            }
        }

        /// <summary>
        ///  员工名称,
        /// </summary>
        [DbProperty(MapingColumnName = "UserName", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {

                this.OnPropertyChanged("UserName", this._UserName, value);
                this._UserName = value;
            }
        }

        /// <summary>
        ///  公司ID,
        /// </summary>
        [DbProperty(MapingColumnName = "CompID", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string CompID
        {
            get
            {
                return this._CompID;
            }
            set
            {

                this.OnPropertyChanged("CompID", this._CompID, value);
                this._CompID = value;
            }
        }

        /// <summary>
        ///  公司名称,
        /// </summary>
        [DbProperty(MapingColumnName = "CompName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string CompName
        {
            get
            {
                return this._CompName;
            }
            set
            {

                this.OnPropertyChanged("CompName", this._CompName, value);
                this._CompName = value;
            }
        }

        /// <summary>
        ///  部门ID,
        /// </summary>
        [DbProperty(MapingColumnName = "DepartID", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string DepartID
        {
            get
            {
                return this._DepartID;
            }
            set
            {

                this.OnPropertyChanged("DepartID", this._DepartID, value);
                this._DepartID = value;
            }
        }

        /// <summary>
        ///  部门名称,
        /// </summary>
        [DbProperty(MapingColumnName = "DepartName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string DepartName
        {
            get
            {
                return this._DepartName;
            }
            set
            {

                this.OnPropertyChanged("DepartName", this._DepartName, value);
                this._DepartName = value;
            }
        }

        /// <summary>
        ///  组ID,
        /// </summary>
        [DbProperty(MapingColumnName = "GroupID", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string GroupID
        {
            get
            {
                return this._GroupID;
            }
            set
            {

                this.OnPropertyChanged("GroupID", this._GroupID, value);
                this._GroupID = value;
            }
        }

        /// <summary>
        ///  组名称,
        /// </summary>
        [DbProperty(MapingColumnName = "GroupName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string GroupName
        {
            get
            {
                return this._GroupName;
            }
            set
            {

                this.OnPropertyChanged("GroupName", this._GroupName, value);
                this._GroupName = value;
            }
        }

        /// <summary>
        ///  角色ID,
        /// </summary>
        [DbProperty(MapingColumnName = "RoleID", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string RoleID
        {
            get
            {
                return this._RoleID;
            }
            set
            {

                this.OnPropertyChanged("RoleID", this._RoleID, value);
                this._RoleID = value;
            }
        }

        /// <summary>
        ///  角色名称,
        /// </summary>
        [DbProperty(MapingColumnName = "RoleName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string RoleName
        {
            get
            {
                return this._RoleName;
            }
            set
            {

                this.OnPropertyChanged("RoleName", this._RoleName, value);
                this._RoleName = value;
            }
        }

        /// <summary>
        ///  登入IP,
        /// </summary>
        [DbProperty(MapingColumnName = "EntryIP", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string EntryIP
        {
            get
            {
                return this._EntryIP;
            }
            set
            {

                this.OnPropertyChanged("EntryIP", this._EntryIP, value);
                this._EntryIP = value;
            }
        }

        /// <summary>
        ///  端口,
        /// </summary>
        [DbProperty(MapingColumnName = "PortName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string PortName
        {
            get
            {
                return this._PortName;
            }
            set
            {

                this.OnPropertyChanged("PortName", this._PortName, value);
                this._PortName = value;
            }
        }

        /// <summary>
        ///  登入日期,
        /// </summary>
        [DbProperty(MapingColumnName = "EntryDate", DbTypeString = "datetime", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public DateTime? EntryDate
        {
            get
            {
                return this._EntryDate;
            }
            set
            {

                this.OnPropertyChanged("EntryDate", this._EntryDate, value);
                this._EntryDate = value;
            }
        }

        /// <summary>
        ///  登出日期,
        /// </summary>
        [DbProperty(MapingColumnName = "OutDate", DbTypeString = "datetime", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public DateTime? OutDate
        {
            get
            {
                return this._OutDate;
            }
            set
            {

                this.OnPropertyChanged("OutDate", this._OutDate, value);
                this._OutDate = value;
            }
        }

        /// <summary>
        ///  登入状态,
        /// </summary>
        [DbProperty(MapingColumnName = "EntryStats", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string EntryStats
        {
            get
            {
                return this._EntryStats;
            }
            set
            {

                this.OnPropertyChanged("EntryStats", this._EntryStats, value);
                this._EntryStats = value;
            }
        }

        /// <summary>
        ///  备注,
        /// </summary>
        [DbProperty(MapingColumnName = "Note", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string Note
        {
            get
            {
                return this._Note;
            }
            set
            {

                this.OnPropertyChanged("Note", this._Note, value);
                this._Note = value;
            }
        }


        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                UserID = new PropertyItem("UserID", tableName);

                UserCode = new PropertyItem("UserCode", tableName);

                UserName = new PropertyItem("UserName", tableName);

                CompID = new PropertyItem("CompID", tableName);

                CompName = new PropertyItem("CompName", tableName);

                DepartID = new PropertyItem("DepartID", tableName);

                DepartName = new PropertyItem("DepartName", tableName);

                GroupID = new PropertyItem("GroupID", tableName);

                GroupName = new PropertyItem("GroupName", tableName);

                RoleID = new PropertyItem("RoleID", tableName);

                RoleName = new PropertyItem("RoleName", tableName);

                EntryIP = new PropertyItem("EntryIP", tableName);

                PortName = new PropertyItem("PortName", tableName);

                EntryDate = new PropertyItem("EntryDate", tableName);

                OutDate = new PropertyItem("OutDate", tableName);

                EntryStats = new PropertyItem("EntryStats", tableName);

                Note = new PropertyItem("Note", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 员工ID,
            /// </summary> 
            public PropertyItem UserID = null;
            /// <summary>
            /// 员工工号,
            /// </summary> 
            public PropertyItem UserCode = null;
            /// <summary>
            /// 员工名称,
            /// </summary> 
            public PropertyItem UserName = null;
            /// <summary>
            /// 公司ID,
            /// </summary> 
            public PropertyItem CompID = null;
            /// <summary>
            /// 公司名称,
            /// </summary> 
            public PropertyItem CompName = null;
            /// <summary>
            /// 部门ID,
            /// </summary> 
            public PropertyItem DepartID = null;
            /// <summary>
            /// 部门名称,
            /// </summary> 
            public PropertyItem DepartName = null;
            /// <summary>
            /// 组ID,
            /// </summary> 
            public PropertyItem GroupID = null;
            /// <summary>
            /// 组名称,
            /// </summary> 
            public PropertyItem GroupName = null;
            /// <summary>
            /// 角色ID,
            /// </summary> 
            public PropertyItem RoleID = null;
            /// <summary>
            /// 角色名称,
            /// </summary> 
            public PropertyItem RoleName = null;
            /// <summary>
            /// 登入IP,
            /// </summary> 
            public PropertyItem EntryIP = null;
            /// <summary>
            /// 端口,
            /// </summary> 
            public PropertyItem PortName = null;
            /// <summary>
            /// 登入日期,
            /// </summary> 
            public PropertyItem EntryDate = null;
            /// <summary>
            /// 登出日期,
            /// </summary> 
            public PropertyItem OutDate = null;
            /// <summary>
            /// 登入状态,
            /// </summary> 
            public PropertyItem EntryStats = null;
            /// <summary>
            /// 备注,
            /// </summary> 
            public PropertyItem Note = null;
        }
        #endregion
    }


}
