using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model;

namespace Lookup.Service
{
    internal static class UDAExtensions
    {
        public static Hashtable GetAttributeList(object tsObject)
        {
            try
            {
                if (tsObject is ModelObject)
                {
                    ModelObject modelObject = tsObject as ModelObject;

                    Hashtable values = new Hashtable();
                    modelObject.GetAllUserProperties(ref values);

                    return values;
                }
            }
            catch
            {
                return null;    
            }

            return null;
        }
    }
}
