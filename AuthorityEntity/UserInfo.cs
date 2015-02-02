using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sharp.Common;
using System.Runtime.Serialization;

namespace AuthorityEntity
{
    /// <summary>
    /// 用户表
    /// </summary> 
    [DataContract]
    public partial class UserInfo : BaseEntity
    {
        public static Column _ = new Column("UserInfo");

        public UserInfo()
        {
            this.TableName = "UserInfo";
        }
        [OnDeserialized]
        public new void OnDeserializing(StreamingContext context)
        {
            this.TableName = "UserInfo";
        }

        #region 私有变量
        private string _ID;
        private string _Code;
        private string _Pwd;
        private string _Name;
        private string _Photo;
        private string _NickyName;
        private string _Sex;
        private DateTime? _Birthday;
        private string _Signature;
        private string _IDNumber;
        private string _FamilyProvince;
        private string _FamilyCity;
        private string _FamilyContry;
        private string _FamilyAddress;
        private string _FamilyPhone;
        private string _ContactProvincial;
        private string _ContactCity;
        private string _ContactContry;
        private string _ContactAddress;
        private string _ContactPhone;
        private DateTime? _EntryDate;
        private DateTime? _TurnoverDate;
        private int? _WorkDays;
        private string _Status;
        private string _AgentID;
        private string _AgentGroup;
        private bool _BJDH;
        private string _SignaturePhot;
        private string _Note;
        private string _Email;
        private string _QQ;

        #endregion

        #region 属性
        /// <summary>
        ///  用户ID,
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
        }

