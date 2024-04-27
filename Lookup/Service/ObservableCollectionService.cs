// This file is part of Lookup.
// Lookup is free software: you can redistribute it and/or modify it under
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lookup.Service
{
    internal static class ObservableCollectionService
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
        {
            var c = new ObservableCollection<T>();
            try
            {
                foreach (T e in collection)
                    c.Add(e);
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
