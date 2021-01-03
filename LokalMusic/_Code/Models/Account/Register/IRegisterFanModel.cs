namespace LokalMusic._Code.Models.Account.Register
{
    public interface IRegisterFanModel
    {
        string Email { get; }
        string Username { get; }
        string Password { get; }
        string ConfirmPassword { get; }
    }
}