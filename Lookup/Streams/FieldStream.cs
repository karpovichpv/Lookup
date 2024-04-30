// This file is part of Lookup.
// Lookup is free software: you can redistribute it and/or modify it under
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Lookup
{
    internal class FieldStream
    {
        public static List<Data> Stream(object obj)
        {
            Type type = obj.GetType();

            List<Data> resultData = new List<Data>();

            resultData.Add(new HeaderData("--- Fields ---", "") { });
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.FlattenHierarchy | BindingFlags.SetProperty | BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (FieldInfo field in fields)
                if (!field.Name.Contains("BackingField"))
                    resultData.Add(DataExtensions.Create(field, obj));

            return resultData;
        }
    }
}
