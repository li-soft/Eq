using Eq.StockDomain.Models.Entities;

namespace Eq.StockDomain.Models.Transaction
{
    public interface ITransaction
    {
        StockBase Stock { get; }
        decimal Cost { get; }
        decimal MarketValue { get; }
        decimal StockWeight { get; }
        bool IsRisky { get; }
        bool IsShortPosittion { get; }
    }
}
