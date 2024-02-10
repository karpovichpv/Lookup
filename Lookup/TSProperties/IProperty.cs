using System.ComponentModel;

namespace Lookup.TSProperties
{
    public interface IProperty : INotifyPropertyChanged
    {
        string CurrentName { get; set; }
        string PreviousName { get; set; }
        string Value { get; set; }
        PropertyType Type { get; }
    }
}
