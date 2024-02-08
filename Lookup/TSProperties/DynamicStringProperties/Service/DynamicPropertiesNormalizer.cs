using Lookup.Service;
using Lookup.ViewModel.Service;
using System.Collections.Generic;
using System.Linq;

namespace Lookup.TSProperties.DynamicProperties
{
    internal static class DynamicPropertiesNormalizer
    {
        public static ItemsObservableCollection<IProperty> Normalize(
            this ItemsObservableCollection<IProperty> inputCollection)
        {
            List<IProperty> collection = inputCollection.ToList();
            int length = collection
                            .Where(p => string.IsNullOrEmpty(p.Name))
                            .ToArray()
                            .Length;

            bool hasMoreThanTwoEmptyItems = length > 1;

            if (hasMoreThanTwoEmptyItems)
            {
                var dd = collection.Where(p => string.IsNullOrEmpty(p.Name))
                    .ToList().FirstOrDefault();
                int index = collection.IndexOf(dd);
                collection.RemoveAt(index);
            }

            bool hasNoEmptyItems = length == 0;
            if (hasNoEmptyItems)
                collection.Add(new DynamicProperty());

            return collection.ToItemsObservableCollection();
        }
    }
}
