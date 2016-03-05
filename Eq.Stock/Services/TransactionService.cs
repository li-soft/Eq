using System;
using Eq.StockDomain.Models.Entities;
using Eq.Core;

namespace Eq.StockDomain.Services
{
    public class TransactionService : ITransactionService
    {
        private Action<ITransaction> _addTransactionToWallet;

        private IStockIdGenerator _stockIdGenerator;
        private IStockIdGenerator StockIdGenerator
        {
            get
            {
                return _stockIdGenerator ?? (_stockIdGenerator = IoC.Container.Resolve<IStockIdGenerator>());
            }
        }

        public TransactionService() : this(Wallet.AddTransaction)
        {}

        public TransactionService(Action<ITransaction> addTransactionToWallet)
        {
            _addTransactionToWallet = addTransactionToWallet;
        }

        public ITransaction CreateTransactionAndAddToWallet(IStock stock)
        {
            if (stock == null)
            {
                return null;
            }

            StockIdGenerator.AssignIdToStock(stock);

            var transaction = new Transaction(stock);
            _addTransactionToWallet(transaction);

            return transaction;
        }
    }
}
