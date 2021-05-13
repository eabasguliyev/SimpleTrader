using SimpleTrader.Domain.Services;

namespace SimpleTrader.WPF.ViewModels.Factories
{
    public class MajorIndexListingViewModelFactory:ISimpleTraderViewModelFactory<MajorIndexListingViewModel>
    {
        private IMajorIndexService _majorIndexService;

        public MajorIndexListingViewModelFactory(IMajorIndexService majorIndexService)
        {
            _majorIndexService = majorIndexService;
        }

        public MajorIndexListingViewModel CreateViewModel()
        {
            return MajorIndexListingViewModel.LoadMajorIndexViewModel(_majorIndexService);
        }
    }
}