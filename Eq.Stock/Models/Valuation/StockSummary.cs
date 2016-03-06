namespace Eq.StockDomain.Models.Valuation
{
    public class StockSummary : IStockSummary
    {
        public StockSummary(int totalNo, decimal totalStockValue, decimal totalStockWeight)
        {
            TotalNumber = totalNo;
            TotalStockValue = totalStockValue;
            TotalStockWeight = totalStockWeight;
        }

        public int TotalNumber { get; private set; }
        public decimal TotalStockValue { get; private set; }
        public decimal TotalStockWeight { get; private set; }
    }
}
