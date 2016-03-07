using Eq.StockDomain.Models.Valuation;

namespace Eq.StockDomain.Services.Interfaces
{
    /// <summary>
    /// ValuationSerice interface
    /// </summary>
    public interface IValuationService
    {
        /// <summary>
        /// Value whole Wallet based on current Transactions
        /// </summary>
        /// <returns></returns>
        IValuationResult ValueWallet();
    }
}
