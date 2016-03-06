using System.Collections.ObjectModel;
using Eq.UI.Model;
using Eq.UI.ViewModel.Interfaces;
using GalaSoft.MvvmLight;

namespace Eq.UI.ViewModel.Implementation
{
    /// <summary>
    /// TransactionsViewModel for TransactionsView
    /// </summary>
    public class TransactionsViewModel : ViewModelBase, ITransactionsViewModel
    {
        /// <summary>
        /// Valuated Transactions Collection
        /// </summary>
        private ObservableCollection<TransactionModel> _transactions = new ObservableCollection<TransactionModel>();
        public ObservableCollection<TransactionModel> Transactions
        {
            get { return _transactions; }
            set
            {
                _transactions = value;
                RaisePropertyChanged("Transactions");
            }
        }
    }
}
