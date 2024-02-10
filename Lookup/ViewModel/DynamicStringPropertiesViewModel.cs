using Lookup.Commands;
using Lookup.Service;
using Lookup.TSProperties;
using Lookup.TSProperties.DynamicProperties;
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
        }

        private void ContentCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            _properties.CollectionChanged -= ContentCollectionChanged;

            UpdateCollection();

            _properties.CollectionChanged += ContentCollectionChanged;
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
                Properties = DynamicPropertiesFromFileReader
                    .Read(SelectedObject.Object)
                    .Normalize()
                    .ToItemsObservableCollection();

                _properties.CollectionChanged += ContentCollectionChanged;
                RaisePropertyChange(nameof(SelectedObject));
            }
        }

        private ItemsObservableCollection<IProperty> _properties;
        public ItemsObservableCollection<IProperty> Properties
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
                    UpdateCollection();
                },
                obj => true);
            }
        }

        private void UpdateCollection()
        {
            Properties = DynamicPropertyUpdatedCollectionGetter
                .Get(Properties, SelectedObject.Object)
                .Normalize()
                .ToItemsObservableCollection();
        }
    }
}
