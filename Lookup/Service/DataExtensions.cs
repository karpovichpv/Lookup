﻿// This file is part of Lookup.
// Lookup is free software: you can redistribute it and/or modify it under
using System;
using System.Reflection;

namespace Lookup
{
    internal static class DataExtensions
    {
        public static Data Create(MemberInfo info, object obj)
        {
            try
            {
                if (info is PropertyInfo)
                    return GetData(info, ((PropertyInfo)info).GetValue(obj));
                else /*(info is FieldInfo)*/
                    return GetData(info, ((FieldInfo)info).GetValue(obj));
            }
            catch (Exception ex)
            {
                return new StringData($"{info.Name}", ex.Message);
            }
        }

        public static Data Create(MethodInfo info, object obj)
        {
            try
            {
                string value = "";
                ParameterInfo[] parameters = info.GetParameters();
                Type returnType = info.ReturnType;

                if (parameters.Length == 0 && (returnType == typeof(string) || returnType == typeof(double) || returnType == typeof(int)))
                {
                    return new StringData(info.Name, $"{info.Invoke(obj, parameters)}");
                }

                else if (parameters.Length == 0 && returnType != typeof(bool))
                {
                    object down = info.Invoke(obj, parameters);
                    if (down != null)
                        value = down.ToString();
                    else
                        value = "null";

                    return new MethodData(info.Name, down);
                }

                return new StringData(info.Name, $"return: {info.ReturnType}");
            }
            catch (Exception ex)
            {
                return new StringData("exception", ex.ToString());
            }
        }

        private static Data GetData(MemberInfo info, object value)
        {
            try
            {
                if (value == null)
                {
                    return new StringData(info.Name, "null");
                }
                else if (value is Enum || value is int)
                {
                    return new StringData(info.Name, value.ToString());
                }
                else if (value.GetType() == typeof(Tekla.Structures.Geometry3d.Point) || value.GetType() == typeof(Tekla.Structures.Geometry3d.Vector))
                {
                    double x = Convert.ToDouble(value.GetType().GetField("X").GetValue(value));
                    double y = Convert.ToDouble(value.GetType().GetField("Y").GetValue(value));
                    double z = Convert.ToDouble(value.GetType().GetField("Z").GetValue(value));
                    return new StringData(info.Name, $"X:{x}; Y:{y}; Z:{z}");
                }
                else
                {
                    return new PropertyData(info.Name, value);
                }
            }
            catch (Exception ex)
            {
                return new StringData("exception", ex.ToString());
            }
        }
    }
}
