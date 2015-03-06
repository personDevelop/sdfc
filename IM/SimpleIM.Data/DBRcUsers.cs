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
    /// 在数据库中操作用户表 用户登录  注册 修改密码等
    /// </summary>
    public static class DBRcUsers
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
        /// Inserts a row in the RcUsers table. Returns new integer id.
        /// </summary>
        /// <param name="userID"> userID </param>
        /// <param name="name"> name </param>
        /// <param name="password"> password </param>
        /// <param name="declaring"> declaring </param>
        /// <param name="status"> status </param>
        /// <param name="isMale"> isMale </param>
        /// <param name="userLevel"> userLevel </param>
        /// <param name="enabled"> enabled </param>
        /// <param name="registerTime"> registerTime </param>
        /// <param name="lastLoginTime"> lastLoginTime </param>
        /// <returns>int</returns>
        public static int Create(
            string userID,
            string name,
            string password,
            string declaring,
            int status,
            int groupID,
            bool isMale,
            int userLevel,
            bool enabled,
            DateTime registerTime,
            DateTime lastLoginTime)
        {
            SqlParameterHelper sph = new SqlParameterHelper(GetWriteConnectionString(), "RcUsers_Insert", 11);
            sph.DefineSqlParameter("@UserID", SqlDbType.NVarChar, 200, ParameterDirection.Input, userID);
            sph.DefineSqlParameter("@Name", SqlDbType.NVarChar, 200, ParameterDirection.Input, name);
            sph.DefineSqlParameter("@Password", SqlDbType.NVarChar, 200, ParameterDirection.Input, password);
            sph.DefineSqlParameter("@Declaring", SqlDbType.NVarChar, 200, ParameterDirection.Input, declaring);
            sph.DefineSqlParameter("@Status", SqlDbType.Int, ParameterDirection.Input, status);
            sph.DefineSqlParameter("@GroupID", SqlDbType.Int, ParameterDirection.Input, groupID);
            sph.DefineSqlParameter("@IsMale", SqlDbType.Bit, ParameterDirection.Input, isMale);
            sph.DefineSqlParameter("@UserLevel", SqlDbType.Int, ParameterDirection.Input, userLevel);
            sph.DefineSqlParameter("@Enabled", SqlDbType.Bit, ParameterDirection.Input, enabled);
            sph.DefineSqlParameter("@RegisterTime", SqlDbType.DateTime, ParameterDirection.Input, registerTime);
            sph.DefineSqlParameter("@LastLoginTime", SqlDbType.DateTime, ParameterDirection.Input, lastLoginTime);
            int newID = Convert.ToInt32(sph.ExecuteScalar());
            return newID;
        }


        /// <summary>
        /// Updates a row in the RcUsers table. Returns true if row updated.
        /// </summary>
        /// <param name="id"> id </param>
        /// <param name="userID"> userID </param>
        /// <param name="name"> name </param>
        /// <param name="password"> password </param>
        /// <param name="declaring"> declaring </param>
        /// <param name="status"> status </param>
        /// <param name="isMale"> isMale </param>
        /// <param name="userLevel"> userLevel </param>
        /// <param name="enabled"> enabled </param>
        /// <param name="registerTime"> registerTime </param>
        /// <param name="lastLoginTime"> lastLoginTime </param>
        /// <returns>bool</returns>
        public static bool Update(
            int id,
            string userID,
            string name,
            string password,
            string declaring,
            int status,
            int groupID,
            bool isMale,
            int userLevel,
            bool enabled,
            DateTime registerTime,
            DateTime lastLoginTime)
        {
            SqlParameterHelper sph = new SqlParameterHelper(GetWriteConnectionString(), "RcUsers_Update", 12);
            sph.DefineSqlParameter("@Id", SqlDbType.Int, ParameterDirection.Input, id);
            sph.DefineSqlParameter("@UserID", SqlDbType.NVarChar, 200, ParameterDirection.Input, userID);
            sph.DefineSqlParameter("@Name", SqlDbType.NVarChar, 200, ParameterDirection.Input, name);
            sph.DefineSqlParameter("@Password", SqlDbType.NVarChar, 200, ParameterDirection.Input, password);
            sph.DefineSqlParameter("@Declaring", SqlDbType.NVarChar, 200, ParameterDirection.Input, declaring);
            sph.DefineSqlParameter("@Status", SqlDbType.Int, ParameterDirection.Input, status);
            sph.DefineSqlParameter("@GroupID", SqlDbType.Int, ParameterDirection.Input, groupID);
            sph.DefineSqlParameter("@IsMale", SqlDbType.Bit, ParameterDirection.Input, isMale);
            sph.DefineSqlParameter("@UserLevel", SqlDbType.Int, ParameterDirection.Input, userLevel);
            sph.DefineSqlParameter("@Enabled", SqlDbType.Bit, ParameterDirection.Input, enabled);
            sph.DefineSqlParameter("@RegisterTime", SqlDbType.DateTime, ParameterDirection.Input, registerTime);
            sph.DefineSqlParameter("@LastLoginTime", SqlDbType.DateTime, ParameterDirection.Input, lastLoginTime);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);

        }

        /// <summary>
        /// Deletes a row from the RcUsers table. Returns true if row deleted.
        /// </summary>
        /// <param name="id"> id </param>
        /// <returns>bool</returns>
        public static bool Delete(
            int id)
        {
            SqlParameterHelper sph = new SqlParameterHelper(GetWriteConnectionString(), "RcUsers_Delete", 1);
            sph.DefineSqlParameter("@Id", SqlDbType.Int, ParameterDirection.Input, id);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);

        }


        /// <summary>
        /// Gets an IDataReader with one row from the RcUsers table.
        /// </summary>
        /// <param name="id"> id </param>
        public static IDataReader GetOne(
            int id)
        {
            SqlParameterHelper sph = new SqlParameterHelper(GetReadConnectionString(), "RcUsers_SelectOne", 1);
            sph.DefineSqlParameter("@Id", SqlDbType.Int, ParameterDirection.Input, id);
            return sph.ExecuteReader();

        }



        /// <summary>
        /// Gets an IDataReader with some list row from the RcUsers table.
        /// </summary>
        /// <param name="id"> id </param>
        public static IDataReader GetTopList(
            int id)
        {
            SqlParameterHelper sph = new SqlParameterHelper(GetReadConnectionString(), "RcUsers_SelectTopList", 1);
            sph.DefineSqlParameter("@pid", SqlDbType.Int, ParameterDirection.Input, id);
            return sph.ExecuteReader();

        }



        /// <summary>
        /// Gets a count of rows in the RcUsers table.
        /// </summary>
        public static int GetCount()
        {

            return Convert.ToInt32(SqlHelper.ExecuteScalar(
                GetReadConnectionString(),
                CommandType.StoredProcedure,
                "RcUsers_GetCount",
                null));

        }



        /// <summary>
        /// Gets a Listcount of rows in the RcUsers table.
        /// </summary>
        public static int GetListCount(int pid)
        {
            SqlParameter theSqlParameter = new SqlParameter("@Pid", pid);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(
                GetReadConnectionString(),
                CommandType.StoredProcedure,
                "RcUsers_GetListCount",
                theSqlParameter));

        }



        /// <summary>
        /// Gets an IDataReader with all rows in the RcUsers table.
        /// </summary>
        public static IDataReader GetAll()
        {

            return SqlHelper.ExecuteReader(
                GetReadConnectionString(),
                CommandType.StoredProcedure,
                "RcUsers_SelectAll",
                null);

        }

        /// <summary>
        /// Gets a page of data from the RcUsers table.
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

            SqlParameterHelper sph = new SqlParameterHelper(GetReadConnectionString(), "RcUsers_SelectPage", 2);
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

            SqlParameterHelper sph = new SqlParameterHelper(GetReadConnectionString(), "RcUsers_SelectListPage", 3);
            sph.DefineSqlParameter("@PageNumber", SqlDbType.Int, ParameterDirection.Input, pageNumber);
            sph.DefineSqlParameter("@PageSize", SqlDbType.Int, ParameterDirection.Input, pageSize);
            sph.DefineSqlParameter("@pid", SqlDbType.Int, ParameterDirection.Input, pid);
            return sph.ExecuteReader();

        }

        //添加 根据UserID获取用户
        public static IDataReader GetOneByUserID(
           string userID)
        {
            SqlParameterHelper sph = new SqlParameterHelper(GetReadConnectionString(), "RcUsers_SelectOneByUserID", 1);
            sph.DefineSqlParameter("@UserID", SqlDbType.NVarChar, 200, ParameterDirection.Input, userID);
            return sph.ExecuteReader();

        }

        //更改用户密码

        public static bool ChangePwd(string userID, string password)
        {
            SqlParameterHelper sph = new SqlParameterHelper(GetWriteConnectionString(), "RcUsers_UpdatePwd", 2);
            sph.DefineSqlParameter("@UserID", SqlDbType.NVarChar, 200, ParameterDirection.Input, userID);
            sph.DefineSqlParameter("@Password", SqlDbType.NVarChar, 200, ParameterDirection.Input, password);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);
        }


        //添加 根据组ID获取用户
        public static IDataReader GetUserByGroup(int groupID)
            
        {
            SqlParameterHelper sph = new SqlParameterHelper(GetReadConnectionString(), "RcUsers_GetUserByGroup", 1);
            sph.DefineSqlParameter("@GroupID", SqlDbType.Int, ParameterDirection.Input, groupID);
            return sph.ExecuteReader();

        }


        //添加 根据组ID获取用户数
        public static int GetUserCountByGroup(int groupID)
        { 
            SqlParameter theSqlParameter = new SqlParameter("@GroupID", groupID);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(
                GetReadConnectionString(),
                CommandType.StoredProcedure,
                "RcUsers_GetUserCountByGroup",
                theSqlParameter));

        }

        //根据用户组删除用户
        public static bool DeleteByUserGroup(
           int id)
        {
            SqlParameterHelper sph = new SqlParameterHelper(GetWriteConnectionString(), "RcUsers_DeleteByGroup", 1);
            sph.DefineSqlParameter("@Id", SqlDbType.Int, ParameterDirection.Input, id);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);

        }


        //添加 根据权限组ID获取用户
        public static IDataReader GetUserByRoleGroup(int groupID)
        {
            SqlParameterHelper sph = new SqlParameterHelper(GetReadConnectionString(), "RcUsers_GetUserByRoleGroup", 1);
            sph.DefineSqlParameter("@RoleGroupID", SqlDbType.Int, ParameterDirection.Input, groupID);
            return sph.ExecuteReader();

        }

        //更新用户的权限组

        //根据用户组删除用户
        public static bool UpdateUserRoleGroup(int id, int userLevel)
        
        {
            SqlParameterHelper sph = new SqlParameterHelper(GetWriteConnectionString(), "RcUsers_UpdateRoleGroup", 2);

            sph.DefineSqlParameter("@Id", SqlDbType.Int, ParameterDirection.Input, id);
            sph.DefineSqlParameter("@UserLevel", SqlDbType.Int, ParameterDirection.Input, userLevel);
            int rowsAffected = sph.ExecuteNonQuery();
            return (rowsAffected > 0);

        }

        
    }

}
