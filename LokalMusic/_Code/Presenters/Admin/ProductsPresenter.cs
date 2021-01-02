using LokalMusic._Code.Models.Admin;
using LokalMusic._Code.Repositories.Admin;
using LokalMusic.Admin;
using System.Collections.Generic;

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

        public static IList<ProductItem> GetProductList()
        {
            var repository = new ProductsRepository();
            return repository.GetProducts();
        }

        public static void UnlistItem(int productId)
        {
            var repository = new ProductsRepository();
            repository.UnlistItem(productId);
        }

        public static void RelistItem(int productId)
        {
            var repository = new ProductsRepository();
            repository.RelistItem(productId);
        }
    }
}