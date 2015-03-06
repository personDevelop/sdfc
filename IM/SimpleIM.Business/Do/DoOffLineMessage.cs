//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using SimpleIM.Data;

namespace SimpleIM.Business
{
    public class DoOffLineMessage
    {

        #region Private Methods

        /// <summary>
        /// Gets an instance of OffLineMessage.
        /// </summary>
        /// <param name="id"> id </param>
        private static OffLineMessage GetOffLineMessage(
            int id)
        {
            using (IDataReader reader = DBOffLineMessage.GetOne(
                id))
            {
                return PopulateFromReader(reader);
            }

        }


        private static OffLineMessage PopulateFromReader(IDataReader reader)
        {
            OffLineMessage offLineMessage = new OffLineMessage();
            if (reader.Read())
            {
                offLineMessage.Id = Convert.ToInt32(reader["Id"]);
                offLineMessage.UserID = reader["UserID"].ToString();
                offLineMessage.UserName = reader["UserName"].ToString();
                offLineMessage.DestUserID = reader["DestUserID"].ToString();
                offLineMessage.DestUerName = reader["DestUerName"].ToString();
                offLineMessage.ChatContent = reader["ChatContent"].ToString();
                offLineMessage.SendTime = Convert.ToDateTime(reader["SendTime"]);

            }
            return offLineMessage;
        }

        /// <summary>
        /// Persists a new instance of OffLineMessage. Returns true on success.
        /// </summary>
        /// <returns></returns>
        private static bool Create(OffLineMessage offLineMessage)
        {
            int newID = 0;

            newID = DBOffLineMessage.Create(
                offLineMessage.UserID,
                offLineMessage.UserName,
                offLineMessage.DestUserID,
                offLineMessage.DestUerName,
                offLineMessage.ChatContent,
                offLineMessage.SendTime);

            offLineMessage.Id = newID;

            return (newID > 0);

        }


        /// <summary>
        /// Updates this instance of OffLineMessage. Returns true on success.
        /// </summary>
        /// <returns>bool</returns>
        private static bool Update(OffLineMessage offLineMessage)
        {

            return DBOffLineMessage.Update(
                offLineMessage.Id,
                offLineMessage.UserID,
                offLineMessage.UserName,
                offLineMessage.DestUserID,
                offLineMessage.DestUerName,
                offLineMessage.ChatContent,
                offLineMessage.SendTime);

        }





        #endregion

        #region Public Methods

        /// <summary>
        /// Saves this instance of OffLineMessage. Returns true on success.
        /// </summary>
        /// <returns>bool</returns>
        public static bool Save(OffLineMessage offLineMessage)
        {
            if (offLineMessage.Id > 0)
            {
                return Update(offLineMessage);
            }
            else
            {
                return Create(offLineMessage);
            }
        }




        #endregion

        #region Static Methods

        /// <summary>
        /// Deletes an instance of OffLineMessage. Returns true on success.
        /// </summary>
        /// <param name="id"> id </param>
        /// <returns>bool</returns>
        public static bool Delete(
            int id)
        {
            return DBOffLineMessage.Delete(
                id);
        }


        /// <summary>
        /// Gets a count of OffLineMessage. 
        /// </summary>
        public static int GetCount()
        {
            return DBOffLineMessage.GetCount();
        }

        private static IList<OffLineMessage> LoadListFromReader(IDataReader reader)
        {
            IList<OffLineMessage> offLineMessageList = new List<OffLineMessage>();
            try
            {
                while (reader.Read())
                {
                    OffLineMessage offLineMessage = new OffLineMessage();
                    offLineMessage.Id = Convert.ToInt32(reader["Id"]);
                    offLineMessage.UserID = reader["UserID"].ToString();
                    offLineMessage.UserName = reader["UserName"].ToString();
                    offLineMessage.DestUserID = reader["DestUserID"].ToString();
                    offLineMessage.DestUerName = reader["DestUerName"].ToString();
                    offLineMessage.ChatContent = reader["ChatContent"].ToString();
                    offLineMessage.SendTime = Convert.ToDateTime(reader["SendTime"]);
                    offLineMessageList.Add(offLineMessage);

                }
            }
            finally
            {
                reader.Close();
            }

            return offLineMessageList;

        }


        /// <summary>
        /// Gets an IList with some instances of OffLineMessage.
        /// </summary>
        public static IList<OffLineMessage> GetTopList(
            string sendUserID)
        {
            IDataReader reader = DBOffLineMessage.GetTopList(
                sendUserID);

            return LoadListFromReader(reader);

        }


        /// <summary>
        /// Gets an IList with all instances of OffLineMessage.
        /// </summary>
        public static IList<OffLineMessage> GetAll()
        {
            IDataReader reader = DBOffLineMessage.GetAll();
            return LoadListFromReader(reader);

        }

        //新增加的

        public static IList<OffLineMessage> GetAllByUserID(string friendUserID)
        {
            IDataReader reader = DBOffLineMessage.GetAllByUserID(friendUserID);
            return LoadListFromReader(reader);
        }

        /// <summary>
        /// Gets an IList with page of instances of OffLineMessage.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalPages">total pages</param>
        public static IList<OffLineMessage> GetPage(int pageNumber, int pageSize, out int itemCount)
        {
            itemCount = 1;
            IDataReader reader = DBOffLineMessage.GetPage(pageNumber, pageSize, out itemCount);
            return LoadListFromReader(reader);
        }


        /// <summary>
        /// Gets an IList with page of instances of OffLineMessage.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="itemCount">total items</param>
        public static IList<OffLineMessage> GetListPage(int pageNumber, int pageSize, string sendUserID, out int itemCount)
        {
            itemCount = 1;
            IDataReader reader = DBOffLineMessage.GetListPage(pageNumber, pageSize, sendUserID, out itemCount);
            return LoadListFromReader(reader);
        }



        #endregion




    }
}
