using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.ViewModels;
using System.Windows.Input;
using SimpleTrader.WPF.Models;
using SimpleTrader.WPF.ViewModels.Factories;

namespace SimpleTrader.WPF.State.Navigators
{
    public class Navigator : ObservableObject, INavigator
    {
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand UpdateCurrentViewModelCommand { get; set; }


        public Navigator(ISimpleTraderViewModelAbstractFactory viewModelFactory)
        {
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(this, viewModelFactory);
        }
    }
}
