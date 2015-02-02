using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sharp.Common;
using System.Runtime.Serialization;

namespace AuthorityEntity
{
    /// <summary>
    /// 组织机构人员关系
    /// </summary> 
    [DataContract]
    public partial class OrgUserRalation : BaseEntity
    {
        public static Column _ = new Column("OrgUserRalation");

        public OrgUserRalation()
        {
            this.TableName = "OrgUserRalation";
        }
        [OnDeserialized]
        public new void OnDeserializing(StreamingContext context)
        {
            this.TableName = "OrgUserRalation";
        }

        #region 私有变量
        private string _ID;
        private string _UserID;
        private string _CompID;
        private string _DepartID;
        private bool _IsDefault;
        private string _PositionID;

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
        ///  用户ID,
        /// </summary>
        [DbProperty(MapingColumnName = "UserID", DbTypeString = "char", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        ///  公司ID,
        /// </summary>
        [DbProperty(MapingColumnName = "CompID", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        ///  部门ID,
        /// </summary>
        [DbProperty(MapingColumnName = "DepartID", DbTypeString = "char", ColumnIsNull = false, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        ///  是否默认,
        /// </summary>
        [DbProperty(MapingColumnName = "IsDefault", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public bool IsDefault
        {
            get
            {
                return this._IsDefault;
            }
            set
            {

                this.OnPropertyChanged("IsDefault", this._IsDefault, value);
                this._IsDefault = value;
            }
        }

        /// <summary>
        ///  岗位ID,
        /// </summary>
        [DbProperty(MapingColumnName = "PositionID", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string PositionID
        {
            get
            {
                return this._PositionID;
            }
            set
            {

                this.OnPropertyChanged("PositionID", this._PositionID, value);
                this._PositionID = value;
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

                CompID = new PropertyItem("CompID", tableName);

                DepartID = new PropertyItem("DepartID", tableName);

                IsDefault = new PropertyItem("IsDefault", tableName);

                PositionID = new PropertyItem("PositionID", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 用户ID,
            /// </summary> 
            public PropertyItem UserID = null;
            /// <summary>
            /// 公司ID,
            /// </summary> 
            public PropertyItem CompID = null;
            /// <summary>
            /// 部门ID,
            /// </summary> 
            public PropertyItem DepartID = null;
            /// <summary>
            /// 是否默认,
            /// </summary> 
            public PropertyItem IsDefault = null;
            /// <summary>
            /// 岗位ID,
            /// </summary> 
            public PropertyItem PositionID = null;
        }
        #endregion
    }


    public partial class OrgUserRalation
    {
        [NotDbCol]
        public OrganizationInfo OrgInfo { get; set; }
        [NotDbCol]
        public UserInfo User { get; set; }

    }
}
