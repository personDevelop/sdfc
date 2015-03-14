using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sharp.Common;
using System.Runtime.Serialization;

namespace AuthorityEntity
{

    /// <summary>
    /// 菜单信息实体
    /// </summary>  
    [DataContract]
    public class MenuInfo : BaseEntity
    {
        public static Column _ = new Column("MenuInfo");

        public MenuInfo()
        {
            this.TableName = "MenuInfo";
        }
        [OnDeserialized]
        public void OnDeserializing(System.Runtime.Serialization.StreamingContext context)
        {
            this.TableName = "MenuInfo";
        }

        #region 私有变量
        private string _ID;
        private string _FuntionID;
        private string _Code;
        private string _Name;
        private string _Type;
        private string _CallerCtrolId;
        private string _Image;
        private string _CallAssembly;
        private string _CallClass;
        private string _CallMethod;
        private string _DockPaneKey;
        private bool _IsCtrl;
        private bool _IsShift;
        private bool _IsAlt;
        private bool _IsWindow;
        private string _Shortcuts;
        private int _Version;
        private int _OrderNo;
        private string _Description;
        private string _ParentID;
        private string _ClassCode;
        private string _ShowType;
        private bool _IsEnable;
        private bool _IsVisble;
        private bool _IsShowGroup;
        private string _MenuType;
        private bool _IsRecord;
        private bool _IsDefaultCheck;
        private string _WebMethod;
        private string _MethodParas;
        private bool _IsMustNot;
        private bool _IsMust;
        private bool _NotShowLoading;

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
        /// 功能ID,
        /// </summary>


