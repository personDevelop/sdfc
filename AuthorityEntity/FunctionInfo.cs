using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sharp.Common;
using System.Runtime.Serialization;

namespace AuthorityEntity
{



    /// <summary>
    /// 功能表实体实体
    /// </summary>  
    [DataContract]
    public partial class FunctionInfo : BaseEntity
    {
        public static Column _ = new Column("FunctionInfo");

        public FunctionInfo()
        {
            this.TableName = "FunctionInfo";
        }
        [OnDeserialized]
        public void OnDeserializing(System.Runtime.Serialization.StreamingContext context)
        {
            this.TableName = "FunctionInfo";
        }

        #region 私有变量
        private string _ID;
        private string _Code;
        private string _Name;
        private string _Type;
        private string _Image;
        private string _CallType;
        private string _CallAssembly;
        private string _CallClass;
        private bool _ToolTip;
        private bool _Enable;
        private bool _Visible;
        private bool _MultilInstance;
        private string _ShowText;
        private string _GroupType;
        private string _DockingStyle;
        private int _Version;
        private string _Description;
        private string _Params;
        private string _ParentID;
        private string _ClassCode;
        private int _OrderNo;
        private string _URL;
        private bool _IsMainMenu;
        private bool _IsMust;
        private bool _IsMustNot;
        private string _MenuControl;

        #endregion

        #region 属性
        /// <summary>
        /// 主键,
        /// </summary>
        [PrimaryKey]

