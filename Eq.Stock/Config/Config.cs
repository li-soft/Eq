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
        private static readonly Dictionary<Type, decimal> Fees = new Dictionary<Type, decimal>
        {
            {typeof(Bond), 0.02m },
            {typeof(Equity), 0.005m }
        };

        private static readonly Dictionary<Type, decimal> CostsTolerances = new Dictionary<Type, decimal>
        {
            {typeof(Bond), 100000 },
            {typeof(Equity), 200000 }
        };

        public static decimal Fee(Type stockType)
        {
            return GetFromProperDictionary(Fees, stockType);
        }

        public static decimal CostTolerance(Type stockType)
        {
            return GetFromProperDictionary(CostsTolerances, stockType);
        }

        private static decimal GetFromProperDictionary(Dictionary<Type, decimal> dict, Type stockType)
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
