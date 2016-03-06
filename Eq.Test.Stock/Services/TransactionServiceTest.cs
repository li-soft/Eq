using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eq.StockDomain.Models.Entities;
using Moq;
using Eq.Core;
using Eq.StockDomain;
using Eq.StockDomain.Services.Implementation;
using Eq.StockDomain.Services.Interfaces;

namespace Eq.Test.StockDomain.Services
{
    [TestClass]
    public class TransactionServiceTest
    {
        private static StockBase _stock;
        private static Mock<IStockIdGenerator> _idGeneratorMock;

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _stock = new Bond(1, 1);
            _stock.AssignId(1);
            _idGeneratorMock = new Mock<IStockIdGenerator>(MockBehavior.Strict);
            _idGeneratorMock.Setup(x => x.AssignIdToStock(_stock));
            IoC.RegisterSingleInstance(_idGeneratorMock.Object);
            IoC.RegisterSingleInstance<IWallet>(new Wallet());
        }

        [TestMethod]
        public void ReturnNullWhenStockIsNull()
        {
            //Arrange
            var service = new TransactionService();

            //Act
            service.CreateTransactionAndAddToWallet(null);

            //Assert
            _idGeneratorMock.Verify(x => x.AssignIdToStock(_stock), Times.Never);
        }

        [TestMethod]
        public void CreateTransactionAndAddToWalletSuccess()
        {
            //Arrange
            var service = new TransactionService();

            //Act
            service.CreateTransactionAndAddToWallet(_stock);

            //Assert
            _idGeneratorMock.Verify(x => x.AssignIdToStock(_stock), Times.Once);
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            IoC.Release((Wallet)IoC.Resolve<IWallet>());
        }
    }
}
