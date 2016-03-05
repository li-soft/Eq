using Eq.StockDomain.Models.Entities;

namespace Eq.StockDomain.Services
{
    public interface ITransactionService
    {
        ITransaction CreateTransactionAndAddToWallet(IStock stock);
    }
}
