using LokalMusic._Code.Helpers;
using LokalMusic._Code.Repositories.Account.Register;
using LokalMusic._Code.Views.Account.Register;

namespace LokalMusic._Code.Presenters.Account.Register
{
    public class RegisterArtistPresenter
    {
        private RegisterArtistRepository repository;
        private IRegisterArtistViewModel viewModel;

        public RegisterArtistPresenter(IRegisterArtistViewModel viewModel, RegisterArtistRepository repository)
        {
            this.viewModel = viewModel;
            this.repository = repository;
        }

        public void Register()
        {
            repository.RegisterArtist(viewModel);
            NavigationHelper.Redirect("~/Account/Login");
        }

        public bool IsUsernameUnique()
        {
            return repository.IsUsernameUnique(viewModel.Username);
        }

        public bool IsEmailUnique()
        {
            return repository.IsEmailUnique(viewModel.Email);
        }
    }
}