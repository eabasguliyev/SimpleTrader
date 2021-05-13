using SimpleTrader.WPF.State.Navigators;

namespace SimpleTrader.WPF.ViewModels.Factories
{
    public interface ISimpleTraderViewModelAbstractFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}