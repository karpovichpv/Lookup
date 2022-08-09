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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lookup
{
    internal class StringData : Data
    {
        string _value;
        public StringData(string label, string value) : base(label)
        {
            _value = value;
            Value = value;
        }

        public override bool CanGet { get; protected set; } = false;
        public override bool IsHeader { get; protected set; } = false;

        public override string GetValueString()
        {
            if (_value == null) 
                return "null";
            if (_value.Length == 0)
                return "empty";

            return _value;
        }

        public override List<object> WalkDown(object fatherObj)
        {
            return null;
        }
    }
}
