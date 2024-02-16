using System.Collections;
using System.Collections.Generic;

namespace Lookup.TSProperties.ReportProperty
{
    internal static class HashTableService
    {
        public static List<PropertyValue> ToPropertyList(this Hashtable propertyHashtable)
        {
            List<PropertyValue> values = new List<PropertyValue>();
            foreach (DictionaryEntry entry in propertyHashtable)
                values.Add(
                    new PropertyValue()
                    {
                        Name = entry.Key.ToString(),
                        Value = entry.Value.ToString(),
                        Type = entry.Value.GetType().ToString()
                    });

            return values;
        }
    }
}
