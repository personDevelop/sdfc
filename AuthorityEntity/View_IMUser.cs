using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sharp.Common;
using System.Runtime.Serialization;

namespace AuthorityEntity
{
    /// <summary>
    /// 即时通讯专用用户表
    /// </summary> 
    [DataContract]
    public partial class View_IMUser : BaseEntity
    {
        public static Column _ = new Column("View_IMUser");

        public View_IMUser()
        {
            this.TableName = "View_IMUser";
        }
        [OnDeserialized]
        public new void OnDeserializing(StreamingContext context)
        {
            this.TableName = "View_IMUser";
        }

        #region 私有变量
        private string _ID;
        private string _Code;
        private string _Name;
        private string _NickyName;
        private string _Signature;
        private string _Photo;
        private string _Pwd;
        private string _Sex;
        private DateTime? _Birthday;
        private string _ContactPhone;
        private string _AgentID;
        private string _AgentGroup;
        private string _ICallPwd;
        private bool _IsWebPerson;
        private bool _BJDH;
        private string _Note;
        private string _Email;
        private string _QQ;
        private string _CompName;
        private string _DepartName;
        private string _IMGroupName;
        private string _DepartID;
        private bool _IsOnLine;

        #endregion

        #region 属性
        /// <summary>
        ///  ID,
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
        ///  用户名,
        /// </summary>
        [DbProperty(MapingColumnName = "Code", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        ///  姓名,
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
        ///  昵称,
        /// </summary>
        [DbProperty(MapingColumnName = "NickyName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        ///  个性签名,
        /// </summary>
        [DbProperty(MapingColumnName = "Signature", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 600, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        ///  密码,
        /// </summary>
        [DbProperty(MapingColumnName = "Pwd", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        ///  性别,
        /// </summary>
        [DbProperty(MapingColumnName = "Sex", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 20, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        ///  联系电话,
        /// </summary>
        [DbProperty(MapingColumnName = "ContactPhone", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        ///  工号（打电话用）,
        /// </summary>
        [DbProperty(MapingColumnName = "AgentID", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 40, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        ///  工号组（打电话用）,
        /// </summary>
        [DbProperty(MapingColumnName = "AgentGroup", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        ///  工号电话密码（打电话用）,
        /// </summary>
        [DbProperty(MapingColumnName = "ICallPwd", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string ICallPwd
        {
            get
            {
                return this._ICallPwd;
            }
            set
            {

                this.OnPropertyChanged("ICallPwd", this._ICallPwd, value);
                this._ICallPwd = value;
            }
        }

        /// <summary>
        ///  是网服,
        /// </summary>
        [DbProperty(MapingColumnName = "IsWebPerson", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 1, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public bool IsWebPerson
        {
            get
            {
                return this._IsWebPerson;
            }
            set
            {

                this.OnPropertyChanged("IsWebPerson", this._IsWebPerson, value);
                this._IsWebPerson = value;
            }
        }

        /// <summary>
        ///  不接电话,
        /// </summary>
        [DbProperty(MapingColumnName = "BJDH", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 1, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        ///  说明,
        /// </summary>
        [DbProperty(MapingColumnName = "Note", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 2000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        ///  邮箱,
        /// </summary>
        [DbProperty(MapingColumnName = "Email", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        [DbProperty(MapingColumnName = "QQ", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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

        /// <summary>
        ///  公司名称,
        /// </summary>
        [DbProperty(MapingColumnName = "CompName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string CompName
        {
            get
            {
                return this._CompName;
            }
            set
            {

                this.OnPropertyChanged("CompName", this._CompName, value);
                this._CompName = value;
            }
        }

        /// <summary>
        ///  部门名称,
        /// </summary>
        [DbProperty(MapingColumnName = "DepartName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string DepartName
        {
            get
            {
                return this._DepartName;
            }
            set
            {

                this.OnPropertyChanged("DepartName", this._DepartName, value);
                this._DepartName = value;
            }
        }

        /// <summary>
        ///  IM分组专用组名,
        /// </summary>
        [DbProperty(MapingColumnName = "IMGroupName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 400, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string IMGroupName
        {
            get
            {
                return this._IMGroupName;
            }
            set
            {

                this.OnPropertyChanged("IMGroupName", this._IMGroupName, value);
                this._IMGroupName = value;
            }
        }

        /// <summary>
        ///  部门ID,
        /// </summary>
        [DbProperty(MapingColumnName = "DepartID", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        ///  是否在线,
        /// </summary>
        [DbProperty(MapingColumnName = "IsOnLine", DbTypeString = "bit", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public bool IsOnLine
        {
            get
            {
                return this._IsOnLine;
            }
            set
            {

                this.OnPropertyChanged("IsOnLine", this._IsOnLine, value);
                this._IsOnLine = value;
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

                NickyName = new PropertyItem("NickyName", tableName);

                Signature = new PropertyItem("Signature", tableName);

                Photo = new PropertyItem("Photo", tableName);

                Pwd = new PropertyItem("Pwd", tableName);

                Sex = new PropertyItem("Sex", tableName);

                Birthday = new PropertyItem("Birthday", tableName);

                ContactPhone = new PropertyItem("ContactPhone", tableName);

                AgentID = new PropertyItem("AgentID", tableName);

                AgentGroup = new PropertyItem("AgentGroup", tableName);

                ICallPwd = new PropertyItem("ICallPwd", tableName);

                IsWebPerson = new PropertyItem("IsWebPerson", tableName);

                BJDH = new PropertyItem("BJDH", tableName);

                Note = new PropertyItem("Note", tableName);

                Email = new PropertyItem("Email", tableName);

                QQ = new PropertyItem("QQ", tableName);

                CompName = new PropertyItem("CompName", tableName);

                DepartName = new PropertyItem("DepartName", tableName);

                IMGroupName = new PropertyItem("IMGroupName", tableName);

                DepartID = new PropertyItem("DepartID", tableName);

                IsOnLine = new PropertyItem("IsOnLine", tableName);


            }
            /// <summary>
            /// ID,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 用户名,
            /// </summary> 
            public PropertyItem Code = null;
            /// <summary>
            /// 姓名,
            /// </summary> 
            public PropertyItem Name = null;
            /// <summary>
            /// 昵称,
            /// </summary> 
            public PropertyItem NickyName = null;
            /// <summary>
            /// 个性签名,
            /// </summary> 
            public PropertyItem Signature = null;
            /// <summary>
            /// 头像,
            /// </summary> 
            public PropertyItem Photo = null;
            /// <summary>
            /// 密码,
            /// </summary> 
            public PropertyItem Pwd = null;
            /// <summary>
            /// 性别,
            /// </summary> 
            public PropertyItem Sex = null;
            /// <summary>
            /// 生日,
            /// </summary> 
            public PropertyItem Birthday = null;
            /// <summary>
            /// 联系电话,
            /// </summary> 
            public PropertyItem ContactPhone = null;
            /// <summary>
            /// 工号（打电话用）,
            /// </summary> 
            public PropertyItem AgentID = null;
            /// <summary>
            /// 工号组（打电话用）,
            /// </summary> 
            public PropertyItem AgentGroup = null;
            /// <summary>
            /// 工号电话密码（打电话用）,
            /// </summary> 
            public PropertyItem ICallPwd = null;
            /// <summary>
            /// 是网服,
            /// </summary> 
            public PropertyItem IsWebPerson = null;
            /// <summary>
            /// 不接电话,
            /// </summary> 
            public PropertyItem BJDH = null;
            /// <summary>
            /// 说明,
            /// </summary> 
            public PropertyItem Note = null;
            /// <summary>
            /// 邮箱,
            /// </summary> 
            public PropertyItem Email = null;
            /// <summary>
            /// QQ,
            /// </summary> 
            public PropertyItem QQ = null;
            /// <summary>
            /// 公司名称,
            /// </summary> 
            public PropertyItem CompName = null;
            /// <summary>
            /// 部门名称,
            /// </summary> 
            public PropertyItem DepartName = null;
            /// <summary>
            /// IM分组专用组名,
            /// </summary> 
            public PropertyItem IMGroupName = null;
            /// <summary>
            /// 部门ID,
            /// </summary> 
            public PropertyItem DepartID = null;
            /// <summary>
            /// 是否在线,
            /// </summary> 
            public PropertyItem IsOnLine = null;
        }
        #endregion
    }


    [Serializable]
    public partial class View_IMUser
    {
        /// <summary>
        /// 获取用户状态
        /// </summary>
        [NotDbCol]
        public int UserState { get; set; }

        /// <summary>
        /// 登录结果
        /// </summary>
        [NotDbCol]
        public string Response { get; set; }
         
         
    }
}
