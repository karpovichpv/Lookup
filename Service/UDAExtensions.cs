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


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model;

namespace Lookup
{
    // Class provides a possibility to get and modify user defined attributes
    internal static class UDAExtensions
    {
        // Getting attributes from model
        public static List<UDAData> GetAttributeList(object tsObject)
        {
            try
            {
                if (tsObject is ModelObject)
                {
                    ModelObject modelObject = tsObject as ModelObject;

                    Hashtable values = new Hashtable();
                    modelObject.GetAllUserProperties(ref values);

                    return values.ToUDAList();
                }
            }
            catch
            {
            }

            return null;
        }

        // Method converts a hashtable to the internal list of the UDAData
        private static List<UDAData> ToUDAList(this Hashtable hashtable)
        {
            List<UDAData> udaList = new List<UDAData>();
            try
            {

                foreach (DictionaryEntry entry in hashtable)
                {
                    udaList.Add(new UDAData()
                    {
                        Name = entry.Key.ToString(),
                        Value = entry.Value.ToString(),
                        Type = entry.Value.GetType().Name
                    });
                }
            }
            catch
            {
            }

            return udaList;
        }
    }
}
