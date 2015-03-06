//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using SimpleIM.Data;

namespace SimpleIM.Business
{

    public class DoRcUsers
    {

        #region Private Methods

        /// <summary>
        /// Gets an instance of RcUsers.
        /// </summary>
        /// <param name="id"> id </param>
        private static RcUsers GetRcUsers(
            int id)
        {
            using (IDataReader reader = DBRcUsers.GetOne(
                id))
            {
                return PopulateFromReader(reader);
            }

        }

        public static RcUsers GetRcUserByID(int id)
        {
            using(IDataReader  reader=DBRcUsers.GetOne(id))
            {
                return  PopulateFromReader (reader);
            }
        }


        private static RcUsers PopulateFromReader(IDataReader reader)
        {
            RcUsers rcUsers = new RcUsers();
            if (reader.Read())
            {
                rcUsers.Id = Convert.ToInt32(reader["Id"]);
                rcUsers.UserID = reader["UserID"].ToString();
                rcUsers.Name = reader["Name"].ToString();
                rcUsers.Password = reader["Password"].ToString();
                rcUsers.Declaring = reader["Declaring"].ToString();
                rcUsers.Status = Convert.ToInt32(reader["Status"]);
                rcUsers.GroupID  = Convert.ToInt32(reader["GroupID"]);
                rcUsers.IsMale = Convert.ToBoolean(reader["IsMale"]);
                rcUsers.UserLevel = Convert.ToInt32(reader["UserLevel"]);
                rcUsers.Enabled = Convert.ToBoolean(reader["Enabled"]);
                rcUsers.RegisterTime = Convert.ToDateTime(reader["RegisterTime"]);
                rcUsers.LastLoginTime = Convert.ToDateTime(reader["LastLoginTime"]);

            }
            return rcUsers;
        }

        /// <summary>
        /// Persists a new instance of RcUsers. Returns true on success.
        /// </summary>
        /// <returns></returns>
        private static bool Create(RcUsers rcUsers)
        {
            int newID = 0;

            newID = DBRcUsers.Create(
                rcUsers.UserID,
                rcUsers.Name,
                rcUsers.Password,
                rcUsers.Declaring,
                rcUsers.Status,
                rcUsers.GroupID,
                rcUsers.IsMale,
                rcUsers.UserLevel,
                rcUsers.Enabled,
                rcUsers.RegisterTime,
                rcUsers.LastLoginTime);

            rcUsers.Id = newID;

            return (newID > 0);

        }


        /// <summary>
        /// Updates this instance of RcUsers. Returns true on success.
        /// </summary>
        /// <returns>bool</returns>
        private static bool Update(RcUsers rcUsers)
        {

            return DBRcUsers.Update(
                rcUsers.Id,
                rcUsers.UserID,
                rcUsers.Name,
                rcUsers.Password,
                rcUsers.Declaring,
                rcUsers.Status,
                rcUsers.GroupID,
                rcUsers.IsMale,
                rcUsers.UserLevel,
                rcUsers.Enabled,
                rcUsers.RegisterTime,
                rcUsers.LastLoginTime);

        }





        #endregion

        #region Public Methods

        /// <summary>
        /// Saves this instance of RcUsers. Returns true on success.
        /// </summary>
        /// <returns>bool</returns>
        public static bool Save(RcUsers rcUsers)
        {
            if (rcUsers.Id > 0)
            {
                return Update(rcUsers);
            }
            else
            {
                return Create(rcUsers);
            }
        }




        #endregion

        #region Static Methods

        /// <summary>
        /// Deletes an instance of RcUsers. Returns true on success.
        /// </summary>
        /// <param name="id"> id </param>
        /// <returns>bool</returns>
        public static bool Delete(
            int id)
        {
            return DBRcUsers.Delete(
                id);
        }

        



        /// <summary>
        /// Gets a count of RcUsers. 
        /// </summary>
        public static int GetCount()
        {
            return DBRcUsers.GetCount();
        }

        //获取好友 
        private static IList<UserContract> LoadUserContractList(IDataReader reader)
        {
            IList<UserContract> rcUsersList = new List<UserContract>();
            try
            {
                while (reader.Read())
                {
                    UserContract rcUsers = new UserContract();
                   
                    rcUsers.UserID = reader["UserID"].ToString();
                    rcUsers.Name = reader["Name"].ToString();
                   
                    rcUsers.Declaring = reader["Declaring"].ToString();
                 
                    rcUsers.IsMale = Convert.ToBoolean(reader["IsMale"]);
                    rcUsers.OnLine = false;
                    rcUsersList.Add(rcUsers);

                }
            }
            finally
            {
                reader.Close();
            }

            return rcUsersList;
        }

        private static IList<RcUsers> LoadListFromReader(IDataReader reader)
        {
            IList<RcUsers> rcUsersList = new List<RcUsers>();
            try
            {
                while (reader.Read())
                {
                    RcUsers rcUsers = new RcUsers();
                    rcUsers.Id = Convert.ToInt32(reader["Id"]);
                    rcUsers.UserID = reader["UserID"].ToString();
                    rcUsers.Name = reader["Name"].ToString();
                    rcUsers.Password = reader["Password"].ToString();
                    rcUsers.Declaring = reader["Declaring"].ToString();
                    rcUsers.Status = Convert.ToInt32(reader["Status"]);
                    rcUsers.GroupID = Convert.ToInt32(reader["GroupID"]);
                    rcUsers.IsMale = Convert.ToBoolean(reader["IsMale"]);
                    rcUsers.UserLevel = Convert.ToInt32(reader["UserLevel"]);
                    rcUsers.Enabled = Convert.ToBoolean(reader["Enabled"]);
                    rcUsers.RegisterTime = Convert.ToDateTime(reader["RegisterTime"]);
                    rcUsers.LastLoginTime = Convert.ToDateTime(reader["LastLoginTime"]);
                    rcUsersList.Add(rcUsers);

                }
            }
            finally
            {
                reader.Close();
            }

            return rcUsersList;

        }

