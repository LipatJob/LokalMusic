using LokalMusic._Code.Models.Account;
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