using LokalMusic.Code.Helpers;
using LokalMusic.Code.Views.Account;
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
        public (bool, int) GetLogin(ILoginViewModel viewModel)
        {
            string commandText = "SELECT UserId FROM users WHERE email = @email AND password = @password";
            SqlDataReader values = DbHelper.QueryDatabase(commandText, ("email",viewModel.email), ("password", viewModel.password));

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