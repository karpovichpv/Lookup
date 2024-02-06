using System;
using System.IO;
using System.Reflection;

namespace Lookup.DynamicStringProperties
{
    public static class DynamicPropertiesFileLocator
    {
        public static string GetPath()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder builder = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(builder.Path);
            string directory = Path.GetDirectoryName(path);
            string filePath = Path.Combine(directory, "DynamicStringProperties.lkp");
            return filePath;
        }
    }
}
