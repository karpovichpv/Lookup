using Lookup.Service;
using Lookup.ViewModel.Service;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Lookup.ViewModel
{
    internal class UserPropertiesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


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
                UDAObjects = UserPropertyExtensions.GetAttributeList(value.Object).ToObservableCollection();
                RaisePropertyChange("SelectedData");
            }
        }

        private ObservableCollection<UserPropertyData> _udaObjects;

        public ObservableCollection<UserPropertyData> UDAObjects
        {
            get => _udaObjects;
            set
            {
                _udaObjects = value.SortByName();
                RaisePropertyChange("UDAObjects");
            }
        }

        private void RaisePropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetSelectedObject(TSObject selectedObject) => SelectedObject = selectedObject;
    }
}