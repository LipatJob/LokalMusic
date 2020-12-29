using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Fan;
using LokalMusic._Code.Repositories.Fan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            int userId;
            if (int.TryParse((string)NavigationHelper.GetRouteValue("UserId"), out userId) == false)
            {
                NavigationHelper.Redirect("~");
            }
            model = repository.SetUserInformation(userId);
        }

    }
}