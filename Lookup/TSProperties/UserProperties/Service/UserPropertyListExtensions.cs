using System.Collections;
using System.Collections.Generic;

namespace Lookup.TSProperties.UserProperties
{
    internal static class UserPropertyListExtensions
    {
        public static List<UserProperty> ToUserPropertiesList<T, K>(this Dictionary<T, K> dictionary, PropertyType type)
        {
            List<UserProperty> udaList = new List<UserProperty>();
            foreach (KeyValuePair<T, K> entry in dictionary)
            {
                udaList.Add(new UserProperty()
                {
                    Name = entry.Key.ToString(),
                    Value = entry.Value.ToString(),
                    Type = type
                });
            }
            return udaList;
        }

        public static List<UserProperty> ToUserPropertiesList(
            this IDictionary hashtable)
        {
            var udaList = new List<UserProperty>();
            foreach (DictionaryEntry entry in hashtable)
            {
                udaList.Add(new UserProperty()
                {
                    Name = entry.Key.ToString(),
                    Value = entry.Value.ToString(),
                    Type = entry.GetUserPropertyType()
                });
            }
            return udaList;
        }
    }
}
