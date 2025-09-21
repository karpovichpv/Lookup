using System.Collections;
using System.Collections.Generic;
using Tekla.Structures.Model;

namespace Lookup.Collectors
{
    internal class Collector
    {
        public static List<Data> CollectData(object obj)
        {
            SelectObjectInModel(obj);
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

        private static void SelectObjectInModel(object obj)
        {
            if (obj is ModelObject modelObject)
            {
                ArrayList objectsToSelectInView = [modelObject];

                var modelObjectSelector = new Tekla.Structures.Model.UI.ModelObjectSelector();
                modelObjectSelector.Select(objectsToSelectInView);

                new Model().CommitChanges();
            }
        }
    }
}
