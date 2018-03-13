using DeathAndTaxes.Billing;
using DeathAndTaxes.Helpers;
using DeathAndTaxes.Products;
using ap = DeathAndTaxes.Products.AvailableProducts.ProductData;
using System;
using System.Text;

namespace DeathAndTaxes.Shopping
{
    /// <summary>
    /// This is the nuts and bolts of the program. I used .Trim() to prevent extra
    /// spaces from breaking the app and used StringComparison to prevent casing 
    /// from breaking the app. I enjoyed this quite a bit and if nothing else I 
    /// learned a great deal and appreciate the opportunity. A lot different when
    /// you dont have QA as a safety net. The inputs for Test Case Three have been
    /// off by about five cents and I sadly couldnt get it worked out to feed me the
    /// correct data. Any feed back is welcomed and grately appreciated.
    /// </summary>
    public class Store
    {
        private ShoppingCart shoppingCart;
        private Inventory storeInventory;
        private PaymentCounter paymentCounter;
        private string country;

        /// <summary>
        /// Shopping store constructor
        /// </summary>
        public Store()
        {
            country = "Local";
            shoppingCart = new ShoppingCart();
            paymentCounter = new PaymentCounter(country);
            storeInventory = new Inventory();
        }

        /// <summary>
        /// Prints list of available sale items/products to console
        /// </summary>
        public void GetAvailableProducts()
        {
            string SaleItems = Get();
            Console.WriteLine(SaleItems);
        }

        /// <summary>
        /// Gets a list of available products so user is aware of choices
        /// </summary>
        /// <returns>list of available products</returns>
        public static string Get()
        {
            string indent = ConsoleFormatting.Indent();
            var sb = new StringBuilder();
            foreach (var product in ap.AvailableProducts)
            {
                sb.AppendLine($"{indent}Product Name: {product.ProductName}, Product Price: {product.ProductPrice:C}");
            }

            Console.WriteLine($"{indent}Your Available Products\n");
            return sb.ToString();
        }

        public void RetrieveOrderAndPlaceInCart(String name, decimal price, bool imported, int quantity)
        {
            Product product = storeInventory.SearchAndRetrieveItemFromShelf(name, price, imported, quantity);
            shoppingCart.AddItemToCart(product);
        }

        /// <summary>
        /// Builds itemized list and prints as receipt
        /// </summary>
        public void CheckOut()
        {
            paymentCounter.BillItemsInCart(shoppingCart);
            Receipt receipt = paymentCounter.GetReceipt();
            paymentCounter.PrintReceipt(receipt);
        }

        /// <summary>
        /// Builds sales order while add another product flag is true
        /// </summary>
        public void GetSalesOrder()
        {
            do
            {
                String name = GetProductName();
                decimal price = GetProductPrice();
                bool imported = IsProductImported();
                int quantity = GetQuantity();
                RetrieveOrderAndPlaceInCart(name, price, imported, quantity);
            }
            while (IsAddAnotherProduct());
        }

        /// <summary>
        /// Gets the product name per user input
        /// </summary>
        /// <returns>returns product name</returns>
        public String GetProductName()
        {
            Console.WriteLine("Enter the product name:\n");
            var input = Console.ReadLine();

            while (!(input != string.Empty))
            {
                Console.WriteLine("Invalid input. Enter Product Name");
                input = Console.ReadLine();
            }
            return input.Trim().ToLower();
        }

        /// <summary>
        /// Gets the price of the product entered
        /// </summary>
        /// <returns>Product Price</returns>
        public decimal GetProductPrice()
        {
            Console.WriteLine("Enter the product price:\n");
            // Add trim method to account for extra spaces added by user by mistake
            // Added to all inputs
            var input = Console.ReadLine().Trim();
            decimal val;
            while (!(decimal.TryParse(input, out val)))
            {
                Console.WriteLine("Invalid price. Enter a number");
            }

            return val;
        }

        /// <summary>
        /// Gets whether or not the product is imported or 
        /// starts the order over for invalid entry
        /// </summary>
        /// <returns>boolean</returns>
        public bool IsProductImported()
        {
            Console.WriteLine("Is product imported or not?(Y/N)\n");

            var input = Console.ReadLine().Trim();
            bool isValid = false;

            while (!isValid)
            {
                if (input != string.Empty &&
                    input.Equals("y", StringComparison.OrdinalIgnoreCase))
                    isValid = true;
                else if (input != string.Empty &&
                         input.Equals("n", StringComparison.OrdinalIgnoreCase))
                    isValid = true;
                else
                {
                    Console.WriteLine("Must enter valid entry...\nProgram will restart.\r\n");
                    GetSalesOrder();
                }
            }

            // Ignore case so user can enter y or Y
            if (input.Equals("y", StringComparison.OrdinalIgnoreCase))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Gets the quantity entered for products - DONE
        /// </summary>
        /// <returns>integer</returns>
        public int GetQuantity()
        {
            Console.WriteLine("Enter the Quantity:\n");
            var input = Console.ReadLine().Trim();
            int intVal;
            while (!(int.TryParse(input, out intVal)))
            {
                Console.WriteLine("Invalid input. Enter a integer");
            }
            return intVal;
        }

        /// <summary>
        /// Converts y/n to boolean based on user input, 
        /// if true program will continue to add products - DONE
        /// </summary>
        /// <returns>boolean</returns>
        public bool IsAddAnotherProduct()
        {
            Console.WriteLine("Do you want to add another Product?(Y/N)");

            var input = Console.ReadLine().Trim();

            while (!(input != string.Empty &&
                     input.Equals("y", StringComparison.OrdinalIgnoreCase) ||
                     input.Equals("n", StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Invalid input. Enter (Y/N)");
                input = Console.ReadLine();
            }

            bool addAnotherProduct = TaxHelper.ParseBoolean(input);
            System.Diagnostics.Debug.WriteLine($"Here is your bool value: {addAnotherProduct}");
            return addAnotherProduct;
        }
    }
}
