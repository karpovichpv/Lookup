using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lookup.TSProperties.DynamicProperties
{
    internal static class DynamicPropertiesFileWriter
    {
        public static void Write(this IEnumerable<IProperty> properties)
        {
            string filePath = DynamicPropertiesFile.GetPath();

            if (!File.Exists(filePath))
                DynamicPropertiesFile.Create();

            WriteFile(properties, filePath);
        }

        private static void WriteFile(IEnumerable<IProperty> properties, string filePath)
        {
            string[] names = properties.Select(p => p.CurrentName).ToArray();
            string resultString = string.Join("\r\n", names);

            using (var streamWriter = File.CreateText(filePath))
                streamWriter.Write(resultString);
        }
    }
}
