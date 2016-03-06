using System.Collections.Generic;
using Eq.StockDomain.Models.Enums;

namespace Eq.StockDomain.Models.Valuation
{
    /// <summary>
    /// ValuationResult entity to keep aggregated StockSummary per Stock Type data
    /// </summary>
    public class ValuationResult : IValuationResult
    {
        /// <summary>
        /// Stock Summary per Stock Type data
        /// </summary>
        public Dictionary<StockType, IStockSummary> StockSummaryPerStockType { get; }

        public ValuationResult(Dictionary<StockType, IStockSummary> stockSummaryPerStockType)
        {
            StockSummaryPerStockType = stockSummaryPerStockType;
        }
    }
}
