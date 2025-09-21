using Lookup.TSProperties.UserProperties;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tekla.Structures.Model;

namespace Lookup.TSProperties.ReportProperty
{
    internal class ResultValuesServiceNew
    {
        private readonly ModelObject _modelObj;
        private ArrayList _doubleValues;
        private ArrayList _intValues;
        private ArrayList _stringValues;

        public ResultValuesServiceNew(ModelObject modelObj)
        {
            _modelObj = modelObj;
            IEnumerable<PossiblePropertyQuery> properties
                = PossiblePropetiesNamesSingleton.Get().PossibleProperties;

            SetArrayListsForGettingProperties(properties);
        }

        private void SetArrayListsForGettingProperties(IEnumerable<PossiblePropertyQuery> properties)
        {
            _doubleValues = [];
            _intValues = [];
            _stringValues = [];
            foreach (PossiblePropertyQuery queryString in properties)
            {
                if (queryString.Type == typeof(double))
                    _doubleValues.Add(queryString.QueryString);
                if (queryString.Type == typeof(int))
                    _intValues.Add(queryString.QueryString);
                if (queryString.Type == typeof(string))
                    _stringValues.Add(queryString.QueryString);
            }
        }

        public IEnumerable<Property> Get()
        {
            Hashtable values = new(_doubleValues.Count + _intValues.Count + _stringValues.Count);
            _modelObj.GetAllReportProperties(_stringValues, _doubleValues, _intValues, ref values);
            IEnumerable<Property> listOfProperties = values.ToPropertyList();
            return listOfProperties.OrderBy(t => t.CurrentName).ToList();
        }
    }
}
