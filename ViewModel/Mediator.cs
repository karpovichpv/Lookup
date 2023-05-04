namespace Lookup.ViewModel
{
    internal class Mediator : IMediator
    {
        private static Mediator _instance;

        private ViewModel _viewModel;
        private UserPropertiesViewModel _userPropertiesModel;

        private Mediator()
        {
        }

        public static Mediator GetInstance()
        {
            if (_instance == null)
                _instance = new Mediator();
            return _instance;
        }

        public void SetViewModel(ViewModel viewModel) => _viewModel = viewModel;
        public void SetUserPropertiesModel(UserPropertiesViewModel viewModel) => _userPropertiesModel = viewModel;

        public void Notify(TSObject tsObject) => _userPropertiesModel.SetSelectedObject(tsObject);
    }
}
