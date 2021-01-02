using LokalMusic._Code.Helpers;
using LokalMusic._Code.Repositories.Account;
using LokalMusic._Code.Views.Account;

namespace LokalMusic._Code.Presenters.Account
{
    public class LoginPresenter
    {
        private ILoginViewModel viewModel;
        private LoginRepository repository;

        public LoginPresenter(ILoginViewModel viewModel, LoginRepository repository)
        {
            this.viewModel = viewModel;
            this.repository = repository;
        }

        public void CheckAuthentication()
        {
            if (AuthenticationHelper.LoggedIn)
            {
                NavigationHelper.Redirect("~/Store/Home");
            }
        }

        public bool Login()
        {
            int userId = repository.GetLogin(viewModel);

            if (IsLoginSuccessful(userId))
            {
                AuthenticationHelper.UserId = userId;
                NavigationHelper.Redirect("~/Store/Home");
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsLoginSuccessful(int userId)
        {
            return userId != LoginRepository.LOGIN_FAILED_ID;
        }
    }
}