namespace Eq.StockDomain.Models.Valuation
{
    /// <summary>
    /// Stock Summary entity to keep aggregated data
    /// </summary>
    public class StockSummary : IStockSummary
    {
        /// <summary>
        /// Total Number of Stocks per Stock Type
        /// </summary>
        public int TotalNumber { get; }
        /// <summary>
        /// Total Value of Stocks
        /// </summary>
        public decimal TotalStockValue { get; }
        /// <summary>
        /// Total Stock Weight
        /// </summary>
        public decimal TotalStockWeight { get; }

        public StockSummary(int totalNo, decimal totalStockValue, decimal totalStockWeight)
        {
            TotalNumber = totalNo;
            TotalStockValue = totalStockValue;
            TotalStockWeight = totalStockWeight;
        }
    }
}
