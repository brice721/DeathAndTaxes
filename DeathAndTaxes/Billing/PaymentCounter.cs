using DeathAndTaxes.Products;
using DeathAndTaxes.Shopping;
using DeathAndTaxes.TaxCalculations;
using System;
using System.Collections.Generic;

namespace DeathAndTaxes.Billing
{
    public class PaymentCounter
    {
        private Billing biller;
        private Receipt receipt;
        private List<Product> productList;
        private String country;

        public PaymentCounter(String country)
        {
            this.country = country;
        }

        public void BillItemsInCart(ShoppingCart cart)
        {
            productList = cart.GetItemsFromCart();

            foreach (Product p in productList)
            {
                biller = GetBiller(country);
                decimal productTax = biller.CalculateTax(p.Price, p.GetTaxValue(country), p.Imported);
                decimal taxedCost = biller.CalcTotalProductCost(p.Price, productTax);
                p.TaxedCost = taxedCost;
            }
        }

        public Receipt GetReceipt()
        {
            decimal totalTax = biller.CalcTotalTax(productList);
            decimal totalAmount = biller.CalcTotalAmount(productList);
            receipt = biller.CreateNewReceipt(productList, totalTax, totalAmount);
            return receipt;
        }

        public void PrintReceipt(Receipt receipt)
        {
            biller.GenerateReceipt(receipt);
        }

        public Billing GetBiller(String strategy)
        {
            TaxCalculatorFactory factory = new TaxCalculatorFactory();
            ITaxCalculation taxCal = factory.GetTaxCalculator(strategy);
            return new Billing(taxCal);
        }
    }
}
