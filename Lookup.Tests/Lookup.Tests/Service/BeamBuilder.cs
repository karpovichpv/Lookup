using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;

namespace Lookup.Tests.Service
{
    internal class BeamBuilder
    {
        public static Beam Build(BuildType type = BuildType.NotSet)
        {
            var model = new Model();
            bool status = model.GetConnectionStatus();

            Beam beam = new Beam();
            beam.Profile.ProfileString = "D20";
            beam.Material.MaterialString = "Steel_Undefined";
            beam.StartPoint = new Point(0, 0, 0);
            beam.EndPoint = new Point(1000, 0, 0);

            if (type == BuildType.NotInsert)
                return beam;

            if (beam.Insert())
                return beam;

            throw new System.Exception("Mock beam wasn't created");
        }
    }
}