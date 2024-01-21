using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Lookup.Service
{
    internal class DynamicStringPropertiesFileExtensions
    {
        public static ObservableCollection<string> Read()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder builder = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(builder.Path);
            string directory = Path.GetDirectoryName(path);

            string filePath = Path.Combine(directory, "DynamicStringProperties.lkp");
            if (!File.Exists(filePath))
                return new List<string>().ToObservableCollection();

            string[] fileContent = File.ReadAllLines(filePath);
            return fileContent.ToList().ToObservableCollection();
        }
    }
}
