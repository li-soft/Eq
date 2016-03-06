using System.Collections.ObjectModel;
using Eq.UI.Model;
using Eq.UI.ViewModel.Interfaces;
using GalaSoft.MvvmLight;

namespace Eq.UI.ViewModel.Implementation
{
    /// <summary>
    /// Summary View Model for SummaryView
    /// </summary>
    public class SummaryViewModel : ViewModelBase, ISummaryViewModel
    {
        /// <summary>
        /// Fund Valuation Summary collection
        /// </summary>
        private ObservableCollection<SummaryModel> _summaries = new ObservableCollection<SummaryModel>();
        public ObservableCollection<SummaryModel> Summaries
        {
            get { return _summaries; }
            set
            {
                _summaries = value;
                RaisePropertyChanged("Summaries");
            }
        }
    }
}
