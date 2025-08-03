using Lookup.TSProperties.UserProperties;

namespace Lookup.ViewModel.PropetyViewModels
{
    public class UserPropertyViewModel : PropertyViewModelBase
    {
        public UserPropertyViewModel()
        {
            _getter = new UserPropertyGetter();
            Mediator.GetInstance().SetUserPropertiesModel(this);
        }
    }
}