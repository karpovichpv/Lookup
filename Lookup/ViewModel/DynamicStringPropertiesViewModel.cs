using Lookup.Service;
using System.Collections.ObjectModel;

namespace Lookup.ViewModel
{
    public class DynamicStringPropertiesViewModel : ViewModelBase
    {
        public DynamicStringPropertiesViewModel()
        {

            Mediator.GetInstance().SetDynamicStringPropertiesModel(this);
            Properties = DynamicStringPropertiesFileExtensions.Read();
        }

        private TSObject _selectedObject;

        public TSObject SelectedObject
        {
            get
            {
                return _selectedObject;
            }
            set
            {
                _selectedObject = value;
                RaisePropertyChange(nameof(SelectedObject));
            }
        }

        private ObservableCollection<string> _properties;
        public ObservableCollection<string> Properties
        {
            get
            {
                return _properties;
            }
            set
            {
                _properties = value;
                RaisePropertyChange(nameof(Properties));
            }
        }

        public void SetSelectedObject(TSObject selectedObject)
            => SelectedObject = selectedObject;
    }
}
