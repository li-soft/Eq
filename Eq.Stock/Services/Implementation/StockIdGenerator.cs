using System;
using System.Collections.Concurrent;
using Eq.StockDomain.Models.Entities;
using Eq.StockDomain.Services.Interfaces;

namespace Eq.StockDomain.Services.Implementation
{
    /// <summary>
    /// Stock Id Generator
    /// </summary>
    public class StockIdGenerator : IStockIdGenerator
    {
        private static readonly ConcurrentDictionary<Type, int> NextHi = new ConcurrentDictionary<Type, int>();
        private static readonly object Lock = new object();

        /// <summary>
        /// Assign proper Id number to provided Stock
        /// </summary>
        /// <param name="stock">Stock entity</param>
        public void AssignIdToStock(StockBase stock)
        {
            if (stock == null)
            {
                throw new ArgumentNullException(nameof(stock));
            }

            var nextHi = GetNextHi(stock);
            stock.AssignId(nextHi);
        }

        /// <summary>
        /// Get next free Id based on provided Stock
        /// </summary>
        /// <param name="stock">Stock entity</param>
        /// <returns>Proper Id</returns>
        private static int GetNextHi(StockBase stock)
        {
            lock(Lock)
            {
                var stockType = stock.GetType();

                var currentHi = 0;
                NextHi.TryGetValue(stockType, out currentHi);

                ++currentHi;
                NextHi.AddOrUpdate(stockType, 1, (t, i) => currentHi);

                return currentHi;
            }
        }
    }
}
