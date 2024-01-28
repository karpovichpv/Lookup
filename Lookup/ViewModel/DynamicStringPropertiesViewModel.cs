using Lookup.Commands;
using Lookup.DynamicStringProperties;
using Lookup.Service;
using Lookup.ViewModel.Service;
using System;
using System.Collections.Specialized;

namespace Lookup.ViewModel
{
    public class DynamicStringPropertiesViewModel : ViewModelBase
    {
        public DynamicStringPropertiesViewModel()
        {

            Mediator.GetInstance().SetDynamicStringPropertiesModel(this);
            Properties = DynamicStringPropertiesFileExtensions.Read();
            _properties.CollectionChanged += ContentCollectionChanged;
        }

        private void ContentCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("SomeAction");
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

        private ItemsChangeObservableCollection<DynamicProperty> _properties;
        public ItemsChangeObservableCollection<DynamicProperty> Properties
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

        public RelayCommand UpdateDynamicStringPropertyFile
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Console.WriteLine("Update file");
                },
                obj => true);
            }
        }
    }
}
