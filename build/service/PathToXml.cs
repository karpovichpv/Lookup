using Nuke.Common.ProjectModel;
using System.IO;

namespace Service
{
    class PathService
    {
        public static string GetXml(Solution solution)
        {
            string xmlName = "Lookup.xml";
            string solutionPath = solution.Directory;
            return Path.Combine(solutionPath, $"TSEP\\{xmlName}");
        }

        public static string GetTSEPFolder(Solution solution)
        {
            string solutionPath = solution.Directory;
            return Path.Combine(solutionPath, $"TSEP\\buildResult\\");
        }
    }
}
