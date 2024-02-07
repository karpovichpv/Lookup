using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lookup.DynamicStringProperties
{
    internal static class DynamicPropertiesFileWriter
    {
        public static void Write(this IEnumerable<DynamicProperty> properties)
        {
            string filePath = DynamicPropertiesFile.GetPath();

            if (!File.Exists(filePath))
                DynamicPropertiesFile.Create();

            WriteFile(properties, filePath);
        }

        private static void WriteFile(IEnumerable<DynamicProperty> properties, string filePath)
        {
            string[] names = properties.Select(p => p.Name).ToArray();
            string resultString = string.Join("\r\n", names);

            using (var streamWriter = File.CreateText(filePath))
                streamWriter.Write(resultString);
        }
    }
}
