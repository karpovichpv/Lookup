using System;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace Tekla.Technology.Akit.UserScript
{
    public class Script
    {
        public static void Run(Tekla.Technology.Akit.IScript akit)
        {
            var runLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var appLocation = Path.GetFullPath(runLocation + "\\..\\..\\..\\common\\extensions\\Lookup.exe");

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
