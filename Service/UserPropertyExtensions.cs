// This file is part of Lookup.
// Lookup is free software: you can redistribute it and/or modify it under
// the terms of the GNU General Public License as published by the
// Free Software Foundation, either version 3 of the License,
// or (at your option) any later version.
//
// Lookup is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty
// of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
// See the GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with Lookup. If not, see <https://www.gnu.org/licenses/>.


using System.Collections;
using System.Collections.Generic;
using Tekla.Structures.Model;
using tsd = Tekla.Structures.Drawing;

namespace Lookup
{
    // Class provides a possibility to get and modify user defined attributes
    internal static class UserPropertyExtensions
    {
        // Getting attributes from model
        public static List<UserPropertyData> GetAttributeList(object teklaObject)
        {
            try
            {
                if (teklaObject is ModelObject)
                    return GetUserPropertiesFromModelObject(teklaObject);
                else if (teklaObject is ProjectInfo)
                    return GetProjectInfoProperties(teklaObject);
                else if (teklaObject is tsd.Drawing)
                    return GetUserPropertiesFromDrawing(teklaObject);
            }
            catch
            {
            }

            return null;
        }

        private static List<UserPropertyData> GetUserPropertiesFromModelObject(object teklaObject)
        {
            ModelObject modelObject = teklaObject as ModelObject;

            Hashtable propertyHashtable = new Hashtable();
            modelObject.GetAllUserProperties(ref propertyHashtable);

            return propertyHashtable.HashtableToUserPopertiesList();
        }

        private static List<UserPropertyData> GetUserPropertiesFromDrawing(object teklaObject)
        {
            tsd.Drawing drawing = teklaObject as tsd.Drawing;
            Dictionary<string, double> doubleValuesDictionary = new Dictionary<string, double>();
            drawing.GetDoubleUserProperties(out doubleValuesDictionary);

            Dictionary<string, string> stringValuesDictionary = new Dictionary<string, string>();
            drawing.GetStringUserProperties(out stringValuesDictionary);

            List<UserPropertyData> udaDataList = new List<UserPropertyData>();
            udaDataList.AddRange(DictionaryToUserPropertiesList(doubleValuesDictionary));
            udaDataList.AddRange(stringValuesDictionary.DictionaryToUserPropertiesList());
            return udaDataList;
        }

        private static List<UserPropertyData> GetProjectInfoProperties(object teklaObject)
        {
            ProjectInfo projectInfo = teklaObject as ProjectInfo;

            Hashtable stringPropertiesHashTable = new Hashtable();
            projectInfo.GetStringUserProperties(ref stringPropertiesHashTable);
            Hashtable doublePropertiesHashTable = new Hashtable();
            projectInfo.GetDoubleUserProperties(ref doublePropertiesHashTable);
            Hashtable intPropertiesHashTable = new Hashtable();
            projectInfo.GetIntegerUserProperties(ref intPropertiesHashTable);

            List<UserPropertyData> udaDataList = stringPropertiesHashTable.HashtableToUserPopertiesList();
            udaDataList.AddRange(doublePropertiesHashTable.HashtableToUserPopertiesList());
            udaDataList.AddRange(intPropertiesHashTable.HashtableToUserPopertiesList());
            return udaDataList;
        }

        private static List<UserPropertyData> HashtableToUserPopertiesList(this IDictionary hashtable)
        {
            List<UserPropertyData> udaList = new List<UserPropertyData>();
            foreach (DictionaryEntry entry in hashtable)
            {
                udaList.Add(new UserPropertyData()
                {
                    Name = entry.Key.ToString(),
                    Value = entry.Value.ToString(),
                    Type = entry.Value.GetType().Name
                });
            }
            return udaList;
        }

        private static List<UserPropertyData> DictionaryToUserPropertiesList<T, K>(this Dictionary<T, K> dictionary)
        {
            List<UserPropertyData> udaList = new List<UserPropertyData>();
            foreach (KeyValuePair<T, K> entry in dictionary)
            {
                udaList.Add(new UserPropertyData()
                {
                    Name = entry.Key.ToString(),
                    Value = entry.Value.ToString(),
                    Type = entry.Value.GetType().Name
                });
            }
            return udaList;
        }
    }
}
