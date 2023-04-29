using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tekla.Structures.Model;

namespace Lookup.ReportProperty
{
    internal class ResultValuesService
    {
        private readonly ModelObject _modelObj;
        private ArrayList _doubleValues;
        private ArrayList _intValues;
        private ArrayList _stringValues;

        public ResultValuesService(ModelObject modelObj)
        {
            _modelObj = modelObj;
            List<PossiblePropertyQuery> properties = new ReadPropertiesFileService().Read();

            SetArrayListsForGettingProperties(properties);
        }

        private void SetArrayListsForGettingProperties(List<PossiblePropertyQuery> properties)
        {
            _doubleValues = new ArrayList();
            _intValues = new ArrayList();
            _stringValues = new ArrayList();
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

        public List<PropertyValue> Get()
        {
            Hashtable values = new Hashtable(_doubleValues.Count + _intValues.Count + _stringValues.Count);
            _modelObj.GetAllReportProperties(_stringValues, _doubleValues, _intValues, ref values);
            List<PropertyValue> listOfProperties = values.ToPropertyList();
            return listOfProperties.OrderBy(t => t.Name).ToList();
        }
    }
}
