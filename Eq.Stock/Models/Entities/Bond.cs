namespace Eq.StockDomain.Models.Entities
{
    /// <summary>
    /// Bond Stock Type entity
    /// </summary>
    public class Bond : StockBase
    {
        public Bond(decimal price, int quantity) : base(price, quantity)
        {}
    }
}
