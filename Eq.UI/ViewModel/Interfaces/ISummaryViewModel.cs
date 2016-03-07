using System.Collections.ObjectModel;
using Eq.UI.Model;

namespace Eq.UI.ViewModel.Interfaces
{
    /// <summary>
    /// ISummaryViewModel
    /// </summary>
    public interface ISummaryViewModel
    {
        /// <summary>
        /// Fund Valuation Summary collection
        /// </summary>
        ObservableCollection<SummaryModel> Summaries { get; set; }
    }
}
