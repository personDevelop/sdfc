//www.networkcomms.cn  www.networkcomms.net
using System;
using System.IO;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;


namespace SimpleIM.Data
{
    /// <summary>
    /// 操作数据库中的离线消息
    /// </summary>
    public static class DBOffLineMessage
    {
        /// <summary>
        /// Gets the connection string for read.
        /// </summary>
        /// <returns></returns>
        private static string GetReadConnectionString()
        {
            return ConfigurationManager.AppSettings["MSSQLConnectionString"];

        }

        /// <summary>
        /// Gets the connection string for write.
        /// </summary>
        /// <returns></returns>
        private static string GetWriteConnectionString()
        {
            if (ConfigurationManager.AppSettings["MSSQLWriteConnectionString"] != null)
            {
                return ConfigurationManager.AppSettings["MSSQLWriteConnectionString"];
            }

            return ConfigurationManager.AppSettings["MSSQLConnectionString"];

        }


        /// <summary>
        /// Inserts a row in the OffLineMessage table. Returns new integer id.
        /// </summary>
        /// <param name="userID"> userID </param>
        /// <param name="userName"> userName </param>
        /// <param name="destUserID"> destUserID </param>
        /// <param name="destUerName"> destUerName </param>
        /// <param name="chatContent"> chatContent </param>
        /// <param name="sendTime"> sendTime </param>
        /// <returns>int</returns>
        public static int Create(
            string userID,
            string userName,
            string destUserID,
            string destUerName,
            string chatContent,
            DateTime sendTime)
        {
            SqlParameterHelper sph = new SqlParameterHelper(GetWriteConnectionString(), "OffLineMessage_Insert", 6);
            sph.DefineSqlParameter("@UserID", SqlDbType.NVarChar, 200, ParameterDirection.Input, userID);
            sph.DefineSqlParameter("@UserName", SqlDbType.NVarChar, 200, ParameterDirection.Input, userName);
            sph.DefineSqlParameter("@DestUserID", SqlDbType.NVarChar, 200, ParameterDirection.Input, destUserID);
            sph.DefineSqlParameter("@DestUerName", SqlDbType.NVarChar, 200, ParameterDirection.Input, destUerName);
            sph.DefineSqlParameter("@ChatContent", SqlDbType.NVarChar, -1, ParameterDirection.Input, chatContent);
            sph.DefineSqlParameter("@SendTime", SqlDbType.DateTime, ParameterDirection.Input, sendTime);
            int newID = Convert.ToInt32(sph.ExecuteScalar());
            return newID;
        }


        /// <summary>
        /// Updates a row in the OffLineMessage table. Returns true if row updated.
        /// </summary>
        /// <param name="id"> id </param>
        /// <param name="userID"> userID </param>
        /// <param name="userName"> userName </param>
        /// <param name="destUserID"> destUserID </param>
        /// <param name="destUerName"> destUerName </param>
        /// <param name="chatContent"> chatContent </param>
        /// <param name="sendTime"> sendTime </param>
        /// <returns>bool</returns>
        public static bool Update(
            int id,
            string userID,
            string userName,
            string destUserID,
            string destUerName,
            string chatContent,
            DateTime sendTime)
        {
            SqlParameterHelper sph = new SqlParameterHelper(GetWriteConnectionString(), "OffLineMessage_Update", 7);
            sph.DefineSqlParameter("@Id", SqlDbType.Int, ParameterDirection.Input, id);
            sph.DefineSqlParameter("@UserID", SqlDbType.NVarChar, 200, ParameterDirection.Input, userID);
            sph.DefineSqlParameter("@UserName", SqlDbType.NVarChar, 200, ParameterDirection.Input, userName);
            sph.DefineSqlParameter("@DestUserID", SqlDbType.NVarChar, 200, ParameterDirection.Input, destUserID);
            sph.DefineSqlParameter("@DestUerName", SqlDbType.NVarChar, 200, ParameterDirection.Input, destUerName);
            sph.DefineSqlParameter("@ChatContent", SqlDbType.NVarChar, -1, ParameterDirection.Input, chatContent);
            sph.DefineSqlParameter("@SendTime", SqlDbType.DateTime, ParameterDirection.Input, sendTime);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);

        }