        [DbProperty(MapingColumnName = "FuntionID", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string FuntionID
        {
            get
            {
                return this._FuntionID;
            }
            set
            {

                this.OnPropertyChanged("FuntionID", this._FuntionID, value);
                this._FuntionID = value;
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
        /// 类型,菜单、工具栏、右键菜单、窗体控件(此时编码需要和控件ID相同)
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
        /// 调用控件ID,只有右键菜单使用，标识改控件调用的右键菜单
        /// </summary>


        [DbProperty(MapingColumnName = "CallerCtrolId", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string CallerCtrolId
        {
            get
            {
                return this._CallerCtrolId;
            }
            set
            {

                this.OnPropertyChanged("CallerCtrolId", this._CallerCtrolId, value);
                this._CallerCtrolId = value;
            }
        }
        /// <summary>
        /// 图标,
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
        /// 程序集,
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
        /// 类,
        /// </summary>


        [DbProperty(MapingColumnName = "CallClass", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        /// 方法,
        /// </summary>


        [DbProperty(MapingColumnName = "CallMethod", DbTypeString = "NText", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string CallMethod
        {
            get
            {
                return this._CallMethod;
            }
            set
            {

                this.OnPropertyChanged("CallMethod", this._CallMethod, value);
                this._CallMethod = value;
            }
        }
        /// <summary>
        /// 需要的dockpanelID,存储Desktop.Instance.dockList中的悬靠窗口Key值。
        /// </summary>


        [DbProperty(MapingColumnName = "DockPaneKey", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string DockPaneKey
        {
            get
            {
                return this._DockPaneKey;
            }
            set
            {

                this.OnPropertyChanged("DockPaneKey", this._DockPaneKey, value);
                this._DockPaneKey = value;
            }
        }
        /// <summary>
        /// 是否使Ctrl键,
        /// </summary>


        [DbProperty(MapingColumnName = "IsCtrl", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public bool IsCtrl
        {
            get
            {
                return this._IsCtrl;
            }
            set
            {

                this.OnPropertyChanged("IsCtrl", this._IsCtrl, value);
                this._IsCtrl = value;
            }
        }
        /// <summary>
        /// 是否使Shift键,
        /// </summary>


        [DbProperty(MapingColumnName = "IsShift", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public bool IsShift
        {
            get
            {
                return this._IsShift;
            }
            set
            {

                this.OnPropertyChanged("IsShift", this._IsShift, value);
                this._IsShift = value;
            }
        }
        /// <summary>
        /// 是否使用Alt键,
        /// </summary>


        [DbProperty(MapingColumnName = "IsAlt", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public bool IsAlt
        {
            get
            {
                return this._IsAlt;
            }
            set
            {

                this.OnPropertyChanged("IsAlt", this._IsAlt, value);
                this._IsAlt = value;
            }
        }
        /// <summary>
        /// 是否使用窗口键,
        /// </summary>


        [DbProperty(MapingColumnName = "IsWindow", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public bool IsWindow
        {
            get
            {
                return this._IsWindow;
            }
            set
            {

                this.OnPropertyChanged("IsWindow", this._IsWindow, value);
                this._IsWindow = value;
            }
        }
        /// <summary>
        /// 快捷键,
        /// </summary>


        [DbProperty(MapingColumnName = "Shortcuts", DbTypeString = "varchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 10, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string Shortcuts
        {
            get
            {
                return this._Shortcuts;
            }
            set
            {

                this.OnPropertyChanged("Shortcuts", this._Shortcuts, value);
                this._Shortcuts = value;
            }
        }
        /// <summary>
        /// 版本,
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
        /// 描述,
        /// </summary>


        [DbProperty(MapingColumnName = "Description", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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


        [DbProperty(MapingColumnName = "ClassCode", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        /// 显示方式,文本、图形、文本兼图形
        /// </summary>


        [DbProperty(MapingColumnName = "ShowType", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string ShowType
        {
            get
            {
                return this._ShowType;
            }
            set
            {

                this.OnPropertyChanged("ShowType", this._ShowType, value);
                this._ShowType = value;
            }
        }
        /// <summary>
        /// 可用,
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
        /// 可见,
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
        /// 是否显示分割线,
        /// </summary>


        [DbProperty(MapingColumnName = "IsShowGroup", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public bool IsShowGroup
        {
            get
            {
                return this._IsShowGroup;
            }
            set
            {

                this.OnPropertyChanged("IsShowGroup", this._IsShowGroup, value);
                this._IsShowGroup = value;
            }
        }
        /// <summary>
        /// 菜单类型,
        /// </summary>


        [DbProperty(MapingColumnName = "MenuType", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string MenuType
        {
            get
            {
                return this._MenuType;
            }
            set
            {

                this.OnPropertyChanged("MenuType", this._MenuType, value);
                this._MenuType = value;
            }
        }
        /// <summary>
        /// 是否记录,ServiceManager.BarItemService.dockPanelView[key]方式获得该菜单项，key为该节点的ID，一般为BarLinkContainerItem的用到
        /// </summary>


        [DbProperty(MapingColumnName = "IsRecord", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public bool IsRecord
        {
            get
            {
                return this._IsRecord;
            }
            set
            {

                this.OnPropertyChanged("IsRecord", this._IsRecord, value);
                this._IsRecord = value;
            }
        }
        /// <summary>
        /// 是否默认勾选,
        /// </summary>


        [DbProperty(MapingColumnName = "IsDefaultCheck", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public bool IsDefaultCheck
        {
            get
            {
                return this._IsDefaultCheck;
            }
            set
            {

                this.OnPropertyChanged("IsDefaultCheck", this._IsDefaultCheck, value);
                this._IsDefaultCheck = value;
            }
        }
        /// <summary>
        /// web调用方法,
        /// </summary>


        [DbProperty(MapingColumnName = "WebMethod", DbTypeString = "NText", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string WebMethod
        {
            get
            {
                return this._WebMethod;
            }
            set
            {

                this.OnPropertyChanged("WebMethod", this._WebMethod, value);
                this._WebMethod = value;
            }
        }
        /// <summary>
        /// 参数,
        /// </summary>


        [DbProperty(MapingColumnName = "MethodParas", DbTypeString = "NVarChar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string MethodParas
        {
            get
            {
                return this._MethodParas;
            }
            set
            {

                this.OnPropertyChanged("MethodParas", this._MethodParas, value);
                this._MethodParas = value;
            }
        }
        /// <summary>
        /// 一定不会在权限设置里出现的功能，一般给设计人员使用的功能,
        /// </summary>


        [DbProperty(MapingColumnName = "IsMustNot", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        /// 超出权限，不用设置权限也会使用的基本功能,
        /// </summary>


        [DbProperty(MapingColumnName = "IsMust", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        /// 不显示加载动画,
        /// </summary>


        [DbProperty(MapingColumnName = "NotShowLoading", DbTypeString = "Bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public bool NotShowLoading
        {
            get
            {
                return this._NotShowLoading;
            }
            set
            {

                this.OnPropertyChanged("NotShowLoading", this._NotShowLoading, value);
                this._NotShowLoading = value;
            }
        }


        #endregion

        #region 列定义

        public class Column
        {
            public Column(string tableName)
            {
                ID = new PropertyItem("ID", tableName);
                FuntionID = new PropertyItem("FuntionID", tableName);
                Code = new PropertyItem("Code", tableName);
                Name = new PropertyItem("Name", tableName);
                Type = new PropertyItem("Type", tableName);
                CallerCtrolId = new PropertyItem("CallerCtrolId", tableName);
                Image = new PropertyItem("Image", tableName);
                CallAssembly = new PropertyItem("CallAssembly", tableName);
                CallClass = new PropertyItem("CallClass", tableName);
                CallMethod = new PropertyItem("CallMethod", tableName);
                DockPaneKey = new PropertyItem("DockPaneKey", tableName);
                IsCtrl = new PropertyItem("IsCtrl", tableName);
                IsShift = new PropertyItem("IsShift", tableName);
                IsAlt = new PropertyItem("IsAlt", tableName);
                IsWindow = new PropertyItem("IsWindow", tableName);
                Shortcuts = new PropertyItem("Shortcuts", tableName);
                Version = new PropertyItem("Version", tableName);
                OrderNo = new PropertyItem("OrderNo", tableName);
                Description = new PropertyItem("Description", tableName);
                ParentID = new PropertyItem("ParentID", tableName);
                ClassCode = new PropertyItem("ClassCode", tableName);
                ShowType = new PropertyItem("ShowType", tableName);
                IsEnable = new PropertyItem("IsEnable", tableName);
                IsVisble = new PropertyItem("IsVisble", tableName);
                IsShowGroup = new PropertyItem("IsShowGroup", tableName);
                MenuType = new PropertyItem("MenuType", tableName);
                IsRecord = new PropertyItem("IsRecord", tableName);
                IsDefaultCheck = new PropertyItem("IsDefaultCheck", tableName);
                WebMethod = new PropertyItem("WebMethod", tableName);
                MethodParas = new PropertyItem("MethodParas", tableName);
                IsMustNot = new PropertyItem("IsMustNot", tableName);
                IsMust = new PropertyItem("IsMust", tableName);
                NotShowLoading = new PropertyItem("NotShowLoading", tableName);

            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 功能ID,
            /// </summary> 
            public PropertyItem FuntionID = null;
            /// <summary>
            /// 编码,
            /// </summary> 
            public PropertyItem Code = null;
            /// <summary>
            /// 名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// 类型,菜单、工具栏、右键菜单、窗体控件(此时编码需要和控件ID相同)
            /// </summary> 
            public PropertyItem Type = null;
            /// <summary>
            /// 调用控件ID,只有右键菜单使用，标识改控件调用的右键菜单
            /// </summary> 
            public PropertyItem CallerCtrolId = null;
            /// <summary>
            /// 图标,
            /// </summary> 
            public PropertyItem Image = null;
            /// <summary>
            /// 程序集,
            /// </summary> 
            public PropertyItem CallAssembly = null;
            /// <summary>
            /// 类,
            /// </summary> 
            public PropertyItem CallClass = null;
            /// <summary>
            /// 方法,
            /// </summary> 
            public PropertyItem CallMethod = null;
            /// <summary>
            /// 需要的dockpanelID,存储Desktop.Instance.dockList中的悬靠窗口Key值。
            /// </summary> 
            public PropertyItem DockPaneKey = null;
            /// <summary>
            /// 是否使Ctrl键,
            /// </summary> 
            public PropertyItem IsCtrl = null;
            /// <summary>
            /// 是否使Shift键,
            /// </summary> 
            public PropertyItem IsShift = null;
            /// <summary>
            /// 是否使用Alt键,
            /// </summary> 
            public PropertyItem IsAlt = null;
            /// <summary>
            /// 是否使用窗口键,
            /// </summary> 
            public PropertyItem IsWindow = null;
            /// <summary>
            /// 快捷键,
            /// </summary> 
            public PropertyItem Shortcuts = null;
            /// <summary>
            /// 版本,
            /// </summary> 
            public PropertyItem Version = null;
            /// <summary>
            /// 顺序,
            /// </summary> 
            public PropertyItem OrderNo = null;
            /// <summary>
            /// 描述,
            /// </summary> 
            public PropertyItem Description = null;
            /// <summary>
            /// 父对象,
            /// </summary> 
            public PropertyItem ParentID = null;
            /// <summary>
            /// 分级码,
            /// </summary> 
            public PropertyItem ClassCode = null;
            /// <summary>
            /// 显示方式,文本、图形、文本兼图形
            /// </summary> 
            public PropertyItem ShowType = null;
            /// <summary>
            /// 可用,
            /// </summary> 
            public PropertyItem IsEnable = null;
            /// <summary>
            /// 可见,
            /// </summary> 
            public PropertyItem IsVisble = null;
            /// <summary>
            /// 是否显示分割线,
            /// </summary> 
            public PropertyItem IsShowGroup = null;
            /// <summary>
            /// 菜单类型,
            /// </summary> 
            public PropertyItem MenuType = null;
            /// <summary>
            /// 是否记录,ServiceManager.BarItemService.dockPanelView[key]方式获得该菜单项，key为该节点的ID，一般为BarLinkContainerItem的用到
            /// </summary> 
            public PropertyItem IsRecord = null;
            /// <summary>
            /// 是否默认勾选,
            /// </summary> 
            public PropertyItem IsDefaultCheck = null;
            /// <summary>
            /// web调用方法,
            /// </summary> 
            public PropertyItem WebMethod = null;
            /// <summary>
            /// 参数,
            /// </summary> 
            public PropertyItem MethodParas = null;
            /// <summary>
            /// 一定不会在权限设置里出现的功能，一般给设计人员使用的功能,
            /// </summary> 
            public PropertyItem IsMustNot = null;
            /// <summary>
            /// 超出权限，不用设置权限也会使用的基本功能,
            /// </summary> 
            public PropertyItem IsMust = null;
            /// <summary>
            /// 不显示加载动画,
            /// </summary> 
            public PropertyItem NotShowLoading = null;


        }
        #endregion
    }
}
