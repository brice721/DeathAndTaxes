using System;
using System.Collections.Generic;

namespace DeathAndTaxes.TaxCalculations
{
    public class TaxCalculatorFactory
    {
        private Dictionary<String, ITaxCalculation> taxCalculators;

        public TaxCalculatorFactory()
        {
            taxCalculators = new Dictionary<String, ITaxCalculation>();
            RegisterInFactory("Local", new LocalTaxCalculator());
        }

        public void RegisterInFactory(string strategy, ITaxCalculation taxCalc)
        {
            taxCalculators.Add(strategy, taxCalc);
        }

        public ITaxCalculation GetTaxCalculator(String strategy)
        {
            ITaxCalculation taxCalc = (ITaxCalculation)taxCalculators[strategy];
            return taxCalc;
        }

        public int GetFactorySize()
        {
            return taxCalculators.Count;
        }
    }
}
