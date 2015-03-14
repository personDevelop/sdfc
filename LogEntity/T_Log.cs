using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sharp.Common;
using System.Runtime.Serialization;

namespace LogEntity
{
    /// <summary>
    /// T_Log
    /// </summary> 
    [DataContract]
    public partial class T_Log : BaseEntity
    {
        public static Column _ = new Column("T_Log");

        public T_Log()
        {
            this.TableName = "T_Log";
        }
        [OnDeserialized]
        public new void OnDeserializing(StreamingContext context)
        {
            this.TableName = "T_Log";
        }

        #region 私有变量
        private string _ID;
        private string _Info;
        private DateTime _CrateDate;
        private string _ModleNameSource;
        private string _ClassNameSource;
        private string _FunNameSource;
        private int _msgOrder;
        private string _ContextInfo;
        private string _Createor;

        #endregion

        #region 属性
        /// <summary>
        ///  主键,
        /// </summary>
        [PrimaryKey]
        [DbProperty(MapingColumnName = "ID", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        ///  日志内容,
        /// </summary>
        [DbProperty(MapingColumnName = "Info", DbTypeString = "text", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string Info
        {
            get
            {
                return this._Info;
            }
            set
            {

                this.OnPropertyChanged("Info", this._Info, value);
                this._Info = value;
            }
        }

        /// <summary>
        ///  创建日期,
        /// </summary>
        [DbProperty(MapingColumnName = "CrateDate", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public DateTime CrateDate
        {
            get
            {
                return this._CrateDate;
            }
            set
            {

                this.OnPropertyChanged("CrateDate", this._CrateDate, value);
                this._CrateDate = value;
            }
        }

        /// <summary>
        ///  模块名称,
        /// </summary>
        [DbProperty(MapingColumnName = "ModleNameSource", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string ModleNameSource
        {
            get
            {
                return this._ModleNameSource;
            }
            set
            {

                this.OnPropertyChanged("ModleNameSource", this._ModleNameSource, value);
                this._ModleNameSource = value;
            }
        }

        /// <summary>
        ///  功能名,
        /// </summary>
        [DbProperty(MapingColumnName = "ClassNameSource", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string ClassNameSource
        {
            get
            {
                return this._ClassNameSource;
            }
            set
            {

                this.OnPropertyChanged("ClassNameSource", this._ClassNameSource, value);
                this._ClassNameSource = value;
            }
        }

        /// <summary>
        ///  函数名,
        /// </summary>
        [DbProperty(MapingColumnName = "FunNameSource", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string FunNameSource
        {
            get
            {
                return this._FunNameSource;
            }
            set
            {

                this.OnPropertyChanged("FunNameSource", this._FunNameSource, value);
                this._FunNameSource = value;
            }
        }

        /// <summary>
        ///  日志等级, 0.消息,1   错误,2 成功,3 致命错误
        /// </summary>
        [DbProperty(MapingColumnName = "msgOrder", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public int msgOrder
        {
            get
            {
                return this._msgOrder;
            }
            set
            {

                this.OnPropertyChanged("msgOrder", this._msgOrder, value);
                this._msgOrder = value;
            }
        }

        /// <summary>
        ///  上下文信息,
        /// </summary>
        [DbProperty(MapingColumnName = "ContextInfo", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 1000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string ContextInfo
        {
            get
            {
                return this._ContextInfo;
            }
            set
            {

                this.OnPropertyChanged("ContextInfo", this._ContextInfo, value);
                this._ContextInfo = value;
            }
        }

        /// <summary>
        ///  当前人,
        /// </summary>
        [DbProperty(MapingColumnName = "Createor", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string Createor
        {
            get
            {
                return this._Createor;
            }
            set
            {

                this.OnPropertyChanged("Createor", this._Createor, value);
                this._Createor = value;
            }
        }


        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                Info = new PropertyItem("Info", tableName);

                CrateDate = new PropertyItem("CrateDate", tableName);

                ModleNameSource = new PropertyItem("ModleNameSource", tableName);

                ClassNameSource = new PropertyItem("ClassNameSource", tableName);

                FunNameSource = new PropertyItem("FunNameSource", tableName);

                msgOrder = new PropertyItem("msgOrder", tableName);

                ContextInfo = new PropertyItem("ContextInfo", tableName);

                Createor = new PropertyItem("Createor", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 日志内容,
            /// </summary> 
            public PropertyItem Info = null;
            /// <summary>
            /// 创建日期,
            /// </summary> 
            public PropertyItem CrateDate = null;
            /// <summary>
            /// 模块名称,
            /// </summary> 
            public PropertyItem ModleNameSource = null;
            /// <summary>
            /// 功能名,
            /// </summary> 
            public PropertyItem ClassNameSource = null;
            /// <summary>
            /// 函数名,
            /// </summary> 
            public PropertyItem FunNameSource = null;
            /// <summary>
            /// 日志等级, 0.消息,1   错误,2 成功,3 致命错误
            /// </summary> 
            public PropertyItem msgOrder = null;
            /// <summary>
            /// 上下文信息,
            /// </summary> 
            public PropertyItem ContextInfo = null;
            /// <summary>
            /// 当前人,
            /// </summary> 
            public PropertyItem Createor = null;
        }
        #endregion
    }
    public partial class T_Log
    {
        [NotDbCol]
        public string msgOrderName { get { return ((LogOrder)msgOrder).ToString(); } }
    }
    
}
