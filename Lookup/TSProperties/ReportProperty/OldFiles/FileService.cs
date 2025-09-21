using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Lookup.TSProperties.ReportProperty
{
    internal class FileService
    {
        public static IEnumerable<string> Read()
        {
            IEnumerable<string> filesContents = ReadFileFromProgramsFolder();
            IEnumerable<string> rows = GetDataRows(filesContents);
            return rows;
        }

        public static IEnumerable<string> ReadFileFromProgramsFolder()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var uri = new UriBuilder(assembly.CodeBase);
            string applictionPath = Uri.UnescapeDataString(uri.Path);
            string folderPath = Path.GetDirectoryName(applictionPath);

            string[] lstFiles = Directory.GetFiles(folderPath, "*.lst", SearchOption.TopDirectoryOnly);

            var result = new List<string>();
            if (lstFiles.Length != 0)
            {
                try
                {

                    foreach (string filePath in lstFiles)
                    {
                        using (var reader = new StreamReader(filePath))
                        {
                            string content = reader.ReadToEnd();
                            if (!string.IsNullOrEmpty(content))
                            {
                                result.Add(content);
                            }
                        }
                    }
                }
                catch
                {
                }
            }

            return result;
        }

        public static IEnumerable<string> GetDataRows(IEnumerable<string> filesContent)
        {
            var result = new List<string>();
            foreach (string content in filesContent)
            {
                string[] splittedContent = content.Split(["\r\n"], StringSplitOptions.RemoveEmptyEntries)
                        .Where(r => !r.StartsWith("//"))
                        .ToArray();
                result.AddRange(splittedContent);
            }

            return result;
        }
    }
}
