using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Fan;
using LokalMusic._Code.Repositories.Fan;

namespace LokalMusic._Code.Presenters.Fan
{
    public class CollectionPresenter
    {
        public CollectionModel model;
        private CollectionRepository repository;

        public CollectionPresenter(CollectionRepository repository)
        {
            this.repository = repository;
        }

        public void InitializeModel()
        {
            string username = (string)NavigationHelper.GetRouteValue("Username");
            if (username == null)
            {
                NavigationHelper.Redirect("~");
            }
            model = repository.SetUserInformation(username);
        }
    }
}