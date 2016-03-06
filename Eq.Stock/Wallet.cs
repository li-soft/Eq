using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Eq.StockDomain.Models.Entities
{
    /// <summary>
    /// Fund wallet which contain all transactions
    /// </summary>
    public static class Wallet
    {
        private static ConcurrentBag<ITransaction> _transactions = new ConcurrentBag<ITransaction>();
        
        /// <summary>
        /// Add transaction to Wallet
        /// </summary>
        /// <param name="transaction">Transaction which will be added to wallet</param>
        public static void AddTransaction(ITransaction transaction)
        {
            if (transaction != null)
            {
                _transactions.Add(transaction);
            }
        }

        /// <summary>
        /// Get all transaction whcich are currently in the wallet
        /// </summary>
        /// <returns>Collection of all transactions in the Wallet</returns>
        public static IEnumerable<ITransaction> GetTransactions()
        {
            return _transactions;
        }
    }
}
