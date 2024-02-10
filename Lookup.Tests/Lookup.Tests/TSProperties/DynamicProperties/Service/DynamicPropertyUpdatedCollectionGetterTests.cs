using Lookup.Tests.Service;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Tekla.Structures.Model;

namespace Lookup.TSProperties.DynamicProperties.Service.Tests
{
    [TestFixture]
    public class DynamicPropertyUpdatedCollectionGetterTests
    {
        private const string Name1 = "name_1";
        private const string Name2 = "name_2";
        private const string Name3 = "name_3";
        private const string ChangedName3 = "changed_name_3";
        private const string Value1 = "value_1";
        private const string Value2 = "value_2";
        private const string Value3 = "value_3";
        private const string ValueInObject3 = "value_in_object_3";
        private const string ChangedValue2 = "changed_value_2";
        private const string ChangedValue3 = "changed_value_3";
        private Beam _beam;
        private List<IProperty> _updatedCollection;

        [SetUp]
        public void SetUp()
        {
            _beam = BeamBuilder.Build();
            Dictionary<string, string> mockAttributes = new Dictionary<string, string>()
           {
                {Name1,Value1},
                {Name2,Value2},
                {ChangedName3,ValueInObject3},
           };

            foreach (KeyValuePair<string, string> pair in mockAttributes)
                _beam.SetDynamicStringProperty(pair.Key, pair.Value);

            var collection = new List<DynamicProperty>
           {
               new DynamicProperty()
               {
                   CurrentName = Name1,
                   CurrentValue = Value1,
                   PreviousName = Name1,
                   PreviousValue = Value1,
               },
               new DynamicProperty()
               {
                   CurrentName = Name2,
                   CurrentValue = ChangedValue2,
                   PreviousName = Name2,
                   PreviousValue = Value2,
               },
               new DynamicProperty()
               {
                   CurrentName = ChangedName3,
                   CurrentValue = ChangedValue3,
                   PreviousName = Name3,
                   PreviousValue = Value3,
               },
           }.Cast<IProperty>().ToList();

            _updatedCollection = DynamicPropertyUpdatedCollectionGetter.Get(collection, _beam).ToList();
        }

        [Test]
        public void GIVEN_updated_mock_collection_WHEN_get_first_element_THEN_expect_the_same_items_for_it()
        {
            IProperty property = _updatedCollection[0];
            Assert.That(property.CurrentName == Name1);
            Assert.That(property.CurrentValue == Value1);
            Assert.That(property.PreviousName == Name1);
            Assert.That(property.PreviousValue == Value1);
        }

        [Test]
        public void GIVEN_updated_mock_collection_WHEN_get_second_element_THEN_expect_the_updated_properties()
        {
            IProperty property = _updatedCollection[1];
            Assert.That(property.CurrentName == Name2);
            Assert.That(property.CurrentValue == ChangedValue2);
            Assert.That(property.PreviousName == Name2);
            Assert.That(property.PreviousValue == ChangedValue2);
        }

        [Test]
        public void GIVEN_updated_mock_collection_WHEN_get_third_element_THEN_expect_new_property_query()
        {
            IProperty property = _updatedCollection[2];
            Assert.That(property.CurrentName == ChangedName3);
            Assert.That(property.CurrentValue == ValueInObject3);
            Assert.That(property.PreviousName == ChangedName3);
            Assert.That(property.PreviousValue == ValueInObject3);
        }
    }
}
