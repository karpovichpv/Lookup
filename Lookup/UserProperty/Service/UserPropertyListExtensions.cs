using System.Collections;
using System.Collections.Generic;

namespace Lookup
{
    internal static class UserPropertyListExtensions
    {
        public static List<UserPropertyData> ToUserPropertiesList<T, K>(this Dictionary<T, K> dictionary, UserPropertyType type)
        {
            List<UserPropertyData> udaList = new List<UserPropertyData>();
            foreach (KeyValuePair<T, K> entry in dictionary)
            {
                udaList.Add(new UserPropertyData()
                {
                    Name = entry.Key.ToString(),
                    Value = entry.Value.ToString(),
                    Type = type
                });
            }
            return udaList;
        }

        public static List<UserPropertyData> ToUserPropertiesList(
            this IDictionary hashtable)
        {
            var udaList = new List<UserPropertyData>();
            foreach (DictionaryEntry entry in hashtable)
            {
                udaList.Add(new UserPropertyData()
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
