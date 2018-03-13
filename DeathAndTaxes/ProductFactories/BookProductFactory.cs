using DeathAndTaxes.Products;

namespace DeathAndTaxes.ProductFactories
{
    public class BookProductFactory : ProductFactory
    {
        public override Product CeateProduct(string name, decimal price, bool imported, int quantity)
        {
            return new BookProduct(name, price, imported, quantity);
        }
    }
}
