namespace Lookup.TSProperties
{
    internal interface IProperty
    {
        string Name { get; set; }
        string Value { get; set; }
        PropertyType Type { get; }
    }
}
