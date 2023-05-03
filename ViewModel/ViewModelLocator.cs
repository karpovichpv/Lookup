namespace Lookup.ViewModel
{
    internal class ViewModelLocator
    {
        private static TeklaObjectGetterService _teklaObjectGetterService = new TeklaObjectGetterService();
        private static ViewModel _viewModel = new ViewModel(_teklaObjectGetterService);
        private static UserPropertiesViewModel _userPropertiesViewModel = new UserPropertiesViewModel();

        public static ViewModel ViewModel => _viewModel;
        public static UserPropertiesViewModel UserPropertiesViewModel => _userPropertiesViewModel;
    }
}
