using Lookup.Commands;
using System;
using System.Diagnostics;

namespace Lookup.ViewModel
{
    public class ViewModelAbout : ViewModelBase
    {
        public RelayCommand _runLink;
        public RelayCommand RunLink
        {
            get
            {
                return _runLink
                    ?? (new RelayCommand(
                    obj => RunLinkRequest(),
                    obj => true));
            }
        }

        private void RunLinkRequest()
        {
            Uri uri = new Uri("https://pkbim.blogspot.com/");
            Process.Start(new ProcessStartInfo(uri.AbsoluteUri));
        }
    }
}
