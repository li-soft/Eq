using Eq.StockDomain.Models.Valuation;
using System.Collections.Generic;

namespace Eq.StockDomain.Models
{
    public interface IValuationResult
    {
        IStockSummary WalletSummary { get; }
        Dictionary<StockType, IStockSummary> StockSummaryPerStockType { get; }
    }
}
