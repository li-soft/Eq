using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Eq.Core;
using Eq.StockDomain.Models.Entities;
using Eq.StockDomain.Models.Enums;
using Eq.StockDomain.Services.Interfaces;
using Eq.UI.Model;
using Eq.UI.ViewModel.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace Eq.UI.ViewModel.Implementation
{
    /// <summary>
    /// View model for AddTransaction partial View
    /// </summary>
    public class AddTransactionViewModel : ViewModelBase
    {
        #region Properties
        private List<string> _stockTypes;
        /// <summary>
        /// List of supported Stock types
        /// </summary>
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
        /// <summary>
        /// Current selected Stock Type
        /// </summary>
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
        /// <summary>
        /// Stock price
        /// </summary>
        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                RaisePropertyChanged("Price");
            }
        }

        private int _quantity;
        /// <summary>
        /// Transaction quantity
        /// </summary>
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                RaisePropertyChanged("Quantity");
            }
        }
        #endregion

        #region Commands
        /// <summary>
        /// Create transaction command definition
        /// </summary>
        public ICommand CreateTransaction { get; private set; }
        #endregion

        #region Services
        /// <summary>
        /// TransactionService to create Transaction and save it in the Wallet
        /// </summary>
        private ITransactionService _transactionService;
        public ITransactionService TransactionService => _transactionService ?? (_transactionService = IoC.Resolve<ITransactionService>());

        /// <summary>
        /// Valuation Service to get valuation results for current Wallet
        /// </summary>
        private IValuationService _valuationService;
        public IValuationService ValuationService => _valuationService ?? (_valuationService = IoC.Resolve<IValuationService>());

        #endregion

        #region ViewModels
        /// <summary>
        /// Summary View Model to assign Summary Valuation Data
        /// </summary>
        private ISummaryViewModel _summaryVm;
        public ISummaryViewModel SummaryVm => _summaryVm ?? (_summaryVm = IoC.Resolve<ISummaryViewModel>());

        /// <summary>
        /// Transaction View Model to assign Transactions after calculations
        /// </summary>
        private ITransactionsViewModel _transactionsVm;
        public ITransactionsViewModel TransactionsVm => _transactionsVm ?? (_transactionsVm = IoC.Resolve<ITransactionsViewModel>());

        #endregion

        #region Ctor
        public AddTransactionViewModel()
        {
            Quantity = 1;

            CreateTransaction = new RelayCommand(() => 
            {
                PrepareTransaction().Wait();
                RecalculateFund();
            }, CanCreateTransaction);

            StockTypes = Enum.GetValues(typeof(StockType)).Cast<StockType>().Select(x => x.ToString()).ToList();
            SelectedStockType = StockTypes.First();
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Can Create new Transaction only when Quantity and Price are bigger than zero
        /// </summary>
        private bool CanCreateTransaction() => Quantity > 0 && Price > 0;

        /// <summary>
        /// Get task where Transaction vcreation is happened. Assign all recalculated transactions to TransactionsViewModel
        /// </summary>
        private Task PrepareTransaction()
        {
            return Task.Factory.StartNew(() =>
            {
                var stockType = GetConvertedSelectedStockType();
                var stock = StockBase.GetNew(stockType, Price, Quantity);

                TransactionService.CreateTransactionAndAddToWallet(stock);
                var mappedTransactions =
                    TransactionService.GetAllTransactions().Select(TransactionModel.MapFrom);

                Application.Current.Dispatcher.InvokeAsync(() =>
                {
                    TransactionsVm.Transactions = new ObservableCollection<TransactionModel>(mappedTransactions);
                });
                
                Price = 0;
                Quantity = 1;
            });
        }

        /// <summary>
        /// Recalculate Fund and assign calculated data to SummaryVuewModel
        /// </summary>
        private void RecalculateFund()
        {
            Task.Factory.StartNew(() =>
            {
                var valuationResults = ValuationService.ValueWallet();
                if(valuationResults == null)
                {
                    return;
                }

                var summaries =
                    valuationResults.StockSummaryPerStockType.Select(
                        result => SummaryModel.MapFrom(result.Value, result.Key.ToString())).ToList();

                var total = new SummaryModel
                {
                    TotalMarketValue = valuationResults.StockSummaryPerStockType.Sum(x => x.Value.TotalStockValue),
                    TotalNumber = valuationResults.StockSummaryPerStockType.Sum(x => x.Value.TotalNumber),
                    TotalStockWeight = valuationResults.StockSummaryPerStockType.Sum(x => x.Value.TotalStockWeight),
                    TypeName = "All"
                };

                summaries.Add(total);

                Application.Current.Dispatcher.InvokeAsync(() =>
                {
                    SummaryVm.Summaries = new ObservableCollection<SummaryModel>(summaries);
                });
            });
        }

        /// <summary>
        /// Parse String Selected Stock Type to Stock Type Enum
        /// </summary>
        /// <returns></returns>
        private StockType GetConvertedSelectedStockType() =>
            (StockType)Enum.Parse(typeof(StockType), SelectedStockType);
        #endregion
    }
}
