using Eq.StockDomain.Models.Entities;
namespace Eq.StockDomain.Services
{
    public interface IStockIdGenerator
    {
        void AssignIdToStock(IStock stock);
    }
}
