using Nuke.Common.ProjectModel;
using service;
using System.IO;
using System.Text.RegularExpressions;

namespace Service
{
    static class TsepXmlWriter
    {
        public static void Write(Solution solution, string newVersion)
        {
            string resultedXML = GetResultedXMLfile(newVersion, solution);
            WriteXmlFileWithNewVersion(resultedXML, solution);
        }

        private static void WriteXmlFileWithNewVersion(string resultedXML, Solution solution)
        {
            string xmlPath = PathToXml.Get(solution);
            File.Delete(xmlPath);
            using (StreamWriter writer = new(xmlPath))
                writer.Write(resultedXML);
        }

        private static string GetResultedXMLfile(string newVersion, Solution solution)
        {
            string xmlPath = PathToXml.Get(solution);
            string file;
            using (StreamReader reader = new(xmlPath))
                file = reader.ReadToEnd();

            Regex versionRegex = new(
              @"(?x) # multirow mode
                (?<=Version="") # before
                {1,2}\d\.{1,2}\d # target
                (?=""\sLanguage) # after
                ");

            return versionRegex.Replace(file, newVersion);
        }
    }
}
