using System.Collections.Generic;
using Eq.StockDomain.Models.Enums;

namespace Eq.StockDomain.Models.Valuation
{
    /// <summary>
    /// IValuationResult
    /// </summary>
    public interface IValuationResult
    {
        /// <summary>
        /// StockSummary per StockType deictionary
        /// </summary>
        Dictionary<StockType, IStockSummary> StockSummaryPerStockType { get; }
    }
}
