using DeathAndTaxes.Helpers;
using DeathAndTaxes.Products;
using DeathAndTaxes.TaxCalculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathAndTaxes.Billing
{
    public class Billing
    {
        ITaxCalculation taxCalculator;

        public Billing(ITaxCalculation taxCalc)
        {
            taxCalculator = taxCalc;
        }

        public decimal CalculateTax(decimal price, decimal tax, bool imported)
        {
            decimal totalProductTax = taxCalculator.CalculateTax(price, tax, imported);
            return totalProductTax;
        }

        public decimal CalcTotalProductCost(decimal price, decimal tax)
        {
            return TaxHelper.Truncate(price + tax);
        }

        public decimal CalcTotalTax(List<Product> prodList)
        {
            decimal totalTax = 0.0m;

            foreach (Product p in prodList)
            {
                totalTax += (p.TaxedCost - p.Price);
            }

            return TaxHelper.Truncate(totalTax);
        }

        public decimal CalcTotalAmount(List<Product> prodList)
        {
            decimal totalAmount = 0.0m;

            foreach (Product p in prodList)
            {
                totalAmount += p.TaxedCost;
            }

            return TaxHelper.Truncate(totalAmount);
        }

        public Receipt CreateNewReceipt(List<Product> productList, decimal totalTax, decimal totalAmount)
        {
            return new Receipt(productList, totalTax, totalAmount);
        }

        public void GenerateReceipt(Receipt r)
        {
            String receipt = r.ToString();
            Console.WriteLine(receipt);
        }
    }
}
