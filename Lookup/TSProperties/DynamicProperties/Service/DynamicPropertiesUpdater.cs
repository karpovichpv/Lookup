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
                DynamicPropertyUpdater.Update(prop, _obj);
        }
    }
}
