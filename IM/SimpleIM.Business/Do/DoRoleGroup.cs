//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using SimpleIM.Data;

namespace SimpleIM.Business
{
    public class DoRoleGroup
    {

        #region Private Methods

        /// <summary>
        /// Gets an instance of RoleGroup.
        /// </summary>
        /// <param name="id"> id </param>
        private static RoleGroup GetRoleGroup(
            int id)
        {
            using (IDataReader reader = DBRoleGroup.GetOne(
                id))
            {
                return PopulateFromReader(reader);
            }

        }

        //增加
        public  static RoleGroup GetGroupTopOne()
        {
            using (IDataReader reader=DBRoleGroup.GetTopOne())
            {
                return  PopulateFromReader(reader);
            }
        }


        private static RoleGroup PopulateFromReader(IDataReader reader)
        {
            RoleGroup RoleGroup = new RoleGroup();
            if (reader.Read())
            {
                RoleGroup.Id = Convert.ToInt32(reader["Id"]);
                RoleGroup.GroupName = reader["GroupName"].ToString();
                RoleGroup.GroupId = Convert.ToInt32(reader["GroupId"]);
                RoleGroup.OrderId = Convert.ToInt32(reader["OrderId"]);

            }
            return RoleGroup;
        }

        /// <summary>
        /// Persists a new instance of RoleGroup. Returns true on success.
        /// </summary>
        /// <returns></returns>
        private static bool Create(RoleGroup RoleGroup)
        {
            int newID = 0;

            newID = DBRoleGroup.Create(
                RoleGroup.GroupName,
                RoleGroup.GroupId,
                RoleGroup.OrderId);

            RoleGroup.Id = newID;

            return (newID > 0);

        }


        /// <summary>
        /// Updates this instance of RoleGroup. Returns true on success.
        /// </summary>
        /// <returns>bool</returns>
        private static bool Update(RoleGroup RoleGroup)
        {

            return DBRoleGroup.Update(
                RoleGroup.Id,
                RoleGroup.GroupName,
                RoleGroup.GroupId,
                RoleGroup.OrderId);

        }





        #endregion

        #region Public Methods

        /// <summary>
        /// Saves this instance of RoleGroup. Returns true on success.
        /// </summary>
        /// <returns>bool</returns>
        public static bool Save(RoleGroup RoleGroup)
        {
            if (RoleGroup.Id > 0)
            {
                return Update(RoleGroup);
            }
            else
            {
                return Create(RoleGroup);
            }
        }




        #endregion

        #region Static Methods

        /// <summary>
        /// Deletes an instance of RoleGroup. Returns true on success.
        /// </summary>
        /// <param name="id"> id </param>
        /// <returns>bool</returns>
        public static bool Delete(
            int id)
        {
            return DBRoleGroup.Delete(
                id);
        }


        /// <summary>
        /// Gets a count of RoleGroup. 
        /// </summary>
        public static int GetCount()
        {
            return DBRoleGroup.GetCount();
        }

        private static IList<RoleGroup> LoadListFromReader(IDataReader reader)
        {
            IList<RoleGroup> RoleGroupList = new List<RoleGroup>();
            try
            {
                while (reader.Read())
                {
                    RoleGroup RoleGroup = new RoleGroup();
                    RoleGroup.Id = Convert.ToInt32(reader["Id"]);
                    RoleGroup.GroupName = reader["GroupName"].ToString();
                    RoleGroup.GroupId = Convert.ToInt32(reader["GroupId"]);
                    RoleGroup.OrderId = Convert.ToInt32(reader["OrderId"]);
                    RoleGroupList.Add(RoleGroup);

                }
            }
            finally
            {
                reader.Close();
            }

            return RoleGroupList;

        }


        /// <summary>
        /// Gets an IList with some instances of RoleGroup.
        /// </summary>
        public static IList<RoleGroup> GetTopList(
            int id)
        {
            IDataReader reader = DBRoleGroup.GetTopList(
                id);

            return LoadListFromReader(reader);

        }


        /// <summary>
        /// Gets an IList with all instances of RoleGroup.
        /// </summary>
        public static IList<RoleGroup> GetAll()
        {
            IDataReader reader = DBRoleGroup.GetAll();
            return LoadListFromReader(reader);

        }

        /// <summary>
        /// Gets an IList with page of instances of RoleGroup.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalPages">total pages</param>
        public static IList<RoleGroup> GetPage(int pageNumber, int pageSize, out int itemCount)
        {
            itemCount = 1;
            IDataReader reader = DBRoleGroup.GetPage(pageNumber, pageSize, out itemCount);
            return LoadListFromReader(reader);
        }


        /// <summary>
        /// Gets an IList with page of instances of RoleGroup.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="itemCount">total items</param>
        public static IList<RoleGroup> GetListPage(int pageNumber, int pageSize, int pid, out int itemCount)
        {
            itemCount = 1;
            IDataReader reader = DBRoleGroup.GetListPage(pageNumber, pageSize, pid, out itemCount);
            return LoadListFromReader(reader);
        }



        #endregion




    }
}
