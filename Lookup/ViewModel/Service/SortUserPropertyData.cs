using Lookup.Service;
using System.Collections.ObjectModel;
using System.Linq;

namespace Lookup.ViewModel.Service
{
    internal static class SortUserPropertyData
    {
        public static ObservableCollection<UserPropertyData> SortByName(this ObservableCollection<UserPropertyData> data)
            => data
                .OrderBy(property => property.Name)
                .ToList()
                .ToObservableCollection();

        public static ObservableCollection<UserPropertyData> SortByValue(this ObservableCollection<UserPropertyData> data)
            => data
                .OrderBy(property => property.Value)
                .ToList()
                .ToObservableCollection();

        public static ObservableCollection<UserPropertyData> SortByType(this ObservableCollection<UserPropertyData> data)
            => data
                .OrderBy(property => property.Type)
                .ToList()
                .ToObservableCollection();
    }
}
