﻿using Lookup.Commands;
using Lookup.DynamicStringProperties;
using Lookup.ViewModel.Service;
using System.Collections.Specialized;

namespace Lookup.ViewModel
{
    public class DynamicStringPropertiesViewModel : ViewModelBase
    {
        public DynamicStringPropertiesViewModel()
        {

            Mediator.GetInstance().SetDynamicStringPropertiesModel(this);
            Properties = DynamicPropertiesFileReader.Read();
            _properties.CollectionChanged += ContentCollectionChanged;
        }

        private void ContentCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Properties = Properties.Update();
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

        private ItemsObservableCollection<DynamicProperty> _properties;
        public ItemsObservableCollection<DynamicProperty> Properties
        {
            get
            {
                return _properties;
            }
            set
            {
                _properties = value.Update();
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
                    // Properties = Properties.Update();
                },
                obj => true);
            }
        }
    }
}
