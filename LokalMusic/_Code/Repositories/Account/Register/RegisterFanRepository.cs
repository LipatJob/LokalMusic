using LokalMusic._Code.Models.Account.Register;
using LokalMusic.Code.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Repositories.Account.Register
{
    public class RegisterFanRepository
    {
        const string FAN_TYPE_NAME = "FAN";
        const string ACTIVE_TYPE_NAME = "ACTIVE";

        public bool RegisterFan(IRegisterFanModel model)
        {
            int userTypeId = GetUserTypeId();
            int userStatusId = GetUserStatusId();

            string query = 
                $"INSERT INTO UserInfo(UserTypeId, UserStatusId, Email, Username, Password, DateRegistered) " +
                $"VALUES @userTypeId, @userStatusId, @email, @username, @password, @dateRegistered";

            DbHelper.ExecuteCommand(
                query, 
                ("userTypeId", userTypeId), 
                ("userStatusId", userStatusId), 
                ("email", model.Email), 
                ("username", model.Username), 
                ("password", model.Password), 
                ("dateRegistered", DateTime.Now));
            return true;
        }

        public bool IsUniqueUsername(string username)
        {
            string query = $"SELECT Username from UserInfo WHERE Username = '@username';";
            var resultSet = DbHelper.ExecuteQuery(query, ("username", username));
            return (int)resultSet["Username"] == 0;
        }

        public bool IsUniqueEmail(string email)
        {
            string query = $"SELECT Email from UserInfo WHERE Email = '@email';";
            var resultSet = DbHelper.ExecuteQuery(query, ("email", email));
            return (int)resultSet["Email"] == 0;
        }

        private int GetUserTypeId()
        {
            // Query ID for user type
            string query = $"SELECT UserTypeId from UserType WHERE TypeName = @FanTypeName;";
            var resultSet = DbHelper.ExecuteQuery(query, ("FanTypeName", FAN_TYPE_NAME));
            return (int) resultSet["UserTypeId"];
        }

        private int GetUserStatusId()
        {
            string query = $"SELECT UserStatusId from UserStatus WHERE UserStatusName = @ActiveTypeName;";
            var resultSet = DbHelper.ExecuteQuery(query, ("ActiveTypeName", ACTIVE_TYPE_NAME));
            return (int)resultSet["UserStatusId"];
        }

    }
}