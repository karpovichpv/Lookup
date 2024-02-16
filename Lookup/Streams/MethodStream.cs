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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lookup
{
    internal class MethodStream
    {
        public static List<Data> Stream(object obj)
        {
            Type type = obj.GetType();
            
            List<Data> resultData = new List<Data>();
            resultData.Add(new HeaderData("--- Methods ---", ""));

            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(t=>!t.IsSpecialName && t.IsSecurityCritical && t.Name != "FromStruct" && t.Name !="ToStruct")
                .ToArray();

            foreach (MethodInfo methodInfo in methods)
             {
                if (methodInfo.DeclaringType.FullName.Contains("Tekla.Structures") && 
                    methodInfo.Name !="Zero") // except method for points - makes points nullable
                    resultData.Add(DataExtensions.Create(methodInfo, obj));
            }

            return resultData;
        }
    }
}
