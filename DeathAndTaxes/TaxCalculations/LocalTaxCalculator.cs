using DeathAndTaxes.Helpers;

namespace DeathAndTaxes.TaxCalculations
{
    public class LocalTaxCalculator : ITaxCalculation
    {
        public decimal CalculateTax(decimal price, decimal localTax, bool imported)
        {
            decimal tax = price * localTax;

            if (imported)
                tax += (price * 0.05m);

            //rounds off to nearest 0.05;
            tax = TaxHelper.RoundOff(tax);

            return tax;
        }
    }
}
