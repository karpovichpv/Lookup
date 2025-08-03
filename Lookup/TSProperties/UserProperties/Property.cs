using System.ComponentModel;

namespace Lookup.TSProperties.UserProperties
{
    public class Property : IProperty
    {
        public string CurrentName { get; set; }
        public string CurrentValue { get; set; }
        public PropertyType Type { get; set; }
        public string PreviousName { get; set; }
        public string PreviousValue { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
