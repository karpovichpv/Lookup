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


using Lookup.UserProperty;
using System.Collections.Generic;
using Tekla.Structures.Model;
using tsd = Tekla.Structures.Drawing;

namespace Lookup
{
    internal static class UserPropertyGetter
    {
        public static List<UserPropertyData> GetAttributeList(object obj)
        {
            try
            {
                if (obj is ModelObject modelObj)
                    return modelObj.Get();
                if (obj is ProjectInfo projectObj)
                    return projectObj.Get();
                if (obj is tsd.Drawing drawingObj)
                    return drawingObj.Get();
                if (obj is tsd.ModelObject tsdModelObj)
                    return tsdModelObj.Get();
            }
            catch
            {
            }

            return null;
        }

    }
}
