using System.ComponentModel;

namespace Lookup.ViewModel
{
    internal class UserPropertiesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Data _selectedData;

        public UserPropertiesViewModel()
        {
            Mediator.GetInstance().SetUserPropertiesModel(this);
        }

        public Data SelectedData
        {
            get
            {
                return _selectedData;
            }
            set
            {
                _selectedData = value;
                RaisePropertyChange("SelectedData");
            }
        }

        private void RaisePropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetSelectedData(Data selectedData) => SelectedData = selectedData;
    }
}