using NUnit.Framework;
using System.Collections;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

namespace Lookup.Tests.Sandbox
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Test()
        {
            Picker picker = new Picker();
            ModelObject modelObject = picker.PickObject(Picker.PickObjectEnum.PICK_ONE_OBJECT, "Pick any object");
            ArrayList sNames = new ArrayList()
            {
                "NAME",
            };

            ArrayList dNames = new ArrayList()
            {
                "LENGTH",
                "SUPPLEMENT_PART_WEIGHT"
            };

            ArrayList iNames = new ArrayList()
            {
                "DATE"
            };
            Hashtable values = new Hashtable(sNames.Count + dNames.Count + iNames.Count);
            modelObject.GetAllReportProperties(sNames, dNames, iNames, ref values);
        }
    }
}
