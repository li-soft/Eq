using Eq.StockDomain.Models.Entities;
using System;
using System.Collections.Generic;

namespace Eq.StockDomain.Config
{
    /// <summary>
    /// Config mockup
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// Fees for supported Stock Types
        /// </summary>
        private static readonly Dictionary<Type, decimal> Fees = new Dictionary<Type, decimal>
        {
            {typeof(Bond), 0.02m },
            {typeof(Equity), 0.005m }
        };

        /// <summary>
        /// Costs tolerance for supported Stock Types
        /// </summary>
        private static readonly Dictionary<Type, decimal> CostsTolerances = new Dictionary<Type, decimal>
        {
            {typeof(Bond), 100000 },
            {typeof(Equity), 200000 }
        };

        /// <summary>
        /// Get proper Fee for provided Stock Type
        /// </summary>
        /// <param name="stockType">Stock Type</param>
        /// <returns>Fee</returns>
        public static decimal Fee(Type stockType) => GetFromProperDictionary(Fees, stockType);

        /// <summary>
        /// Get proper Cost Tolerance for provided Stock Type
        /// </summary>
        /// <param name="stockType">Stock Type</param>
        /// <returns>Cost Tolerance</returns>
        public static decimal CostTolerance(Type stockType) => GetFromProperDictionary(CostsTolerances, stockType);

        /// <summary>
        /// Generic method to select proper value from Dictionary based on provided Stock Type
        /// </summary>
        private static decimal GetFromProperDictionary(IReadOnlyDictionary<Type, decimal> dict, Type stockType)
        {
            decimal fee;
            if (!dict.TryGetValue(stockType, out fee))
            {
                throw new ArgumentException("Unknown stock type");
            }

            return fee;
        }
    }
}
