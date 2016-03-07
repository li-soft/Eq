using System.Collections.Generic;
using Eq.StockDomain.Models.Entities;
using Eq.StockDomain.Models.Transaction;

namespace Eq.StockDomain.Services.Interfaces
{
    /// <summary>
    /// TransactionService Interface
    /// </summary>
    public interface ITransactionService
    {
        /// <summary>
        /// Create Transaction based on provided Stock and add Transaction to the Wallet
        /// </summary>
        /// <param name="stock">Stock Entity</param>
        void CreateTransactionAndAddToWallet(StockBase stock);

        /// <summary>
        /// Get all Transactions which are current in the wallet
        /// </summary>
        /// <returns>List of Transactions</returns>
        IEnumerable<ITransaction> GetAllTransactions();
    }
}
