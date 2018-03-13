using DeathAndTaxes.Products;

namespace DeathAndTaxes.ProductFactories
{
    public class ImportedProductFactory : ProductFactory
    {
        public override Product CeateProduct(string name, decimal price, bool imported, int quantity)
        {
            return new ImportedProduct(name, price, imported, quantity);
        }
    }
}
