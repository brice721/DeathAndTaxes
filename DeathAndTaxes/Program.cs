using System;
using DeathAndTaxes.Helpers;
using CF = DeathAndTaxes.Constants.ConsoleFormatters;
using DeathAndTaxes.Shopping;

namespace DeathAndTaxes
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Dealer On Demo";

            Run();
        }

        public void ErrorHandle()
        {
            Run();
        }

        static void Run()
        {
            string indent = ConsoleFormatting.Indent();
            while (true)
            {
                var consoleInput = ReadFromConsole();
                if (string.IsNullOrWhiteSpace(consoleInput)) continue;

                try
                {
                    Store store = new Store();
                    store.GetAvailableProducts();
                    store.GetSalesOrder();
                    store.CheckOut();

                    string result = CF.ThankYouBanner;

                    WriteToConsole(result);
                }
                catch (Exception ex)
                {
                    WriteToConsole(ex.Message);
                }
            }
        }

        public static void WriteToConsole(string message = "")
        {
            if (message.Length > 0)
            {
                Console.WriteLine(message);
            }
        }
        const string _readPrompt = "<DealerOn_Demo> \n";
        public static string ReadFromConsole(string promptMessage = "Enter 'start' and press ENTER to begin...\n")
        {
            Console.Write(_readPrompt + promptMessage);
            string input = Console.ReadLine().Trim().ToLower();

            if (input != string.Empty && 
                input.Equals("start", StringComparison.OrdinalIgnoreCase))
                return input;
            else
            {
                return Console.ReadLine();
            }
        }
    }
}
