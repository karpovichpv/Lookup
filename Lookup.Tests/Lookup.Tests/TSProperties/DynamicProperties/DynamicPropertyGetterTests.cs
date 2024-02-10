using Lookup.TSProperties.DynamicProperties;
using NUnit.Framework;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;

namespace Lookup.Tests
{
    [TestFixture]
    public class DynamicPropertyGetterTests
    {
        [Test]
        public void GIVEN_TS_is_running_and_property_is_set_WHEN_get_property_THEN_expect_that_equal_value()
        {
            var model = new Model();
            bool status = model.GetConnectionStatus();

            Beam beam = new Beam();
            beam.Profile.ProfileString = "D20";
            beam.Material.MaterialString = "Steel_Undefined";
            beam.StartPoint = new Point(0, 0, 0);
            beam.EndPoint = new Point(1000, 0, 0);
            bool creationResult = beam.Insert();

            if (creationResult)
            {
                const string AttributeName = "testProperty";
                const string AttributeValue = "some very long string";
                bool writtingResult = beam
                    .SetDynamicStringProperty(AttributeName, AttributeValue);

                DynamicPropertyResult gettingResult = DynamicPropertyGetter.GetDynamicPropertyResult(beam, AttributeName);

                Assert.That(gettingResult.Exist);
                Assert.That(gettingResult.Value == AttributeValue);

                beam.Delete();
                return;
            }

            throw new System.Exception("some problems");
        }

        [Test]
        public void GIVEN_TS_is_running_and_property_is_Not_set_WHEN_get_property_THEN_expect_that_it_Doesnot_exist()
        {
            var model = new Model();
            bool status = model.GetConnectionStatus();

            Beam beam = new Beam();
            beam.Profile.ProfileString = "D20";
            beam.Material.MaterialString = "Steel_Undefined";
            beam.StartPoint = new Point(0, 0, 0);
            beam.EndPoint = new Point(1000, 0, 0);
            bool creationResult = beam.Insert();

            if (creationResult)
            {
                const string AttributeName = "testProperty2";

                DynamicPropertyResult gettingResult = DynamicPropertyGetter.GetDynamicPropertyResult(beam, AttributeName);

                Assert.That(!gettingResult.Exist);

                beam.Delete();
                return;
            }

            throw new System.Exception("some problems");
        }
    }
}
