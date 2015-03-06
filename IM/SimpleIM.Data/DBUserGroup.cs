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
    /// 用户所在的机构组
    /// </summary>
    public static class DBUserGroup
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
        /// Inserts a row in the UserGroup table. Returns new integer id.
        /// </summary>
        /// <param name="groupName"> groupName </param>
        /// <param name="groupId"> groupId </param>
        /// <param name="orderId"> orderId </param>
        /// <returns>int</returns>
        public static int Create(
            string groupName,
            int groupId,
            int orderId)
        {
            SqlParameterHelper sph = new SqlParameterHelper(GetWriteConnectionString(), "UserGroup_Insert", 3);
            sph.DefineSqlParameter("@GroupName", SqlDbType.NVarChar, 200, ParameterDirection.Input, groupName);
            sph.DefineSqlParameter("@GroupId", SqlDbType.Int, ParameterDirection.Input, groupId);
            sph.DefineSqlParameter("@OrderId", SqlDbType.Int, ParameterDirection.Input, orderId);
            int newID = Convert.ToInt32(sph.ExecuteScalar());
            return newID;
        }


        /// <summary>
        /// Updates a row in the UserGroup table. Returns true if row updated.
        /// </summary>
        /// <param name="id"> id </param>
        /// <param name="groupName"> groupName </param>
        /// <param name="groupId"> groupId </param>
        /// <param name="orderId"> orderId </param>
        /// <returns>bool</returns>
        public static bool Update(
            int id,
            string groupName,
            int groupId,
            int orderId)
        {
            SqlParameterHelper sph = new SqlParameterHelper(GetWriteConnectionString(), "UserGroup_Update", 4);
            sph.DefineSqlParameter("@Id", SqlDbType.Int, ParameterDirection.Input, id);
            sph.DefineSqlParameter("@GroupName", SqlDbType.NVarChar, 200, ParameterDirection.Input, groupName);
            sph.DefineSqlParameter("@GroupId", SqlDbType.Int, ParameterDirection.Input, groupId);
            sph.DefineSqlParameter("@OrderId", SqlDbType.Int, ParameterDirection.Input, orderId);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);

        }

        /// <summary>
        /// Deletes a row from the UserGroup table. Returns true if row deleted.
        /// </summary>
        /// <param name="id"> id </param>
        /// <returns>bool</returns>
        public static bool Delete(
            int id)
        {
            SqlParameterHelper sph = new SqlParameterHelper(GetWriteConnectionString(), "UserGroup_Delete", 1);
            sph.DefineSqlParameter("@Id", SqlDbType.Int, ParameterDirection.Input, id);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);

        }


        /// <summary>
        /// Gets an IDataReader with one row from the UserGroup table.
        /// </summary>
        /// <param name="id"> id </param>
        public static IDataReader GetOne(
            int id)
        {
            SqlParameterHelper sph = new SqlParameterHelper(GetReadConnectionString(), "UserGroup_SelectOne", 1);
            sph.DefineSqlParameter("@Id", SqlDbType.Int, ParameterDirection.Input, id);
            return sph.ExecuteReader();

        }

        //增加

        public static IDataReader GetTopOne()
        {
            return SqlHelper.ExecuteReader(
              GetReadConnectionString(),
              CommandType.StoredProcedure,
              "UserGroup_SelectTopOne",
              null);
        }



        /// <summary>
        /// Gets an IDataReader with some list row from the UserGroup table.
        /// </summary>
        /// <param name="id"> id </param>
        public static IDataReader GetTopList(
            int id)
        {
            SqlParameterHelper sph = new SqlParameterHelper(GetReadConnectionString(), "UserGroup_SelectTopList", 1);
            sph.DefineSqlParameter("@pid", SqlDbType.Int, ParameterDirection.Input, id);
            return sph.ExecuteReader();

        }



        /// <summary>
        /// Gets a count of rows in the UserGroup table.
        /// </summary>
        public static int GetCount()
        {

            return Convert.ToInt32(SqlHelper.ExecuteScalar(
                GetReadConnectionString(),
                CommandType.StoredProcedure,
                "UserGroup_GetCount",
                null));

        }



        /// <summary>
        /// Gets a Listcount of rows in the UserGroup table.
        /// </summary>
        public static int GetListCount(int pid)
        {
            SqlParameter theSqlParameter = new SqlParameter("@Pid", pid);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(
                GetReadConnectionString(),
                CommandType.StoredProcedure,
                "UserGroup_GetListCount",
                theSqlParameter));

        }



        /// <summary>
        /// Gets an IDataReader with all rows in the UserGroup table.
        /// </summary>
        public static IDataReader GetAll()
        {

            return SqlHelper.ExecuteReader(
                GetReadConnectionString(),
                CommandType.StoredProcedure,
                "UserGroup_SelectAll",
                null);

        }

        /// <summary>
        /// Gets a page of data from the UserGroup table.
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

            SqlParameterHelper sph = new SqlParameterHelper(GetReadConnectionString(), "UserGroup_SelectPage", 2);
            sph.DefineSqlParameter("@PageNumber", SqlDbType.Int, ParameterDirection.Input, pageNumber);
            sph.DefineSqlParameter("@PageSize", SqlDbType.Int, ParameterDirection.Input, pageSize);
            return sph.ExecuteReader();

        }


        public static IDataReader GetListPage(
            int pageNumber,
            int pageSize,
            int pid,
            out int itemCount)
        {
            itemCount = GetListCount(pid);

            SqlParameterHelper sph = new SqlParameterHelper(GetReadConnectionString(), "UserGroup_SelectListPage", 3);
            sph.DefineSqlParameter("@PageNumber", SqlDbType.Int, ParameterDirection.Input, pageNumber);
            sph.DefineSqlParameter("@PageSize", SqlDbType.Int, ParameterDirection.Input, pageSize);
            sph.DefineSqlParameter("@pid", SqlDbType.Int, ParameterDirection.Input, pid);
            return sph.ExecuteReader();

        }

    }
}
