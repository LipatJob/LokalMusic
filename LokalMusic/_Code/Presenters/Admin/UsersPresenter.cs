using LokalMusic._Code.Models.Admin;
using LokalMusic._Code.Repositories.Admin;
using System;
using System.Collections.Generic;
using System.Data;

namespace LokalMusic._Code.Presenters.Admin
{
    public class UsersPresenter
    {
        private UsersRepository repository;

        public UsersPresenter(LokalMusic.Admin.Users users)
        {
            repository = new UsersRepository();
        }

        public DataTable GetUsers()
        {
            var repository = new UsersRepository();
            return repository.GetUsers();
        }

        internal void ActivateReactivateAccount(int userId)
        {
            repository.ActivateReactivateAccount(userId);
        }
    }
}