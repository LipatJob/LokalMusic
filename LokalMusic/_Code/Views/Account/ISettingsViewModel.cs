using LokalMusic._Code.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LokalMusic._Code.Views.Account
{
    public interface ISettingsViewModel : ISettingsModel
    {
        string NewPassword { get; }
        string ConfrimNewPassword { get; }
        HttpPostedFile UploadedProfilePicture { get; }
    }
}
