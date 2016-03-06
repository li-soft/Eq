using Eq.Core;
using System.Windows.Controls;
using Eq.UI.ViewModel.Implementation;
using Eq.UI.ViewModel.Interfaces;

namespace Eq.UI.View
{
    /// <summary>
    /// Interaction logic for TransactionsView.xaml
    /// </summary>
    public partial class TransactionsView : UserControl
    {
        public TransactionsView()
        {
            var vm = new TransactionsViewModel();
            IoC.RegisterSingleInstance<ITransactionsViewModel>(vm);

            DataContext = vm;
            InitializeComponent();
        }
    }
}
