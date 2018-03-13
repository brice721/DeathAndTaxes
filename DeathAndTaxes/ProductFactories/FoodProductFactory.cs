using DeathAndTaxes.Products;

namespace DeathAndTaxes.ProductFactories
{
    public class FoodProductFactory : ProductFactory
    {
        public override Product CeateProduct(string name, decimal price, bool imported, int quantity)
        {
            return new FoodProduct(name, price, imported, quantity);
        }
    }
}
