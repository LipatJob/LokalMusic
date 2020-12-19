using LokalMusic.Code.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LokalMusic.Code.Repositories.Account
{
    public class LoginRepository
    {
        public bool AreLoginCredentialsValid(string email, string password)
        {
            SqlDataReader values = null;
            string commandText = "SELECT COUNT(*) AS userscount FROM users WHERE email = @email AND password = @password";

            using (var connection = DbHelper.GetConnection())
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = commandText;
                command.Parameters.AddWithValue("email", email);
                command.Parameters.AddWithValue("password", password);
                values = command.ExecuteReader();
            }

            return (int)values.GetOrdinal("userscount") == 1;
        }
    }
}