// This file is part of Lookup.
// Lookup is free software: you can redistribute it and/or modify it under
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Lookup
{
    internal class MethodStream
    {
        public static List<Data> Stream(object obj)
        {
            Type type = obj.GetType();

            List<Data> resultData = new List<Data>();
            resultData.Add(new HeaderData("--- Methods ---", ""));

            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(t => !t.IsSpecialName && t.IsSecurityCritical && t.Name != "FromStruct" && t.Name != "ToStruct")
                .ToArray();

            foreach (MethodInfo methodInfo in methods)
            {
                if (methodInfo.DeclaringType.FullName.Contains("Tekla.Structures") &&
                    methodInfo.Name != "Zero") // except method for points - makes points nullable
                    resultData.Add(DataExtensions.Create(methodInfo, obj));
            }

            return resultData;
        }
    }
}
