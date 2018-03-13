namespace DeathAndTaxes.TaxCalculations
{
    public interface ITaxCalculation
    {
        decimal CalculateTax(decimal price, decimal taxes, bool isImported);
    }
}
