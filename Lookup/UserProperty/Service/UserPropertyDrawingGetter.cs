using System.Collections.Generic;
using tsd = Tekla.Structures.Drawing;

namespace Lookup.UserProperty
{
    internal static class UserPropertyDrawingGetter
    {
        public static List<UserPropertyData> Get(
            this tsd.Drawing drawing)
        {
            drawing.GetDoubleUserProperties(out Dictionary<string, double> doubleValuesDictionary);
            drawing.GetStringUserProperties(out Dictionary<string, string> stringValuesDictionary);

            List<UserPropertyData> udaDataList = new List<UserPropertyData>();
            udaDataList.AddRange(doubleValuesDictionary.ToUserPropertiesList(UserPropertyType.Double));
            udaDataList.AddRange(stringValuesDictionary.ToUserPropertiesList(UserPropertyType.String));
            return udaDataList;
        }
    }
}
