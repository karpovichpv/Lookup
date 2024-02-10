using Lookup.Commands;
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
                Properties = DynamicPropertiesFileReader.Read(SelectedObject.Object);
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
            new DynamicPropertiesUpdater(Properties, SelectedObject).Update();
            NormalizeProperties();
        }

        private void NormalizeProperties()
        {
            ItemsObservableCollection<IProperty> normalizedCollection
                = Properties.Normalize();
            normalizedCollection.Write();
            Properties = normalizedCollection;
        }
    }
}
