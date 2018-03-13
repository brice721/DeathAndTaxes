using DeathAndTaxes.ProductFactories;
using DeathAndTaxes.TaxCalculations;
using System;

namespace DeathAndTaxes.Products
{
    public class BookProduct : Product
    {

        public BookProduct()
            : base()
        {
        }

        public BookProduct(String name, decimal price, bool imported, int quantity)
            : base(name, price, imported, quantity)
        {

        }

        public override ProductFactory GetFactory()
        {
            return new BookProductFactory();
        }

        // Make sure that is the correct value for tax
        public override decimal GetTaxValue(string country)
        {
            if (country == "Local")
                return TaxValues.TaxExempt;
            else
                return 0;
        }
    }
}
