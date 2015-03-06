//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using SimpleIM.Data;

namespace SimpleIM.Business
{
    public class DoUserGroup
    {

        #region Private Methods

        /// <summary>
        /// Gets an instance of UserGroup.
        /// </summary>
        /// <param name="id"> id </param>
        private static UserGroup GetUserGroup(
            int id)
        {
            using (IDataReader reader = DBUserGroup.GetOne(
                id))
            {
                return PopulateFromReader(reader);
            }

        }

        //增加
        public  static UserGroup GetGroupTopOne()
        {
            using (IDataReader reader=DBUserGroup.GetTopOne())
            {
                return  PopulateFromReader(reader);
            }
        }


        private static UserGroup PopulateFromReader(IDataReader reader)
        {
            UserGroup userGroup = new UserGroup();
            if (reader.Read())
            {
                userGroup.Id = Convert.ToInt32(reader["Id"]);
                userGroup.GroupName = reader["GroupName"].ToString();
                userGroup.GroupId = Convert.ToInt32(reader["GroupId"]);
                userGroup.OrderId = Convert.ToInt32(reader["OrderId"]);

            }
            return userGroup;
        }

        /// <summary>
        /// Persists a new instance of UserGroup. Returns true on success.
        /// </summary>
        /// <returns></returns>
        private static bool Create(UserGroup userGroup)
        {
            int newID = 0;

            newID = DBUserGroup.Create(
                userGroup.GroupName,
                userGroup.GroupId,
                userGroup.OrderId);

            userGroup.Id = newID;

            return (newID > 0);

        }


        /// <summary>
        /// Updates this instance of UserGroup. Returns true on success.
        /// </summary>
        /// <returns>bool</returns>
        private static bool Update(UserGroup userGroup)
        {

            return DBUserGroup.Update(
                userGroup.Id,
                userGroup.GroupName,
                userGroup.GroupId,
                userGroup.OrderId);

        }





        #endregion

        #region Public Methods

        /// <summary>
        /// Saves this instance of UserGroup. Returns true on success.
        /// </summary>
        /// <returns>bool</returns>
        public static bool Save(UserGroup userGroup)
        {
            if (userGroup.Id > 0)
            {
                return Update(userGroup);
            }
            else
            {
                return Create(userGroup);
            }
        }




        #endregion

        #region Static Methods

        /// <summary>
        /// Deletes an instance of UserGroup. Returns true on success.
        /// </summary>
        /// <param name="id"> id </param>
        /// <returns>bool</returns>
        public static bool Delete(
            int id)
        {
            return DBUserGroup.Delete(
                id);
        }


        /// <summary>
        /// Gets a count of UserGroup. 
        /// </summary>
        public static int GetCount()
        {
            return DBUserGroup.GetCount();
        }

        private static IList<UserGroup> LoadListFromReader(IDataReader reader)
        {
            IList<UserGroup> userGroupList = new List<UserGroup>();
            try
            {
                while (reader.Read())
                {
                    UserGroup userGroup = new UserGroup();
                    userGroup.Id = Convert.ToInt32(reader["Id"]);
                    userGroup.GroupName = reader["GroupName"].ToString();
                    userGroup.GroupId = Convert.ToInt32(reader["GroupId"]);
                    userGroup.OrderId = Convert.ToInt32(reader["OrderId"]);
                    userGroupList.Add(userGroup);

                }
            }
            finally
            {
                reader.Close();
            }

            return userGroupList;

        }


        /// <summary>
        /// Gets an IList with some instances of UserGroup.
        /// </summary>
        public static IList<UserGroup> GetTopList(
            int id)
        {
            IDataReader reader = DBUserGroup.GetTopList(
                id);

            return LoadListFromReader(reader);

        }


        /// <summary>
        /// Gets an IList with all instances of UserGroup.
        /// </summary>
        public static IList<UserGroup> GetAll()
        {
            IDataReader reader = DBUserGroup.GetAll();
            return LoadListFromReader(reader);

        }

        /// <summary>
        /// Gets an IList with page of instances of UserGroup.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalPages">total pages</param>
        public static IList<UserGroup> GetPage(int pageNumber, int pageSize, out int itemCount)
        {
            itemCount = 1;
            IDataReader reader = DBUserGroup.GetPage(pageNumber, pageSize, out itemCount);
            return LoadListFromReader(reader);
        }


        /// <summary>
        /// Gets an IList with page of instances of UserGroup.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="itemCount">total items</param>
        public static IList<UserGroup> GetListPage(int pageNumber, int pageSize, int pid, out int itemCount)
        {
            itemCount = 1;
            IDataReader reader = DBUserGroup.GetListPage(pageNumber, pageSize, pid, out itemCount);
            return LoadListFromReader(reader);
        }



        #endregion




    }
}
