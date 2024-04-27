// This file is part of Lookup.
// Lookup is free software: you can redistribute it and/or modify it under
using Tekla.Structures.Model;

namespace Lookup.TSProperties.DynamicProperties
{
    public static class DynamicPropertyGetter
    {
        public static string GetDynamicPropertyResult(this object obj, string propertyName)
        {
            if (obj is ModelObject modelObj)
                return modelObj.GetForModelObject(propertyName);
            if (obj is ProjectInfo projectObj)
                return projectObj.GetForProjectObject(propertyName);

            return string.Empty;
        }

        private static string GetForModelObject(
            this ModelObject obj,
            string propertyName)
        {
            string result = string.Empty;
            _ = obj.GetDynamicStringProperty(propertyName, ref result);
            return result;
        }

        private static string GetForProjectObject(
            this ProjectInfo obj,
            string propertyName)
        {
            string result = string.Empty;
            _ = obj.GetDynamicStringProperty(propertyName, ref result);
            return result;
        }

    }
}
