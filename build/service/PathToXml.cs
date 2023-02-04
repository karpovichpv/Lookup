using Nuke.Common.ProjectModel;
using System.IO;

namespace service
{
    class PathToXml
    {
        public static string Get(Solution solution)
        {
            string xmlName = "Lookup.xml";
            string solutionPath = solution.Directory;
            string xmlPath = Path.Combine(solutionPath, $"TSEP\\{xmlName}");
            return xmlPath;
        }
    }
}
