using System.Collections;
using System.Collections.Generic;

namespace Lookup.TSProperties.UserProperties
{
    internal static class UserPropertyListExtensions
    {
        public static List<Property> ToUserPropertiesList<T, K>(this Dictionary<T, K> dictionary, PropertyType type)
        {
            List<Property> udaList = new List<Property>();
            foreach (KeyValuePair<T, K> entry in dictionary)
            {
                udaList.Add(new Property()
                {
                    CurrentName = entry.Key.ToString(),
                    CurrentValue = entry.Value.ToString(),
                    Type = type
                });
            }
            return udaList;
        }

        public static List<Property> ToUserPropertiesList(
            this IDictionary hashtable)
        {
            var udaList = new List<Property>();
            foreach (DictionaryEntry entry in hashtable)
            {
                udaList.Add(new Property()
                {
                    CurrentName = entry.Key.ToString(),
                    CurrentValue = entry.Value.ToString(),
                    Type = entry.GetUserPropertyType()
                });
            }
            return udaList;
        }
    }
}
