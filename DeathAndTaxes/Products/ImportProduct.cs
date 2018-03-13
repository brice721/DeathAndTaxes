using DeathAndTaxes.ProductFactories;
using DeathAndTaxes.TaxCalculations;
using System;

namespace DeathAndTaxes.Products
{
    class ImportedProduct : Product
    {
        public ImportedProduct() { }

        public ImportedProduct(String name, decimal price, bool imported, int quantity)
            : base(name, price, imported, quantity) { }

        public override ProductFactory GetFactory() =>
            new ImportedProductFactory();

        public override decimal GetTaxValue(string country)
        {
            decimal taxValue = TaxValues.ImportDutySalesTaxValue;
            ImportDutySalesTaxCalculations ImportDuty = new ImportDutySalesTaxCalculations();

            return ImportDuty.CalculateTax(Price, taxValue, Imported);
        }
    }
}
