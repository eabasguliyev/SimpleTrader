using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.WPF.ViewModels
{
    public class MajorIndexListingViewModel:ViewModelBase
    {
        private readonly IMajorIndexService _majorIndexService;
        private MajorIndex _dowJones;
        private MajorIndex _nasdaq;
        private MajorIndex _sp500;

        public MajorIndex DowJones
        {
            get => _dowJones;
            set
            {
                _dowJones = value;
                OnPropertyChanged();
            }
        }

        public MajorIndex Nasdaq
        {
            get => _nasdaq;
            set
            {
                _nasdaq = value;
                OnPropertyChanged();
            }
        }

        public MajorIndex SP500
        {
            get => _sp500;
            set
            {
                _sp500 = value;
                OnPropertyChanged();
            }
        }


        public MajorIndexListingViewModel(IMajorIndexService majorIndexService)
        {
            _majorIndexService = majorIndexService;
        }

        public static MajorIndexListingViewModel LoadMajorIndexViewModel(IMajorIndexService majorIndexService)
        {
            MajorIndexListingViewModel majorIndexViewModel = new MajorIndexListingViewModel(majorIndexService);

            majorIndexViewModel.LoadMajorIndexes();

            return majorIndexViewModel;
        }

        private void LoadMajorIndexes()
        {
            _majorIndexService.GetMajorIndex(MajorIndexType.DowJones).ContinueWith(task =>
            {
                if (task.Exception == null)
                    DowJones = task.Result;
            });
            _majorIndexService.GetMajorIndex(MajorIndexType.Nasdaq).ContinueWith(task =>
            {
                if (task.Exception == null)
                    Nasdaq = task.Result;
            });
            _majorIndexService.GetMajorIndex(MajorIndexType.SP500).ContinueWith(task =>
            {
                if (task.Exception == null)
                    SP500 = task.Result;
            });
        }
    }
}