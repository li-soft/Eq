namespace Eq.StockDomain.Models.Entities
{
    public class Equity : StockBase
    {
        public Equity(decimal price, int quantity) : base(price, quantity)
        {}
    }
}
