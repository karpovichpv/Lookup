using Lookup.Tests.Service;
using NUnit.Framework;
using Tekla.Structures.Model;

namespace Lookup.TSProperties.DynamicProperties.Service.Tests
{
    [TestFixture]
    public class DynamicPropertyUpdaterTests
    {
        private Beam _tsObject;
        private IProperty _changedProperty;
        private DynamicProperty _notChangedProperty;
        private DynamicProperty _propertyWithDifferentNames;

        [SetUp]
        public void SetUp()
        {
            _changedProperty = new DynamicProperty()
            {
                CurrentName = "test_attribute_1",
                PreviousName = "test_attribute_1",
                CurrentValue = "currentValue",
                PreviousValue = "previousValue",
            };

            _notChangedProperty = new DynamicProperty()
            {
                CurrentName = "test_attribute_1",
                PreviousName = "test_attribute_1",
                CurrentValue = "previousValue",
                PreviousValue = "previousValue",
            };

            _propertyWithDifferentNames = new DynamicProperty()
            {
                CurrentName = "test_attribute_1",
                PreviousName = "test_attribute_2",
                CurrentValue = "previousValue",
                PreviousValue = "previousValue",
            };
        }

        [Test]
        public void GIVEN_valid_beam_and_property_WHEN_update_property_THEN_expect_succeded_update()
        {
            Beam beam = BeamBuilder.Build(BuildType.Insert);
            DynamicPropertyUpdateType settingResult = DynamicPropertyUpdater.Update(_changedProperty, beam);
            Assert.That(settingResult == DynamicPropertyUpdateType.Succeeded);
        }

        [Test]
        public void GIVEN_invalid_beam_and_property_WHEN_update_THEN_expect_failed_update()
        {
            Beam beam = BeamBuilder.Build(BuildType.NotInsert);
            DynamicPropertyUpdateType settingResult = DynamicPropertyUpdater.Update(_changedProperty, beam);
            Assert.That(settingResult == DynamicPropertyUpdateType.Failed);
        }

        [Test]
        public void GIVEN_valid_beam_and_property_with_equals_propeties_WHEN_update_THEN_expect_not_changed_update()
        {
            Beam beam = BeamBuilder.Build(BuildType.NotInsert);
            DynamicPropertyUpdateType settingResult = DynamicPropertyUpdater.Update(_notChangedProperty, beam);
            Assert.That(settingResult == DynamicPropertyUpdateType.DoNotNeedUpdate);
        }

        [Test]
        public void GIVEN_valid_beam_and_property_with_different_names_WHEN_update_THEN_expect_not_changed_update()
        {
            Beam beam = BeamBuilder.Build(BuildType.NotInsert);
            DynamicPropertyUpdateType settingResult = DynamicPropertyUpdater.Update(_propertyWithDifferentNames, beam);
            Assert.That(settingResult == DynamicPropertyUpdateType.PropertyNamesAreDifferent);
        }
    }
}
