using Tekla.Structures.Model;

namespace Lookup.TSProperties.DynamicProperties.Service
{
    internal static class DynamicPropertiesObjectChecker
    {
        public static bool CheckIfPossibleGet(this TSObject obj)
        {
            if (obj?.Object is ModelObject or ProjectInfo)
                return true;

            return false;
        }
    }
}
