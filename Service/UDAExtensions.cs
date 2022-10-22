using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model;

namespace Lookup
{
    internal static class UDAExtensions
    {
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
