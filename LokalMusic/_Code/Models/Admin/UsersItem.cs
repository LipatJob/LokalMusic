using LokalMusic._Code.Helpers;
using System;
using System.Globalization;

namespace LokalMusic._Code.Models.Admin
{
    public class UsersItem
    {
        public int UserId { get; set; }
        public string Username { get; internal set; }
        public string Email { get; set; }
        public DateTime DateRegistered { get; set; }

        private string _userType;
        public string UserType { get { return _userType; } set { _userType = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower()); } }

        public string UserStatus { get; set; }

        public string ProfilePage
        {
            get
            {
                return NavigationHelper.CreateAbsoluteUrl($"/Fan/{Username}");
            }
        }

        public string FormattedDate
        {
            get
            {
                return DateRegistered.ToShortDateString();
            }
        }
    }
}