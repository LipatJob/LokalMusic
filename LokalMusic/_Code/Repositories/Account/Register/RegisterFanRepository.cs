using LokalMusic._Code.Models.Account.Register;
using LokalMusic._Code.Helpers;
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
                $"VALUES (@userTypeId, @userStatusId, @email, @username, @password, @dateRegistered)";

            DbHelper.ExecuteScalar(
                query, 
                ("userTypeId", userTypeId), 
                ("userStatusId", userStatusId), 
                ("email", model.Email), 
                ("username", model.Username), 
                ("password", model.Password), 
                ("dateRegistered", DateTime.Now));
            return true;
        }

        public bool IsUsernameUnique(string username)
        {
            string query = $"SELECT Username from UserInfo WHERE Username = '@username';";
            return DbHelper.ExecuteScalar(query, ("username", username)) == null;
        }

        public bool IsEmailUnique(string email)
        {
            string query = $"SELECT Email from UserInfo WHERE Email = '@email';";
            return DbHelper.ExecuteScalar(query, ("email", email)) == null;
        }

        private int GetUserTypeId()
        {
            // Query ID for user type
            string query = $"SELECT UserTypeId from UserType WHERE TypeName = @FanTypeName;";
            return (int) DbHelper.ExecuteScalar(query, ("FanTypeName", FAN_TYPE_NAME));
        }

        private int GetUserStatusId()
        {
            string query = $"SELECT UserStatusId from UserStatus WHERE UserStatusName = @ActiveTypeName;";
            return (int) DbHelper.ExecuteScalar(query, ("ActiveTypeName", ACTIVE_TYPE_NAME));
        }

    }
}