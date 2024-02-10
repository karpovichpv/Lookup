using System.ComponentModel;

namespace Lookup.TSProperties.DynamicProperties
{
    public class DynamicProperty : INotifyPropertyChanged, IProperty
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name = string.Empty;
        public string CurrentName
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChange(nameof(CurrentName));
            }
        }

        private string _value;
        public string CurrentValue
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                RaisePropertyChange(nameof(CurrentValue));
            }
        }

        public PropertyType Type => PropertyType.String;
        public string PreviousName { get; set; }
        public string PreviousValue { get; set; }

        private protected void RaisePropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
