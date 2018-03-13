using DeathAndTaxes.ProductFactories;
using DeathAndTaxes.TaxCalculations;
using System;

namespace DeathAndTaxes.Products
{
    public class FoodProduct : Product
    {
        public FoodProduct() : base(){ }

        public FoodProduct(String name, decimal price, bool imported, int quantity)
            : base(name, price, imported, quantity)
        {
        }

        public override ProductFactory GetFactory()
        {
            return new FoodProductFactory();
        }

        public override decimal GetTaxValue(string country)
        {
            if (country == "Local")
                return TaxValues.TaxExempt;
            else
                return 0m;
        }
    }
}
