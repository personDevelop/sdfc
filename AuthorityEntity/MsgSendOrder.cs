using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sharp.Common;
using System.Runtime.Serialization;

namespace AuthorityEntity
{
    /// <summary>
    /// 短信发送队列
    /// </summary> 
    [DataContract]
    public partial class MsgSendOrder : BaseEntity
    {
        public static Column _ = new Column("MsgSendOrder");

        public MsgSendOrder()
        {
            this.TableName = "MsgSendOrder";
        }
        [OnDeserialized]
        public new void OnDeserializing(StreamingContext context)
        {
            this.TableName = "MsgSendOrder";
        }

        #region 私有变量
        private string _ID;
        private string _ReciverTel;
        private string _ReciverName;
        private string _ReciverID;
        private string _SenderID;
        private string _SenderName;
        private string _SenderTel;
        private string _MsgContent;
        private string _MsgStatus;
        private DateTime _CreateDate;
        private DateTime? _SendTime;

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
        ///  接收短信电话,
        /// </summary>
        [DbProperty(MapingColumnName = "ReciverTel", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string ReciverTel
        {
            get
            {
                return this._ReciverTel;
            }
            set
            {

                this.OnPropertyChanged("ReciverTel", this._ReciverTel, value);
                this._ReciverTel = value;
            }
        }

        /// <summary>
        ///  接收短信人,
        /// </summary>
        [DbProperty(MapingColumnName = "ReciverName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = true, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string ReciverName
        {
            get
            {
                return this._ReciverName;
            }
            set
            {

                this.OnPropertyChanged("ReciverName", this._ReciverName, value);
                this._ReciverName = value;
            }
        }

        /// <summary>
        ///  短信接收人ID,
        /// </summary>
        [DbProperty(MapingColumnName = "ReciverID", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string ReciverID
        {
            get
            {
                return this._ReciverID;
            }
            set
            {

                this.OnPropertyChanged("ReciverID", this._ReciverID, value);
                this._ReciverID = value;
            }
        }

        /// <summary>
        ///  发送短信人ID,
        /// </summary>
        [DbProperty(MapingColumnName = "SenderID", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string SenderID
        {
            get
            {
                return this._SenderID;
            }
            set
            {

                this.OnPropertyChanged("SenderID", this._SenderID, value);
                this._SenderID = value;
            }
        }

        /// <summary>
        ///  发送短信人,
        /// </summary>
        [DbProperty(MapingColumnName = "SenderName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string SenderName
        {
            get
            {
                return this._SenderName;
            }
            set
            {

                this.OnPropertyChanged("SenderName", this._SenderName, value);
                this._SenderName = value;
            }
        }

        /// <summary>
        ///  发送短信人电话,
        /// </summary>
        [DbProperty(MapingColumnName = "SenderTel", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string SenderTel
        {
            get
            {
                return this._SenderTel;
            }
            set
            {

                this.OnPropertyChanged("SenderTel", this._SenderTel, value);
                this._SenderTel = value;
            }
        }

        /// <summary>
        ///  短信内容,
        /// </summary>
        [DbProperty(MapingColumnName = "MsgContent", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string MsgContent
        {
            get
            {
                return this._MsgContent;
            }
            set
            {

                this.OnPropertyChanged("MsgContent", this._MsgContent, value);
                this._MsgContent = value;
            }
        }

        /// <summary>
        ///  状态,待发送，正在发送，发送成功，发送失败
        /// </summary>
        [DbProperty(MapingColumnName = "MsgStatus", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string MsgStatus
        {
            get
            {
                return this._MsgStatus;
            }
            set
            {

                this.OnPropertyChanged("MsgStatus", this._MsgStatus, value);
                this._MsgStatus = value;
            }
        }

        /// <summary>
        ///  创建日期,
        /// </summary>
        [DbProperty(MapingColumnName = "CreateDate", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public DateTime CreateDate
        {
            get
            {
                return this._CreateDate;
            }
            set
            {

                this.OnPropertyChanged("CreateDate", this._CreateDate, value);
                this._CreateDate = value;
            }
        }

        /// <summary>
        ///  发送时间,
        /// </summary>
        [DbProperty(MapingColumnName = "SendTime", DbTypeString = "datetime", ColumnIsNull = true, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public DateTime? SendTime
        {
            get
            {
                return this._SendTime;
            }
            set
            {

                this.OnPropertyChanged("SendTime", this._SendTime, value);
                this._SendTime = value;
            }
        }


        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                ReciverTel = new PropertyItem("ReciverTel", tableName);

                ReciverName = new PropertyItem("ReciverName", tableName);

                ReciverID = new PropertyItem("ReciverID", tableName);

                SenderID = new PropertyItem("SenderID", tableName);

                SenderName = new PropertyItem("SenderName", tableName);

                SenderTel = new PropertyItem("SenderTel", tableName);

                MsgContent = new PropertyItem("MsgContent", tableName);

                MsgStatus = new PropertyItem("MsgStatus", tableName);

                CreateDate = new PropertyItem("CreateDate", tableName);

                SendTime = new PropertyItem("SendTime", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 接收短信电话,
            /// </summary> 
            public PropertyItem ReciverTel = null;
            /// <summary>
            /// 接收短信人,
            /// </summary> 
            public PropertyItem ReciverName = null;
            /// <summary>
            /// 短信接收人ID,
            /// </summary> 
            public PropertyItem ReciverID = null;
            /// <summary>
            /// 发送短信人ID,
            /// </summary> 
            public PropertyItem SenderID = null;
            /// <summary>
            /// 发送短信人,
            /// </summary> 
            public PropertyItem SenderName = null;
            /// <summary>
            /// 发送短信人电话,
            /// </summary> 
            public PropertyItem SenderTel = null;
            /// <summary>
            /// 短信内容,
            /// </summary> 
            public PropertyItem MsgContent = null;
            /// <summary>
            /// 状态,待发送，正在发送，发送成功，发送失败
            /// </summary> 
            public PropertyItem MsgStatus = null;
            /// <summary>
            /// 创建日期,
            /// </summary> 
            public PropertyItem CreateDate = null;
            /// <summary>
            /// 发送时间,
            /// </summary> 
            public PropertyItem SendTime = null;
        }
        #endregion
    }

}
