using DeathAndTaxes.Shopping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathAndTaxes.Helpers
{
    public class TaxHelper
    {
        private const decimal NearestNickle = 0.05m;

        /// <summary>
        /// Rounds off a double value to the nearest 0.05
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal RoundOff(decimal value)
        {
            decimal deathAndTaxes = (value / 0.05m) * 0.05m;
            return Math.Round(deathAndTaxes / NearestNickle, MidpointRounding.AwayFromZero) * 0.05m;
        }

        public static decimal Truncate(decimal value)
        {
            String result = value.ToString("N2"); ;
            return Decimal.Parse(result);
        }

        public static bool ParseBoolean(string value)
        {
            Store shopping = new Store();
            bool flag = true;
            bool boolValue = false;

            while (flag)
            {
                //parses 'Y' into 'true'
                if (value.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    boolValue = true;
                    flag = false;
                }

                //parses 'N' into 'false'
                else if (value.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    boolValue = false;
                    flag = false;
                }

                //validates user input
                else
                {
                    Console.WriteLine("Invalid input. Enter (Y/N)");
                }
            }

            return boolValue;
        }
    }
}
