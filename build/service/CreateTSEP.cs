using Nuke.Common.ProjectModel;
using System.Diagnostics;

namespace service
{
    class CreateTSEP
    {
        public static void Create(Solution solution, string newVersion)
        {
            string xmlPath = PathToXml.Get(solution);

            string outputFile = @"C:\other\YandexDisk\WORK\Lookup\TSEP\buildResult\tset.tsep";

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = @"C:\TeklaStructures\2021.0\nt\bin\TeklaExtensionPackage.BatchBuilder.exe",
                    Arguments = $"-i {xmlPath} -o {outputFile} -v {newVersion}",
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
