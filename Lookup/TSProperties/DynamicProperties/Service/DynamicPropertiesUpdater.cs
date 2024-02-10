using Lookup.ViewModel.Service;

namespace Lookup.TSProperties.DynamicProperties
{
    internal class DynamicPropertiesUpdater
    {
        private readonly ItemsObservableCollection<IProperty> _collection;
        private readonly object _obj;

        public DynamicPropertiesUpdater(
            ItemsObservableCollection<IProperty> collection,
            TSObject tsObj)
        {
            _collection = collection;
            _obj = tsObj.Object;
        }

        public void Update()
        {
            foreach (var prop in _collection)
            {
                DynamicPropertyResult propertyInObjectResult
                    = _obj.GetDynamicPropertyResult(prop.CurrentName);

                if (propertyInObjectResult.Exist)
                    UpdateIfPropertyExists(prop, propertyInObjectResult.Value);

                prop.Value = _obj.GetDynamicPropertyResult(prop.CurrentName).Value;
            }
        }

        private void UpdateIfPropertyExists(IProperty prop, string propertyInObject)
        {
            if (propertyInObject != prop.Value)
                _obj.SetDynamicProperty(prop.CurrentName, prop.Value);
        }
    }
}
