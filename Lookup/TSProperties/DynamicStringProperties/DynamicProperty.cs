using System.ComponentModel;

namespace Lookup.TSProperties.DynamicProperties
{
    public class DynamicProperty : INotifyPropertyChanged, IProperty
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name = string.Empty;
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

        public PropertyType Type => PropertyType.String;

        private protected void RaisePropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
