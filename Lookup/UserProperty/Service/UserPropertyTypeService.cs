using System.Collections;

namespace Lookup
{
    internal static class UserPropertyTypeService
    {
        public static UserPropertyType GetUserPropertyType(this DictionaryEntry entry)
        {
            if (entry.Value is string)
                return UserPropertyType.String;
            if (entry.Value is double)
                return UserPropertyType.Double;
            if (entry.Value is int)
                return UserPropertyType.Int;

            return UserPropertyType.NotSet;
        }
    }
}
