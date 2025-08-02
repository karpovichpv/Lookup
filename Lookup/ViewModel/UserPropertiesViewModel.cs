using Lookup.Service;
using Lookup.TSProperties.UserProperties;
using Lookup.ViewModel.Service;
using System.Collections.ObjectModel;

namespace Lookup.ViewModel
{
    public class UserPropertiesViewModel : ViewModelBase
    {
        public UserPropertiesViewModel()
        {
            Mediator.GetInstance().SetUserPropertiesModel(this);
        }

        private TSObject _selectedData;
        public TSObject SelectedObject
        {
            get
            {
                return _selectedData;
            }
            set
            {
                _selectedData = value;
                UDAObjects = UserPropertyGetter.GetAttributeList(value.Object).ToObservableCollection();
                RaisePropertyChange(nameof(SelectedObject));
            }
        }

        private ObservableCollection<UserProperty> _udaObjects;

        public ObservableCollection<UserProperty> UDAObjects
        {
            get => _udaObjects;
            set
            {
                _udaObjects = value.SortByName();
                RaisePropertyChange(nameof(UDAObjects));
            }
        }

        public void SetSelectedObject(TSObject selectedObject)
            => SelectedObject = selectedObject;
    }
}