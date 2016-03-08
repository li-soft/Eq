using System;
using Eq.Core;
using Eq.StockDomain.Models.Entities;

namespace Eq.StockDomain.Models.Transaction
{
    public class Transaction : ITransaction
    {
        private readonly decimal _fee;
        private readonly decimal _tolerance;

        /// <summary>
        /// Transaction Stock
        /// </summary>
        public StockBase Stock { get; }
        /// <summary>
        /// Transaction Cost
        /// </summary>
        public decimal Cost => Math.Abs(MarketValue * _fee);
        /// <summary>
        /// Is this transaction risky
        /// </summary>
        public bool IsRisky => MarketValue < 0 || Cost > _tolerance;
        /// <summary>
        /// Is this transaction on short position
        /// </summary>
        public bool IsShortPosittion => Stock.Quantity < 0;
        /// <summary>
        /// Transaction Market Value
        /// </summary>
        public decimal MarketValue => Stock.Quantity * Stock.Price;
        /// <summary>
        /// Transaction Stock Weight
        /// </summary>
        public decimal StockWeight
        {
            get
            {
                var totalEquity = Wallet.TotalEquity;
                return totalEquity == 0 ? 0 : Math.Abs(MarketValue) * 100 / totalEquity;
            }
        } 

        private IWallet _wallet;
        private IWallet Wallet => _wallet ?? (_wallet = IoC.Resolve<IWallet>());

        public Transaction(StockBase stock)
        {
            if (stock == null)
            {
                throw new ArgumentNullException(nameof(stock));
            }

            if (!stock.IsValid())
            {
                throw new InvalidOperationException("Cannot create transaction when Stock is not valid");
            }

            Stock = stock;
            _fee = Config.Config.Fee(stock.GetType());
            _tolerance = Config.Config.CostTolerance(stock.GetType());
        }

        /// <summary>
        /// Transaction Name same as Stock Name
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Stock.ToString();
    }
}