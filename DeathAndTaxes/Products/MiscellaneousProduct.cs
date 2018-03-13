using DeathAndTaxes.ProductFactories;
using DeathAndTaxes.TaxCalculations;
using System;

namespace DeathAndTaxes.Products
{
    public class MiscellaneousProduct : Product
    {
        public MiscellaneousProduct()
            : base()
        {
        }

        public MiscellaneousProduct(String name, decimal price, bool imported, int quantity)
            : base(name, price, imported, quantity)
        {
        }

        public override ProductFactories.ProductFactory GetFactory()
        {
            return new MiscellaneousProductFactory();
        }

        public override decimal GetTaxValue(string country)
        {
            if (country == "Local")
                return TaxValues.BasicSalesTaxValue;
            else
                return 0;
        }
    }
}
