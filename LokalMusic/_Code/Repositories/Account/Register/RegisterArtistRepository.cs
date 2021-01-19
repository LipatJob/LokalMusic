using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Account.Register;
using System;

namespace LokalMusic._Code.Repositories.Account.Register
{
    public class RegisterArtistRepository
    {
        private const string ACCOUNT_TYPE_NAME = "ARTIST";
        private const string ACTIVE_TYPE_NAME = "ACTIVE";

        private IRegisterArtistModel model;
        private int userId;

        public void RegisterArtist(IRegisterArtistModel model)
        {
            this.model = model;
            CreateArtistAccount();
            CreateArtistProfile();
        }

        private void CreateArtistAccount()
        {
            int userTypeId = GetUserTypeId();
            int userStatusId = GetUserStatusId();

            string query =
                "INSERT INTO UserInfo(UserTypeId, UserStatusId, Email, Username, Password, DateRegistered) " +
                "VALUES (@userTypeId, @userStatusId, @email, @username, @password, @dateRegistered) " +
                "SELECT CONVERT(int, SCOPE_IDENTITY())";

            userId = (int) DbHelper.ExecuteScalar(
                query,
                ("userTypeId", userTypeId),
                ("userStatusId", userStatusId),
                ("email", model.Email),
                ("username", model.Username),
                ("password", model.Password),
                ("dateRegistered", DateTime.Now));
        }

        private void CreateArtistProfile()
        {
            string query =
                "INSERT INTO ArtistInfo(UserId, ArtistName) " +
                "VALUES (@UserId, @ArtistName)";
            DbHelper.ExecuteScalar(
                query,
                ("UserId", userId),
                ("ArtistName", model.ArtistName));
        }

        private int GetUserTypeId()
        {
            string query = $"SELECT UserTypeId from UserType WHERE TypeName = @ArtistTypeName;";
            return (int)DbHelper.ExecuteScalar(query, ("ArtistTypeName", ACCOUNT_TYPE_NAME));
        }

        private int GetUserStatusId()
        {
            string query = $"SELECT UserStatusId from UserStatus WHERE UserStatusName = @ActiveTypeName;";
            return (int)DbHelper.ExecuteScalar(query, ("ActiveTypeName", ACTIVE_TYPE_NAME));
        }

        public bool IsUsernameUnique(string username)
        {
            string query = $"SELECT Username from UserInfo WHERE Username = @username;";
            return DbHelper.ExecuteScalar(query, ("username", username)) == null;
        }

        public bool IsEmailUnique(string email)
        {
            string query = $"SELECT Email from UserInfo WHERE Email = @email;";
            return DbHelper.ExecuteScalar(query, ("email", email)) == null;
        }
    }
}