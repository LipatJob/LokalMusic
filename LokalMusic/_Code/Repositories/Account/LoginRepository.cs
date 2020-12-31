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
        public int GetLogin(ILoginModel model)
        {
            string commandText = "SELECT UserId FROM UserInfo WHERE Email = @Email AND Password = @Password";
            var userId = (int?)DbHelper.ExecuteScalar(commandText, ("Email", model.Email), ("Password", model.Password));
            return userId ?? -1;
        }

        public bool IsCredentailsValid(ILoginModel model)
        {
            string commandText = "SELECT UserId FROM users WHERE email = @email AND password = @password";
            var userId = DbHelper.ExecuteScalar(commandText, ("Email", model.Email), ("Password", model.Password));
            return userId != null;
        }
    }
}