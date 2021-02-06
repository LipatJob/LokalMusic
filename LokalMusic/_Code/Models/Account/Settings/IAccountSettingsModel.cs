using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Account.Settings
{
    public interface IAccountSettingsModel
    {
        string Username { get; set; }
        string Email { get; set; }
        string OldPassword { get; }
    }
}