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

using Lookup.Collectors;
using Lookup.Commands;
using Lookup.ReportProperty;
using Lookup.Service;
using Lookup.ViewModel.Service;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using tsm = Tekla.Structures.Model;

namespace Lookup.ViewModel
{
    public class ViewModel : ViewModelBase
    {
        public object CurrentObject { get; set; }

        public string Version => Service.AssemblyVersionGetter.GetVersion();

        #region RelayCommand
        public RelayCommand _snoopSelectedObject;
        public RelayCommand SnoopSelectedObject
        {
            get
            {
                return _snoopSelectedObject
                    ?? (_snoopSelectedObject = new RelayCommand(
                    obj => Data = Collector.CollectData(SelectedObject.Object).ToObservableCollection(),
                    obj => Objects != null));
            }
        }

        private RelayCommand _runNewWindow;
        public RelayCommand RunNewWindow
        {
            get
            {
                return _runNewWindow
                    ?? (_runNewWindow = new RelayCommand(
                        obj => new NewInstanceRunner(SelectedData, CurrentObject).RunNewInstance(obj),
                        obj => NewInstanceRunner.CanRunNewInstance(obj, SelectedData)
                        )
                    );
            }
        }

        private RelayCommand _getSelectedObjectsFromModel;
        public RelayCommand GetSelectedObjectsFromModel
        {
            get
            {
                return _getSelectedObjectsFromModel ??
                    (_getSelectedObjectsFromModel = new RelayCommand(
                        obj => GetSelectedObjects(),
                        obj => new tsm.Model().GetConnectionStatus())
                    );
            }
        }

        private RelayCommand _showAbout;
        public RelayCommand ShowAbout
        {
            get
            {
                return _showAbout ??
                    (_getSelectedObjectsFromModel = new RelayCommand(
                        obj => MessageBox.Show("some text"),
                        obj => true)
                    ); ;
            }
        }

        private RelayCommand _windowLoad;
        public RelayCommand WindowLoad
        {
            get
            {
                return _windowLoad ??
                    (_windowLoad = new RelayCommand(
                        obj => GetSelectedObjects(),
                        obj => CanGetSelectedObjects())
                    );
            }
        }

        private bool CanGetSelectedObjects()
        {
            bool hasConnection = new tsm.Model().GetConnectionStatus();
            bool isObjectsNull = CurrentObject == null || Objects == null;
            if (isObjectsNull && hasConnection)
                return true;
            return false;
        }

        private void GetSelectedObjects()
        {
            Objects = SelectObject.GetSelectedObjects()
                                  .ToObservableCollection();
            TSObject selectedObject = Objects.FirstOrDefault();
            CurrentObject = selectedObject.Object;
            Mediator.GetInstance().Notify(selectedObject);

            Data = Collector.CollectData(CurrentObject)
                            .ToObservableCollection();
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
                Mediator.GetInstance().Notify(value);
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
        #endregion

        public ViewModel() => Mediator.GetInstance().SetViewModel(this);
    }
}
