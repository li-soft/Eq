using System.Collections.Generic;
using Eq.Core;
using Eq.StockDomain.Models.Entities;
using Eq.StockDomain.Models.Transaction;
using Eq.StockDomain.Services.Interfaces;

namespace Eq.StockDomain.Services.Implementation
{
    /// <summary>
    /// Service to create and add Transaction to the Wallet
    /// </summary>
    public class TransactionService : ITransactionService
    {
        /// <summary>
        /// Service to generate and Assing proper Id to Stock
        /// </summary>
        private IStockIdGenerator _stockIdGenerator;
        private IStockIdGenerator StockIdGenerator => _stockIdGenerator ?? (_stockIdGenerator = IoC.Resolve<IStockIdGenerator>());

        /// <summary>
        /// Wallet instance
        /// </summary>
        private IWallet _wallet;
        private IWallet Wallet => _wallet ?? (_wallet = IoC.Resolve<IWallet>());

        public void CreateTransactionAndAddToWallet(StockBase stock)
        {
            if (stock == null)
            {
                return;
            }

            StockIdGenerator.AssignIdToStock(stock);

            var transaction = new Transaction(stock);
            Wallet.AddTransaction(transaction);
        }

        /// <summary>
        /// Get all Transactions fron the Wallet
        /// </summary>
        /// <returns>List of Transactions</returns>
        public IEnumerable<ITransaction> GetAllTransactions()
        {
            return Wallet.GetTransactions();
        }
    }
}
