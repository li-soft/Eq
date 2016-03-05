using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eq.StockDomain.Models.Enums;

namespace Eq.StockDomain.Models.Entities
{
    public class Transaction : ITransaction
    {
        /// <summary>
        /// Tolerance of transaction costs depends on Stock Type
        /// This can be taken from DB or config dynamically in the future
        /// </summary>
        private const decimal BondTransactionCostTolerance = 100000;
        private const decimal EquityTransactionCostTolerance = 200000;

        public decimal Cost
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public decimal MarketValue
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IStock Stock
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public decimal StockWeight
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public decimal Tolerance
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public DateTime TransactionTimeStamp
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public TransactionType TransactionType
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
