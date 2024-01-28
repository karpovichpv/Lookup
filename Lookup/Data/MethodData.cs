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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model;

namespace Lookup
{
    internal class MethodData : Data
    {
        private readonly string _stringValue = "";
        private readonly object _value;
        private readonly List<object> _returnObjects;
        public override bool CanGet
        {
            get
            {
                if (_value == null && _returnObjects == null)
                    return false;
                else
                    return true;
            }
            protected set { }
        }
        public override bool IsHeader { get; protected set; } = false;

        public MethodData(string label, object value) : base(label)
        {
            _name = label;
            _value = value;

            if (value != null)
                _stringValue = value.ToString();
            else if (value == null)
                _stringValue = "null";

            if (value is IEnumerator)
            {
                _returnObjects = ObservableCollectionService.GetObjFromEnumerator(value as IEnumerator);
                _value = null;
            }

            Value = GetValueString();
        }

        public override string GetValueString()
        {
            string val = _stringValue;
            if (_stringValue.Contains("Tekla.Structures."))
                val = _stringValue.Remove(0, 17);
            return val;
        }

        public override List<object> WalkDown(object fatherObj)
        {
            if (_returnObjects != null)
                return _returnObjects;
            else
                return new List<object> { _value };
        }
    }
}
