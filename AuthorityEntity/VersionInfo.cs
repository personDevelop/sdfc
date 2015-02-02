using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sharp.Common;
using System.Runtime.Serialization;

namespace AuthorityEntity
{

    /// <summary>
    /// 版本信息实体
    /// </summary>  
    [DataContract]
    public class VersionInfo : BaseEntity
    {
        public static Column _ = new Column("VersionInfo");

        public VersionInfo()
        {
            this.TableName = "VersionInfo";
        }
        [OnDeserialized]
        public new  void OnDeserializing(System.Runtime.Serialization.StreamingContext context)
        {
            this.TableName = "VersionInfo";
        }

        #region 私有变量
        private Guid _ID;
        private string _Code;
        private string _Name;
        private string _AppName;
        private int _VersionNum;

        #endregion

        #region 属性
        /// <summary>
        /// 主键,
        /// </summary>
        [PrimaryKey]

        [DbProperty(MapingColumnName = "ID", DbTypeString = "UniqueIdentifier", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public Guid ID
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
        /// 编码,
        /// </summary>


        [DbProperty(MapingColumnName = "Code", DbTypeString = "NVarChar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string Code
        {
            get
            {
                return this._Code;
            }
            set
            {

                this.OnPropertyChanged("Code", this._Code, value);
                this._Code = value;
            }
        }
        /// <summary>
        /// 名称,
        /// </summary>


        [DbProperty(MapingColumnName = "Name", DbTypeString = "NVarChar", ColumnIsNull = false, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {

                this.OnPropertyChanged("Name", this._Name, value);
                this._Name = value;
            }
        }
        /// <summary>
        /// 程序名称,
        /// </summary>


        [DbProperty(MapingColumnName = "AppName", DbTypeString = "NVarChar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string AppName
        {
            get
            {
                return this._AppName;
            }
            set
            {

                this.OnPropertyChanged("AppName", this._AppName, value);
                this._AppName = value;
            }
        }
        /// <summary>
        /// 版本号,
        /// </summary>


        [DbProperty(MapingColumnName = "VersionNum", DbTypeString = "Int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public int VersionNum
        {
            get
            {
                return this._VersionNum;
            }
            set
            {

                this.OnPropertyChanged("VersionNum", this._VersionNum, value);
                this._VersionNum = value;
            }
        }


        #endregion

        #region 列定义

        public class Column
        {
            public Column(string tableName)
            {
                ID = new PropertyItem("ID", tableName);
                Code = new PropertyItem("Code", tableName);
                Name = new PropertyItem("Name", tableName);
                AppName = new PropertyItem("AppName", tableName);
                VersionNum = new PropertyItem("VersionNum", tableName);

            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 编码,
            /// </summary> 
            public PropertyItem Code = null;
            /// <summary>
            /// 名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// 程序名称,
            /// </summary> 
            public PropertyItem AppName = null;
            /// <summary>
            /// 版本号,
            /// </summary> 
            public PropertyItem VersionNum = null;


        }
        #endregion
    }
}
