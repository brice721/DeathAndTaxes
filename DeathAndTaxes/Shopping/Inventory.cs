using DeathAndTaxes.Products;
using System;
using System.Collections.Generic;

namespace DeathAndTaxes.Shopping
{
    public class Inventory
    {
        private readonly Dictionary<string, Product> productItems;

        public Inventory()
        {
            productItems = new Dictionary<string, Product>();
            AddProductItemsToInventory("book", new BookProduct());
            AddProductItemsToInventory("music cd", new MiscellaneousProduct());
            AddProductItemsToInventory("chocolate bar", new FoodProduct());
            AddProductItemsToInventory("box of chocolates", new FoodProduct());
            AddProductItemsToInventory("bottle of perfume", new MiscellaneousProduct());
            AddProductItemsToInventory("packet of headache pills", new MedicalProduct());
            AddProductItemsToInventory("imported box of chocolates", new FoodProduct());
            AddProductItemsToInventory("imported bottle of perfume", new MiscellaneousProduct());
        }

        public void AddProductItemsToInventory(String productItem, Product productCategory)
        {
            productItems.Add(productItem, productCategory);
        }

        public Product SearchAndRetrieveItemFromShelf(String name, decimal price, bool imported, int quantity)
        {
            Product productItem = productItems[name].GetFactory().CeateProduct(name, price, imported, quantity);
            return productItem;
        }

        public int GetStoreInventorySize() =>
            productItems.Count;
    }
}
