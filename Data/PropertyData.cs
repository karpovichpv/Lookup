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

using Lookup.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lookup
{
    internal class PropertyData : Data
    {
        private readonly object _value;
        private readonly List<object> _values;
        private readonly string _stringValue = "";
        public override bool CanGet { get; protected set; }
        public override bool IsHeader { get; protected set; } = false;

        public PropertyData(string label, object value) : base(label)
        {
            _value = value;
            _name = label;

            CanGet = CheckCanGet();

            if (value is IEnumerable || value is ArrayList)
                _values = CollectionExtensions.GetObjFromEnumerable<object>(value as IEnumerable);

            if (value != null)
                _stringValue = value.ToString();
            else if (value == null)
                _stringValue = "null";

            Value = GetValueString();
        }

        public override string GetValueString()
        {
            string val = _stringValue;
            string[] array = val.Split(new char[] { '.', '[', ']' });
            if (val.Contains("List") && val.Contains("Tekla"))
                val = $"< { array[array.Length - 2]} >"; 
            else if (_stringValue.Contains("Tekla") || _stringValue.Contains("ArrayList"))
                val = $"< {array.LastOrDefault()} >";
            return val;
        }

        public override List<object> WalkDown(object fatherObj)
        {
            if (_values != null)
                return _values;
            else
                return new List<object> { _value };
        }

        private bool CheckCanGet()
        {
            if (_value != null && (_value.GetType().ToString().Contains("Tekla.Structures.") || _value.GetType()==typeof(ArrayList)))
                return true;

            return false;
        }
    }
}
