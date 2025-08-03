using Lookup.TSProperties.ReportProperty;
using System.Collections.Generic;
using Tekla.Structures.Model;

namespace Lookup.TSProperties.UserProperties
{
    internal class ReportPropertyGetter : IPropertyGetter
    {
        public IEnumerable<Property> GetAttributeList(object obj)
        {
            try
            {
                if (obj is ModelObject modelObj)
                {
                    ResultValuesServiceNew service = new ResultValuesServiceNew(modelObj);
                    return service.Get();
                }
            }
            catch
            { }

            return null;
        }

    }
}
