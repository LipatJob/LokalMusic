namespace LokalMusic._Code.Models.Account.Register
{
    public interface IRegisterArtistModel
    {
        string FirstName { get; }
        string LastName { get; }

        string Email { get; }
        string ArtistName { get; }
        string Username { get; }
        string Password { get; }
        string ConfirmPassword { get; }
    }
}