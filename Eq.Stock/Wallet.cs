using System.Collections.Concurrent;
using System.Collections.Generic;
using Eq.StockDomain.Models.Transaction;

namespace Eq.StockDomain
{
    /// <summary>
    /// Fund wallet which contain all transactions
    /// </summary>
    public class Wallet : IWallet
    {
        private static readonly ConcurrentBag<ITransaction> Transactions = new ConcurrentBag<ITransaction>();
        
        /// <summary>
        /// Add transaction to Wallet
        /// </summary>
        /// <param name="transaction">Transaction which will be added to wallet</param>
        public void AddTransaction(ITransaction transaction)
        {
            if (transaction != null)
            {
                Transactions.Add(transaction);
            }
        }

        /// <summary>
        /// Get all transaction whcich are currently in the wallet
        /// </summary>
        /// <returns>Collection of all transactions in the Wallet</returns>
        public IEnumerable<ITransaction> GetTransactions()
        {
            return Transactions;
        }
    }
}
