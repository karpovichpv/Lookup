using Lookup.Service;
using Lookup.TSProperties;
using Lookup.TSProperties.UserProperties;
using Lookup.ViewModel.Service;
using System.Collections.ObjectModel;

namespace Lookup.ViewModel.PropetyViewModels
{
    public abstract class PropertyViewModelBase : ViewModelBase
    {

        private protected IPropertyGetter _getter;


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
                PropertyObjects = _getter.GetAttributeList(value.Object).ToObservableCollection();
                RaisePropertyChange(nameof(SelectedObject));
            }
        }

        private ObservableCollection<Property> _udaObjects;

        public ObservableCollection<Property> PropertyObjects
        {
            get => _udaObjects;
            set
            {
                _udaObjects = value.SortByName();
                RaisePropertyChange(nameof(PropertyObjects));
            }
        }

        public void SetSelectedObject(TSObject selectedObject)
            => SelectedObject = selectedObject;
    }
}