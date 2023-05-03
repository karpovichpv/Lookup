using Lookup.ViewModel;
using System.Windows;

namespace Lookup
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = ViewModelLocator.ViewModel;
        }
    }
}
