using Lookup.ViewModel.Service;

namespace Lookup.TSProperties.DynamicProperties
{
    internal class DynamicPropertiesUpdater(
        ItemsObservableCollection<IProperty> collection,
        TSObject tsObj)
    {
        private readonly ItemsObservableCollection<IProperty> _collection = collection;
        private readonly object _obj = tsObj.Object;

        public void Update()
        {
            foreach (var prop in _collection)
                DynamicPropertyUpdater.Update(prop, _obj);
        }
    }
}
