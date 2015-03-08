using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sharp.Common;
using System.Runtime.Serialization;

namespace AuthorityEntity
{
    /// <summary>
    /// 信息表
    /// </summary> 
    [DataContract]
    public partial class MsgInfo : BaseEntity
    {
        public static Column _ = new Column("MsgInfo");

        public MsgInfo()
        {
            this.TableName = "MsgInfo";
        }
        [OnDeserialized]
        public new void OnDeserializing(StreamingContext context)
        {
            this.TableName = "MsgInfo";
        }

        #region 私有变量
        private string _ID;
        private string _SenderID;
        private string _SenderName;
        private string _MsgTitle;
        private string _MsgContent;
        private DateTime _SendTime;
        private int _MsgSendType;
        private int _MsgType;
        private string _Reciver;
        private string _ReciverName;

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
        ///  发送人ID,
        /// </summary>
        [DbProperty(MapingColumnName = "SenderID", DbTypeString = "char", ColumnIsNull = true, IsUnique = true, ColumnLength = 36, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        ///  发送人名称,
        /// </summary>
        [DbProperty(MapingColumnName = "SenderName", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        ///  消息标题,
        /// </summary>
        [DbProperty(MapingColumnName = "MsgTitle", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = true, ColumnLength = 100, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string MsgTitle
        {
            get
            {
                return this._MsgTitle;
            }
            set
            {

                this.OnPropertyChanged("MsgTitle", this._MsgTitle, value);
                this._MsgTitle = value;
            }
        }

        /// <summary>
        ///  消息内容,图片的话就是图片附件ID
        /// </summary>
        [DbProperty(MapingColumnName = "MsgContent", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 500, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        ///  发送时间,
        /// </summary>
        [DbProperty(MapingColumnName = "SendTime", DbTypeString = "datetime", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public DateTime SendTime
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

        /// <summary>
        ///  消息发送类型,
        /// </summary>
        [DbProperty(MapingColumnName = "MsgSendType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public int MsgSendType
        {
            get
            {
                return this._MsgSendType;
            }
            set
            {

                this.OnPropertyChanged("MsgSendType", this._MsgSendType, value);
                this._MsgSendType = value;
            }
        }

        /// <summary>
        ///  消息内容类型,
        /// </summary>
        [DbProperty(MapingColumnName = "MsgType", DbTypeString = "int", ColumnIsNull = false, IsUnique = false, ColumnLength = 0, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public int MsgType
        {
            get
            {
                return this._MsgType;
            }
            set
            {

                this.OnPropertyChanged("MsgType", this._MsgType, value);
                this._MsgType = value;
            }
        }

        /// <summary>
        ///  接收者ID,最多20个人,人ID,组ID,或者多个人（组）之间用逗号隔开,如果为空则表示是所有人
        /// </summary>
        [DbProperty(MapingColumnName = "Reciver", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 720, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string Reciver
        {
            get
            {
                return this._Reciver;
            }
            set
            {

                this.OnPropertyChanged("Reciver", this._Reciver, value);
                this._Reciver = value;
            }
        }

        /// <summary>
        ///  接收者姓名,和ID对应
        /// </summary>
        [DbProperty(MapingColumnName = "ReciverName", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 720, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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


        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                ID = new PropertyItem("ID", tableName);

                SenderID = new PropertyItem("SenderID", tableName);

                SenderName = new PropertyItem("SenderName", tableName);

                MsgTitle = new PropertyItem("MsgTitle", tableName);

                MsgContent = new PropertyItem("MsgContent", tableName);

                SendTime = new PropertyItem("SendTime", tableName);

                MsgSendType = new PropertyItem("MsgSendType", tableName);

                MsgType = new PropertyItem("MsgType", tableName);

                Reciver = new PropertyItem("Reciver", tableName);

                ReciverName = new PropertyItem("ReciverName", tableName);


            }
            /// <summary>
            /// 主键,
            /// </summary> 
            public PropertyItem ID = null;
            /// <summary>
            /// 发送人ID,
            /// </summary> 
            public PropertyItem SenderID = null;
            /// <summary>
            /// 发送人名称,
            /// </summary> 
            public PropertyItem SenderName = null;
            /// <summary>
            /// 消息标题,
            /// </summary> 
            public PropertyItem MsgTitle = null;
            /// <summary>
            /// 消息内容,图片的话就是图片附件ID
            /// </summary> 
            public PropertyItem MsgContent = null;
            /// <summary>
            /// 发送时间,
            /// </summary> 
            public PropertyItem SendTime = null;
            /// <summary>
            /// 消息发送类型,
            /// </summary> 
            public PropertyItem MsgSendType = null;
            /// <summary>
            /// 消息内容类型,
            /// </summary> 
            public PropertyItem MsgType = null;
            /// <summary>
            /// 接收者ID,最多20个人,人ID,组ID,或者多个人（组）之间用逗号隔开,如果为空则表示是所有人
            /// </summary> 
            public PropertyItem Reciver = null;
            /// <summary>
            /// 接收者姓名,和ID对应
            /// </summary> 
            public PropertyItem ReciverName = null;
        }
        #endregion
    }

}
