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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lookup.Service
{
    internal static class CollectionExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
        {
            ObservableCollection<T> c = new ObservableCollection<T>();
            try
            {
                foreach (T e in collection)
                {
                    c.Add(e);
                }
            }
            catch { }
            return c;
        }
        public static ObservableCollection<T> AddRange<T>(this ObservableCollection<T> inputCol, ObservableCollection<T> addCol)
        {
            foreach (T obj in addCol)
                inputCol.Add(obj);
            return inputCol;
        }
        public static List<TSObject> ToTSObjects(this List<object> objects)
        {
            List<TSObject> result = new List<TSObject>();
            foreach (object obj in objects)
                result.Add(new TSObject() { Name = obj.GetType().Name, Object = obj });

            return result;
        }
        public static List<object> GetObjFromEnumerator<T>(T enumerator) where T : IEnumerator
        {
            List<object> result = new List<object>();

            while (enumerator.MoveNext())
                result.Add(enumerator.Current);

            if (result.Count == 0)
                return null;

            return result;
        }
        public static List<object> GetObjFromEnumerable<T>(IEnumerable list)
        {
            List<object> result = new List<object>();
            foreach (T obj in list)
                result.Add(obj);

            if (result.Count == 0)
                return null;

            return result;
        }
    }
}
