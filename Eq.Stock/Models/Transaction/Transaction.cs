using System;
using System.Collections.Generic;
using System.Linq;

namespace Eq.StockDomain.Models.Entities
{
    public class Transaction : ITransaction
    {
        private readonly decimal _fee;
        private readonly decimal _tolerance;
        private readonly Func<IEnumerable<ITransaction>> _transactionsProvider;

        public IStock Stock { get; private set; }

        public decimal Cost
        {
            get { return MarketValue * _fee; }
        }

        public bool IsRisky
        {
            get { return MarketValue < 0 || Cost > _tolerance; }
        }

        public decimal MarketValue
        {
            get { return Stock.Quantity * Stock.Price; }
        }

        public decimal StockWeight
        {
            get
            {
                var totalMarketValue = _transactionsProvider().Sum(x => x.MarketValue);
                return MarketValue * 100 / totalMarketValue;
            }
        }

        public Transaction(IStock stock) : this(stock, Wallet.GetTransactions)
        {}

        /// <summary>
        /// For Unit Test purposes
        /// </summary>
        public Transaction(IStock stock, Func<IEnumerable<ITransaction>> transactionsProvider)
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
            _transactionsProvider = transactionsProvider;
        }

        public override string ToString() => Stock.ToString();
    }
}
