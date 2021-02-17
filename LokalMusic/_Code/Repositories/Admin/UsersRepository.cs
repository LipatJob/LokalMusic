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

        private const string WITHDRAWN_PRODUCT_STATUS = "WITHDRAWN";
        private const string UNPUBLISHED_PRODUCT_STATUS = "UNPUBLISHED";

        public DataTable GetUsers()
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
ORDER BY DateRegistered DESC
";
            return DbHelper.ExecuteDataTableQuery(query);
        }

        internal void ActivateReactivateAccount(int userId)
        {
            if(GetAccountStatus(userId).ToUpper() == ACTIVE_USER_STATUS)
            {
                DeactivateUserAccount(userId);
            }
            else
            {
                ReactivateUserAccount(userId);
            }
        }

        private string GetAccountStatus(int userId)
        {
            string query = @"
SELECT [UserStatus].UserStatusName
FROM [UserInfo]
	INNER JOIN [UserStatus] ON [UserStatus].UserStatusId = [UserInfo].UserStatusId
WHERE [UserInfo].UserId = @UserId";
            return (string)DbHelper.ExecuteScalar(query, ("UserId", userId));
        }

        public void DeactivateUserAccount(int userId)
        {
            ChangeUserStatus(userId, DEACTIVATED_USER_STATUS, WITHDRAWN_PRODUCT_STATUS);
        }

        public void ReactivateUserAccount(int userId)
        {
            ChangeUserStatus(userId, ACTIVE_USER_STATUS, UNPUBLISHED_PRODUCT_STATUS);
        }

        public void ChangeUserStatus(int UserId, string userStatus, string productStatus)
        {
            string query =
@"
UPDATE [UserInfo]
SET UserStatusId = (SELECT UserStatusId
					FROM [UserStatus]
					WHERE UserStatusName = @UserStatusName)
WHERE UserId = @UserId;

UPDATE [Product]
SET [ProductStatusId] = (SELECT ProductStatusID FROM [ProductStatus] WHERE StatusName = @ProductStatusName)
WHERE ProductId IN (SELECT 
	                    [Product].ProductId
                    FROM [Product]
                        LEFT JOIN [Track] ON [Track].TrackId = [Product].ProductId
                        LEFT JOIN [Album] ON [Album].AlbumId = COALESCE([Track].AlbumId, [Product].ProductId)
                    WHERE UserId = @UserId)
";
            DbHelper.ExecuteNonQuery(
                query,
                ("UserStatusName", userStatus),
                ("UserId", UserId),
                ("ProductStatusName",productStatus));
        }
    }
}