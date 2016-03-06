using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eq.StockDomain.Models.Entities;
using Eq.StockDomain.Services;
using Moq;
using Eq.Core;
using Castle.Windsor;
using Castle.MicroKernel.Registration;

namespace Eq.Test.StockDomain.Services
{
    [TestClass]
    public class TransactionServiceTest
    {
        [TestInitialize]
        public void SetUp()
        {
            IoC.Container = new WindsorContainer();
        }

        [TestMethod]
        public void ReturnNullWhenStockIsNull()
        {
            //Arrange
            var service = new TransactionService();

            //Act
            var transaction = service.CreateTransactionAndAddToWallet(null);

            //Assert
            Assert.IsNull(transaction);
        }

        [TestMethod]
        public void CreateTransactionAndAddToWalletSuccess()
        {
            //Arrange
            var walletTestValue = 0;
            Action<ITransaction> walletAddTransaction = _ => walletTestValue = 1;
            var bond = new Bond(1, 1);
            bond.AssignId(1);
            var idGeneratorMock = new Mock<IStockIdGenerator>(MockBehavior.Strict);
            idGeneratorMock.Setup(x => x.AssignIdToStock(bond));
            IoC.Container.Register(Component.For<IStockIdGenerator>().Instance(idGeneratorMock.Object));
            var service = new TransactionService(walletAddTransaction);

            //Act
            var transaction = service.CreateTransactionAndAddToWallet(bond);

            //Assert
            idGeneratorMock.Verify();
            Assert.IsNotNull(transaction);
            Assert.AreEqual(0.02m, transaction.Cost);
            Assert.IsFalse(transaction.IsRisky);
            Assert.AreEqual(1m, transaction.MarketValue);
            Assert.AreEqual("Bond1", transaction.ToString());
            Assert.AreEqual(bond, transaction.Stock);
            Assert.AreEqual(1, walletTestValue);
        }
    }
}
