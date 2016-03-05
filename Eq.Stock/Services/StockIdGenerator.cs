using System;
using Eq.StockDomain.Models.Entities;
using System.Collections.Concurrent;

namespace Eq.StockDomain.Services
{
    public class StockIdGenerator : IStockIdGenerator
    {
        private static ConcurrentDictionary<Type, int> NextHi = new ConcurrentDictionary<Type, int>();

        public void AssignIdToStock(IStock stock)
        {
            if (stock == null)
            {
                throw new ArgumentNullException(nameof(stock));
            }

            var nextHi = GetNextHi(stock);
            stock.AssignId(nextHi);
        }

        private int GetNextHi(IStock stock)
        {
            var stockType = stock.GetType();

            int currentHi = 0;
            if (NextHi.ContainsKey(stockType))
            {
                NextHi.TryGetValue(stockType, out currentHi);
            }

            ++currentHi;
            NextHi.AddOrUpdate(stockType, 1, (t, i) => { return currentHi; });

            return currentHi;
        }
    }
}
