using System.Collections.Generic;
using System.Linq;

namespace Lookup.TSProperties.DynamicProperties
{
    internal static class DynamicPropertyUpdatedCollectionGetter
    {
        public static IEnumerable<IProperty> Get(this IEnumerable<IProperty> collection, object @object)
        {
            var result = new List<DynamicProperty>();

            foreach (var prop in collection)
                result.Add(UpdateSingleProperty(prop, @object));

            return result.Cast<IProperty>();
        }

        private static DynamicProperty UpdateSingleProperty(IProperty prop, object @object)
        {
            if (prop.CurrentName == prop.PreviousName)
                DynamicPropertyUpdater.Update(prop, @object);

            string valueInObject = DynamicPropertyGetter
                                .GetDynamicPropertyResult(@object, prop.CurrentName)
                                .Value;

            return new DynamicProperty
            {
                CurrentName = prop.CurrentName,
                PreviousName = prop.CurrentName,
                CurrentValue = valueInObject,
                PreviousValue = valueInObject
            };
        }
    }
}
