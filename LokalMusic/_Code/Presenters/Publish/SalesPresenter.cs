using LokalMusic._Code.Helpers;
using LokalMusic._Code.Models.Publish;
using LokalMusic._Code.Repositories.Publish;
using LokalMusic.Publish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Presenters.Publish
{
    public class SalesPresenter
    {
        private Sales sales;
        private SalesRepository salesRepository;

        public SalesPresenter(Sales sales, SalesRepository salesRepository)
        {
            this.sales = sales;
            this.salesRepository = salesRepository;
        }

        public void PageLoad()
        {
            if (AuthenticationHelper.LoggedIn == false)
            {
                NavigationHelper.Redirect("~/Account/Login");
            }
            else if (AuthenticationHelper.UserType != AuthenticationHelper.ARTIST_USER_TYPE)
            {
                NavigationHelper.Redirect("~");
            }
        }

        public SalesModel GetSalesModel()
        {
            return new SalesModel()
            {
                ArtistName = salesRepository.GetArtistName(AuthenticationHelper.UserId),
                SalesItems = salesRepository.GetSalesItems(AuthenticationHelper.UserId)
            };
        }

    }
}