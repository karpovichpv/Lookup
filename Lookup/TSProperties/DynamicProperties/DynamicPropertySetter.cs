// This file is part of Lookup.
// Lookup is free software: you can redistribute it and/or modify it under
using Tekla.Structures.Model;

namespace Lookup.TSProperties.DynamicProperties
{
    internal static class DynamicPropertySetter
    {
        public static bool SetDynamicProperty(this object obj, string name, string value)
        {
            try
            {
                if (obj is ModelObject modelObj)
                    return modelObj.SetDynamicStringProperty(name, value);
                if (obj is ProjectInfo projectObj)
                    return projectObj.SetDynamicStringProperty(name, value);
            }
            catch
            { }

            return false;
        }
    }
}
