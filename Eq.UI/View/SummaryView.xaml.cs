using Eq.Core;
using System.Windows.Controls;
using Eq.UI.ViewModel.Implementation;
using Eq.UI.ViewModel.Interfaces;

namespace Eq.UI.View
{
    /// <summary>
    /// Interaction logic for SummaryView.xaml
    /// </summary>
    public partial class SummaryView : UserControl
    {
        public SummaryView()
        {
            var vm = new SummaryViewModel();
            IoC.RegisterSingleInstance<ISummaryViewModel>(vm);

            DataContext = vm;
            InitializeComponent();
        }
    }
}
