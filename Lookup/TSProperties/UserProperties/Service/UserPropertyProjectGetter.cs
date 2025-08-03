using System.Collections;
using System.Collections.Generic;
using Tekla.Structures.Model;

namespace Lookup.TSProperties.UserProperties
{
    internal static class UserPropertyProjectGetter
    {
        public static List<Property> Get(this ProjectInfo projectInfo)
        {
            Hashtable stringPropertiesHashTable = new Hashtable();
            projectInfo.GetStringUserProperties(ref stringPropertiesHashTable);
            Hashtable doublePropertiesHashTable = new Hashtable();
            projectInfo.GetDoubleUserProperties(ref doublePropertiesHashTable);
            Hashtable intPropertiesHashTable = new Hashtable();
            projectInfo.GetIntegerUserProperties(ref intPropertiesHashTable);

            List<Property> udaDataList = stringPropertiesHashTable.ToUserPropertiesList();
            udaDataList.AddRange(doublePropertiesHashTable.ToUserPropertiesList());
            udaDataList.AddRange(intPropertiesHashTable.ToUserPropertiesList());
            return udaDataList;
        }
    }
}
