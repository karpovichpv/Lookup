using System;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;

namespace Tekla.Technology.Akit.UserScript
{
    public class Script
    {
        public static void Run(Tekla.Technology.Akit.IScript akit)
        {
            string xsBinPath = System.Environment.GetEnvironmentVariable("XS_MACRO_DIRECTORY");
            if (!string.IsNullOrEmpty(xsBinPath))
            {
                string[] macroPaths = xsBinPath.Split(';');
                string commonMacro = macroPaths.Where(p => p.Contains("common")).ToList().FirstOrDefault().Replace(@"\\",@"\");
                string pathToCommonFolder = Path.Combine(commonMacro, @"..\extensions\Lookup\Lookup.exe");
                StartApplication(pathToCommonFolder);
            }
            else
            {
                var appLocation = Path.Combine(xsBinPath,"\\..\\","extensions\\Lookup\\Lookup.exe");
                StartApplication(appLocation);
            }
        }

        private static void StartApplication(string appLocation)
        {
            if (File.Exists(appLocation))
            {
                Process process = new Process();
                process.EnableRaisingEvents = false;
                process.StartInfo.FileName = appLocation;
                process.Start();
                process.Close();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("It's impossible to start " + appLocation);
            }
        }
    }
}
