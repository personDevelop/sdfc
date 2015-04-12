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
        [DbProperty(MapingColumnName = "mes_content", DbTypeString = "nvarchar", ColumnIsNull = true, IsUnique = false, ColumnLength = 50, ColumnJingDu = 0, IsGenarator = false, StepSize = 0, ColumnDefaultValue = "")]
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
        }
        #endregion
    }

}
