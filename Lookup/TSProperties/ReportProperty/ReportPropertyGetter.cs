using System.Collections.Generic;
using Tekla.Structures.Model;
using tsd = Tekla.Structures.Drawing;

namespace Lookup.TSProperties.UserProperties
{
    internal class ReportPropertyGetter : IPropertyGetter
    {
        public IEnumerable<Property> GetAttributeList(object obj)
        {
            try
            {
                if (obj is ModelObject modelObj)
                    return modelObj.Get();
                if (obj is ProjectInfo projectObj)
                    return projectObj.Get();
                if (obj is tsd.Drawing drawingObj)
                    return drawingObj.Get();
                if (obj is tsd.ModelObject tsdModelObj)
                    return tsdModelObj.Get();
            }
            catch
            { }

            return null;
        }

    }
}
