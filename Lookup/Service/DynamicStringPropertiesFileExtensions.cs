using Lookup.DynamicStringProperties;
using Lookup.ViewModel.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Lookup.Service
{
    internal class DynamicStringPropertiesFileExtensions
    {
        public static ItemsChangeObservableCollection<DynamicProperty> Read()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder builder = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(builder.Path);
            string directory = Path.GetDirectoryName(path);

            var result = new List<DynamicProperty>() { new DynamicProperty() };
            string filePath = Path.Combine(directory, "DynamicStringProperties.lkp");
            if (!File.Exists(filePath))
                return result.ToItemsObservableCollection();

            string[] fileContent = File.ReadAllLines(filePath);
            foreach (string line in fileContent)
                result.Add(new DynamicProperty() { Name = line });

            return result
                .ToList()
                .ToItemsObservableCollection();
        }
    }
}
