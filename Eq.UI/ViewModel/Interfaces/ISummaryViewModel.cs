using System.Collections.ObjectModel;
using Eq.UI.Model;

namespace Eq.UI.ViewModel.Interfaces
{
    /// <summary>
    /// ISummaryViewModel
    /// </summary>
    public interface ISummaryViewModel
    {
        ObservableCollection<SummaryModel> Summaries { get; set; }
    }
}
