using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Account;
using LokalMusic._Code.Repositories.Account;
using LokalMusic._Code.Views.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Presenters.Account
{
    public class RegisterPresenter
    {
        private RegisterRepository repository;
        private IRegisterModel model;
        private IRegisterViewModel view;

        public RegisterPresenter(IRegisterViewModel view, IRegisterModel model, RegisterRepository repository)
        {
            this.view = view;
            this.repository = repository;
        }

        public void Register()
        {
            var success = repository.RegisterFan(model);
            if(success)
            {
                NavigationHelper.Redirect("~/Account/Login");
            }
        }

        public bool IsUniqueEmail()
        {
            return repository.IsUniqueEmail(view.Email);
        }

        public bool IsUniqueUsername()
        {
            return repository.IsUniqueUsername(view.Username);
        }
    }
}