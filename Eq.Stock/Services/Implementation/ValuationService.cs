using System;
using System.Collections.Generic;
using System.Linq;
using Eq.Core;
using Eq.StockDomain.Models.Enums;
using Eq.StockDomain.Models.Valuation;
using Eq.StockDomain.Services.Interfaces;

namespace Eq.StockDomain.Services.Implementation
{
    /// <summary>
    /// Valuation Service to value currrent wallet
    /// </summary>
    public class ValuationService : IValuationService
    {
        private IWallet _wallet;
        private IWallet Wallet => _wallet ?? (_wallet = IoC.Resolve<IWallet>());

        /// <summary>
        /// Value v=current wallet and get aggregated ValuationResults
        /// </summary>
        /// <returns></returns>
        public IValuationResult ValueWallet()
        {
            var perStockTypeSummary = GetPerStockTypeSummary();

            return new ValuationResult(perStockTypeSummary);
        }

        /// <summary>
        /// Group Wallet by Stock Type and calculate data per Stock Type
        /// </summary>
        /// <returns>Aggregated Stock Summary per Stock Type</returns>
        private Dictionary<StockType, IStockSummary> GetPerStockTypeSummary()
        {
            var perStockTypeSummary = new Dictionary<StockType, IStockSummary>();
            var groupedByTypeName = Wallet.GetTransactions().GroupBy(x => x.Stock.GetType().Name).ToList();

            foreach(var typeGroup in groupedByTypeName)
            {
                StockType stockType;
                if (!Enum.TryParse(typeGroup.Key, out stockType))
                {
                    throw new InvalidOperationException("Unsupported Stock Type");
                }

                var totalNo = typeGroup.Count();
                var totalValue = typeGroup.Sum(x => x.MarketValue);
                var totalStockWeight = typeGroup.Sum(x => x.StockWeight);

                perStockTypeSummary.Add(stockType, new StockSummary(totalNo, totalValue, totalStockWeight));
            }

            return perStockTypeSummary;
        }
    }
}
