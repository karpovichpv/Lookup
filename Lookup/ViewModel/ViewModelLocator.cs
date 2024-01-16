namespace Lookup.ViewModel
{
    internal class ViewModelLocator
    {
        private static ViewModel _viewModel = new ViewModel();
        private static UserPropertiesViewModel _userPropertiesViewModel = new UserPropertiesViewModel();

        public static ViewModel ViewModel => _viewModel;
        public static UserPropertiesViewModel UserPropertiesViewModel => _userPropertiesViewModel;
    }
}
