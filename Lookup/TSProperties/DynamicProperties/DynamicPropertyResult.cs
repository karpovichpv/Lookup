namespace Lookup.TSProperties.DynamicProperties
{
    public class DynamicPropertyResult
    {
        public DynamicPropertyResult(string value, bool exist)
        {
            Value = value;
            Exist = exist;
        }

        public string Value { get; }
        public bool Exist { get; }
    }
}
