using LokalMusic._Code.Models.Admin;
using LokalMusic._Code.Repositories.Admin;
using LokalMusic.Admin;
using System;
using System.Collections.Generic;
using System.Data;

namespace LokalMusic._Code.Presenters.Admin
{
    public class ProductsPresenter
    {
        private Products products;
        private ProductsRepository repository;

        public ProductsPresenter(Products products)
        {
            this.products = products;
            this.repository = new ProductsRepository();
        }

        public DataTable GetProductList()
        {
            var repository = new ProductsRepository();
            return repository.GetProducts();
        }

        public void WithdrawItem(int productId)
        {
            var repository = new ProductsRepository();
            repository.WithdrawItem(productId);
        }

        internal void UnlistRepublishProduct(int productId)
        {
            repository.UnlistRepublishProduct(productId);
        }

        public void RepublishItem(int productId)
        {
            var repository = new ProductsRepository();
            repository.UnpublishItem(productId);
        }
    }
}