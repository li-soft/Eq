namespace Eq.StockDomain.Models.Entities
{
    /// <summary>
    /// Equity Stock Type entity
    /// </summary>
    public class Equity : StockBase
    {
        public Equity(decimal price, int quantity) : base(price, quantity)
        {}
    }
}
