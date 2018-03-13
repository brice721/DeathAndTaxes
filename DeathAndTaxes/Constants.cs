using System;
using DeathAndTaxes.Helpers;

namespace DeathAndTaxes
{
    public class Constants
    {
        public class ConsoleFormatters
        {
            private static readonly string Indent = ConsoleFormatting.Indent();
            public static string ReceiptSpacer = $"{Indent}\n{Indent}Your Receipt\n{Indent}-----------------\n";
            public static string ThankYouBanner = $"{Indent}Thank You for Shopping...\r\n\n{Indent}Date: {CurrentDate()}\n{Indent}-----------------\r\n";
            public static string Indenter = $"{Indent}";
        }

        private static string CurrentDate()
        {
            string currentDate = DateTime.Now.ToString();
            return currentDate;
        }

    }
}
