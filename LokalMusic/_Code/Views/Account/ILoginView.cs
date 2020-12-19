using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LokalMusic.Code.Views.Account
{
    public interface ILoginView
    {
        string email { get; }
        string password { get; }
        void ShowLoginErrorMessage();
        void RedirectToHomePage();

    }
}
