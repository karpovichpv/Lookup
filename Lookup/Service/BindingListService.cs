// This file is part of Lookup.
// Lookup is free software: you can redistribute it and/or modify it under
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
