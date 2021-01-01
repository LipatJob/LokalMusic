using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Helpers
{
    public class DbHelper
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["lokalmusic-db"].ConnectionString;
            return new SqlConnection(connectionString);
        }

        public static void FillCommand(SqlCommand command, string commandText, params (string name, object value)[] parameters)
        {
            command.CommandText = commandText;
            foreach (var parameter in parameters)
            {
                command.Parameters.AddWithValue(parameter.name, parameter.value);
            }
        }

        /// Safely executes a database query and returns a DataTable
        /// - Stores data in memory
        /// - Will slow website down if used in queries with large result sets 
        /// - It is preferrable to manually create query code for large result set 
        public static DataTable ExecuteDataTableQuery(string commandText, params (string name, object value)[] parameters) 
        {
            DataTable dataTable = new DataTable();
            using(var connection = GetConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    FillCommand(command, commandText, parameters);
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }

        public static object ExecuteScalar(string commandText, params (string name, object value)[] parameters) 
        {
            object result;
            using (var connection = GetConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    FillCommand(command, commandText, parameters);
                    connection.Open();
                    result = command.ExecuteScalar();
                }
            }
            return result;
        }

        public static int ExecuteNonQuery(string commandText, params (string name, object value)[] parameters)
        {
            int result;
            using (var connection = GetConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    FillCommand(command, commandText, parameters);
                    connection.Open();
                    result = command.ExecuteNonQuery();
                }
            }
            return result;
        }
    }
}