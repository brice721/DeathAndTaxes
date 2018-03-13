using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathAndTaxes.Products
{
    public class AvailableProducts
    {
        public class AvailableProduct
        {
            public int Id { get; set; }
            public string ProductName { get; set; }
            public string ProductPrice { get; set; }
        }

        static string book = "12.49";
        static string headachePills = "9.75";
        static string chocolateBar = "0.85";
        static string importedBottleOfPerfume = "47.50";
        static string musicCd = "14.99";
        static string bottleOfPerfume = "18.99";

        public static class ProductData
        {
            private static List<AvailableProduct> _availableProduct;
            public static List<AvailableProduct> AvailableProducts
            {
                get
                {
                    if (_availableProduct == null)
                    {
                        _availableProduct = CreateInitialProducts();
                    }
                    return _availableProduct;
                }
            }

            static List<AvailableProduct> CreateInitialProducts()
            {
                var initialProducts = new List<AvailableProduct>()
                {
                    new AvailableProduct { Id = 1, ProductName = "Book", ProductPrice = $"${book}" },
                    new AvailableProduct { Id = 2, ProductName = "Choclate Bar", ProductPrice = $"${chocolateBar}" },
                    new AvailableProduct { Id = 3, ProductName = "Packet of Headache Pills", ProductPrice = $"${headachePills}" },
                    new AvailableProduct { Id = 4, ProductName = "Imported Bottle of Perfume", ProductPrice = $"${importedBottleOfPerfume}" },
                    new AvailableProduct { Id = 4, ProductName = "Bottle Of Perfume", ProductPrice = $"${bottleOfPerfume}" },
                    new AvailableProduct { Id = 4, ProductName = "Music CD", ProductPrice = $"${musicCd}" }
                };
                return initialProducts;
            }
        }
    }
}
