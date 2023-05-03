namespace Lookup.ViewModel
{
    internal class Mediator : IMediator
    {
        private ViewModel _viewModel;
        private readonly UserPropertiesViewModel _userPropertiesModel;

        public Mediator(ViewModel viewModel, UserPropertiesViewModel userPropertiesModel)
        {
            _viewModel = viewModel;
            _userPropertiesModel = userPropertiesModel;
        }

        public void Notify(object recipient, string message)
        {
            if (recipient is UserPropertiesViewModel) { }

        }
    }
}
