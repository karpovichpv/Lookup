using Lookup.Service;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lookup.TSProperties.DynamicProperties
{
    internal static class DynamicPropertiesFromFileReader
    {
        public static IEnumerable<IProperty> Read(object obj)
        {
            string filePath = DynamicPropertiesFile.GetPath();
            if (!File.Exists(filePath))
                return new List<DynamicProperty>();

            return GetAttributesIfFileExists(filePath, obj);
        }

        private static IEnumerable<IProperty> GetAttributesIfFileExists(
            string filePath, object obj)
        {
            List<DynamicProperty> result = [];

            string[] fileContent = File
                .ReadAllLines(filePath)
                .Distinct()
                .ToArray();

            foreach (string line in fileContent)
            {
                string propertyValueInObject = obj.GetDynamicPropertyResult(line);
                result.Add(new DynamicProperty()
                {
                    CurrentName = line,
                    CurrentValue = propertyValueInObject,
                    PreviousName = line,
                    PreviousValue = propertyValueInObject
                });
            }

            return result
                .Cast<IProperty>()
                .ToItemsObservableCollection()
                .Normalize();
        }
    }
}
