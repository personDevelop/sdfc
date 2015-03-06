﻿//www.networkcomms.cn  www.networkcomms.net

using System;
using System.Data;
using System.Data.SqlClient;

namespace SimpleIM.Data
{
    public static class SqlHelper
    {
        private static void PrepareCommand(
            SqlCommand command,
            SqlConnection connection,
            SqlTransaction transaction,
            CommandType commandType,
            string commandText,
            SqlParameter[] commandParameters)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (string.IsNullOrEmpty(commandText)) throw new ArgumentNullException("commandText");

            command.CommandType = commandType;
            command.CommandText = commandText;
            command.Connection = connection;

            if (transaction != null)
            {
                if (transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
                command.Transaction = transaction;
            }

            if (commandParameters != null) { AttachParameters(command, commandParameters); }
        }

        private static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandParameters != null)
            {
                foreach (SqlParameter p in commandParameters)
                {
                    if (p != null)
                    {
                        if ((p.Direction == ParameterDirection.InputOutput ||
                            p.Direction == ParameterDirection.Input) &&
                            (p.Value == null))
                        {
                            p.Value = DBNull.Value;
                        }
                        command.Parameters.Add(p);
                    }
                }
            }
        }

        public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            int commandTimeout = 30; //30 seconds default http://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlcommand.commandtimeout.aspx

            return ExecuteNonQuery(connectionString, commandType, commandText, commandTimeout, commandParameters);

            //if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    using (SqlCommand command = new SqlCommand())
            //    {
            //        PrepareCommand(command, connection, null, commandType, commandText, commandParameters);
            //        return command.ExecuteNonQuery();   
            //    }
            //}
        }

        public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, int commandTimeout, params SqlParameter[] commandParameters)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    PrepareCommand(command, connection, null, commandType, commandText, commandParameters);
                    command.CommandTimeout = commandTimeout;
                    return command.ExecuteNonQuery();
                }
            }
        }

        public static int ExecuteNonQuery(
            SqlTransaction transaction,
            CommandType commandType,
            string commandText,
            params SqlParameter[] commandParameters)
        {
            int commandTimeout = 30; //30 seconds default

            return ExecuteNonQuery(transaction, commandType, commandText, commandTimeout, commandParameters);

            //if (transaction == null) throw new ArgumentNullException("transaction");
            //if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");

            //using (SqlCommand command = new SqlCommand())
            //{
            //    PrepareCommand(
            //        command,
            //        transaction.Connection,
            //        transaction,
            //        commandType,
            //        commandText,
            //        commandParameters);

            //    return command.ExecuteNonQuery();
            //} 
        }

        public static int ExecuteNonQuery(
            SqlTransaction transaction,
            CommandType commandType,
            string commandText,
            int commandTimeout,
            params SqlParameter[] commandParameters)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");

            using (SqlCommand command = new SqlCommand())
            {
                PrepareCommand(
                    command,
                    transaction.Connection,
                    transaction,
                    commandType,
                    commandText,
                    commandParameters);

                command.CommandTimeout = commandTimeout;

                return command.ExecuteNonQuery();
            }
        }

        public static SqlDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            int commandTimeout = 30; //30 seconds default
            return ExecuteReader(connectionString, commandType, commandText, commandTimeout, commandParameters);

            //if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            //SqlConnection connection = null;
            //try
            //{
            //    connection = new SqlConnection(connectionString);
            //    connection.Open();
            //    using (SqlCommand command = new SqlCommand())
            //    {
            //        PrepareCommand(
            //            command,
            //            connection,
            //            null,
            //            commandType,
            //            commandText,
            //            commandParameters);

            //        return command.ExecuteReader(CommandBehavior.CloseConnection);
            //    }
            //}
            //catch
            //{
            //    if ((connection != null) && (connection.State == ConnectionState.Open)) { connection.Close(); }
            //    throw;
            //}
        }

        public static SqlDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText, int commandTimeout, params SqlParameter[] commandParameters)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    PrepareCommand(
                        command,
                        connection,
                        null,
                        commandType,
                        commandText,
                        commandParameters);

                    command.CommandTimeout = commandTimeout;

                    return command.ExecuteReader(CommandBehavior.CloseConnection);
                }
            }
            catch
            {
                if ((connection != null) && (connection.State == ConnectionState.Open)) { connection.Close(); }
                throw;
            }
        }

        public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            int commandTimeout = 30; //30 seconds default
            return ExecuteScalar(connectionString, commandType, commandText, commandTimeout, commandParameters);

            //if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    using (SqlCommand command = new SqlCommand())
            //    {
            //        PrepareCommand(command, connection, (SqlTransaction)null, commandType, commandText, commandParameters);
            //        return command.ExecuteScalar();
            //    }
            //}
        }

        public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText, int commandTimeout, params SqlParameter[] commandParameters)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    PrepareCommand(command, connection, (SqlTransaction)null, commandType, commandText, commandParameters);
                    command.CommandTimeout = commandTimeout;

                    return command.ExecuteScalar();
                }
            }
        }

        public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText)
        {
            return ExecuteDataset(connectionString, commandType, commandText, (SqlParameter[])null);
        }

        public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    PrepareCommand(command, connection, (SqlTransaction)null, commandType, commandText, commandParameters);
                    using (SqlDataAdapter adpater = new SqlDataAdapter(command))
                    {
                        DataSet dataSet = new DataSet();
                        adpater.Fill(dataSet);
                        return dataSet;
                    }
                }
            }
        }
    }
}
