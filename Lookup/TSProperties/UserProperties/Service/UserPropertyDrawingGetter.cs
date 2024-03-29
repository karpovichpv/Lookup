﻿using System.Collections.Generic;
using tsd = Tekla.Structures.Drawing;

namespace Lookup.TSProperties.UserProperties
{
    internal static class UserPropertyDrawingGetter
    {
        public static List<UserProperty> Get(
            this tsd.Drawing drawing)
        {
            drawing.GetDoubleUserProperties(out Dictionary<string, double> doubleValuesDictionary);
            drawing.GetStringUserProperties(out Dictionary<string, string> stringValuesDictionary);

            List<UserProperty> udaDataList = new List<UserProperty>();
            udaDataList.AddRange(doubleValuesDictionary.ToUserPropertiesList(PropertyType.Double));
            udaDataList.AddRange(stringValuesDictionary.ToUserPropertiesList(PropertyType.String));
            return udaDataList;
        }
    }
}
