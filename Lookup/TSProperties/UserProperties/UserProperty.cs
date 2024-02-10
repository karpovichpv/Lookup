using System.ComponentModel;

namespace Lookup.TSProperties.UserProperties
{
    public class UserProperty : IProperty
    {
        public string CurrentName { get; set; }
        public string Value { get; set; }
        public PropertyType Type { get; set; }
        public string PreviousName { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
