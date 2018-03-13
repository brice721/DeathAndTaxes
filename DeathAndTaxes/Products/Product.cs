using DeathAndTaxes.ProductFactories;
using DeathAndTaxes.TaxCalculations;
using System;
using CF = DeathAndTaxes.Constants.ConsoleFormatters;

namespace DeathAndTaxes.Products
{
    public abstract class Product
    {
        protected string Name { get; set; }

        private decimal _price;
        public decimal Price
        {
            set { _price = value; }
            get { return _price * Convert.ToDecimal(Quantity); }
        }

        public decimal UnitPrice(bool imported)
        {
            if (imported)
            {
                decimal something = Price * TaxValues.ImportDutySalesTaxValue;
                decimal test = Math.Round(something / 0.05m, MidpointRounding.AwayFromZero) * 0.05m;
                System.Diagnostics.Debug.WriteLine($"This is the test >>>> {test}");
                return test + Price;
            }

            return Price;
        }

        public bool Imported { get; set; }
        public int Quantity { get; set; }
        public decimal TaxedCost { get; set; }

        public Product()
        {
            Name = string.Empty;
            Price = 0.0m;
            Imported = false;
            Quantity = 0;
            TaxedCost = 0.0m;
        }

        public Product(String name, decimal price, bool imported, int quantity)
        {
            Name = name;
            Price = price;
            Imported = imported;
            Quantity = quantity;
        }

        public override string ToString()
        {
            string purchaseString = $"{ImportedToString(Imported)}{Name}: {Price:C} ({Quantity} @ {UnitPrice(Imported):C})";
            return purchaseString;
        }

        public String ImportedToString(bool imported)
        {
            if (!imported)
                return string.Empty;
            else
                return $"--Imported--\n{CF.Indenter}";
        }

        public abstract ProductFactory GetFactory();

        public abstract decimal GetTaxValue(String country);
    }
}
