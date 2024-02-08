using System.ComponentModel;

namespace Lookup.TSProperties
{
    public interface IProperty : INotifyPropertyChanged
    {
        string Name { get; set; }
        string Value { get; set; }
        PropertyType Type { get; }
    }
}
