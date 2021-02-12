using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LokalMusic._Code.Repositories.Admin
{
    public class UsersRepository
    {
        private const string DEACTIVATED_USER_STATUS = "DEACTIVATED";
        private const string ACTIVE_USER_STATUS = "ACTIVE";

        public IList<UsersItem> GetUsers()
        {
            string query =
@"
SELECT
	[UserInfo].UserId			AS UserId,
	[UserInfo].Username			AS Username,
	[UserInfo].Email			AS Email,
	[UserInfo].DateRegistered	AS DateRegistered,
	[UserType].TypeName			AS UserType,
	[UserStatus].UserStatusName AS UserStatus
FROM [UserInfo]
INNER JOIN [UserStatus] ON
	[UserStatus].UserStatusId = [UserInfo].UserStatusId
INNER JOIN [UserType] ON
	[UserType].UserTypeId = [UserInfo].UserTypeId
WHERE [UserType].TypeName IN ('FAN', 'ARTIST')
";
            return DbHelper.ExecuteDataTableQuery(query).AsEnumerable().Select((row) =>
            {
                return new UsersItem()
                {
                    UserId = (int)row["UserId"],
                    Username = (string)row["Username"],
                    Email = (string)row["Email"],
                    DateRegistered = (DateTime)row["DateRegistered"],
                    UserType = (string)row["UserType"],
                    UserStatus = (string)row["UserStatus"],
                };
            }).ToList();
        }

        public void DeactivateUserAccount(int userId)
        {
            ChangeUserStatus(userId, DEACTIVATED_USER_STATUS);
        }

        public void ReactivateUserAccount(int userId)
        {
            ChangeUserStatus(userId, ACTIVE_USER_STATUS);
        }

        public void ChangeUserStatus(int UserId, string userStatus)
        {
            string query =
@"
UPDATE [UserInfo]
SET UserStatusId = (SELECT UserStatusId
					FROM [UserStatus]
					WHERE UserStatusName = @UserStatusName)
WHERE UserId = @UserId
";
            DbHelper.ExecuteNonQuery(
                query,
                ("UserStatusName", userStatus),
                ("UserId", UserId));
        }
    }
}