using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sharp.Common;
using System.Runtime.Serialization;

namespace AuthorityEntity
{
    /// <summary>
    /// MsgLog
    /// </summary> 
    [DataContract]
    public partial class MsgLog : BaseEntity
    {
        public static Column _ = new Column("MsgLog");

        public MsgLog()
        {
            this.TableName = "MsgLog";
        }
        [OnDeserialized]
        public new void OnDeserializing(StreamingContext context)
        {
            this.TableName = "MsgLog";
        }

        #region 私有变量
        private string _msg_id;
        private string _msg_from;
        private string _msg_to;
        private string _msg_content;
        private string _msg_isread;
        private string _msg_time;

        #endregion

        #region 属性
        /// <summary>
        ///  msg_id,
        /// </summary>
        [PrimaryKey]
        [DbProperty(MapingColumnName = "msg_id", DbTypeString = "nvarchar", ColumnIsNull = false, IsUnique = true, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string msg_id
        {
            get
            {
                return this._msg_id;
            }
            set
            {

                this.OnPropertyChanged("msg_id", this._msg_id, value);
                this._msg_id = value;
            }
        }

        /// <summary>
        ///  msg_from,
        /// </summary>
        [DbProperty(MapingColumnName = "msg_from", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string msg_from
        {
            get
            {
                return this._msg_from;
            }
            set
            {

                this.OnPropertyChanged("msg_from", this._msg_from, value);
                this._msg_from = value;
            }
        }

        /// <summary>
        ///  msg_to,
        /// </summary>
        [DbProperty(MapingColumnName = "msg_to", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string msg_to
        {
            get
            {
                return this._msg_to;
            }
            set
            {

                this.OnPropertyChanged("msg_to", this._msg_to, value);
                this._msg_to = value;
            }
        }

        /// <summary>
        ///  msg_content,
        /// </summary>
        [DbProperty(MapingColumnName = "msg_content", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string msg_content
        {
            get
            {
                return this._msg_content;
            }
            set
            {

                this.OnPropertyChanged("msg_content", this._msg_content, value);
                this._msg_content = value;
            }
        }

        /// <summary>
        ///  msg_isread,
        /// </summary>
        [DbProperty(MapingColumnName = "msg_isread", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string msg_isread
        {
            get
            {
                return this._msg_isread;
            }
            set
            {

                this.OnPropertyChanged("msg_isread", this._msg_isread, value);
                this._msg_isread = value;
            }
        }

        /// <summary>
        ///  msg_time,
        /// </summary>
        [DbProperty(MapingColumnName = "msg_time", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
        [DataMember]
        public string msg_time
        {
            get
            {
                return this._msg_time;
            }
            set
            {

                this.OnPropertyChanged("msg_time", this._msg_time, value);
                this._msg_time = value;
            }
        }


        #endregion

        #region 列定义
        public class Column
        {
            public Column(string tableName)
            {

                msg_id = new PropertyItem("msg_id", tableName);

                msg_from = new PropertyItem("msg_from", tableName);

                msg_to = new PropertyItem("msg_to", tableName);

                msg_content = new PropertyItem("msg_content", tableName);

                msg_isread = new PropertyItem("msg_isread", tableName);

                msg_time = new PropertyItem("msg_time", tableName);


            }
            /// <summary>
            /// msg_id,
            /// </summary> 
            public PropertyItem msg_id = null;
            /// <summary>
            /// msg_from,
            /// </summary> 
            public PropertyItem msg_from = null;
            /// <summary>
            /// msg_to,
            /// </summary> 
            public PropertyItem msg_to = null;
            /// <summary>
            /// msg_content,
            /// </summary> 
            public PropertyItem msg_content = null;
            /// <summary>
            /// msg_isread,
            /// </summary> 
            public PropertyItem msg_isread = null;
            /// <summary>
            /// msg_time,
            /// </summary> 
            public PropertyItem msg_time = null;
        }
        #endregion
    }

}
