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
    /// 功能权限表
    /// </summary> 
    [DataContract]
    public partial class Permission : BaseEntity
    {
        public static Column _ = new Column("Permission");

        public Permission()
        {
            this.TableName = "Permission";
        }
        [OnDeserialized]
        public new void OnDeserializing(StreamingContext context)
        {
            this.TableName = "Permission";
        }

        #region 私有变量
        private string _ID;
        private string _RoleID;
        private string _FunID;
        private string _MenuID;
        private bool _IsVisble;
        private bool _IsEnable;
        private bool _IsRight;

        #endregion

        #region 属性
        /// <summary>
        ///  ID,
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
        ///  角色ID,
        /// </summary>
        [DbProperty(MapingColumnName = "RoleID", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        ///  功能ID,
        /// </summary>
        [DbProperty(MapingColumnName = "FunID", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string FunID
        {
            get
            {
                return this._FunID;
            }
            set
            {

                this.OnPropertyChanged("FunID", this._FunID, value);
                this._FunID = value;
            }
        }

        /// <summary>
        ///  菜单ID,
        /// </summary>
        [DbProperty(MapingColumnName = "MenuID", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string MenuID
        {
            get
            {
                return this._MenuID;
            }
            set
            {

                this.OnPropertyChanged("MenuID", this._MenuID, value);
                this._MenuID = value;
            }
        }

        /// <summary>
        ///  是否可见,
        /// </summary>
        [DbProperty(MapingColumnName = "IsVisble", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public bool IsVisble
        {
            get
            {
                return this._IsVisble;
            }
            set
            {

                this.OnPropertyChanged("IsVisble", this._IsVisble, value);
                this._IsVisble = value;
            }
        }

        /// <summary>
        ///  是否可用,
        /// </summary>
        [DbProperty(MapingColumnName = "IsEnable", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public bool IsEnable
        {
            get
            {
                return this._IsEnable;
            }
            set
            {

                this.OnPropertyChanged("IsEnable", this._IsEnable, value);
                this._IsEnable = value;
            }
        }

        /// <summary>
        ///  是否可分配权限,
        /// </summary>
        [DbProperty(MapingColumnName = "IsRight", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public bool IsRight
        {
            get
            {
                return this._IsRight;
            }
            set
            {

                this.OnPropertyChanged("IsRight", this._IsRight, value);
                this._IsRight = value;
            }
        }


        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                RoleID = new PropertyItem("RoleID", tableName);

                FunID = new PropertyItem("FunID", tableName);

                MenuID = new PropertyItem("MenuID", tableName);

                IsVisble = new PropertyItem("IsVisble", tableName);

                IsEnable = new PropertyItem("IsEnable", tableName);

                IsRight = new PropertyItem("IsRight", tableName);


            }
            /// <summary>
            /// ID,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 角色ID,
            /// </summary> 
            public PropertyItem RoleID = null;
            /// <summary>
            /// 功能ID,
            /// </summary> 
            public PropertyItem FunID = null;
            /// <summary>
            /// 菜单ID,
            /// </summary> 
            public PropertyItem MenuID = null;
            /// <summary>
            /// 是否可见,
            /// </summary> 
            public PropertyItem IsVisble = null;
            /// <summary>
            /// 是否可用,
            /// </summary> 
            public PropertyItem IsEnable = null;
            /// <summary>
            /// 是否可分配权限,
            /// </summary> 
            public PropertyItem IsRight = null;
        }
        #endregion
    }

}
