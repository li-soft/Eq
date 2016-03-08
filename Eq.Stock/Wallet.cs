using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Eq.StockDomain.Models.Transaction;

namespace Eq.StockDomain
{
    /// <summary>
    /// Fund wallet which contain all transactions
    /// </summary>
    public class Wallet : IWallet
    {
        private static readonly ConcurrentBag<ITransaction> Transactions = new ConcurrentBag<ITransaction>();

        public decimal TotalEquity { get; private set; }

        /// <summary>
        /// Add transaction to Wallet and trigger total equity recalculation
        /// </summary>
        /// <param name="transaction">Transaction which will be added to wallet</param>
        public void AddTransaction(ITransaction transaction)
        {
            if (transaction == null)
            {
                return;
            }

            Transactions.Add(transaction);
            RecalculateTotalEquity();
        }

        /// <summary>
        /// Get all transaction whcich are currently in the wallet
        /// </summary>
        /// <returns>Collection of all transactions in the Wallet</returns>
        public IEnumerable<ITransaction> GetTransactions()
        {
            return Transactions;
        }

        /// <summary>
        /// Recalculate total wallet equity
        /// </summary>
        /// <returns></returns>
        private void RecalculateTotalEquity()
        {
            TotalEquity = Transactions.Sum(x => Math.Abs(x.MarketValue));
        }
    }
}
