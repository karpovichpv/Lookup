using Nuke.Common.ProjectModel;
using System.IO;
using System.Text.RegularExpressions;

namespace Service
{
    static class TsepXmlWriter
    {
        public static void Write(Solution solution)
        {
            string xmlName = "Lookup.xml";
            string solutionPath = solution.Directory;
            string xmlPath = Path.Combine(solutionPath, $"TSEP\\{xmlName}");

            string file;
            using (StreamReader reader = new StreamReader(xmlPath))
                file = reader.ReadToEnd();

            Regex versionRegex = new Regex("Version");
            string result = versionRegex.Match(file).Value;

        }
    }
}
