using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sharp.Common;
using System.Runtime.Serialization;

namespace AuthorityEntity
{
    /// <summary>
    /// 角色信息
    /// </summary> 
    [DataContract]
    public partial class Role : BaseEntity
    {
        public static Column _ = new Column("Role");

        public Role()
        {
            this.TableName = "Role";
        }
        [OnDeserialized]
        public new void OnDeserializing(StreamingContext context)
        {
            this.TableName = "Role";
        }

        #region 私有变量

        private string _ID;

        private string _RoleClass;

            private string _Code;

        private string _Name;

        private bool _Enable;

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
        }/// <summary>
        ///  角色分类,
        /// </summary>

        [DbProperty(MapingColumnName = "RoleClass", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string RoleClass
        {
            get
            {
                return this._RoleClass;
            }
            set
            {

                this.OnPropertyChanged("RoleClass", this._RoleClass, value);
                this._RoleClass = value;
            }
        }/// <summary>
        ///  编号,
        /// </summary>

        [DbProperty(MapingColumnName = "Code", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        }/// <summary>
        ///  名称,
        /// </summary>

        [DbProperty(MapingColumnName = "Name", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        }/// <summary>
        ///  可用,
        /// </summary>

        [DbProperty(MapingColumnName = "Enable", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 1, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public bool Enable
        {
            get
            {
                return this._Enable;
            }
            set
            {

                this.OnPropertyChanged("Enable", this._Enable, value);
                this._Enable = value;
            }
        }/// <summary>
        ///  备注,
        /// </summary>

        [DbProperty(MapingColumnName = "Note", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 1000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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

                RoleClass = new PropertyItem("RoleClass", tableName);

                Code = new PropertyItem("Code", tableName);

                Name = new PropertyItem("Name", tableName);

                Enable = new PropertyItem("Enable", tableName);

                Note = new PropertyItem("Note", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 角色分类,
            /// </summary> 
            public PropertyItem RoleClass = null;
            /// <summary>
            /// 编号,
            /// </summary> 
            public PropertyItem Code = null;
            /// <summary>
            /// 名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// 可用,
            /// </summary> 
            public PropertyItem Enable = null;
            /// <summary>
            /// 备注,
            /// </summary> 
            public PropertyItem Note = null;
        }
        #endregion
    }

    public partial class Role {

        /// <summary>
        /// 是否是默认角色
        /// </summary>
        [NotDbCol]
        [DataMember]
        public bool IsDefault { get; set; } 

           /// <summary>
        /// 是否选择
        /// </summary>
        [NotDbCol]
        [DataMember]
        public bool Iselected { get; set; } 
        
    
    }
}
