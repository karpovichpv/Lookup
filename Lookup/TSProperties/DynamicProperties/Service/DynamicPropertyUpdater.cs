namespace Lookup.TSProperties.DynamicProperties
{
    internal static class DynamicPropertyUpdater
    {
        public static DynamicPropertyUpdateType Update(IProperty prop, object @object)
        {
            if (prop.CurrentName != prop.PreviousName)
                return DynamicPropertyUpdateType.PropertyNamesAreDifferent;

            if (prop.CurrentValue != prop.PreviousValue)
            {
                if (@object.SetDynamicProperty(prop.CurrentName, prop.CurrentValue))
                    return DynamicPropertyUpdateType.Succeeded;

                return DynamicPropertyUpdateType.Failed;
            }

            return DynamicPropertyUpdateType.DoNotNeedUpdate;
        }
    }
}
