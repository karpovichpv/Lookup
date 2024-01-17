using System.Collections;
using System.Collections.Generic;
using Tekla.Structures.Model;

namespace Lookup
{
    internal static class UserPropertyProjectGetter
    {
        public static List<UserPropertyData> Get(this ProjectInfo projectInfo)
        {
            Hashtable stringPropertiesHashTable = new Hashtable();
            projectInfo.GetStringUserProperties(ref stringPropertiesHashTable);
            Hashtable doublePropertiesHashTable = new Hashtable();
            projectInfo.GetDoubleUserProperties(ref doublePropertiesHashTable);
            Hashtable intPropertiesHashTable = new Hashtable();
            projectInfo.GetIntegerUserProperties(ref intPropertiesHashTable);

            List<UserPropertyData> udaDataList = stringPropertiesHashTable.ToUserPropertiesList();
            udaDataList.AddRange(doublePropertiesHashTable.ToUserPropertiesList());
            udaDataList.AddRange(intPropertiesHashTable.ToUserPropertiesList());
            return udaDataList;
        }
    }
}
