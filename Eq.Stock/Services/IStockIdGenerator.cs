using Eq.StockDomain.Models.Entities;
namespace Eq.StockDomain.Services
{
    public interface IStockIdGenerator
    {
        IStock AssignIdToStock(IStock stock);
    }
}
