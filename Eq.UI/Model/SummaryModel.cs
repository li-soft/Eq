using Eq.StockDomain.Models.Valuation;

namespace Eq.UI.Model
{
    /// <summary>
    /// Summary Model for Summary View/ViewModel
    /// </summary>
    public class SummaryModel
    {
        /// <summary>
        /// Stock type name
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// Stock weight for current type
        /// </summary>
        public decimal TotalStockWeight { get; set; }
        /// <summary>
        /// Total value of current stock type
        /// </summary>
        public decimal TotalMarketValue { get; set; }
        /// <summary>
        /// Total current type stocks number
        /// </summary>
        public int TotalNumber { get; set; }

        /// <summary>
        /// Map Service entity to UI mmodel
        /// </summary>
        /// <param name="stockSummary">StockSummary entity</param>
        /// <param name="typeName">Stock type name</param>
        /// <returns>UI model</returns>
        public static SummaryModel MapFrom(IStockSummary stockSummary, string typeName) =>
            new SummaryModel
            {
                TotalMarketValue = stockSummary.TotalStockValue,
                TotalStockWeight = stockSummary.TotalStockWeight,
                TotalNumber = stockSummary.TotalNumber,
                TypeName = typeName
            };
    }
}
