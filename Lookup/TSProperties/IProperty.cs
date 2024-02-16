using System.ComponentModel;

namespace Lookup.TSProperties
{
    public interface IProperty : INotifyPropertyChanged
    {
        string CurrentName { get; set; }
        string PreviousName { get; set; }
        string CurrentValue { get; set; }
        string PreviousValue { get; set; }
        PropertyType Type { get; }
    }
}
