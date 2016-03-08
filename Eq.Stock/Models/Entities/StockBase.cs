using System;
using Eq.StockDomain.Models.Enums;

namespace Eq.StockDomain.Models.Entities
{
    /// <summary>
    /// Base class for all Stock Types
    /// </summary>
    public abstract class StockBase
    {
        /// <summary>
        /// Stock Type Id
        /// </summary>
        public virtual int Id { get; protected set; }
        /// <summary>
        /// Stock Price
        /// </summary>
        public virtual decimal Price { get; }
        /// <summary>
        /// Stock Quantity
        /// </summary>
        public virtual int Quantity { get; }

        protected StockBase(decimal price, int quantity)
        {
            if (price < 0.01m)
            {
                throw new ArgumentException("Value cannot be less than 0.01", nameof(price));
            }

            if (quantity == 0)
            {
                throw new ArgumentException("Value cannot be 0", nameof(quantity));
            }

            Price = price;
            Quantity = quantity;
        }

        /// <summary>
        /// Get new Stock prepared based on provided Stock Type
        /// </summary>
        /// <param name="type">Stock Type</param>
        /// <param name="price">Stock Proce</param>
        /// <param name="quantity">Stock Quantity</param>
        /// <returns>Proper Stock Entity based on provided Stock Type</returns>
        public static StockBase GetNew(StockType type, decimal price, int quantity)
        {
            switch(type)
            {
                case StockType.Bond:
                    return new Bond(price, quantity);
                case StockType.Equity:
                    return new Equity(price, quantity);
                default:
                    throw new ArgumentNullException(nameof(type), "Unknown stock type");
            }
        }

        /// <summary>
        /// Assign provided Id to Stock
        /// </summary>
        /// <param name="id">Id to assign</param>
        public virtual void AssignId(int id)
        {
            if ( id < 1 )
            {
                throw new ArgumentException("Proposed id is less than 1", nameof(id));
            }

            Id = id;
        }

        /// <summary>
        /// Stock validation check
        /// </summary>
        /// <returns>True when Stock is valid</returns>
        public virtual bool IsValid() => Id > 0;

        /// <summary>
        /// Get Stock Name based on type and Id
        /// </summary>
        /// <returns>Stock Name</returns>
        public override string ToString() => $"{GetType().Name}{Id}";

        /// <summary>
        /// Parse Stock Type
        /// </summary>
        /// <returns>Proper Stock Type</returns>
        public StockType GetStockType() => (StockType)Enum.Parse(typeof(StockType), GetType().Name);
    }
}
