namespace SimpleTrader.WPF.ViewModels.Factories
{
    public class PortfolioViewModelFactory:ISimpleTraderViewModelFactory<PortfolioViewModel>
    {
        public PortfolioViewModel CreateViewModel()
        {
            return new PortfolioViewModel();
        }
    }
}