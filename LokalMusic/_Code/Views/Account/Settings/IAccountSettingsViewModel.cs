using LokalMusic._Code.Models.Account.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Views.Account.Settings
{
    public interface IAccountSettingsViewModel: IAccountSettingsModel
    {
        string NewPassword { get; }
        string ConfrimNewPassword { get; }
    }
}