        //获取某组中的UserID
        private static IList<String> LoadListFromReaderUserID(IDataReader reader)
        {
            IList<String> userIDList = new List<String>();
            try
            {
                while (reader.Read())
                { 

                    userIDList.Add(reader["UserID"].ToString());

                }
            }
            finally
            {
                reader.Close();
            }

            return userIDList;

        }

        //获取某组中的UserID
        private static IList<UserGroupIDContract> LoadListFromReaderUserGroupID(IDataReader reader)
        {
            IList<UserGroupIDContract> userGroupIDList = new List<UserGroupIDContract>();
            try
            {
                while (reader.Read())
                {

                    userGroupIDList.Add(new UserGroupIDContract(reader["UserID"].ToString(), Convert.ToInt32(reader["GroupID"])));

                }
            }
            finally
            {
                reader.Close();
            }

            return userGroupIDList;

        }


        /// <summary>
        /// Gets an IList with some instances of RcUsers.
        /// </summary>
        public static IList<RcUsers> GetTopList(
            int id)
        {
            IDataReader reader = DBRcUsers.GetTopList(
                id);

            return LoadListFromReader(reader);

        }


        /// <summary>
        /// Gets an IList with all instances of RcUsers.
        /// </summary>
        public static IList<RcUsers> GetAll()
        {
            IDataReader reader = DBRcUsers.GetAll();
            return LoadListFromReader(reader);

        }

        //获取所有好友

        public static IList<UserContract> GetAllMyFriends()
        {
            IDataReader reader = DBRcUsers.GetAll();
            return LoadUserContractList(reader);
        }

        /// <summary>
        /// Gets an IList with page of instances of RcUsers.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalPages">total pages</param>
        public static IList<RcUsers> GetPage(int pageNumber, int pageSize, out int itemCount)
        {
            itemCount = 1;
            IDataReader reader = DBRcUsers.GetPage(pageNumber, pageSize, out itemCount);
            return LoadListFromReader(reader);
        }


        /// <summary>
        /// Gets an IList with page of instances of RcUsers.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="itemCount">total items</param>
        public static IList<RcUsers> GetListPage(int pageNumber, int pageSize, int pid, out int itemCount)
        {
            itemCount = 1;
            IDataReader reader = DBRcUsers.GetListPage(pageNumber, pageSize, pid, out itemCount);
            return LoadListFromReader(reader);
        }



        #endregion

        public static UserLoginContract Login(string userId, string password)
        {
            UserContract newContract = new UserContract();

            UserLoginContract loginContract = new UserLoginContract();
             

            using (IDataReader reader = DBRcUsers.GetOneByUserID(userId))
            {
                string theResult = "登录不成功";
                RcUsers theUser = PopulateFromReader(reader);
                if (theUser == null)
                {
                    theResult = "用户不存在";
                }
                else if (theUser.Password == password)
                {

                    theResult = "success";

                    newContract.UserID = theUser.UserID;
                    newContract.Name = theUser.Name;
                    newContract.Declaring = theUser.Declaring;
                    newContract.IsMale = theUser.IsMale;
                    newContract.OnLine = true;

                }
              
                else
                {
                    theResult = "密码不正确";
                    //密码不正确
                }

                loginContract.Message = theResult;
                loginContract.UserContract = newContract;

                return loginContract;
            }


        }

        //获取用户数据
        public static RcUsers GetByUserID(string userId)
        { 
            using (IDataReader reader = DBRcUsers.GetOneByUserID(userId))
            {
                return PopulateFromReader(reader);
            }
             
        }


        //更改用户密码
        public static string ChangePassword(string userId, string oldPassword, string newPassword)
        {
            

            RcUsers theUser = GetByUserID(userId);

            if (theUser.Password == oldPassword)
            {
                DBRcUsers.ChangePwd(userId, newPassword);

                return "success";
            }
            else
            {
                return "修改密码不成功";
            }
 

        }

        //根据组获取用户
        public static IList<RcUsers> GetUserByGroup(int groupID)
        {

            IDataReader reader = DBRcUsers.GetUserByGroup(groupID);

            return LoadListFromReader(reader);
        }



        //根据组获取用户ID列表
        public static IList<string> GetUsersIDByGroup(int groupId)
        {
            IDataReader reader = DBRcUsers.GetUserByGroup(groupId);
            return LoadListFromReaderUserID(reader);
        }

        //获取所有用户及组ID
        public static IList<UserGroupIDContract> GetAllUserGroupID()
        {
            IDataReader reader = DBRcUsers.GetAll();
            return LoadListFromReaderUserGroupID(reader);
        }

        //根据组获取用户数

        public static int GetUserCountByGroup(int groupID)
        {
            return DBRcUsers.GetUserCountByGroup(groupID);
        }



        //删除用户组中的数据

        public static bool DeleteByGroupID(int groupID)
        {
            return DBRcUsers.DeleteByUserGroup(groupID);
        }


        //根据权限组获取用户
        public static IList<RcUsers> GetUserByRoleGroup(int groupID)
        {

            IDataReader reader = DBRcUsers.GetUserByRoleGroup(groupID);

            return LoadListFromReader(reader);
        }

        //更新用户权限组
        public static bool UpdateUserRoleGroup(int id, int userLevel)
        {
            return DBRcUsers.UpdateUserRoleGroup(id, userLevel);
        }

    }

}


