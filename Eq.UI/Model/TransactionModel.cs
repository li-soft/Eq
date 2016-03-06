using Eq.StockDomain.Models.Enums;
using Eq.StockDomain.Models.Transaction;

namespace Eq.UI.Model
{
    /// <summary>
    /// Transaction Model for Transaction View/ViewModel
    /// </summary>
    public class TransactionModel
    {
        /// <summary>
        /// Stock Type
        /// </summary>
        public StockType StockType { get; set; }
        /// <summary>
        /// Stock Name
        /// </summary>
        public string StockName { get; set; }
        /// <summary>
        /// Stock Price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Stock Quantity
        /// </summary>
        public decimal Quantity { get; set; }
        /// <summary>
        /// Transaction Market Value
        /// </summary>
        public decimal MarketValue { get; set; }
        /// <summary>
        /// Transaction Cost
        /// </summary>
        public decimal Cost { get; set; }
        /// <summary>
        /// Transaction Weight
        /// </summary>
        public decimal Weight { get; set; }
        /// <summary>
        /// Is Transaction Risky
        /// </summary>
        public bool IsRisky { get; set; }

        /// <summary>
        /// Map Service entity to UI Model
        /// </summary>
        /// <param name="transaction">Transaction to map</param>
        /// <returns>UI Model</returns>
        public static TransactionModel MapFrom(ITransaction transaction) =>
            new TransactionModel
            {
                StockType = transaction.Stock.GetStockType(),
                StockName = transaction.Stock.ToString(),
                Price = transaction.Stock.Price,
                Quantity = transaction.Stock.Quantity,
                MarketValue = transaction.MarketValue,
                Cost = transaction.Cost,
                Weight = transaction.StockWeight,
                IsRisky = transaction.IsRisky
            };
    }
}
