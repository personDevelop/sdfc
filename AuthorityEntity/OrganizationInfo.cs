using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Sharp.Common;

namespace AuthorityEntity
{
    /// <summary>
    /// 组织机构
    /// </summary> 
    [DataContract]
    public partial class OrganizationInfo : BaseEntity
    {
        public static Column _ = new Column("OrganizationInfo");

        public OrganizationInfo()
        {
            this.TableName = "OrganizationInfo";
        }
        [OnDeserialized]
        public new void OnDeserializing(StreamingContext context)
        {
            this.TableName = "OrganizationInfo";
        }

        #region 私有变量

        private string _ID;

        private string _Code;

        private string _Name;

        private string _FullName;

        private string _ClassCode;

        private int _Series;

        private bool _IsDetails;

        private string _ParentID;

        private bool _Enable;

        private string _ComType;

        private string _Industry;

        private string _Address;

        private string _Privinace;

        private string _City;

        private string _County;

        private string _Phone;

        private string _Fax;

        private string _WebSite;

        private string _Email;

        private string _RegisteredCapital;

        private string _Legal;

        private string _LicenseNo;

        private string _Logo;

        private string _PubImage;

        private string _Note;

        private string _OrgType;

        private string _CompID;

        private string _LegalerID;

        private string _Legaler;

        private string _GJ;
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
        ///  全称,
        /// </summary>

