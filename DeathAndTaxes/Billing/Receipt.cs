using DeathAndTaxes.Products;
using System;
using System.Collections.Generic;
using CF = DeathAndTaxes.Constants.ConsoleFormatters;

namespace DeathAndTaxes.Billing
{
    public class Receipt
    {
        private List<Product> ProductList { get; set; }
        private decimal TotalSalesTax { get; set; }
        private decimal TotalAmount { get; set; }

        public Receipt(List<Product> prod, decimal tax, decimal amount)
        {
            ProductList = prod;
            TotalSalesTax = tax;
            TotalAmount = amount;
        }

        public int GetTotalNumberOfItems()
        {
            return ProductList.Count;
        }

        public override string ToString()
        {
            String receipt = "";
            Console.WriteLine(CF.ReceiptSpacer);
            foreach (var p in ProductList)
            {
                receipt += $"{CF.Indenter}{p}\n";
            }

            receipt += $"{CF.Indenter}Total sales tax: ${TotalSalesTax}\n";
            receipt += $"{CF.Indenter}Total amount: ${TotalAmount}\n";

            return receipt;
        }

        #region Helpers


        #endregion
    }
}
