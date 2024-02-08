using Lookup.Service;
using System.Collections;
using System.Collections.Generic;
using Tekla.Structures.Model;
using tsd = Tekla.Structures.Drawing;

namespace Lookup.TSProperties.UserProperties
{
    internal static class UserPropertyModelObjectGetter
    {
        public static List<UserProperty> Get(this ModelObject obj)
        {
            Hashtable propertyHashtable = new Hashtable();
            obj.GetAllUserProperties(ref propertyHashtable);

            return propertyHashtable.ToUserPropertiesList();
        }

        public static List<UserProperty> Get(this tsd.ModelObject obj)
        {
            ModelObject modelObject = ModelObjectByDrawingObjectSelector.GetModelObject(obj);
            return modelObject.Get();
        }
    }
}
