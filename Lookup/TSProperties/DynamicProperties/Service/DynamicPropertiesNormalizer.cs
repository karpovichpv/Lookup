using System.Collections.Generic;
using System.Linq;

namespace Lookup.TSProperties.DynamicProperties
{
    internal static class DynamicPropertiesNormalizer
    {
        public static IEnumerable<IProperty> Normalize(
            this IEnumerable<IProperty> inputCollection)
        {
            List<IProperty> collection = inputCollection.ToList();
            int length = collection
                            .Where(p => string.IsNullOrEmpty(p.CurrentName))
                            .ToArray()
                            .Length;

            bool hasMoreThanTwoEmptyItems = length > 1;

            if (hasMoreThanTwoEmptyItems)
            {
                IProperty targetIndex = collection
                    .Where(p => string.IsNullOrEmpty(p.CurrentName))
                    .FirstOrDefault();
                int index = collection.IndexOf(targetIndex);
                collection.RemoveAt(index);
            }

            bool hasNoEmptyItems = length == 0;
            if (hasNoEmptyItems)
                collection.Add(new DynamicProperty());

            return collection;
        }
    }
}