        /// <summary>
        /// Deletes a row from the OffLineMessage table. Returns true if row deleted.
        /// </summary>
        /// <param name="id"> id </param>
        /// <returns>bool</returns>
        public static bool Delete(
            int id)
        {
            SqlParameterHelper sph = new SqlParameterHelper(GetWriteConnectionString(), "OffLineMessage_Delete", 1);
            sph.DefineSqlParameter("@Id", SqlDbType.Int, ParameterDirection.Input, id);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);

        }


        /// <summary>
        /// Gets an IDataReader with one row from the OffLineMessage table.
        /// </summary>
        /// <param name="id"> id </param>
        public static IDataReader GetOne(
            int id)
        {
            SqlParameterHelper sph = new SqlParameterHelper(GetReadConnectionString(), "OffLineMessage_SelectOne", 1);
            sph.DefineSqlParameter("@Id", SqlDbType.Int, ParameterDirection.Input, id);
            return sph.ExecuteReader();

        }



        /// <summary>
        /// Gets an IDataReader with some list row from the OffLineMessage table.
        /// </summary>
        /// <param name="id"> id </param>
        public static IDataReader GetTopList(
            string  destUserID)
        {
            SqlParameterHelper sph = new SqlParameterHelper(GetReadConnectionString(), "OffLineMessage_SelectTopList", 1);
            sph.DefineSqlParameter("@DestUserID", SqlDbType.NVarChar,200, ParameterDirection.Input, destUserID);
            return sph.ExecuteReader();

        }



        /// <summary>
        /// Gets a count of rows in the OffLineMessage table.
        /// </summary>
        public static int GetCount()
        {

            return Convert.ToInt32(SqlHelper.ExecuteScalar(
                GetReadConnectionString(),
                CommandType.StoredProcedure,
                "OffLineMessage_GetCount",
                null));

        }





        /// <summary>
        /// Gets a Listcount of rows in the OffLineMessage table.
        /// </summary>
        public static int GetListCount(string destUserID)
        {
            SqlParameter theSqlParameter = new SqlParameter("@DestUserID", destUserID);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(
                GetReadConnectionString(),
                CommandType.StoredProcedure,
                "OffLineMessage_GetListCount",
                theSqlParameter));

        }



        /// <summary>
        /// Gets an IDataReader with all rows in the OffLineMessage table.
        /// </summary>
        public static IDataReader GetAll()
        {

            return SqlHelper.ExecuteReader(
                GetReadConnectionString(),
                CommandType.StoredProcedure,
                "OffLineMessage_SelectAll",
                null);

        }


        /// <summary>
        /// 新增加的 
        /// </summary>
        /// <param name="id"> id </param>
        public static IDataReader GetAllByUserID(
           string friendUserID)
        {
            SqlParameterHelper sph = new SqlParameterHelper(GetReadConnectionString(), "OffLineMessage_SelectByUserID", 1);
            sph.DefineSqlParameter("@FriendUserID", SqlDbType.NVarChar,200, ParameterDirection.Input, friendUserID);
            return sph.ExecuteReader();

        }



        /// <summary>
        /// Gets a page of data from the OffLineMessage table.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalPages">total pages</param>
        public static IDataReader GetPage(
            int pageNumber,
            int pageSize,
            out int itemCount)
        {
            itemCount = GetCount();

            SqlParameterHelper sph = new SqlParameterHelper(GetReadConnectionString(), "OffLineMessage_SelectPage", 2);
            sph.DefineSqlParameter("@PageNumber", SqlDbType.Int, ParameterDirection.Input, pageNumber);
            sph.DefineSqlParameter("@PageSize", SqlDbType.Int, ParameterDirection.Input, pageSize);
            return sph.ExecuteReader();

        }


        public static IDataReader GetListPage(
            int pageNumber,
            int pageSize,
            string destUserID,
            out int itemCount)
        {
            itemCount = GetListCount(destUserID);

            SqlParameterHelper sph = new SqlParameterHelper(GetReadConnectionString(), "OffLineMessage_SelectListPage", 3);
            sph.DefineSqlParameter("@PageNumber", SqlDbType.Int, ParameterDirection.Input, pageNumber);
            sph.DefineSqlParameter("@PageSize", SqlDbType.Int, ParameterDirection.Input, pageSize);
            sph.DefineSqlParameter("@DestUserID", SqlDbType.NVarChar,200, ParameterDirection.Input, destUserID);
            return sph.ExecuteReader();

        }

    }
}
