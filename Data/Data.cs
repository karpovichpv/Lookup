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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lookup
{
    public abstract class Data : INotifyPropertyChanged
    {
        private protected string _name;

        public abstract bool IsHeader { get; protected set; }
        public abstract bool CanGet { get; protected set; }
        public string Label { get; }
        public string Value { get; protected set; }

        protected Data(string label)
        {
            Label = label;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public abstract string GetValueString();
        public abstract List<object> WalkDown(object fatherObj);

        public override string ToString()
        {
            return $"{Label}: {GetValueString()}";
        }
    }
}
