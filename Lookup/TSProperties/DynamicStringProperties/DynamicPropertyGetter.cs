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
    internal static class DynamicPropertyGetter
    {
        public static string GetDynamicProperty(this object obj, string propertyName)
        {
            try
            {
                if (obj is ModelObject modelObj)
                    return modelObj.GetForModelObject(propertyName);
                if (obj is ProjectInfo projectObj)
                    return projectObj.GetForProjectObject(propertyName);
            }
            catch
            { }

            return null;
        }

        private static string GetForModelObject(this ModelObject obj, string propertyName)
        {
            string result = string.Empty;
            obj.GetDynamicStringProperty(propertyName, ref result);

            return result;
        }

        private static string GetForProjectObject(this ProjectInfo obj, string propertyName)
        {
            string result = string.Empty;
            obj.GetDynamicStringProperty(propertyName, ref result);

            return result;
        }

    }
}
