using LokalMusic._Code.Models.Account;
using LokalMusic._Code.Helpers;
using LokalMusic._Code.Views.Account;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Repositories.Account
{
    public class LoginRepository
    {
        public (bool, int) GetLogin(ILoginModel model)
        {
            string commandText = "SELECT UserId FROM UserInfo WHERE Email = @Email AND Password = @Password";
            var values = DbHelper.ExecuteDataTableQuery(commandText, ("Email", model.Email), ("Password", model.Password));

            bool valid = values.Rows.Count == 1;
            int userId = -1;
            if (valid)
            {
                userId = (int)values.Rows[0]["UserId"];
            }

            return (valid, userId);
        }

        public bool IsCredentailsValid(ILoginModel model)
        {
            string commandText = "SELECT UserId FROM users WHERE email = @email AND password = @password";
            var values = DbHelper.ExecuteDataTableQuery(commandText, ("email", model.Email), ("password", model.Password));
            return values.Rows.Count == 1;
        }
    }
}