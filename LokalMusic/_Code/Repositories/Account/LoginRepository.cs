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
        public const int LOGIN_FAILED_ID = -1;
        public int GetLogin(ILoginModel model)
        {
            string commandText = @"
SELECT UserId
FROM [UserInfo]
WHERE
    Email = @Email AND
    Password = @Password AND
    UserStatusId = (SELECT UserStatusId
                    FROM UserStatus
                    WHERE UserStatusName = @UserStatusName )";
            var userId = (int?)DbHelper.ExecuteScalar(
                commandText,
                ("Email", model.Email),
                ("Password", model.Password),
                ("UserStatusName ", "ACTIVE"));
            return userId ?? LOGIN_FAILED_ID;
        }
    }
}