using Eq.StockDomain.Models.Valuation;

namespace Eq.StockDomain.Services.Interfaces
{
    public interface IValuationService
    {
        IValuationResult ValueWallet();
    }
}
