using System.IO;
using System.Reflection;

namespace Lookup.ViewModel.Service
{
    internal class AssemblyVersionGetter
    {
        public static string GetVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resName = "Lookup.Resources.BuildDate.txt";

            string result;
            using (Stream stream = assembly.GetManifestResourceStream(resName))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadLine().Replace("\r\n", string.Empty);
            }

            return "Lookup v." + Assembly.GetExecutingAssembly().GetName().Version.ToString(4)
                + " (build from " + result + ")";
        }
    }
}
