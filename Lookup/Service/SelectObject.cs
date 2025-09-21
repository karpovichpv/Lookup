using Lookup.Service;
using System.Collections.Generic;
using Tekla.Structures.Model;
using tsd = Tekla.Structures.Drawing;
using tsdui = Tekla.Structures.Drawing.UI;
using tsm = Tekla.Structures.Model;
using tsmui = Tekla.Structures.Model.UI;

namespace Lookup
{
    internal static class SelectObject
    {
        public static List<TSObject> GetSelectedObjects()
        {
            tsd.DrawingHandler handler = new tsd.DrawingHandler();
            tsd.Drawing drawing = handler.GetActiveDrawing();

            List<TSObject> selectedObjects = new List<TSObject>();

            if (drawing != null)
            {
                tsdui.DrawingObjectSelector objectSelector = handler.GetDrawingObjectSelector();
                tsd.DrawingObjectEnumerator drawingEnumerator = objectSelector.GetSelected();

                if (drawingEnumerator.GetSize() > 0)
                    selectedObjects = ObservableCollectionService.GetObjFromEnumerator(drawingEnumerator).ToTSObjects();
                else
                {
                    TSObject drawingTSObj = new TSObject() { Name = drawing.GetType().Name, Object = drawing };
                    selectedObjects = new List<TSObject> { drawingTSObj };
                }
            }
            else
            {
                tsmui.ModelObjectSelector selector = new tsmui.ModelObjectSelector();
                tsm.ModelObjectEnumerator modelEnumerator = selector.GetSelectedObjects();

                if (modelEnumerator.GetSize() > 0)
                    selectedObjects = ObservableCollectionService.GetObjFromEnumerator(modelEnumerator).ToTSObjects();
                else
                {
                    Model model = new Model();
                    TSObject modelTSObj = new TSObject() { Name = model.GetType().Name, Object = model };
                    selectedObjects = new List<TSObject> { modelTSObj };
                }
            }

            return selectedObjects;
        }
    }
}
