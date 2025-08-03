using Lookup.ViewModel.PropetyViewModels;

namespace Lookup.ViewModel
{
    internal class Mediator : IMediator
    {
        private static Mediator _instance;

        private ViewModel _viewModel;
        private PropertyViewModelBase _userPropertiesModel;
        private PropertyViewModelBase _reportPropertiesModel;
        private DynamicStringPropertiesViewModel _dynamicStringPropertiesModel;

        private Mediator()
        { }

        public static Mediator GetInstance()
        {
            _instance ??= new Mediator();
            return _instance;
        }

        public void SetViewModel(ViewModel viewModel)
            => _viewModel = viewModel;

        public void SetUserPropertiesModel(PropertyViewModelBase viewModel)
            => _userPropertiesModel = viewModel;

        public void SetReportPropertiesModel(PropertyViewModelBase viewModel)
            => _reportPropertiesModel = viewModel;

        public void SetDynamicStringPropertiesModel(DynamicStringPropertiesViewModel viewModel)
            => _dynamicStringPropertiesModel = viewModel;

        public void Notify(TSObject tsObject)
        {
            _userPropertiesModel.SetSelectedObject(tsObject);
            _reportPropertiesModel.SetSelectedObject(tsObject);
            _dynamicStringPropertiesModel.SetSelectedObject(tsObject);
        }
    }
}
