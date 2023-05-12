using Lookup.Service;
using System.Collections.Generic;
using System.Linq;

namespace Lookup.ViewModel
{
    internal class NewInstanceRunner
    {
        private readonly Data _selectedData;
        private readonly object _currentObject;

        public NewInstanceRunner(Data selectedData, object currentObject)
        {
            _selectedData = selectedData;
            _currentObject = currentObject;
        }

        public void RunNewInstance(object obj)
        {
            ViewModel subViewModel = new ViewModel();
            List<object> objects = _selectedData.WalkDown(_currentObject);
            subViewModel.CurrentObject = objects.FirstOrDefault();
            subViewModel.Objects = objects.ToTSObjects().ToObservableCollection();
            TSObject selectedObject = subViewModel.Objects.FirstOrDefault();
            subViewModel.Data = Collector.Collector.CollectData(selectedObject.Object).ToObservableCollection();
            MainWindow window = new MainWindow();
            window.DataContext = subViewModel;
            window.Show();
            Mediator.GetInstance().Notify(selectedObject);
        }

        public static bool CanRunNewInstance(object obj, Data selectedData)
        {
            if (selectedData.CanGet) return true;

            return false;
        }
    }
}
