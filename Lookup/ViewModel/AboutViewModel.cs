using Lookup.Commands;
using Lookup.ViewModel.Service;
using System;
using System.Diagnostics;

namespace Lookup.ViewModel
{
    public class AboutViewModel : ViewModelBase
    {
        public string Version => AssemblyVersionGetter.GetAssemblyVersionNumber();

        public RelayCommand _runGitHubCommon;
        public RelayCommand RunGitHubCommon
        {
            get
            {
                return _runGitHubCommon
                    ?? (new RelayCommand(
                    obj => RunGitHubCommonLink(),
                    obj => true));
            }
        }

        public RelayCommand _runGitHubLookup;
        public RelayCommand RunGitHubLookup
        {
            get
            {
                return _runGitHubLookup
                    ?? (new RelayCommand(
                    obj => RunGitHubLookupLink(),
                    obj => true));
            }
        }

        private void RunGitHubLookupLink()
        {
            Uri uri = new Uri("https://github.com/karpovichpv/Lookup");
            Process.Start(new ProcessStartInfo(uri.AbsoluteUri));
        }

        private void RunGitHubCommonLink()
        {
            Uri uri = new Uri("https://github.com/karpovichpv");
            Process.Start(new ProcessStartInfo(uri.AbsoluteUri));
        }
    }
}
