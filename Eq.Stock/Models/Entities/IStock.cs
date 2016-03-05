namespace Eq.StockDomain.Models.Entities
{
    public interface IStock
    {
        int Id { get; }
        decimal Price { get; }
        int Quantity { get; }
        bool IsValid();
    }
}
