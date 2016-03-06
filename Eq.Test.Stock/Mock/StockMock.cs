using Eq.StockDomain.Models.Entities;

namespace Eq.Test.StockDomain.Mock
{
    public class StockMock : StockBase
    {
        public StockMock(decimal price, int quantity) : base(price, quantity)
        { }
    }
}
