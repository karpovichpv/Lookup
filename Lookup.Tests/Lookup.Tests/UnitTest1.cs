using NUnit.Framework;
using NUnit.Framework.Legacy;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;

namespace Lookup.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void GIVEN_TS_is_running_WHEN_try_to_write_DynamicStringProperty_to_an_element_THEN_expect_positive_result()
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
                bool writtingResult = beam.SetDynamicStringProperty("testProperty", "some very long string ");

                ClassicAssert.IsTrue(writtingResult);
                return;
            }

            throw new System.Exception("some problems");
        }
    }
}
