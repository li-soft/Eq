using System.Collections.Generic;
using Eq.Core;
using Eq.StockDomain.Models.Entities;
using Eq.StockDomain.Models.Transaction;
using Eq.StockDomain.Services.Interfaces;

namespace Eq.StockDomain.Services.Implementation
{
    public class TransactionService : ITransactionService
    {
        private IStockIdGenerator _stockIdGenerator;
        private IStockIdGenerator StockIdGenerator => _stockIdGenerator ?? (_stockIdGenerator = IoC.Resolve<IStockIdGenerator>());

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

        public IEnumerable<ITransaction> GetAllTransactions()
        {
            return Wallet.GetTransactions();
        }
    }
}
