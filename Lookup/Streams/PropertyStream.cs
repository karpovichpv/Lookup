// This file is part of Lookup.
// Lookup is free software: you can redistribute it and/or modify it under
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Lookup
{
    internal class PropertyStream
    {
        public static List<Data> Stream(object obj)
        {
            Type type = obj.GetType();

            List<Data> resultData = new List<Data>();

            resultData.Add(new HeaderData("--- Properties ---", "") { });
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.FlattenHierarchy | BindingFlags.SetProperty | BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (PropertyInfo property in properties)
                resultData.Add(DataExtensions.Create(property, obj));

            return resultData;
        }
    }
}
