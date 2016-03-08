using System;
using System.Linq;
using Eq.Core;
using Eq.StockDomain;
using Eq.StockDomain.Models.Entities;
using Eq.StockDomain.Models.Enums;
using Eq.StockDomain.Models.Transaction;
using Eq.StockDomain.Services.Implementation;
using Eq.Test.StockDomain.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eq.Test.StockDomain.Services
{
    [TestClass]
    public class ValuationServiceTest
    {
        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            IoC.RegisterSingleInstance(new Wallet(), true);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThrowExceptionWhenStcokTypeIsUnsupported()
        {
            //Arrange
            var transaction = new Transaction(new StockMock(1, 1));
            IoC.Resolve<IWallet>().AddTransaction(transaction);

            //Act
            new ValuationService().ValueWallet();
        }

        [TestMethod]
        public void GetValuationResultsSuccess()
        {
            //Arrange
            IoC.RegisterSingleInstance(new Wallet(), true);
            var bond = new Bond(1, 1);
            bond.AssignId(1);
            var transaction = new Transaction(bond);
            IoC.Resolve<IWallet>().AddTransaction(transaction);

            //Act
            var valuationResult = new ValuationService().ValueWallet();

            //Assert
            Assert.IsNotNull(valuationResult);
            Assert.AreEqual(5, valuationResult.StockSummaryPerStockType.Values.First().TotalStockValue);
            Assert.AreEqual(5, valuationResult.StockSummaryPerStockType.Values.First().TotalNumber);
            Assert.AreEqual(100, valuationResult.StockSummaryPerStockType.Values.First().TotalStockWeight);
            Assert.AreEqual(StockType.Bond, valuationResult.StockSummaryPerStockType.Keys.First());
        }
    }
}
