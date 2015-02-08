using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sharp.Common;
using System.Runtime.Serialization;

namespace AuthorityEntity
{
    /// <summary>
    /// 通讯录
    /// </summary> 
    [DataContract]
    public partial class Contacts : BaseEntity
    {
        public static Column _ = new Column("Contacts");

        public Contacts()
        {
            this.TableName = "Contacts";
        }
        [OnDeserialized]
        public new void OnDeserializing(StreamingContext context)
        {
            this.TableName = "Contacts";
        }

        #region 私有变量
        private string _ID;
        private string _Name;
        private string _TelNo;
        private string _UserID;
        private string _GroupName;

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
        ///  名称,
        /// </summary>
        [DbProperty(MapingColumnName = "Name", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        ///  电话,
        /// </summary>
        [DbProperty(MapingColumnName = "TelNo", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string TelNo
        {
            get
            {
                return this._TelNo;
            }
            set
            {

                this.OnPropertyChanged("TelNo", this._TelNo, value);
                this._TelNo = value;
            }
        }

        /// <summary>
        ///  员工ID,
        /// </summary>
        [DbProperty(MapingColumnName = "UserID", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        ///  分组,
        /// </summary>
        [DbProperty(MapingColumnName = "GroupName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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


        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                Name = new PropertyItem("Name", tableName);

                TelNo = new PropertyItem("TelNo", tableName);

                UserID = new PropertyItem("UserID", tableName);

                GroupName = new PropertyItem("GroupName", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// 电话,
            /// </summary> 
            public PropertyItem TelNo = null;
            /// <summary>
            /// 员工ID,
            /// </summary> 
            public PropertyItem UserID = null;
            /// <summary>
            /// 分组,
            /// </summary> 
            public PropertyItem GroupName = null;
        }
        #endregion
    }

}
