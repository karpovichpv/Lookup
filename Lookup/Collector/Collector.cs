﻿using System.Collections.Generic;

namespace Lookup.Collectors
{
    internal class Collector
    {
        public static List<Data> CollectData(object obj)
        {
            List<Data> propertyData = PropertyStream.Stream(obj);
            List<Data> fieldData = FieldStream.Stream(obj);
            List<Data> methodData = MethodStream.Stream(obj);

            List<Data> result = new List<Data>();

            if (fieldData.Count > 1)
                result.AddRange(fieldData);

            if (propertyData.Count > 1)
                result.AddRange(propertyData);

            if (methodData.Count > 1)
                result.AddRange(methodData);

            return result;
        }
    }
}
