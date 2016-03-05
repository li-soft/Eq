using System;
using System.Collections.Generic;
using Eq.StockDomain.Models.Valuation;

namespace Eq.StockDomain.Models
{
    public class ValuationResult : IValuationResult
    {
        public Dictionary<StockType, IStockSummary> StockSummaryPerStockType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IStockSummary WalletSummary
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
