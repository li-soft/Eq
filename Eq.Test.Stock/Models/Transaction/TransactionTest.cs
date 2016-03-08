using System;
using Trans = Eq.StockDomain.Models.Transaction.Transaction;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eq.StockDomain.Models.Entities;
using Eq.Core;
using Eq.StockDomain;

namespace Eq.Test.StockDomain.Models.Transaction
{
    [TestClass]
    public class TransactionTest
    {
        private static Trans _testTransactionWithBonds;
        private static Trans _testTransactionWithEquities;

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            var bond = new Bond(1.99m, 100);
            bond.AssignId(1);

            _testTransactionWithBonds = new Trans(bond);

            var equity = new Equity(2.79m, 101);
            equity.AssignId(1);

            _testTransactionWithEquities = new Trans(equity);

            var wallet = new Wallet();
            wallet.AddTransaction(_testTransactionWithEquities);

            IoC.RegisterSingleInstance(wallet, true);
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
    }
}
