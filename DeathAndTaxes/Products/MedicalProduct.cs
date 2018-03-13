using DeathAndTaxes.ProductFactories;
using System;

namespace DeathAndTaxes.Products
{
    public class MedicalProduct : Product
    {

        public MedicalProduct()
            : base()
        {

        }

        public MedicalProduct(String name, decimal price, bool imported, int quantity)
            : base(name, price, imported, quantity)
        {
        }

        public override ProductFactories.ProductFactory GetFactory()
        {
            return new MedicalProductFactory();
        }

        public override decimal GetTaxValue(string country)
        {
            if (country == "Local")
                return 0;
            else
                return 0;
        }
    }
}
