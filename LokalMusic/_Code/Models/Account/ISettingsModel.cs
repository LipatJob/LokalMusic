namespace LokalMusic._Code.Models.Account
{
    public interface ISettingsModel
    {
        string ProfileImage { get; set; }
        string Username { get; set; }
        string Email { get; set; }
        string OldPassword { get; }
        string ArtistBio { get; set; }
        string ArtistName { get; set; }

    }
}