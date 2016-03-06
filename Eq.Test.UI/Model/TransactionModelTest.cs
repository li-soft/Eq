using System;
using Eq.Core;
using Eq.StockDomain;
using Eq.StockDomain.Models.Entities;
using Eq.StockDomain.Models.Enums;
using Eq.StockDomain.Models.Transaction;
using Eq.UI.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eq.Test.UI.Model
{
    [TestClass]
    public class TransactionModelTest
    {
        [TestMethod]
        public void MapFromTransactionSuccess()
        {
            //Arrange 
            var stock = new Bond(1, 1);
            stock.AssignId(1);
            var transaction = new Transaction(stock);
            var wallet = new Wallet();
            wallet.AddTransaction(transaction);
            IoC.RegisterSingleInstance<IWallet>(wallet);

            //Act
            var model = TransactionModel.MapFrom(transaction);

            //Assert
            Assert.AreEqual(StockType.Bond, model.StockType);
            Assert.AreEqual(1, model.Quantity);
            Assert.AreEqual(0.02m, model.Cost);
            Assert.IsFalse(model.IsRisky);
            Assert.AreEqual(1, model.MarketValue);
            Assert.AreEqual(1, model.Price);
            Assert.AreEqual(100, model.Weight);
            Assert.AreEqual(stock.ToString(), model.StockName);

            IoC.Release(wallet);
        }
    }
}
