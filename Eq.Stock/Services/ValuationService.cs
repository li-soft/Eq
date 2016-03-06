using Eq.StockDomain.Models;
using Eq.StockDomain.Models.Valuation;
using Eq.StockDomain.Models.Entities;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Eq.StockDomain.Services
{
    public class ValuationService : IValuationService
    {
        private readonly IEnumerable<ITransaction> _currentTransactions;

        public ValuationService() : this(Wallet.GetTransactions)
        {}

        public ValuationService(Func<IEnumerable<ITransaction>> transactionProvider)
        {
            _currentTransactions = transactionProvider();
        }

        public IValuationResult ValueWallet()
        {
            var walletSummary = GetWalletSummary();
            var perStockTypeSummary = GetPerStockTypeSummary();

            return new ValuationResult(walletSummary, perStockTypeSummary);
        }

        private IStockSummary GetWalletSummary()
        {
            var totalNo = _currentTransactions.Count();
            var totalValue = _currentTransactions.Sum(x => x.MarketValue);

            return new StockSummary(totalNo, totalValue, 100);
        }

        private Dictionary<StockType, IStockSummary> GetPerStockTypeSummary()
        {
            var perStockTypeSummary = new Dictionary<StockType, IStockSummary>();
            var groupedByTypeName = _currentTransactions.GroupBy(x => x.Stock.GetType().Name);

            foreach(var typeGroup in groupedByTypeName)
            {
                StockType stockType;
                if (!Enum.TryParse(typeGroup.Key, out stockType))
                {
                    //log or throw an exception but we are intrested only about B and E
                    continue;
                }

                var totalNo = groupedByTypeName.Count();
                var totalValue = groupedByTypeName.SelectMany(x => x).Sum(x => x.MarketValue);
                var totalStockWeight = groupedByTypeName.SelectMany(x => x).Sum(x => x.StockWeight);

                perStockTypeSummary.Add(stockType, new StockSummary(totalNo, totalValue, totalStockWeight));
            }

            return perStockTypeSummary;
        }
    }
}
