using LokalMusic._Code.Models.Admin;
using LokalMusic._Code.Repositories.Admin;
using System.Collections.Generic;

namespace LokalMusic._Code.Presenters.Admin
{
    public class UsersPresenter
    {
        private UsersRepository repository;

        public UsersPresenter(LokalMusic.Admin.Users users)
        {
            repository = new UsersRepository();
        }

        public static IList<UsersItem> GetUsers()
        {
            var repository = new UsersRepository();
            return repository.GetUsers();
        }

        public static void DeactivateUser(int userId)
        {
            var repository = new UsersRepository();
            repository.DeactivateUserAccount(userId);
        }

        public static void ReactivateUser(int userId)
        {
            var repository = new UsersRepository();
            repository.ReactivateUserAccount(userId);
        }
    }
}