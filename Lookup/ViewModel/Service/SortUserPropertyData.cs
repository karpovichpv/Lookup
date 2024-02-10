using Lookup.Service;
using Lookup.TSProperties.UserProperties;
using System.Collections.ObjectModel;
using System.Linq;

namespace Lookup.ViewModel.Service
{
    internal static class SortUserPropertyData
    {
        public static ObservableCollection<UserProperty> SortByName(this ObservableCollection<UserProperty> data)
            => data
                .OrderBy(property => property.CurrentName)
                .ToList()
                .ToObservableCollection();

        public static ObservableCollection<UserProperty> SortByValue(this ObservableCollection<UserProperty> data)
            => data
                .OrderBy(property => property.CurrentValue)
                .ToList()
                .ToObservableCollection();

        public static ObservableCollection<UserProperty> SortByType(this ObservableCollection<UserProperty> data)
            => data
                .OrderBy(property => property.Type)
                .ToList()
                .ToObservableCollection();
    }
}
