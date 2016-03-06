using System;
using Trans = Eq.StockDomain.Models.Entities.Transaction;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eq.StockDomain.Models.Entities;
using System.Collections.Generic;

namespace Eq.Test.StockDomain.Models.Transaction
{
    [TestClass]
    public class TransactionTest
    {
        private Trans _testTransactionWithBonds;
        private Trans _testTransactionWithEquities;
        private Func<IEnumerable<ITransaction>> transactionsProvider = () => 
        {
            var bond = new Bond(0.1m, 100);
            bond.AssignId(1);
            var equity = new Equity(1.3m, 1000);
            equity.AssignId(1);

            return new List<ITransaction> { new Trans(bond), new Trans(equity) };
        };

        [TestInitialize]
        public void SetUp()
        {
            var bond = new Bond(1.99m, 100);
            bond.AssignId(1);

            _testTransactionWithBonds = new Trans(bond, transactionsProvider);

            var equity = new Equity(2.79m, 101);
            equity.AssignId(1);

            _testTransactionWithEquities = new Trans(equity, transactionsProvider);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowExceptionWhenProvidedStockIsNull()
        {
            //Arrange //Act //Assert
            new Trans(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThrowExceptionWhenProvidedStockIsNotValid()
        {
            //Arrange //Act //Assert
            new Trans(new Bond(1, 1));
        }

        [TestMethod]
        public void GetTransactionCostForBondTransactionSuccess()
        {
            Assert.AreEqual(3.98m, _testTransactionWithBonds.Cost);
        }

        [TestMethod]
        public void GetTransactionCostForEquityTransactionSuccess()
        {
            Assert.AreEqual(1.40895m, _testTransactionWithEquities.Cost);
        }

        [TestMethod]
        public void GetMarketValueSuccess()
        {
            Assert.AreEqual(281.79m, _testTransactionWithEquities.MarketValue);
        }

        [TestMethod]
        public void CheckIfTransactionIsNotRiskySuccess()
        {
            Assert.IsFalse(_testTransactionWithEquities.IsRisky);
        }

        [TestMethod]
        public void CheckIfTransactionIsRiskySuccess()
        {
            //Arrange
            var equity = new Equity(13999999.81m, 100000);
            equity.AssignId(1);

            //Act
            var riskyTransaction = new Trans(equity);

            //Assert
            Assert.IsTrue(riskyTransaction.IsRisky);
        }

        [TestMethod]
        public void CheckStockWeightSuccess()
        {
            Assert.AreEqual(21.51m, Math.Round(_testTransactionWithEquities.StockWeight, 2));
        }
    }
}
