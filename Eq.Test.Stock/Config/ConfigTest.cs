using System;
using Eq.StockDomain.Models.Entities;
using Eq.Test.StockDomain.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eq.Test.StockDomain.Config
{
    [TestClass]
    public class ConfigTest
    {
        [TestMethod]
        public void GetProperFeeForBondSuccess()
        {
            //Arrange //Act
            var fee = Eq.StockDomain.Config.Config.Fee(typeof (Bond));

            //Assert
            Assert.AreEqual(0.02m, fee);
        }

        [TestMethod]
        public void GetProperFeeForEquitySuccess()
        {
            //Arrange //Act
            var fee = Eq.StockDomain.Config.Config.Fee(typeof(Equity));

            //Assert
            Assert.AreEqual(0.005m, fee);
        }

        [TestMethod]
        public void GetProperCostToleranceForBondSuccess()
        {
            //Arrange //Act
            var fee = Eq.StockDomain.Config.Config.CostTolerance(typeof(Bond));

            //Assert
            Assert.AreEqual(100000, fee);
        }

        [TestMethod]
        public void GetProperCostToleranceForEquitySuccess()
        {
            //Arrange //Act
            var fee = Eq.StockDomain.Config.Config.CostTolerance(typeof(Equity));

            //Assert
            Assert.AreEqual(200000, fee);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExceptionWhenStockTypeIsUnknown()
        {
            //Arrange //Act //Assert
            var fee = Eq.StockDomain.Config.Config.CostTolerance(typeof(StockMock));
        }
    }
}