        [DbProperty(MapingColumnName = "ID", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        /// 编码,
        /// </summary>


        [DbProperty(MapingColumnName = "Code", DbTypeString = "varchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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


        [DbProperty(MapingColumnName = "Name", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        /// 功能类型,模块、功能、停靠窗口
        /// </summary>


        [DbProperty(MapingColumnName = "Type", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string Type
        {
            get
            {
                return this._Type;
            }
            set
            {

                this.OnPropertyChanged("Type", this._Type, value);
                this._Type = value;
            }
        }
        /// <summary>
        /// 图标,固定图片文件夹下的图像名称
        /// </summary>


        [DbProperty(MapingColumnName = "Image", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string Image
        {
            get
            {
                return this._Image;
            }
            set
            {

                this.OnPropertyChanged("Image", this._Image, value);
                this._Image = value;
            }
        }
        /// <summary>
        /// 功能调用类型,winfrom/web
        /// </summary>


        [DbProperty(MapingColumnName = "CallType", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string CallType
        {
            get
            {
                return this._CallType;
            }
            set
            {

                this.OnPropertyChanged("CallType", this._CallType, value);
                this._CallType = value;
            }
        }
        /// <summary>
        /// 程序集,当为winform程序时，调用的程序集
        /// </summary>


        [DbProperty(MapingColumnName = "CallAssembly", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string CallAssembly
        {
            get
            {
                return this._CallAssembly;
            }
            set
            {

                this.OnPropertyChanged("CallAssembly", this._CallAssembly, value);
                this._CallAssembly = value;
            }
        }
        /// <summary>
        /// 类,Winform：对应程序集中的类
        /// </summary>


        [DbProperty(MapingColumnName = "CallClass", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string CallClass
        {
            get
            {
                return this._CallClass;
            }
            set
            {

                this.OnPropertyChanged("CallClass", this._CallClass, value);
                this._CallClass = value;
            }
        }
        /// <summary>
        /// 鼠标停留时,是否提示,
        /// </summary>


        [DbProperty(MapingColumnName = "ToolTip", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public bool ToolTip
        {
            get
            {
                return this._ToolTip;
            }
            set
            {

                this.OnPropertyChanged("ToolTip", this._ToolTip, value);
                this._ToolTip = value;
            }
        }
        /// <summary>
        /// 启用,
        /// </summary>


        [DbProperty(MapingColumnName = "Enable", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        }
        /// <summary>
        /// 可见,
        /// </summary>


        [DbProperty(MapingColumnName = "Visible", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public bool Visible
        {
            get
            {
                return this._Visible;
            }
            set
            {

                this.OnPropertyChanged("Visible", this._Visible, value);
                this._Visible = value;
            }
        }
        /// <summary>
        /// 是否多开,
        /// </summary>


        [DbProperty(MapingColumnName = "MultilInstance", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public bool MultilInstance
        {
            get
            {
                return this._MultilInstance;
            }
            set
            {

                this.OnPropertyChanged("MultilInstance", this._MultilInstance, value);
                this._MultilInstance = value;
            }
        }
        /// <summary>
        /// 窗口显示的名称,给窗口Text属性用
        /// </summary>


        [DbProperty(MapingColumnName = "ShowText", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string ShowText
        {
            get
            {
                return this._ShowText;
            }
            set
            {

                this.OnPropertyChanged("ShowText", this._ShowText, value);
                this._ShowText = value;
            }
        }
        /// <summary>
        /// 分组,的Group值,给悬靠窗口分组用
        /// </summary>


        [DbProperty(MapingColumnName = "GroupType", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string GroupType
        {
            get
            {
                return this._GroupType;
            }
            set
            {

                this.OnPropertyChanged("GroupType", this._GroupType, value);
                this._GroupType = value;
            }
        }
        /// <summary>
        /// 停靠方式,给悬靠窗口确定停靠方式
        /// </summary>


        [DbProperty(MapingColumnName = "DockingStyle", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string DockingStyle
        {
            get
            {
                return this._DockingStyle;
            }
            set
            {

                this.OnPropertyChanged("DockingStyle", this._DockingStyle, value);
                this._DockingStyle = value;
            }
        }
        /// <summary>
        /// 版本,为了比对服务器和客户端版本用，自增型
        /// </summary>


        [DbProperty(MapingColumnName = "Version", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public int Version
        {
            get
            {
                return this._Version;
            }
            set
            {

                this.OnPropertyChanged("Version", this._Version, value);
                this._Version = value;
            }
        }
        /// <summary>
        /// 功能模块描述,
        /// </summary>


        [DbProperty(MapingColumnName = "Description", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 4000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {

                this.OnPropertyChanged("Description", this._Description, value);
                this._Description = value;
            }
        }
        /// <summary>
        /// 参数,参数个数，对应构造函数，要求顺序相同，val1:val2:val3样式
        /// </summary>


        [DbProperty(MapingColumnName = "Params", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string Params
        {
            get
            {
                return this._Params;
            }
            set
            {

                this.OnPropertyChanged("Params", this._Params, value);
                this._Params = value;
            }
        }
        /// <summary>
        /// 父对象,
        /// </summary>


        [DbProperty(MapingColumnName = "ParentID", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string ParentID
        {
            get
            {
                return this._ParentID;
            }
            set
            {

                this.OnPropertyChanged("ParentID", this._ParentID, value);
                this._ParentID = value;
            }
        }
        /// <summary>
        /// 分级码,
        /// </summary>


        [DbProperty(MapingColumnName = "ClassCode", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string ClassCode
        {
            get
            {
                return this._ClassCode;
            }
            set
            {

                this.OnPropertyChanged("ClassCode", this._ClassCode, value);
                this._ClassCode = value;
            }
        }
        /// <summary>
        /// 顺序,
        /// </summary>


        [DbProperty(MapingColumnName = "OrderNo", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public int OrderNo
        {
            get
            {
                return this._OrderNo;
            }
            set
            {

                this.OnPropertyChanged("OrderNo", this._OrderNo, value);
                this._OrderNo = value;
            }
        }
        /// <summary>
        /// 网址,web：对应页面URL
        /// </summary>


        [DbProperty(MapingColumnName = "URL", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string URL
        {
            get
            {
                return this._URL;
            }
            set
            {

                this.OnPropertyChanged("URL", this._URL, value);
                this._URL = value;
            }
        }
        /// <summary>
        /// 框架展示菜单,
        /// </summary>


        [DbProperty(MapingColumnName = "IsMainMenu", DbTypeString = "Bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public bool IsMainMenu
        {
            get
            {
                return this._IsMainMenu;
            }
            set
            {

                this.OnPropertyChanged("IsMainMenu", this._IsMainMenu, value);
                this._IsMainMenu = value;
            }
        }
        /// <summary>
        /// 必备超出权限，不用设置权限也会使用的基本功能,
        /// </summary>


        [DbProperty(MapingColumnName = "IsMust", DbTypeString = "Bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public bool IsMust
        {
            get
            {
                return this._IsMust;
            }
            set
            {

                this.OnPropertyChanged("IsMust", this._IsMust, value);
                this._IsMust = value;
            }
        }
        /// <summary>
        /// 不会在权限设置里显示的功能,
        /// </summary>


        [DbProperty(MapingColumnName = "IsMustNot", DbTypeString = "Bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public bool IsMustNot
        {
            get
            {
                return this._IsMustNot;
            }
            set
            {

                this.OnPropertyChanged("IsMustNot", this._IsMustNot, value);
                this._IsMustNot = value;
            }
        }
        /// <summary>
        /// 菜单依附容器,
        /// </summary>


        [DbProperty(MapingColumnName = "MenuControl", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string MenuControl
        {
            get
            {
                return this._MenuControl;
            }
            set
            {

                this.OnPropertyChanged("MenuControl", this._MenuControl, value);
                this._MenuControl = value;
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
                Type = new PropertyItem("Type", tableName);
                Image = new PropertyItem("Image", tableName);
                CallType = new PropertyItem("CallType", tableName);
                CallAssembly = new PropertyItem("CallAssembly", tableName);
                CallClass = new PropertyItem("CallClass", tableName);
                ToolTip = new PropertyItem("ToolTip", tableName);
                Enable = new PropertyItem("Enable", tableName);
                Visible = new PropertyItem("Visible", tableName);
                MultilInstance = new PropertyItem("MultilInstance", tableName);
                ShowText = new PropertyItem("ShowText", tableName);
                GroupType = new PropertyItem("GroupType", tableName);
                DockingStyle = new PropertyItem("DockingStyle", tableName);
                Version = new PropertyItem("Version", tableName);
                Description = new PropertyItem("Description", tableName);
                Params = new PropertyItem("Params", tableName);
                ParentID = new PropertyItem("ParentID", tableName);
                ClassCode = new PropertyItem("ClassCode", tableName);
                OrderNo = new PropertyItem("OrderNo", tableName);
                URL = new PropertyItem("URL", tableName);
                IsMainMenu = new PropertyItem("IsMainMenu", tableName);
                IsMust = new PropertyItem("IsMust", tableName);
                IsMustNot = new PropertyItem("IsMustNot", tableName);
                MenuControl = new PropertyItem("MenuControl", tableName);

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
            /// 功能类型,模块、功能、停靠窗口
            /// </summary> 
            public PropertyItem Type = null;
            /// <summary>
            /// 图标,固定图片文件夹下的图像名称
            /// </summary> 
            public PropertyItem Image = null;
            /// <summary>
            /// 功能调用类型,winfrom/web
            /// </summary> 
            public PropertyItem CallType = null;
            /// <summary>
            /// 程序集,当为winform程序时，调用的程序集
            /// </summary> 
            public PropertyItem CallAssembly = null;
            /// <summary>
            /// 类,Winform：对应程序集中的类
            /// </summary> 
            public PropertyItem CallClass = null;
            /// <summary>
            /// 鼠标停留时,是否提示,
            /// </summary> 
            public PropertyItem ToolTip = null;
            /// <summary>
            /// 启用,
            /// </summary> 
            public PropertyItem Enable = null;
            /// <summary>
            /// 可见,
            /// </summary> 
            public PropertyItem Visible = null;
            /// <summary>
            /// 是否多开,
            /// </summary> 
            public PropertyItem MultilInstance = null;
            /// <summary>
            /// 窗口显示的名称,给窗口Text属性用
            /// </summary> 
            public PropertyItem ShowText = null;
            /// <summary>
            /// 分组,的Group值,给悬靠窗口分组用
            /// </summary> 
            public PropertyItem GroupType = null;
            /// <summary>
            /// 停靠方式,给悬靠窗口确定停靠方式
            /// </summary> 
            public PropertyItem DockingStyle = null;
            /// <summary>
            /// 版本,为了比对服务器和客户端版本用，自增型
            /// </summary> 
            public PropertyItem Version = null;
            /// <summary>
            /// 功能模块描述,
            /// </summary> 
            public PropertyItem Description = null;
            /// <summary>
            /// 参数,参数个数，对应构造函数，要求顺序相同，val1:val2:val3样式
            /// </summary> 
            public PropertyItem Params = null;
            /// <summary>
            /// 父对象,
            /// </summary> 
            public PropertyItem ParentID = null;
            /// <summary>
            /// 分级码,
            /// </summary> 
            public PropertyItem ClassCode = null;
            /// <summary>
            /// 顺序,
            /// </summary> 
            public PropertyItem OrderNo = null;
            /// <summary>
            /// 网址,web：对应页面URL
            /// </summary> 
            public PropertyItem URL = null;
            /// <summary>
            /// 框架展示菜单,
            /// </summary> 
            public PropertyItem IsMainMenu = null;
            /// <summary>
            /// 必备超出权限，不用设置权限也会使用的基本功能,
            /// </summary> 
            public PropertyItem IsMust = null;
            /// <summary>
            /// 不会在权限设置里显示的功能,
            /// </summary> 
            public PropertyItem IsMustNot = null;
            /// <summary>
            /// 菜单依附容器,
            /// </summary> 
            public PropertyItem MenuControl = null;


        }
        #endregion
    }

    public partial class FunctionInfo
    {
        #region 工作流分配
        [NotDbCol]
        public bool IsSelected { get; set; }
        [NotDbCol]
        public string WfID { get; set; }
        [NotDbCol]
        public string DistributionID { get; set; }
        #endregion
        public FunctionInfo(System.Xml.Linq.XElement xElement)
        {
            this.ID = xElement.Attribute("ID").Value;
            this.Code = xElement.Attribute("Code").Value;
            this.Name = xElement.Attribute("Name").Value;
            this.Type = xElement.Attribute("Type").Value;
            if (xElement.Attribute("Image") != null)
            {
                this.Image = xElement.Attribute("Image").Value;
            }
            if (xElement.Attribute("CallType") != null)
            {
                this.CallType = xElement.Attribute("CallType").Value;
            }
            if (xElement.Attribute("CallAssembly") != null)
            { this.CallAssembly = xElement.Attribute("CallAssembly").Value; }
            if (xElement.Attribute("CallClass") != null)
            { this.CallClass = xElement.Attribute("CallClass").Value; }
            if (xElement.Attribute("ToolTip") != null)
            { this.ToolTip = bool.Parse(xElement.Attribute("ToolTip").Value); }
            if (xElement.Attribute("Enable") != null)
            { this.Enable = bool.Parse(xElement.Attribute("Enable").Value); }
            if (xElement.Attribute("Visible") != null)
            { this.Visible = bool.Parse(xElement.Attribute("Visible").Value); }
            if (xElement.Attribute("MultilInstance") != null)
            {
                this.MultilInstance = bool.Parse(xElement.Attribute("MultilInstance").Value);
            }
            if (xElement.Attribute("ShowText") != null)
            {
                this.ShowText = xElement.Attribute("ShowText").Value;
            }
            if (xElement.Attribute("GroupType") != null)
            {
                this.GroupType = xElement.Attribute("GroupType").Value;
            }
            if (xElement.Attribute("DockingStyle") != null)
            {
                this.DockingStyle = xElement.Attribute("DockingStyle").Value;
            }
            if (xElement.Attribute("Version") != null)
            {
                this.Version = int.Parse(xElement.Attribute("Version").Value);
            }
            if (xElement.Attribute("Description") != null)
            {
                this.Description = xElement.Attribute("Description").Value;
            }
            if (xElement.Attribute("Params") != null)
            {
                this.Params = xElement.Attribute("Params").Value;
            }
            if (xElement.Attribute("ParentID") != null)
            {
                this.ParentID = xElement.Attribute("ParentID").Value;
            }
            if (xElement.Attribute("ClassCode") != null)
            {
                this.ClassCode = xElement.Attribute("ClassCode").Value;
            }
            if (xElement.Attribute("OrderNo") != null)
            {
                this.OrderNo = int.Parse(xElement.Attribute("OrderNo").Value);
            }
            if (xElement.Attribute("URL") != null)
            {
                this.URL = xElement.Attribute("URL").Value;
            }
            if (xElement.Attribute("IsMainMenu") != null)
            {
                this.IsMainMenu = bool.Parse(xElement.Attribute("IsMainMenu").Value);
            }
            if (xElement.Attribute("IsMust") != null)
            {
                this.IsMust = bool.Parse(xElement.Attribute("IsMust").Value);
            }
            if (xElement.Attribute("IsMustNot") != null)
            {
                this.IsMustNot = bool.Parse(xElement.Attribute("IsMustNot").Value);
            }
            if (xElement.Attribute("MenuControl") != null)
            {
                this.MenuControl = xElement.Attribute("MenuControl").Value;
            }

        }
        [NotDbCol]
        public object WForm { get; set; }
    }
}
