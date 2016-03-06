using System.Collections.Generic;
using Eq.StockDomain.Models.Entities;
using Eq.StockDomain.Models.Transaction;

namespace Eq.StockDomain.Services.Interfaces
{
    public interface ITransactionService
    {
        void CreateTransactionAndAddToWallet(StockBase stock);
        IEnumerable<ITransaction> GetAllTransactions();
    }
}
