using System.ComponentModel;

namespace Lookup.TSProperties.UserProperties
{
    public class UserProperty : IProperty
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public PropertyType Type { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
