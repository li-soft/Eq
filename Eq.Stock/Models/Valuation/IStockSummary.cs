namespace Eq.StockDomain.Models.Valuation
{
    /// <summary>
    /// IStockSummary
    /// </summary>
    public interface IStockSummary
    {
        /// <summary>
        /// Total Number of Stocks per Stock Type
        /// </summary>
        int TotalNumber { get; }
        /// <summary>
        /// Total Stock Weight
        /// </summary>
        decimal TotalStockWeight { get; }
        /// <summary>
        /// Total Value of Stocks
        /// </summary>
        decimal TotalStockValue { get; }
    }
}
