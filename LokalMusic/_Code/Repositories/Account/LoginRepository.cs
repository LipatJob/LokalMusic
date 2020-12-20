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
        /// <returns> First value is whether the login attempt is successful and the second value is the id of the user. If it's -1 then the login attempt failed</returns>
        public (bool, int) GetLogin(string email, string password)
        {
            SqlDataReader values;
            string commandText = "SELECT UserId FROM users WHERE email = @email AND password = @password";

            using (var connection = DbHelper.GetConnection())
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = commandText;
                command.Parameters.AddWithValue("email", email);
                command.Parameters.AddWithValue("password", password);
                values = command.ExecuteReader();
            }

            bool valid = values.HasRows;
            int userId = -1;
            if (valid)
            {
                userId = (int) values["UserId"];
            }

            return (valid, userId);
        }
    }
}