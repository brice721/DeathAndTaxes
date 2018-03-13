using System;

namespace DeathAndTaxes.TaxCalculations
{
    public class ImportDutySalesTaxCalculations : ITaxCalculation
    {
        public decimal CalculateTax(decimal itemPrice, decimal importDuty, bool isImported)
        {
            decimal tax = itemPrice * TaxValues.BasicSalesTaxValue;

            if (isImported)
                tax += (itemPrice * 0.05m) + 0.5m;

            tax = RoundOff(tax);
            return tax;
        }

        public static decimal RoundOff(decimal value)
        {
            decimal deathAndTaxes = (value / 0.05m + 0.5m) * 0.05m;
            return Math.Round(deathAndTaxes / 0.05m, MidpointRounding.AwayFromZero) * 0.05m;
        }
    }
}
