using DeathAndTaxes.Products;

namespace DeathAndTaxes.ProductFactories
{
    public class MedicalProductFactory : ProductFactory
    {
        public override Product CeateProduct(string name, decimal price, bool imported, int quantity)
        {
            return new MedicalProduct(name, price, imported, quantity);
        }
    }
}
