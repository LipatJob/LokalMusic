using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LokalMusic._Code.Helpers
{
    public class DbHelper
    {
        private const string DB_NAME = "lokalmusic-db";

        public static SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[DB_NAME].ConnectionString;
            return new SqlConnection(connectionString);
        }

        /// <summary>
        /// Fills up an SqlCommand with the specified command text and parameters
        /// </summary>
        /// <param name="command">SqlCommand to be filled up</param>
        /// <param name="commandText">the command text to be added to the command</param>
        /// <param name="parameters"></param>
        public static void FillCommand(SqlCommand command, string commandText, params (string name, object value)[] parameters)
        {
            command.CommandText = commandText;
            foreach (var parameter in parameters)
            {
                command.Parameters.AddWithValue(parameter.name, parameter.value);
            }
        }

        /// <summary>
        /// Safely executes a database query and returns a DataTable
        /// - Stores data in memory
        /// - Will slow website down if used in queries with large result sets
        /// - It is preferrable to manually create query code for large result set
        /// </summary>
        /// <param name="commandText">SQL query to be executed</param>
        /// <param name="parameters">the names and the values of the parameters in the command text</param>
        /// <returns>The value at the first row and column. Will return null if there are no rows as DbNull if the value is null</returns>
        public static DataTable ExecuteDataTableQuery(string commandText, params (string name, object value)[] parameters)
        {
            DataTable dataTable = new DataTable();
            using (var connection = GetConnection())
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

        /// <summary>
        /// Safely executes a scalar command and returns the value at the first row and column.
        /// </summary>
        /// <param name="commandText">SQL query to be executed</param>
        /// <param name="parameters">the names and the values of the parameters in the command text</param>
        /// <returns>The value at the first row and column. Will return null if there are no rows as DbNull if the value is null</returns>
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

        /// <summary>
        /// Safely executes a non query command and returns the number of affected rows.
        /// </summary>
        /// <param name="commandText">SQL query to be executed</param>
        /// <param name="parameters">the names and the values of the parameters in the command text</param>
        /// <returns>the number of affected rows</returns>
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