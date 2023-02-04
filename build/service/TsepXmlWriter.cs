using Nuke.Common.ProjectModel;
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
            string xmlPath = GetPathToXmlFile(solution);
            File.Delete(xmlPath);
            StreamWriter writer = new(xmlPath);
            writer.Write(resultedXML);
        }

        private static string GetPathToXmlFile(Solution solution)
        {
            string xmlName = "Lookup.xml";
            string solutionPath = solution.Directory;
            string xmlPath = Path.Combine(solutionPath, $"TSEP\\{xmlName}");
            return xmlPath;
        }

        private static string GetResultedXMLfile(string newVersion, Solution solution)
        {
            string xmlPath = GetPathToXmlFile(solution);
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
