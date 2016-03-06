using Eq.StockDomain.Models.Enums;
using System;

namespace Eq.StockDomain.Models.Entities
{
    public interface ITransaction
    {
        IStock Stock { get; }
        decimal Cost { get; }
        decimal MarketValue { get; }
        decimal StockWeight { get; }
        bool IsRisky { get; }
    }
}
