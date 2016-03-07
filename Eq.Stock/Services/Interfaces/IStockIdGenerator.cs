using Eq.StockDomain.Models.Entities;

namespace Eq.StockDomain.Services.Interfaces
{
    /// <summary>
    /// StockIdGenerator interface
    /// </summary>
    public interface IStockIdGenerator
    {
        /// <summary>
        /// Assign proper Id to provided Stock
        /// </summary>
        /// <param name="stock">Stock Entity</param>
        void AssignIdToStock(StockBase stock);
    }
}
