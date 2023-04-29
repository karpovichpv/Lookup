// This file is part of Lookup.
// Lookup is free software: you can redistribute it and/or modify it under
// the terms of the GNU General Public License as published by the
// Free Software Foundation, either version 3 of the License,
// or (at your option) any later version.
//
// Lookup is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty
// of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
// See the GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with Lookup. If not, see <https://www.gnu.org/licenses/>.

using Lookup.Commands;
using Lookup.ReportProperty;
using Lookup.Service;
using Lookup.ViewModel.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using tsm = Tekla.Structures.Model;

namespace Lookup.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        public object CurrentObject;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Version
        {
            get
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                string resName = "Lookup.Resources.BuildDate.txt";

                string result;
                using (Stream stream = assembly.GetManifestResourceStream(resName))
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadLine().Replace("\r\n", string.Empty);
                }

                return "Lookup v." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(4) + " (build from " + result + ")";
            }
        }

        #region RelayCommand
        public RelayCommand snoopSelectedObject;
        public RelayCommand SnoopSelectedObject
        {
            get
            {
                return snoopSelectedObject ?? (snoopSelectedObject = new RelayCommand(obj =>
                {
                    //CurrentObject = SelectedObject.Object;
                    Data = Collector.Collector.CollectData(SelectedObject.Object).ToObservableCollection();
                    UDAObjects = UserPropertyExtensions.GetAttributeList(SelectedObject.Object).ToObservableCollection();
                },
                obj =>
                {
                    return Objects != null;
                }));
            }
        }

        private RelayCommand runNewWindow;
        public RelayCommand RunNewWindow
        {
            get
            {
                return runNewWindow ??
                    (runNewWindow = new RelayCommand(obj => RunNewInstance(obj), obj => CanRunNewInstance(obj)));
            }
        }

        private RelayCommand getSelectedObjectsFromModel;
        public RelayCommand GetSelectedObjectsFromModel
        {
            get
            {
                return getSelectedObjectsFromModel ??
                    (getSelectedObjectsFromModel = new RelayCommand(obj =>
                    {
                        Objects = SelectObject.GetSelectedObjects().ToObservableCollection();
                        CurrentObject = Objects.FirstOrDefault().Object;
                        Data = Collector.Collector.CollectData(CurrentObject).ToObservableCollection();
                        UDAObjects = UserPropertyExtensions.GetAttributeList(CurrentObject).ToObservableCollection();
                    },
                    obj => new tsm.Model().GetConnectionStatus()));
            }
        }

        private RelayCommand windowLoad;
        public RelayCommand WindowLoad
        {
            get
            {
                return windowLoad ??
                    (windowLoad = new RelayCommand(obj =>
                    {
                        if (CurrentObject == null || Objects == null)
                        {

                            Objects = SelectObject.GetSelectedObjects().ToObservableCollection();
                            CurrentObject = Objects.FirstOrDefault().Object;

                            //var service = new ResultValuesService(CurrentObject as tsm.ModelObject);
                            //PropertyData = service.Get().ToObservableCollection();

                            Data = Collector.Collector.CollectData(CurrentObject).ToObservableCollection();
                            UDAObjects = UserPropertyExtensions.GetAttributeList(CurrentObject).ToObservableCollection();
                        }
                    },
                    obj => new tsm.Model().GetConnectionStatus()));
            }
        }
        #endregion

        #region MVVM view properties
        private Data _selectedData;
        public Data SelectedData
        {
            get
            {
                return _selectedData;
            }
            set
            {
                _selectedData = value;
                RaisePropertyChange("SelectedData");
            }
        }

        private ObservableCollection<Data> _data;
        public ObservableCollection<Data> Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
                RaisePropertyChange("Data");
            }
        }

        private ObservableCollection<PropertyValue> _propertyData;
        public ObservableCollection<PropertyValue> PropertyData
        {
            get
            {
                return _propertyData;
            }
            set
            {
                _propertyData = value;
                RaisePropertyChange("PropertyData");
            }
        }

        private TSObject _selectedObject;
        public TSObject SelectedObject
        {
            get
            {
                return _selectedObject;
            }
            set
            {
                _selectedObject = value;
                RaisePropertyChange("SelectedObject");
            }
        }

        private ObservableCollection<TSObject> _objects;
        public ObservableCollection<TSObject> Objects
        {
            get
            {
                return _objects;
            }
            set
            {
                _objects = value;
                RaisePropertyChange("Objects");
            }
        }

        private ObservableCollection<UserPropertyData> _udaObjects;
        public ObservableCollection<UserPropertyData> UDAObjects
        {
            get => _udaObjects;
            set
            {
                _udaObjects = value.SortByName();
                RaisePropertyChange("UDAObjects");
            }
        }
        #endregion

        public ViewModel()
        {
        }

        #region RelayCommand methods
        private void RunNewInstance(object obj)
        {
            ViewModel subViewModel = new ViewModel();
            List<object> objects = SelectedData.WalkDown(CurrentObject);
            subViewModel.CurrentObject = objects.FirstOrDefault();
            subViewModel.Objects = objects.ToTSObjects().ToObservableCollection();
            subViewModel.Data = Collector.Collector.CollectData(subViewModel.Objects.FirstOrDefault().Object).ToObservableCollection();
            subViewModel.UDAObjects = UserPropertyExtensions.GetAttributeList(objects.FirstOrDefault()).ToObservableCollection();
            MainWindow window = new MainWindow();
            window.DataContext = subViewModel;
            window.Show();
        }
        private bool CanRunNewInstance(object obj)
        {
            if (SelectedData.CanGet) return true;

            return false;
        }
        #endregion

        private void RaisePropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
