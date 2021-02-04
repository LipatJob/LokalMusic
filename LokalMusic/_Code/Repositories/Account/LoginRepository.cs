using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Account;

namespace LokalMusic._Code.Repositories.Account
{
    public class LoginRepository
    {
        public const int LOGIN_FAILED_ID = -1;

        public int GetLogin(ILoginModel model)
        {
            string commandText = @"
SELECT UserId
FROM [ActiveUserInfo]
    INNER JOIN [UserType] ON [UserType].UserTypeId = [ActiveUserInfo].UserTypeId
WHERE
    Email = @Email AND
    Password = @Password AND
    TypeName IN ('ARTIST', 'FAN');";
            var userId = (int?)DbHelper.ExecuteScalar(
                commandText,
                ("Email", model.Email),
                ("Password", model.Password),
                ("UserStatusName ", "ACTIVE"));
            return userId ?? LOGIN_FAILED_ID;
        }
    }
}