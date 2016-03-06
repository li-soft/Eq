using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eq.StockDomain.Models.Entities;
using System;

namespace Eq.Test.StockDomain.Models.Entities
{
    [TestClass]
    public class EquityTest
    {
        [TestMethod]
        public void StockToStringOverrideMethodTestSuccess()
        {
            //Arrange
            IStock equity = new Equity(12.9m, 100);

            //Act
            var stockName = equity.ToString();

            //Assert
            Assert.AreEqual("Equity0", stockName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExceptionWhenPriceIsLessThan1Cent()
        {
            new Equity(0, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExceptionWhenQuantityIsLessThan1()
        {
            new Equity(12, -3);
        }
    }
}
