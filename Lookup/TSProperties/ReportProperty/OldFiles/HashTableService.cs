using Lookup.TSProperties.UserProperties;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Lookup.TSProperties.ReportProperty
{
    internal static class HashTableService
    {
        public static List<PropertyValue> ToPropertyValueList(this Hashtable propertyHashtable)
        {
            List<PropertyValue> values = [];
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

        public static IEnumerable<Property> ToPropertyList(this Hashtable propertyHashtable)
        {
            List<Property> values = [];
            foreach (DictionaryEntry entry in propertyHashtable)
                values.Add(
                    new Property()
                    {
                        CurrentName = entry.Key.ToString(),
                        CurrentValue = entry.Value.ToString(),
                        Type = entry.Value.GetType().GetPropertyType()
                    });

            return values;
        }

        private static PropertyType GetPropertyType(this Type type)
        {
            if (type == typeof(string))
                return PropertyType.String;
            if (type == typeof(double))
                return PropertyType.Double;
            if (type == typeof(int))
                return PropertyType.Int;

            return PropertyType.NotSet;
        }
    }
}
