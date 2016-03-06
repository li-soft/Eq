using Eq.StockDomain;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Eq.UI.ViewModel
{
    public class AddTransactionViewModel : ViewModelBase
    {
        private List<string> _stockTypes;
        public List<string> StockTypes
        {
            get { return _stockTypes; }
            private set
            {
                _stockTypes = value;
                RaisePropertyChanged("StockTypes");
            }
        }

        private string _selectedStocktype;
        public string SelectedStockType
        {
            get { return _selectedStocktype; }
            set
            {
                _selectedStocktype = value;
                RaisePropertyChanged("SelectedStockType");
            }
        }

        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                RaisePropertyChanged("Price");
            }
        }

        private decimal _quantity;
        public decimal Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                RaisePropertyChanged("Quantity");
            }
        }

        public ICommand CreateTransaction { get; private set; }

        public AddTransactionViewModel()
        {
            CreateTransaction = new RelayCommand(() => 
            {
                var c = SelectedStockType;
                System.Windows.MessageBox.Show("OK");
            }, () => Quantity > 0 && Price > 0);

            StockTypes = Enum.GetValues(typeof(StockType)).Cast<StockType>().Select(x => x.ToString()).ToList();
            SelectedStockType = StockTypes.First();
        }
    }
}
