using Lookup.ViewModel.PropetyViewModels;

namespace Lookup.ViewModel
{
    internal class ViewModelLocator
    {
        private static readonly ViewModel _viewModel = new ViewModel();
        private static readonly PropertyViewModelBase _userPropertiesViewModel = new UserPropertyViewModel();
        private static readonly PropertyViewModelBase _reportPropertiesViewModel = new ReportPropertyViewModel();
        private static readonly DynamicStringPropertiesViewModel _dynamicStringPropertiesViewModel
            = new DynamicStringPropertiesViewModel();

        public static ViewModel ViewModel => _viewModel;
        public static PropertyViewModelBase UserPropertiesViewModel => _userPropertiesViewModel;
        public static PropertyViewModelBase ReportPropertiesViewModel => _reportPropertiesViewModel;
        public static DynamicStringPropertiesViewModel DynamicStringPropertiesViewModel
            => _dynamicStringPropertiesViewModel;
    }
}
