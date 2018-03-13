using DeathAndTaxes.Products;
using System.Collections.Generic;

namespace DeathAndTaxes.Shopping
{
    public class ShoppingCart
    {
        private List<Product> productList { get; set; }

        public ShoppingCart() =>
            productList = new List<Product>();

        public void AddItemToCart(Product product) =>
            productList.Add(product);

        public List<Product> GetItemsFromCart() =>
            productList;

        public int GetCartSize() =>
            productList.Count;
    }
}
