using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LokalMusic.Code.Helpers
{
    public class DbHelper
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["lokalmusic-db"].ConnectionString;
            return new SqlConnection(connectionString);
        }

        public static void FillCommand(SqlCommand command,string commandText, params (string name, object value)[] parameters)
        {
            command.CommandText = commandText;
            foreach (var parameter in parameters)
            {
                command.Parameters.AddWithValue(parameter.name, parameter.value);
            }
        }

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

        public static int ExecuteCommand(string commandText, params (string name, object value)[] parameters) 
        {
            int affectedRow;
            using (var connection = GetConnection())
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = commandText;
                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.name, parameter.value);
                }
                connection.Open();
                affectedRow = Convert.ToInt32(command.ExecuteScalar());
            }
            return affectedRow;
        }
    }
}