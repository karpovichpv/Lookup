using System.Collections.Generic;

namespace Lookup.TSProperties.ReportProperty
{
    internal class PossiblePropetiesNamesSingleton
    {
        private static PossiblePropetiesNamesSingleton _instance;

        private PossiblePropetiesNamesSingleton()
        {
            ReadPropertiesFileService service = new();
            PossibleProperties = service.Read();
        }

        public IEnumerable<PossiblePropertyQuery> PossibleProperties { get; set; }

        public static PossiblePropetiesNamesSingleton Get()
        {
            if (_instance == null)
                _instance = new PossiblePropetiesNamesSingleton();

            return _instance;
        }

    }
}