using Lookup.Service;
using Lookup.ViewModel.Service;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lookup.TSProperties.DynamicProperties
{
    internal static class DynamicPropertiesFileReader
    {
        public static ItemsObservableCollection<IProperty> Read(object obj)
        {
            string filePath = DynamicPropertiesFile.GetPath();
            if (!File.Exists(filePath))
                return GetAttributesIfFileDoesNotExist(obj);

            return GetAttributesIfFileExists(filePath, obj);
        }

        private static ItemsObservableCollection<IProperty> GetAttributesIfFileDoesNotExist(object obj)
        {
            List<DynamicProperty> result = new List<DynamicProperty>
            {
                new DynamicProperty()
            };
            List<IProperty> interfaceList = result.Cast<IProperty>().ToList();
            return interfaceList.ToItemsObservableCollection();
        }

        private static ItemsObservableCollection<IProperty> GetAttributesIfFileExists(
            string filePath, object obj)
        {
            List<DynamicProperty> result = new List<DynamicProperty>();

            string[] fileContent = File.ReadAllLines(filePath);

            foreach (string line in fileContent)
                result.Add(new DynamicProperty()
                {
                    CurrentName = line,
                    CurrentValue = obj.GetDynamicPropertyResult(line).Value
                });

            return result
                .Cast<IProperty>()
                .ToItemsObservableCollection()
                .Normalize();
        }
    }
}
