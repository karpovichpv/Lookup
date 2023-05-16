using Lookup.Collectors;
using Lookup.Service;
using System.Collections.Generic;
using System.Linq;

namespace Lookup.ViewModel.Service
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
            TSObject selectedObject = GetSelectedObject();
            ViewModel subViewModel = GetViewModel();

            MainWindow window = new MainWindow();
            window.DataContext = subViewModel;
            window.Show();

            Mediator.GetInstance().Notify(selectedObject);
        }

        private ViewModel GetViewModel()
        {
            List<object> objects = _selectedData.WalkDown(_currentObject);
            ViewModel subViewModel = new ViewModel();
            subViewModel.CurrentObject = objects.FirstOrDefault();
            subViewModel.Objects = objects.ToTSObjects()
                                          .ToObservableCollection();
            subViewModel.Data = Collector.CollectData(objects.FirstOrDefault())
                                         .ToObservableCollection();
            return subViewModel;
        }

        private TSObject GetSelectedObject()
        {
            List<object> objects = _selectedData.WalkDown(_currentObject);
            return objects.ToTSObjects().FirstOrDefault();
        }

        public static bool CanRunNewInstance(object obj, Data selectedData)
        {
            if (selectedData.CanGet) return true;
            return false;
        }
    }
}
