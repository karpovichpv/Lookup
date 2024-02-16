using Nuke.Common.ProjectModel;
using System.IO;

namespace Service
{
    static class MoveFileToTargetFolder
    {
        public static void Move(Solution solution)
        {
            string dllName = "Lookup.exe";
            string solutionPath = solution.Directory;
            string originPath = Path.Combine(solutionPath, $"Lookup\\bin\\Release\\{dllName}");
            string targetPath = Path.Combine(solutionPath, $"TSEP\\dll\\{dllName}");

            bool isFileExists = File.Exists(targetPath);
            if (isFileExists)
                File.Delete(targetPath);

            File.Move(originPath, targetPath);
        }
    }
}
