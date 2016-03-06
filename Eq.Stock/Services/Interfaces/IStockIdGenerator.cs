using Eq.StockDomain.Models.Entities;

namespace Eq.StockDomain.Services.Interfaces
{
    public interface IStockIdGenerator
    {
        void AssignIdToStock(StockBase stock);
    }
}
