using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eq.StockDomain.Models.Entities;
using Eq.StockDomain.Services;
using System;
using Eq.StockDomain.Services.Implementation;

namespace Eq.Test.StockDomain.Services
{
    [TestClass]
    public class StockIdGeneratorTest
    {
        private readonly StockIdGenerator _stockIdGenerator = new StockIdGenerator();

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowExceptionWhenStockIsNull()
        {
            _stockIdGenerator.AssignIdToStock(null);
        }

        [TestMethod]
        public void AssignId1ToBondSuccess()
        {
            //Arranhge
            StockBase bond = new Bond(1, 100);

            //Act
            _stockIdGenerator.AssignIdToStock(bond);

            //Assert
            Assert.AreEqual(1, bond.Id);
        }

        [TestMethod]
        public void AssignId2ToBondSuccess()
        {
            //Arranhge
            StockBase bond = new Bond(1, 100);

            //Act
            _stockIdGenerator.AssignIdToStock(bond);

            //Assert
            Assert.AreEqual(2, bond.Id);
        }

        [TestMethod]
        public void AssignId1ToEquitySuccess()
        {
            //Arranhge
            StockBase equity = new Equity(1, 100);

            //Act
            _stockIdGenerator.AssignIdToStock(equity);

            //Assert
            Assert.AreEqual(1, equity.Id);
        }

        [TestMethod]
        public void AssignId3ToBondSuccess()
        {
            //Arranhge
            StockBase bond = new Bond(1, 100);

            //Act
            _stockIdGenerator.AssignIdToStock(bond);

            //Assert
            Assert.AreEqual(3, bond.Id);
        }
    }
}
