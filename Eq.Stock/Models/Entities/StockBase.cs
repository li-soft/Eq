using System;

namespace Eq.StockDomain.Models.Entities
{
    public abstract class StockBase : IStock
    {
        public virtual int Id { get; protected set; }
        public virtual decimal Price { get; }
        public virtual int Quantity { get; }

        public StockBase(decimal price, int quantity)
        {
            if (price < 0.01m)
            {
                throw new ArgumentException("Value cannot be less than 0.01", nameof(price));
            }

            if (quantity < 1)
            {
                throw new ArgumentException("Value cannot be less than 1", nameof(quantity));
            }

            Price = price;
            Quantity = quantity;
        }

        public virtual void AssignId(int id)
        {
            if ( id < 1 )
            {
                throw new ArgumentException("Proposed id is less than 1", nameof(id));
            }

            Id = id;
        }

        public virtual bool IsValid()
        {
            return Id > 0;
        }

        public override string ToString() => string.Format("{0}{1}", GetType().Name, Id);
    }
}
