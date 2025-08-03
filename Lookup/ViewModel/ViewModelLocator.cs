using Lookup.ViewModel.PropetyViewModels;

namespace Lookup.ViewModel
{
    internal class ViewModelLocator
    {
        private static readonly ViewModel _viewModel = new ViewModel();
        private static readonly UserPropertyViewModel _userPropertiesViewModel = new UserPropertyViewModel();
        private static readonly DynamicStringPropertiesViewModel _dynamicStringPropertiesViewModel
            = new DynamicStringPropertiesViewModel();

        public static ViewModel ViewModel => _viewModel;
        public static UserPropertyViewModel UserPropertiesViewModel => _userPropertiesViewModel;
        public static DynamicStringPropertiesViewModel DynamicStringPropertiesViewModel
            => _dynamicStringPropertiesViewModel;
    }
}