        [DbProperty(MapingColumnName = "FullName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 400, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string FullName
        {
            get
            {
                return this._FullName;
            }
            set
            {

                this.OnPropertyChanged("FullName", this._FullName, value);
                this._FullName = value;
            }
        }/// <summary>
        ///  分级码,
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
        }/// <summary>
        ///  级次,
        /// </summary>

        [DbProperty(MapingColumnName = "Series", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public int Series
        {
            get
            {
                return this._Series;
            }
            set
            {

                this.OnPropertyChanged("Series", this._Series, value);
                this._Series = value;
            }
        }/// <summary>
        ///  是否明细,
        /// </summary>

        [DbProperty(MapingColumnName = "IsDetails", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 1, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public bool IsDetails
        {
            get
            {
                return this._IsDetails;
            }
            set
            {

                this.OnPropertyChanged("IsDetails", this._IsDetails, value);
                this._IsDetails = value;
            }
        }/// <summary>
        ///  父ID,
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
        }/// <summary>
        ///  是否可用,
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
        ///  公司类型,
        /// </summary>

        [DbProperty(MapingColumnName = "ComType", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string ComType
        {
            get
            {
                return this._ComType;
            }
            set
            {

                this.OnPropertyChanged("ComType", this._ComType, value);
                this._ComType = value;
            }
        }/// <summary>
        ///  公司行业,
        /// </summary>

        [DbProperty(MapingColumnName = "Industry", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string Industry
        {
            get
            {
                return this._Industry;
            }
            set
            {

                this.OnPropertyChanged("Industry", this._Industry, value);
                this._Industry = value;
            }
        }/// <summary>
        ///  公司地址,
        /// </summary>

        [DbProperty(MapingColumnName = "Address", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 400, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string Address
        {
            get
            {
                return this._Address;
            }
            set
            {

                this.OnPropertyChanged("Address", this._Address, value);
                this._Address = value;
            }
        }/// <summary>
        ///  省,
        /// </summary>

        [DbProperty(MapingColumnName = "Privinace", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string Privinace
        {
            get
            {
                return this._Privinace;
            }
            set
            {

                this.OnPropertyChanged("Privinace", this._Privinace, value);
                this._Privinace = value;
            }
        }/// <summary>
        ///  市,
        /// </summary>

        [DbProperty(MapingColumnName = "City", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string City
        {
            get
            {
                return this._City;
            }
            set
            {

                this.OnPropertyChanged("City", this._City, value);
                this._City = value;
            }
        }/// <summary>
        ///  县,
        /// </summary>

        [DbProperty(MapingColumnName = "County", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string County
        {
            get
            {
                return this._County;
            }
            set
            {

                this.OnPropertyChanged("County", this._County, value);
                this._County = value;
            }
        }/// <summary>
        ///  电话,
        /// </summary>

        [DbProperty(MapingColumnName = "Phone", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string Phone
        {
            get
            {
                return this._Phone;
            }
            set
            {

                this.OnPropertyChanged("Phone", this._Phone, value);
                this._Phone = value;
            }
        }/// <summary>
        ///  传真,
        /// </summary>

        [DbProperty(MapingColumnName = "Fax", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string Fax
        {
            get
            {
                return this._Fax;
            }
            set
            {

                this.OnPropertyChanged("Fax", this._Fax, value);
                this._Fax = value;
            }
        }/// <summary>
        ///  网址,
        /// </summary>

        [DbProperty(MapingColumnName = "WebSite", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string WebSite
        {
            get
            {
                return this._WebSite;
            }
            set
            {

                this.OnPropertyChanged("WebSite", this._WebSite, value);
                this._WebSite = value;
            }
        }/// <summary>
        ///  邮箱,
        /// </summary>

        [DbProperty(MapingColumnName = "Email", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {

                this.OnPropertyChanged("Email", this._Email, value);
                this._Email = value;
            }
        }/// <summary>
        ///  注册资金,
        /// </summary>

        [DbProperty(MapingColumnName = "RegisteredCapital", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string RegisteredCapital
        {
            get
            {
                return this._RegisteredCapital;
            }
            set
            {

                this.OnPropertyChanged("RegisteredCapital", this._RegisteredCapital, value);
                this._RegisteredCapital = value;
            }
        }/// <summary>
        ///  法人,
        /// </summary>

        [DbProperty(MapingColumnName = "Legal", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string Legal
        {
            get
            {
                return this._Legal;
            }
            set
            {

                this.OnPropertyChanged("Legal", this._Legal, value);
                this._Legal = value;
            }
        }/// <summary>
        ///  许可证号,
        /// </summary>

        [DbProperty(MapingColumnName = "LicenseNo", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string LicenseNo
        {
            get
            {
                return this._LicenseNo;
            }
            set
            {

                this.OnPropertyChanged("LicenseNo", this._LicenseNo, value);
                this._LicenseNo = value;
            }
        }/// <summary>
        ///  logo,
        /// </summary>

        [DbProperty(MapingColumnName = "Logo", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string Logo
        {
            get
            {
                return this._Logo;
            }
            set
            {

                this.OnPropertyChanged("Logo", this._Logo, value);
                this._Logo = value;
            }
        }/// <summary>
        ///  宣传图片,
        /// </summary>

        [DbProperty(MapingColumnName = "PubImage", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string PubImage
        {
            get
            {
                return this._PubImage;
            }
            set
            {

                this.OnPropertyChanged("PubImage", this._PubImage, value);
                this._PubImage = value;
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
        }/// <summary>
        ///  组织类型,
        /// </summary>

        [DbProperty(MapingColumnName = "OrgType", DbTypeString = "char", ColumnIsNull = false, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string OrgType
        {
            get
            {
                return this._OrgType;
            }
            set
            {

                this.OnPropertyChanged("OrgType", this._OrgType, value);
                this._OrgType = value;
            }
        }/// <summary>
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
        }/// <summary>
        ///  负责人ID,
        /// </summary>

        [DbProperty(MapingColumnName = "LegalerID", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string LegalerID
        {
            get
            {
                return this._LegalerID;
            }
            set
            {

                this.OnPropertyChanged("LegalerID", this._LegalerID, value);
                this._LegalerID = value;
            }
        }/// <summary>
        ///  负责人名称,
        /// </summary>

        [DbProperty(MapingColumnName = "Legaler", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string Legaler
        {
            get
            {
                return this._Legaler;
            }
            set
            {

                this.OnPropertyChanged("Legaler", this._Legaler, value);
                this._Legaler = value;
            }
        }/// <summary>
        ///  国家,
        /// </summary>

        [DbProperty(MapingColumnName = "GJ", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string GJ
        {
            get
            {
                return this._GJ;
            }
            set
            {

                this.OnPropertyChanged("GJ", this._GJ, value);
                this._GJ = value;
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

                FullName = new PropertyItem("FullName", tableName);

                ClassCode = new PropertyItem("ClassCode", tableName);

                Series = new PropertyItem("Series", tableName);

                IsDetails = new PropertyItem("IsDetails", tableName);

                ParentID = new PropertyItem("ParentID", tableName);

                Enable = new PropertyItem("Enable", tableName);

                ComType = new PropertyItem("ComType", tableName);

                Industry = new PropertyItem("Industry", tableName);

                Address = new PropertyItem("Address", tableName);

                Privinace = new PropertyItem("Privinace", tableName);

                City = new PropertyItem("City", tableName);

                County = new PropertyItem("County", tableName);

                Phone = new PropertyItem("Phone", tableName);

                Fax = new PropertyItem("Fax", tableName);

                WebSite = new PropertyItem("WebSite", tableName);

                Email = new PropertyItem("Email", tableName);

                RegisteredCapital = new PropertyItem("RegisteredCapital", tableName);

                Legal = new PropertyItem("Legal", tableName);

                LicenseNo = new PropertyItem("LicenseNo", tableName);

                Logo = new PropertyItem("Logo", tableName);

                PubImage = new PropertyItem("PubImage", tableName);

                Note = new PropertyItem("Note", tableName);

                OrgType = new PropertyItem("OrgType", tableName);

                CompID = new PropertyItem("CompID", tableName);

                LegalerID = new PropertyItem("LegalerID", tableName);

                Legaler = new PropertyItem("Legaler", tableName);

                GJ = new PropertyItem("GJ", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 编号,
            /// </summary> 
            public PropertyItem Code = null;
            /// <summary>
            /// 名称,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// 全称,
            /// </summary> 
            public PropertyItem FullName = null;
            /// <summary>
            /// 分级码,
            /// </summary> 
            public PropertyItem ClassCode = null;
            /// <summary>
            /// 级次,
            /// </summary> 
            public PropertyItem Series = null;
            /// <summary>
            /// 是否明细,
            /// </summary> 
            public PropertyItem IsDetails = null;
            /// <summary>
            /// 父ID,
            /// </summary> 
            public PropertyItem ParentID = null;
            /// <summary>
            /// 是否可用,
            /// </summary> 
            public PropertyItem Enable = null;
            /// <summary>
            /// 公司类型,
            /// </summary> 
            public PropertyItem ComType = null;
            /// <summary>
            /// 公司行业,
            /// </summary> 
            public PropertyItem Industry = null;
            /// <summary>
            /// 公司地址,
            /// </summary> 
            public PropertyItem Address = null;
            /// <summary>
            /// 省,
            /// </summary> 
            public PropertyItem Privinace = null;
            /// <summary>
            /// 市,
            /// </summary> 
            public PropertyItem City = null;
            /// <summary>
            /// 县,
            /// </summary> 
            public PropertyItem County = null;
            /// <summary>
            /// 电话,
            /// </summary> 
            public PropertyItem Phone = null;
            /// <summary>
            /// 传真,
            /// </summary> 
            public PropertyItem Fax = null;
            /// <summary>
            /// 网址,
            /// </summary> 
            public PropertyItem WebSite = null;
            /// <summary>
            /// 邮箱,
            /// </summary> 
            public PropertyItem Email = null;
            /// <summary>
            /// 注册资金,
            /// </summary> 
            public PropertyItem RegisteredCapital = null;
            /// <summary>
            /// 法人,
            /// </summary> 
            public PropertyItem Legal = null;
            /// <summary>
            /// 许可证号,
            /// </summary> 
            public PropertyItem LicenseNo = null;
            /// <summary>
            /// logo,
            /// </summary> 
            public PropertyItem Logo = null;
            /// <summary>
            /// 宣传图片,
            /// </summary> 
            public PropertyItem PubImage = null;
            /// <summary>
            /// 备注,
            /// </summary> 
            public PropertyItem Note = null;
            /// <summary>
            /// 组织类型,
            /// </summary> 
            public PropertyItem OrgType = null;
            /// <summary>
            /// 公司ID,
            /// </summary> 
            public PropertyItem CompID = null;
            /// <summary>
            /// 负责人ID,
            /// </summary> 
            public PropertyItem LegalerID = null;
            /// <summary>
            /// 负责人名称,
            /// </summary> 
            public PropertyItem Legaler = null;
            /// <summary>
            /// 国家,
            /// </summary> 
            public PropertyItem GJ = null;
        }
        #endregion
    }


    public partial class OrganizationInfo
    {
        [NotDbCol]
        public bool IsDefault { get; set; }
        [NotDbCol]
        public string PositionID { get; set; }
        [NotDbCol]
        public string PositionName { get; set; }

         [NotDbCol]
        public string OrgTypeName { get; set; }

         [NotDbCol]
         public string CompanyName { get; set; }

         #region 工作流分配
         [NotDbCol]
         public bool IsSelected { get; set; }
         [NotDbCol]
         public string WfID { get; set; }
         [NotDbCol]
         public string DistributionID { get; set; }
         #endregion
    }
}
