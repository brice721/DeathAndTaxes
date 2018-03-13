using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeathAndTaxes.Shopping;
using store = DeathAndTaxes.Shopping.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeathAndTaxes.Billing;

namespace DeathAndTaxes.Tests
{
    [TestClass()]
    public class StoreTests
    {
        [TestMethod()]
        public void GetSalesOrderTest()
        {
            Store _store = new Store();

            var result = new _store.CheckOut();


            Assert.Fail();
        }

        [TestMethod()]
        public void CheckOutTest()
        {
            Receipt receipt = new Receipt();
            var result = receipt as TestResult();
            Assert.Fail();
        }
    }
}