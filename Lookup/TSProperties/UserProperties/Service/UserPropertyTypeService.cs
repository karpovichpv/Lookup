using System.Collections;

namespace Lookup.TSProperties.UserProperties
{
    internal static class UserPropertyTypeService
    {
        public static PropertyType GetUserPropertyType(this DictionaryEntry entry)
        {
            if (entry.Value is string)
                return PropertyType.String;
            if (entry.Value is double)
                return PropertyType.Double;
            if (entry.Value is int)
                return PropertyType.Int;

            return PropertyType.NotSet;
        }
    }
}
