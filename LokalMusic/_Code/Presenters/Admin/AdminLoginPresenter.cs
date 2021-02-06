using LokalMusic._Code.Helpers;
using LokalMusic._Code.Repositories.Admin;
using LokalMusic._Code.Views.Account;

namespace LokalMusic._Code.Presenters.Admin
{
    public class AdminLoginPresenter
    {
        private ILoginViewModel viewModel;
        private AdminLoginRepository repository;

        public AdminLoginPresenter(ILoginViewModel viewModel, AdminLoginRepository repository)
        {
            this.viewModel = viewModel;
            this.repository = repository;
        }

        public void CheckAuthentication()
        {
            if (BackendAuthenticationHelper.LoggedIn)
            {
                if (BackendAuthenticationHelper.UserType == BackendAuthenticationHelper.FINANCE_USER_TYPE)
                {
                    NavigationHelper.Redirect("~/Finance/Reports");
                }
                else if (BackendAuthenticationHelper.UserType == BackendAuthenticationHelper.ADMIN_USER_TYPE)
                {
                    NavigationHelper.Redirect("~/Admin/Products");
                }
            }
        }

        public bool Login()
        {
            int userId = repository.GetLogin(viewModel);

            if (IsLoginSuccessful(userId))
            {
                BackendAuthenticationHelper.UserId = userId;

                if (BackendAuthenticationHelper.UserType == BackendAuthenticationHelper.FINANCE_USER_TYPE)
                {
                    NavigationHelper.Redirect("~/Finance/Reports");
                }
                else if (BackendAuthenticationHelper.UserType == BackendAuthenticationHelper.ADMIN_USER_TYPE)
                {
                    NavigationHelper.Redirect("~/Admin/Products");
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsLoginSuccessful(int userId)
        {
            return userId != AdminLoginRepository.LOGIN_FAILED_ID;
        }
    }
}