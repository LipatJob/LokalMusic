using LokalMusic._Code.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Admin
{
    public class UsersItem
    {
        public int UserId { get; set; }
        public string Username { get; internal set; }
        public string Email { get; set; }
        public DateTime DateRegistered { get; set; }
        public string UserType { get; set; }
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