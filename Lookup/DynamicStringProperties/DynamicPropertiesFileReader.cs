using Lookup.Service;
using Lookup.ViewModel.Service;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lookup.DynamicStringProperties
{
    internal static class DynamicPropertiesFileReader
    {
        public static ItemsObservableCollection<DynamicProperty> Read()
        {
            string filePath = DynamicPropertiesFileLocator.GetPath();
            var result = new List<DynamicProperty>();
            if (!File.Exists(filePath))
                return GetAttributesIfFileDoesNotExist(result);

            return GetAttributesIfFileExists(result, filePath);
        }

        private static ItemsObservableCollection<DynamicProperty> GetAttributesIfFileDoesNotExist(
            List<DynamicProperty> result)
        {
            result.Add(new DynamicProperty());
            return result.ToItemsObservableCollection();
        }

        private static ItemsObservableCollection<DynamicProperty> GetAttributesIfFileExists(
            List<DynamicProperty> result, string filePath)
        {
            string[] fileContent = File.ReadAllLines(filePath);
            foreach (string line in fileContent)
                result.Add(new DynamicProperty() { Name = line });

            result.Add(new DynamicProperty());
            return result
                .ToList()
                .ToItemsObservableCollection();
        }
    }
}
