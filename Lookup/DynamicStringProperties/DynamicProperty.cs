using System.ComponentModel;

namespace Lookup.DynamicStringProperties
{
    public class DynamicProperty : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChange(nameof(Name));
            }
        }

        private string _value;
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                RaisePropertyChange(nameof(Value));
            }
        }

        private protected void RaisePropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
