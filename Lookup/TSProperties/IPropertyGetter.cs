using Lookup.TSProperties.UserProperties;
using System.Collections.Generic;

namespace Lookup.TSProperties
{
    internal interface IPropertyGetter
    {
        IEnumerable<Property> GetAttributeList(object obj);
    }
}
