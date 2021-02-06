using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Models.Account.Settings
{
    public interface IProfileSettingsModel
    {
        string ProfileImage { get; set; }
        string ArtistBio { get; set; }
        string ArtistName { get; set; }
    }
}