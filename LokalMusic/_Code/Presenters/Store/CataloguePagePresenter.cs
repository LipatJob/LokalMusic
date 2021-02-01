using LokalMusic._Code.Models.Store;
using LokalMusic._Code.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LokalMusic._Code.Presenters.Store
{
    public class CataloguePagePresenter
    {

        private StoreRepository repository;

        public CataloguePagePresenter(StoreRepository repo)
        {
            this.repository = repo;
        }

        public List<CatalogueItem> GetSearchedProducts(string searchValue)
        {
            return this.repository.GetSearchedProducts(searchValue);
        }

    }
}