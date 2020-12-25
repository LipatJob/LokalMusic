using LokalMusic._Code.Models.Account.Register;
using LokalMusic._Code.Repositories.Account.Register;
using LokalMusic._Code.Views.Account.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Presenters.Account.Register
{
    public class RegisterFanPresenter
    {
        private RegisterFanRepository repository;
        private IRegisterFanViewModel view;

        public RegisterFanPresenter(IRegisterFanViewModel view, RegisterFanRepository repository)
        {
            this.view = view;
            this.repository = repository;
        }

        public void Register()
        {
        }
    }
}