// This file is part of Lookup.
// Lookup is free software: you can redistribute it and/or modify it under
// the terms of the GNU General Public License as published by the
// Free Software Foundation, either version 3 of the License,
// or (at your option) any later version.
//
// Lookup is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty
// of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
// See the GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with Lookup. If not, see <https://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tsm = Tekla.Structures.Model;
using tsmui = Tekla.Structures.Model.UI;
using tsdui = Tekla.Structures.Drawing.UI;
using tsd = Tekla.Structures.Drawing;
using Lookup.Service;

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
                    selectedObjects = CollectionExtensions.GetObjFromEnumerator(drawingEnumerator).ToTSObjects();
            }
            else
            {
                tsmui.ModelObjectSelector selector = new tsmui.ModelObjectSelector();
                tsm.ModelObjectEnumerator modelEnumerator = selector.GetSelectedObjects();

                if (modelEnumerator.GetSize() > 0)
                    selectedObjects = CollectionExtensions.GetObjFromEnumerator(modelEnumerator).ToTSObjects();
            }

            return selectedObjects;
        }
    }
}