        /// <summary>
        ///  密码,
        /// </summary>
        [DbProperty(MapingColumnName = "Pwd", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string Pwd
        {
            get
            {
                return this._Pwd;
            }
            set
            {

                this.OnPropertyChanged("Pwd", this._Pwd, value);
                this._Pwd = value;
            }
        }

        /// <summary>
        ///  姓名,
        /// </summary>
        [DbProperty(MapingColumnName = "Name", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        ///  头像,
        /// </summary>
        [DbProperty(MapingColumnName = "Photo", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string Photo
        {
            get
            {
                return this._Photo;
            }
            set
            {

                this.OnPropertyChanged("Photo", this._Photo, value);
                this._Photo = value;
            }
        }

        /// <summary>
        ///  昵称,
        /// </summary>
        [DbProperty(MapingColumnName = "NickyName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string NickyName
        {
            get
            {
                return this._NickyName;
            }
            set
            {

                this.OnPropertyChanged("NickyName", this._NickyName, value);
                this._NickyName = value;
            }
        }

        /// <summary>
        ///  性别,
        /// </summary>
        [DbProperty(MapingColumnName = "Sex", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 10, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string Sex
        {
            get
            {
                return this._Sex;
            }
            set
            {

                this.OnPropertyChanged("Sex", this._Sex, value);
                this._Sex = value;
            }
        }

        /// <summary>
        ///  生日,
        /// </summary>
        [DbProperty(MapingColumnName = "Birthday", DbTypeString = "datetime", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public DateTime? Birthday
        {
            get
            {
                return this._Birthday;
            }
            set
            {

                this.OnPropertyChanged("Birthday", this._Birthday, value);
                this._Birthday = value;
            }
        }

        /// <summary>
        ///  个性签名,
        /// </summary>
        [DbProperty(MapingColumnName = "Signature", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 300, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string Signature
        {
            get
            {
                return this._Signature;
            }
            set
            {

                this.OnPropertyChanged("Signature", this._Signature, value);
                this._Signature = value;
            }
        }

        /// <summary>
        ///  身份证,
        /// </summary>
        [DbProperty(MapingColumnName = "IDNumber", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 30, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string IDNumber
        {
            get
            {
                return this._IDNumber;
            }
            set
            {

                this.OnPropertyChanged("IDNumber", this._IDNumber, value);
                this._IDNumber = value;
            }
        }

        /// <summary>
        ///  家庭省,
        /// </summary>
        [DbProperty(MapingColumnName = "FamilyProvince", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string FamilyProvince
        {
            get
            {
                return this._FamilyProvince;
            }
            set
            {

                this.OnPropertyChanged("FamilyProvince", this._FamilyProvince, value);
                this._FamilyProvince = value;
            }
        }

        /// <summary>
        ///  家庭市,
        /// </summary>
        [DbProperty(MapingColumnName = "FamilyCity", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string FamilyCity
        {
            get
            {
                return this._FamilyCity;
            }
            set
            {

                this.OnPropertyChanged("FamilyCity", this._FamilyCity, value);
                this._FamilyCity = value;
            }
        }

        /// <summary>
        ///  家庭县,
        /// </summary>
        [DbProperty(MapingColumnName = "FamilyContry", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string FamilyContry
        {
            get
            {
                return this._FamilyContry;
            }
            set
            {

                this.OnPropertyChanged("FamilyContry", this._FamilyContry, value);
                this._FamilyContry = value;
            }
        }

        /// <summary>
        ///  籍贯详细地址,
        /// </summary>
        [DbProperty(MapingColumnName = "FamilyAddress", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string FamilyAddress
        {
            get
            {
                return this._FamilyAddress;
            }
            set
            {

                this.OnPropertyChanged("FamilyAddress", this._FamilyAddress, value);
                this._FamilyAddress = value;
            }
        }

        /// <summary>
        ///  家庭电话,
        /// </summary>
        [DbProperty(MapingColumnName = "FamilyPhone", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string FamilyPhone
        {
            get
            {
                return this._FamilyPhone;
            }
            set
            {

                this.OnPropertyChanged("FamilyPhone", this._FamilyPhone, value);
                this._FamilyPhone = value;
            }
        }

        /// <summary>
        ///  长住省,
        /// </summary>
        [DbProperty(MapingColumnName = "ContactProvincial", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string ContactProvincial
        {
            get
            {
                return this._ContactProvincial;
            }
            set
            {

                this.OnPropertyChanged("ContactProvincial", this._ContactProvincial, value);
                this._ContactProvincial = value;
            }
        }

        /// <summary>
        ///  长住市,
        /// </summary>
        [DbProperty(MapingColumnName = "ContactCity", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string ContactCity
        {
            get
            {
                return this._ContactCity;
            }
            set
            {

                this.OnPropertyChanged("ContactCity", this._ContactCity, value);
                this._ContactCity = value;
            }
        }

        /// <summary>
        ///  长住县,
        /// </summary>
        [DbProperty(MapingColumnName = "ContactContry", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string ContactContry
        {
            get
            {
                return this._ContactContry;
            }
            set
            {

                this.OnPropertyChanged("ContactContry", this._ContactContry, value);
                this._ContactContry = value;
            }
        }

        /// <summary>
        ///  长住详细地址,
        /// </summary>
        [DbProperty(MapingColumnName = "ContactAddress", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string ContactAddress
        {
            get
            {
                return this._ContactAddress;
            }
            set
            {

                this.OnPropertyChanged("ContactAddress", this._ContactAddress, value);
                this._ContactAddress = value;
            }
        }

        /// <summary>
        ///  联系手机,
        /// </summary>
        [DbProperty(MapingColumnName = "ContactPhone", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string ContactPhone
        {
            get
            {
                return this._ContactPhone;
            }
            set
            {

                this.OnPropertyChanged("ContactPhone", this._ContactPhone, value);
                this._ContactPhone = value;
            }
        }

        /// <summary>
        ///  入职日期,
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
        ///  离职日期,
        /// </summary>
        [DbProperty(MapingColumnName = "TurnoverDate", DbTypeString = "datetime", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public DateTime? TurnoverDate
        {
            get
            {
                return this._TurnoverDate;
            }
            set
            {

                this.OnPropertyChanged("TurnoverDate", this._TurnoverDate, value);
                this._TurnoverDate = value;
            }
        }

        /// <summary>
        ///  工龄,
        /// </summary>
        [DbProperty(MapingColumnName = "WorkDays", DbTypeString = "int", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public int? WorkDays
        {
            get
            {
                return this._WorkDays;
            }
            set
            {

                this.OnPropertyChanged("WorkDays", this._WorkDays, value);
                this._WorkDays = value;
            }
        }

        /// <summary>
        ///  状态,
        /// </summary>
        [DbProperty(MapingColumnName = "Status", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 20, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string Status
        {
            get
            {
                return this._Status;
            }
            set
            {

                this.OnPropertyChanged("Status", this._Status, value);
                this._Status = value;
            }
        }

        /// <summary>
        ///  工号,
        /// </summary>
        [DbProperty(MapingColumnName = "AgentID", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 20, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string AgentID
        {
            get
            {
                return this._AgentID;
            }
            set
            {

                this.OnPropertyChanged("AgentID", this._AgentID, value);
                this._AgentID = value;
            }
        }

        /// <summary>
        ///  坐席组,
        /// </summary>
        [DbProperty(MapingColumnName = "AgentGroup", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string AgentGroup
        {
            get
            {
                return this._AgentGroup;
            }
            set
            {

                this.OnPropertyChanged("AgentGroup", this._AgentGroup, value);
                this._AgentGroup = value;
            }
        }

        /// <summary>
        ///  不接电话,
        /// </summary>
        [DbProperty(MapingColumnName = "BJDH", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public bool BJDH
        {
            get
            {
                return this._BJDH;
            }
            set
            {

                this.OnPropertyChanged("BJDH", this._BJDH, value);
                this._BJDH = value;
            }
        }

        /// <summary>
        ///  个人签名图形,
        /// </summary>
        [DbProperty(MapingColumnName = "SignaturePhot", DbTypeString = "char", ColumnIsNull = true, IsUnique = false, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string SignaturePhot
        {
            get
            {
                return this._SignaturePhot;
            }
            set
            {

                this.OnPropertyChanged("SignaturePhot", this._SignaturePhot, value);
                this._SignaturePhot = value;
            }
        }

        /// <summary>
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

        /// <summary>
        ///  Email,
        /// </summary>
        [DbProperty(MapingColumnName = "Email", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        }

        /// <summary>
        ///  QQ,
        /// </summary>
        [DbProperty(MapingColumnName = "QQ", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string QQ
        {
            get
            {
                return this._QQ;
            }
            set
            {

                this.OnPropertyChanged("QQ", this._QQ, value);
                this._QQ = value;
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

                Pwd = new PropertyItem("Pwd", tableName);

                Name = new PropertyItem("Name", tableName);

                Photo = new PropertyItem("Photo", tableName);

                NickyName = new PropertyItem("NickyName", tableName);

                Sex = new PropertyItem("Sex", tableName);

                Birthday = new PropertyItem("Birthday", tableName);

                Signature = new PropertyItem("Signature", tableName);

                IDNumber = new PropertyItem("IDNumber", tableName);

                FamilyProvince = new PropertyItem("FamilyProvince", tableName);

                FamilyCity = new PropertyItem("FamilyCity", tableName);

                FamilyContry = new PropertyItem("FamilyContry", tableName);

                FamilyAddress = new PropertyItem("FamilyAddress", tableName);

                FamilyPhone = new PropertyItem("FamilyPhone", tableName);

                ContactProvincial = new PropertyItem("ContactProvincial", tableName);

                ContactCity = new PropertyItem("ContactCity", tableName);

                ContactContry = new PropertyItem("ContactContry", tableName);

                ContactAddress = new PropertyItem("ContactAddress", tableName);

                ContactPhone = new PropertyItem("ContactPhone", tableName);

                EntryDate = new PropertyItem("EntryDate", tableName);

                TurnoverDate = new PropertyItem("TurnoverDate", tableName);

                WorkDays = new PropertyItem("WorkDays", tableName);

                Status = new PropertyItem("Status", tableName);

                AgentID = new PropertyItem("AgentID", tableName);

                AgentGroup = new PropertyItem("AgentGroup", tableName);

                BJDH = new PropertyItem("BJDH", tableName);

                SignaturePhot = new PropertyItem("SignaturePhot", tableName);

                Note = new PropertyItem("Note", tableName);

                Email = new PropertyItem("Email", tableName);

                QQ = new PropertyItem("QQ", tableName);


            }
            /// <summary>
            /// 用户ID,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 编号,
            /// </summary> 
            public PropertyItem Code = null;
            /// <summary>
            /// 密码,
            /// </summary> 
            public PropertyItem Pwd = null;
            /// <summary>
            /// 姓名,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// 头像,
            /// </summary> 
            public PropertyItem Photo = null;
            /// <summary>
            /// 昵称,
            /// </summary> 
            public PropertyItem NickyName = null;
            /// <summary>
            /// 性别,
            /// </summary> 
            public PropertyItem Sex = null;
            /// <summary>
            /// 生日,
            /// </summary> 
            public PropertyItem Birthday = null;
            /// <summary>
            /// 个性签名,
            /// </summary> 
            public PropertyItem Signature = null;
            /// <summary>
            /// 身份证,
            /// </summary> 
            public PropertyItem IDNumber = null;
            /// <summary>
            /// 家庭省,
            /// </summary> 
            public PropertyItem FamilyProvince = null;
            /// <summary>
            /// 家庭市,
            /// </summary> 
            public PropertyItem FamilyCity = null;
            /// <summary>
            /// 家庭县,
            /// </summary> 
            public PropertyItem FamilyContry = null;
            /// <summary>
            /// 籍贯详细地址,
            /// </summary> 
            public PropertyItem FamilyAddress = null;
            /// <summary>
            /// 家庭电话,
            /// </summary> 
            public PropertyItem FamilyPhone = null;
            /// <summary>
            /// 长住省,
            /// </summary> 
            public PropertyItem ContactProvincial = null;
            /// <summary>
            /// 长住市,
            /// </summary> 
            public PropertyItem ContactCity = null;
            /// <summary>
            /// 长住县,
            /// </summary> 
            public PropertyItem ContactContry = null;
            /// <summary>
            /// 长住详细地址,
            /// </summary> 
            public PropertyItem ContactAddress = null;
            /// <summary>
            /// 联系手机,
            /// </summary> 
            public PropertyItem ContactPhone = null;
            /// <summary>
            /// 入职日期,
            /// </summary> 
            public PropertyItem EntryDate = null;
            /// <summary>
            /// 离职日期,
            /// </summary> 
            public PropertyItem TurnoverDate = null;
            /// <summary>
            /// 工龄,
            /// </summary> 
            public PropertyItem WorkDays = null;
            /// <summary>
            /// 状态,
            /// </summary> 
            public PropertyItem Status = null;
            /// <summary>
            /// 工号,
            /// </summary> 
            public PropertyItem AgentID = null;
            /// <summary>
            /// 坐席组,
            /// </summary> 
            public PropertyItem AgentGroup = null;
            /// <summary>
            /// 不接电话,
            /// </summary> 
            public PropertyItem BJDH = null;
            /// <summary>
            /// 个人签名图形,
            /// </summary> 
            public PropertyItem SignaturePhot = null;
            /// <summary>
            /// 备注,
            /// </summary> 
            public PropertyItem Note = null;
            /// <summary>
            /// Email,
            /// </summary> 
            public PropertyItem Email = null;
            /// <summary>
            /// QQ,
            /// </summary> 
            public PropertyItem QQ = null;
        }
        #endregion

      
    }

    public partial class UserInfo
    {
        /// <summary>
        ///  隶属部门
        /// </summary>
        [NotDbCol]
        public List<OrgUserRalation> DepartmentList { get; set; }

        

        [NotDbCol]
        public bool IsSelected { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is UserInfo)
            {
                return this.ID == (obj as UserInfo).ID;
            }
            else return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        [NotDbCol]
        public bool IsDefault { get; set; }
        [NotDbCol]
        public string PositionID { get; set; }
        [NotDbCol]
        public string PositionName { get; set; }

    }

}
