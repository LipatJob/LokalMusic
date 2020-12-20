using System;
using System.Collections.Generic;
using System.Configuration;
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

        public static SqlDataReader QueryDatabase(string commandText, params (string name, object value)[] parameters)
        {
            SqlDataReader values;
            using (var connection = GetConnection())
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = commandText;
                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.name, parameter.value);
                }
                values = command.ExecuteReader();
            }
            return values;
        }
    }
}