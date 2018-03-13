using DeathAndTaxes.Products;

namespace DeathAndTaxes.ProductFactories
{
    public class MiscellaneousProductFactory : ProductFactory
    {
        public override Product CeateProduct(string name, decimal price, bool imported, int quantity)
        {
            return new MiscellaneousProduct(name, price, imported, quantity);
        }
    }
}
