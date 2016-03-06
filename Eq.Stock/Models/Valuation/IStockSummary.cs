namespace Eq.StockDomain.Models.Valuation
{
    public interface IStockSummary
    {
        int TotalNumber { get; }
        decimal TotalStockWeight { get; }
        decimal TotalStockValue { get; }
    }
}
