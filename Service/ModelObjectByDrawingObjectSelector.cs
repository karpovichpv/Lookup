using Tekla.Structures;
using Tekla.Structures.Model;

namespace Lookup.Service
{
    internal class ModelObjectByDrawingObjectSelector
    {
        public static ModelObject GetModelObject(Tekla.Structures.Drawing.ModelObject drawingModelObject)
        {
            Identifier identifier = drawingModelObject.ModelIdentifier;
            return new Model().SelectModelObject(identifier);
        }
    }
}
