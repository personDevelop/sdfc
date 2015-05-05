using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sharp.Common;
using System.Runtime.Serialization;

namespace AuthorityEntity
{
    /// <summary>
    /// leavemsg
    /// </summary> 
    [DataContract]
    public partial class leavemsg : BaseEntity
    {
        public static Column _ = new Column("leavemsg");

        public leavemsg()
        {
            this.TableName = "leavemsg";
        }
        [OnDeserialized]
        public new void OnDeserializing(StreamingContext context)
        {
            this.TableName = "leavemsg";
        }

        #region 私有变量
        private string _mes_id;
        private string _mes_time;
        private string _mes_content;
        private string _mes_op;
        private string _mes_tel;
        private string _mes_name;
        private string _mes_mail;
        private string _mes_address;
        private string _mes_replyid;
        private string _mes_replyname;
        private string _mes_replytime;
        private string _mes_replylasttime;
        private string _mes_replycontent;
        private string _mes_status;

        #endregion

        #region 属性
        /// <summary>
        ///  mes_id,
        /// </summary>
        [PrimaryKey]
        [DbProperty(MapingColumnName = "mes_id", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string mes_id
        {
            get
            {
                return this._mes_id;
            }
            set
            {

                this.OnPropertyChanged("mes_id", this._mes_id, value);
                this._mes_id = value;
            }
        }

        /// <summary>
        ///  mes_time,
        /// </summary>
        [DbProperty(MapingColumnName = "mes_time", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string mes_time
        {
            get
            {
                return this._mes_time;
            }
            set
            {

                this.OnPropertyChanged("mes_time", this._mes_time, value);
                this._mes_time = value;
            }
        }

        /// <summary>
        ///  mes_content,
        /// </summary>
        [DbProperty(MapingColumnName = "mes_content", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 1000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string mes_content
        {
            get
            {
                return this._mes_content;
            }
            set
            {

                this.OnPropertyChanged("mes_content", this._mes_content, value);
                this._mes_content = value;
            }
        }

        /// <summary>
        ///  mes_op,
        /// </summary>
        [DbProperty(MapingColumnName = "mes_op", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string mes_op
        {
            get
            {
                return this._mes_op;
            }
            set
            {

                this.OnPropertyChanged("mes_op", this._mes_op, value);
                this._mes_op = value;
            }
        }

        /// <summary>
        ///  mes_tel,
        /// </summary>
        [DbProperty(MapingColumnName = "mes_tel", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string mes_tel
        {
            get
            {
                return this._mes_tel;
            }
            set
            {

                this.OnPropertyChanged("mes_tel", this._mes_tel, value);
                this._mes_tel = value;
            }
        }

        /// <summary>
        ///  mes_name,
        /// </summary>
        [DbProperty(MapingColumnName = "mes_name", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string mes_name
        {
            get
            {
                return this._mes_name;
            }
            set
            {

                this.OnPropertyChanged("mes_name", this._mes_name, value);
                this._mes_name = value;
            }
        }

        /// <summary>
        ///  mes_mail,
        /// </summary>
        [DbProperty(MapingColumnName = "mes_mail", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string mes_mail
        {
            get
            {
                return this._mes_mail;
            }
            set
            {

                this.OnPropertyChanged("mes_mail", this._mes_mail, value);
                this._mes_mail = value;
            }
        }

        /// <summary>
        ///  mes_address,
        /// </summary>
        [DbProperty(MapingColumnName = "mes_address", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string mes_address
        {
            get
            {
                return this._mes_address;
            }
            set
            {

                this.OnPropertyChanged("mes_address", this._mes_address, value);
                this._mes_address = value;
            }
        }

        /// <summary>
        ///  mes_replyid,
        /// </summary>
        [DbProperty(MapingColumnName = "mes_replyid", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string mes_replyid
        {
            get
            {
                return this._mes_replyid;
            }
            set
            {

                this.OnPropertyChanged("mes_replyid", this._mes_replyid, value);
                this._mes_replyid = value;
            }
        }

        /// <summary>
        ///  mes_replyname,
        /// </summary>
        [DbProperty(MapingColumnName = "mes_replyname", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string mes_replyname
        {
            get
            {
                return this._mes_replyname;
            }
            set
            {

                this.OnPropertyChanged("mes_replyname", this._mes_replyname, value);
                this._mes_replyname = value;
            }
        }

        /// <summary>
        ///  mes_replytime,
        /// </summary>
        [DbProperty(MapingColumnName = "mes_replytime", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string mes_replytime
        {
            get
            {
                return this._mes_replytime;
            }
            set
            {

                this.OnPropertyChanged("mes_replytime", this._mes_replytime, value);
                this._mes_replytime = value;
            }
        }

        /// <summary>
        ///  mes_replylasttime,
        /// </summary>
        [DbProperty(MapingColumnName = "mes_replylasttime", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 200, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string mes_replylasttime
        {
            get
            {
                return this._mes_replylasttime;
            }
            set
            {

                this.OnPropertyChanged("mes_replylasttime", this._mes_replylasttime, value);
                this._mes_replylasttime = value;
            }
        }

        /// <summary>
        ///  mes_replycontent,
        /// </summary>
        [DbProperty(MapingColumnName = "mes_replycontent", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 1000, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string mes_replycontent
        {
            get
            {
                return this._mes_replycontent;
            }
            set
            {

                this.OnPropertyChanged("mes_replycontent", this._mes_replycontent, value);
                this._mes_replycontent = value;
            }
        }

        /// <summary>
        ///  mes_status,
        /// </summary>
        [DbProperty(MapingColumnName = "mes_status", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string mes_status
        {
            get
            {
                return this._mes_status;
            }
            set
            {

                this.OnPropertyChanged("mes_status", this._mes_status, value);
                this._mes_status = value;
            }
        }


        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                mes_id = new PropertyItem("mes_id", tableName);

                mes_time = new PropertyItem("mes_time", tableName);

                mes_content = new PropertyItem("mes_content", tableName);

                mes_op = new PropertyItem("mes_op", tableName);

                mes_tel = new PropertyItem("mes_tel", tableName);

                mes_name = new PropertyItem("mes_name", tableName);

                mes_mail = new PropertyItem("mes_mail", tableName);

                mes_address = new PropertyItem("mes_address", tableName);

                mes_replyid = new PropertyItem("mes_replyid", tableName);

                mes_replyname = new PropertyItem("mes_replyname", tableName);

                mes_replytime = new PropertyItem("mes_replytime", tableName);

                mes_replylasttime = new PropertyItem("mes_replylasttime", tableName);

                mes_replycontent = new PropertyItem("mes_replycontent", tableName);

                mes_status = new PropertyItem("mes_status", tableName);


            }
            /// <summary>
            /// mes_id,
            /// </summary> 
            public PropertyItem mes_id = null;
            /// <summary>
            /// mes_time,
            /// </summary> 
            public PropertyItem mes_time = null;
            /// <summary>
            /// mes_content,
            /// </summary> 
            public PropertyItem mes_content = null;
            /// <summary>
            /// mes_op,
            /// </summary> 
            public PropertyItem mes_op = null;
            /// <summary>
            /// mes_tel,
            /// </summary> 
            public PropertyItem mes_tel = null;
            /// <summary>
            /// mes_name,
            /// </summary> 
            public PropertyItem mes_name = null;
            /// <summary>
            /// mes_mail,
            /// </summary> 
            public PropertyItem mes_mail = null;
            /// <summary>
            /// mes_address,
            /// </summary> 
            public PropertyItem mes_address = null;
            /// <summary>
            /// mes_replyid,
            /// </summary> 
            public PropertyItem mes_replyid = null;
            /// <summary>
            /// mes_replyname,
            /// </summary> 
            public PropertyItem mes_replyname = null;
            /// <summary>
            /// mes_replytime,
            /// </summary> 
            public PropertyItem mes_replytime = null;
            /// <summary>
            /// mes_replylasttime,
            /// </summary> 
            public PropertyItem mes_replylasttime = null;
            /// <summary>
            /// mes_replycontent,
            /// </summary> 
            public PropertyItem mes_replycontent = null;
            /// <summary>
            /// mes_status,
            /// </summary> 
            public PropertyItem mes_status = null;
        }
        #endregion
    }


}
