using System.Collections.Generic;
using Eq.StockDomain.Models.Transaction;

namespace Eq.StockDomain
{
    /// <summary>
    /// IWallet
    /// </summary>
    public interface IWallet
    {
        /// <summary>
        /// Add one transaction to Wallet
        /// </summary>
        /// <param name="transaction"></param>
        void AddTransaction(ITransaction transaction);
        /// <summary>
        /// Get all Transactions from Wallet
        /// </summary>
        /// <returns>List of Transactions</returns>
        IEnumerable<ITransaction> GetTransactions();
    }
}
