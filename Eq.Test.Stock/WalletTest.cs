using Microsoft.VisualStudio.TestTools.UnitTesting;
using Eq.StockDomain.Models.Entities;
using System.Linq;
using Eq.StockDomain;
using Eq.StockDomain.Models.Transaction;

namespace Eq.Test.StockDomain
{
    [TestClass]
    public class WalletTest
    {
        [TestMethod]
        public void DoNotAddTransactionToBagWhetItIsNull()
        {
            //Arrange 
            var wallet = new Wallet();

            //Act
            wallet.AddTransaction(null);

            //Assert
            Assert.AreEqual(0, wallet.GetTransactions().Count());
        }

        [TestMethod]
        public void AddTransactionToWalletSuccess()
        {
            //Arrange 
            var wallet = new Wallet();
            var bond = new Bond(1, 1);
            bond.AssignId(1);
            var transaction = new Transaction(bond);

            //Act
            wallet.AddTransaction(transaction);
            var transactions = wallet.GetTransactions().ToList();

            //Assert
            Assert.AreEqual(1, transactions.Count);
            Assert.AreEqual(transaction, transactions.First());
        }

        [TestMethod]
        public void GetTotalEquitySuccess()
        {
            //Arrange 
            var wallet = new Wallet();
            var bond = new Bond(1, 1);
            bond.AssignId(1);
            var bondTr = new Transaction(bond);
            var eq = new Equity(1, -1);
            eq.AssignId(1);
            var eqTr = new Transaction(bond);

            //Act
            wallet.AddTransaction(bondTr);
            wallet.AddTransaction(eqTr);
            var totalEquity = wallet.TotalEquity;

            //Assert
            Assert.AreEqual(3, totalEquity);
        }
    }
}
