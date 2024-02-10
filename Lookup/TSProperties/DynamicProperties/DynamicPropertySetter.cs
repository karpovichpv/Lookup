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


using Tekla.Structures.Model;

namespace Lookup.TSProperties.DynamicProperties
{
    internal static class DynamicPropertySetter
    {
        public static bool SetDynamicProperty(this object obj, string name, string value)
        {
            try
            {
                if (obj is ModelObject modelObj)
                    return modelObj.SetDynamicStringProperty(name, value);
                if (obj is ProjectInfo projectObj)
                    return projectObj.SetDynamicStringProperty(name, value);
            }
            catch
            { }

            return false;
        }
    }
}
