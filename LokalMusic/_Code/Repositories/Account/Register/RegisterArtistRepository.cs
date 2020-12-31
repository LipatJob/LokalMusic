﻿using LokalMusic._Code.Models.Account.Register;
using LokalMusic._Code.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Repositories.Account.Register
{
    public class RegisterArtistRepository
    {
        const string ACCOUNT_TYPE_NAME = "ARTIST";
        const string ACTIVE_TYPE_NAME = "ACTIVE";

        private IRegisterArtistModel model;
        private int userId;

        public bool RegisterArtist(IRegisterArtistModel model)
        {
            this.model = model;
            CreateArtistAccount();
            CreateArtistProfile();
            return true;
        }

        private void CreateArtistAccount()
        {
            int userTypeId = GetUserTypeId();
            int userStatusId = GetUserStatusId();

            string query =
                "INSERT INTO UserInfo(UserTypeId, UserStatusId, Email, Username, Password, DateRegistered) " +
                "VALUES (@userTypeId, @userStatusId, @email, @username, @password, @dateRegistered) " +
                "SELECT SCOPE_IDENTITY()";

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
                "INSERT INTO ArtistInfo(UserId, ArtistName) VALUES " +
                "(@UserId, @ArtistName)";
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
            return DbHelper.ExecuteDataTableQuery(query, ("username", username)) != null;
        }

        public bool IsEmailUnique(string email)
        {
            string query = $"SELECT Email from UserInfo WHERE Email = @email;";
            return DbHelper.ExecuteDataTableQuery(query, ("email", email)) != null;
        }

        

    }
}