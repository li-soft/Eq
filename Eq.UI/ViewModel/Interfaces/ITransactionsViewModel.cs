using System.Collections.ObjectModel;
using Eq.UI.Model;

namespace Eq.UI.ViewModel.Interfaces
{
    /// <summary>
    /// ITransactionsViewModel
    /// </summary>
    public interface ITransactionsViewModel
    {
        /// <summary>
        /// Valuated Transactions Collection
        /// </summary>
        ObservableCollection<TransactionModel> Transactions { get; set; }
    }
}
