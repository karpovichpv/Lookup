using Lookup.Service;
using Lookup.TSProperties.UserProperties;
using System.Collections.ObjectModel;
using System.Linq;

namespace Lookup.ViewModel.Service
{
    internal static class SortUserPropertyData
    {
        public static ObservableCollection<Property> SortByName(this ObservableCollection<Property> data)
            => data
                .OrderBy(property => property.CurrentName)
                .ToList()
                .ToObservableCollection();

        public static ObservableCollection<Property> SortByValue(this ObservableCollection<Property> data)
            => data
                .OrderBy(property => property.CurrentValue)
                .ToList()
                .ToObservableCollection();

        public static ObservableCollection<Property> SortByType(this ObservableCollection<Property> data)
            => data
                .OrderBy(property => property.Type)
                .ToList()
                .ToObservableCollection();
    }
}
