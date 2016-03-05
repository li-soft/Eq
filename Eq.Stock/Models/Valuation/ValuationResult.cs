using System.Collections.Generic;
using Eq.StockDomain.Models.Valuation;

namespace Eq.StockDomain.Models
{
    public class ValuationResult : IValuationResult
    {
        public Dictionary<StockType, IStockSummary> StockSummaryPerStockType { get; private set; }
        public IStockSummary WalletSummary { get; private set; }

        public ValuationResult(IStockSummary walletSummary, Dictionary<StockType, IStockSummary> stockSummaryPerStockType)
        {
            StockSummaryPerStockType = stockSummaryPerStockType;
            WalletSummary = walletSummary; ;
        }
    }
}
