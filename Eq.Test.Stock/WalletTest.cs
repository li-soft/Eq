using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eq.StockDomain.Models.Entities;
using System.Linq;

namespace Eq.Test.StockDomain
{
    [TestClass]
    public class WalletTest
    {
        [TestMethod]
        public void DoNotAddTransactionToBagWhetItIsNull()
        {
            //Arrange //Act
            Wallet.AddTransaction(null);

            //Assert
            Assert.AreEqual(0, Wallet.GetTransactions().Count());
        }

        [TestMethod]
        public void AddTransactionToWalletSuccess()
        {
            //Arrange 
            var bond = new Bond(1, 1);
            bond.AssignId(1);
            var transaction = new Transaction(bond);

            //Act
            Wallet.AddTransaction(transaction);
            var transactions = Wallet.GetTransactions().ToList();

            //Assert
            Assert.AreEqual(1, transactions.Count);
            Assert.AreEqual(transaction, transactions.First());
        }
    }
}
