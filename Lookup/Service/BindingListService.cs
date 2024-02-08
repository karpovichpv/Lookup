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

using Lookup.ViewModel.Service;
using System.Collections.Generic;
using System.ComponentModel;

namespace Lookup.Service
{
    internal static class ItemsChangeObservableCollectionSevice
    {
        public static ItemsObservableCollection<T> ToItemsObservableCollection<T>(
            this IEnumerable<T> collection)
            where T : INotifyPropertyChanged

        {
            var c = new ItemsObservableCollection<T>();
            try
            {
                foreach (T e in collection)
                    c.Add(e);
            }
            catch { }
            return c;
        }

        public static BindingList<T> AddRange<T>(this BindingList<T> inputCol, BindingList<T> addCol)
        {
            foreach (T obj in addCol)
                inputCol.Add(obj);
            return inputCol;
        }
    }
}
