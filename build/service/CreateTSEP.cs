using Nuke.Common.ProjectModel;
using System.Diagnostics;
using System.IO;

namespace Service
{
    class CreateTSEP
    {
        public static void Create(Solution solution, string newVersion)
        {
            string xmlPath = PathService.GetXml(solution);
            string outputFile = PathService.GetTSEPFolder(solution);
            RunBuildProcess(newVersion, xmlPath, outputFile);
        }

        private static void RunBuildProcess(string newVersion, string xmlPath, string outputFile)
        {
            string targetFile = Path.Combine(outputFile, $"Lookup_{newVersion}.tsep");
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = @"C:\TeklaStructures\2021.0\nt\bin\TeklaExtensionPackage.BatchBuilder.exe",
                    Arguments = $"-i {xmlPath} -o {targetFile} -v {newVersion}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            process.Start();
            process.WaitForExit();
        }
    }
}
