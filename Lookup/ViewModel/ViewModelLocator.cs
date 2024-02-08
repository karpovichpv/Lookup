namespace Lookup.ViewModel
{
    internal class ViewModelLocator
    {
        private static readonly ViewModel _viewModel = new ViewModel();
        private static readonly UserPropertiesViewModel _userPropertiesViewModel = new UserPropertiesViewModel();
        private static readonly DynamicStringPropertiesViewModel _dynamicStringPropertiesViewModel
            = new DynamicStringPropertiesViewModel();

        public static ViewModel ViewModel => _viewModel;
        public static UserPropertiesViewModel UserPropertiesViewModel => _userPropertiesViewModel;
        public static DynamicStringPropertiesViewModel DynamicStringPropertiesViewModel
            => _dynamicStringPropertiesViewModel;
    }
}
