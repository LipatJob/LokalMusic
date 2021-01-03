namespace LokalMusic._Code.Models.Account.Register
{
    public interface IRegisterArtistModel
    {
        string Email { get; }
        string ArtistName { get; }
        string Username { get; }
        string Password { get; }
        string ConfirmPassword { get; }
    }
}