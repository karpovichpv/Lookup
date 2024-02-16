using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Lookup.TSProperties.ReportProperty
{
    internal class FileService
    {
        public static string[] Read(string fileName)
        {
            string file = FileService.ReadFileFromProgramsFolder(fileName);
            string[] rows = GetDataRows(file);
            return rows;
        }

        public static string ReadFileFromProgramsFolder(string fileName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            UriBuilder uri = new UriBuilder(assembly.CodeBase);
            string applictionPath = Uri.UnescapeDataString(uri.Path);
            string folderPath = Path.GetDirectoryName(applictionPath);
            string filePath = Path.Combine(folderPath, fileName);

            string file;
            using (StreamReader reader = new StreamReader(filePath))
                file = reader.ReadToEnd();
            return file;
        }

        public static string[] GetDataRows(string file)
            => file.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Where(r => !r.StartsWith("//"))
                .ToArray();
    }
}
