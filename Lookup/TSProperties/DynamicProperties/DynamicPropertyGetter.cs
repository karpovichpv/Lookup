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
    public static class DynamicPropertyGetter
    {
        public static DynamicPropertyResult GetDynamicPropertyResult(this object obj, string propertyName)
        {
            if (obj is ModelObject modelObj)
                return modelObj.GetForModelObject(propertyName);
            if (obj is ProjectInfo projectObj)
                return projectObj.GetForProjectObject(propertyName);

            return new DynamicPropertyResult(string.Empty, false);
        }

        private static DynamicPropertyResult GetForModelObject(
            this ModelObject obj,
            string propertyName)
        {
            string result = string.Empty;
            bool gettingResult
                = obj.GetDynamicStringProperty(propertyName, ref result);
            return new DynamicPropertyResult(result, gettingResult);
        }

        private static DynamicPropertyResult GetForProjectObject(
            this ProjectInfo obj,
            string propertyName)
        {
            string result = string.Empty;

            bool gettingResult
                = obj.GetDynamicStringProperty(propertyName, ref result);
            return new DynamicPropertyResult(result, gettingResult);
        }

    }
}
