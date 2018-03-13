using DeathAndTaxes.Products;
using System;

namespace DeathAndTaxes.ProductFactories
{
    public abstract class ProductFactory
    {
        public abstract Product CeateProduct(String name, decimal price, bool imported, int quantity);
    }
}
