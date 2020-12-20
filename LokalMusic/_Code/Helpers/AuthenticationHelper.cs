﻿using LokalMusic.Code.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Helpers
{
    public class AuthenticationHelper
    {
        private const string UserIdSessionName = "USERID";
        private const string UsernameSessionName = "USERNAME";


        public static int? UserId 
        {
            set { HttpContext.Current.Session[UserIdSessionName] = value; }
            get { return (int?)HttpContext.Current.Session[UserIdSessionName]; }
        }
        public static bool IsLoggedIn() { return UserId != null; }

        public static string GetUsername()
        {
            if (IsLoggedIn() == false) { return "Guest"; }
            // TODO: Refactor this part
            if(HttpContext.Current.Session[UsernameSessionName] != null) { return (string)HttpContext.Current.Session[UsernameSessionName]; }

            string username = GetUsernameFromDatabase();
            HttpContext.Current.Session[UsernameSessionName] = username;
            return username;
        }

        private static string GetUsernameFromDatabase()
        {
            string query = "SELECT Username FROM UserInfo WHERE UserId = @UserId;";
            SqlDataReader data = null;
            using (var connection = DbHelper.GetConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("UserId", UserId);
                data = command.ExecuteReader();
            }
            string userType = (string)data["Username"];
            return userType;
        }


        public static string GetUserType() {
                if (IsLoggedIn() == false) { return "Guest"; }
                return GetUserTypeFromDatabase();
        }

        private static string GetUserTypeFromDatabase()
        {
            string query = "SELECT TypeName FROM UserType WHERE UserTypeId = (SELECT UserTypeId FROM UserInfo WHERE UserId = @UserId);";
            SqlDataReader data = null;
            using (var connection = DbHelper.GetConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("UserId", UserId);
                data = command.ExecuteReader();
            }
            string userType = (string) data["TypeName"];
            return userType;
        }

    }
}