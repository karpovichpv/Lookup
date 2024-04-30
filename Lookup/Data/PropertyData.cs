// This file is part of Lookup.
// Lookup is free software: you can redistribute it and/or modify it under
using Lookup.Service;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
                _values = ObservableCollectionService.GetObjFromEnumerable<object>(value as IEnumerable);

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
                val = $"< {array[array.Length - 2]} >";
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
            if (_value != null && (_value.GetType().ToString().Contains("Tekla.Structures.")))
                return true;
            else if (_value.GetType() == typeof(ArrayList) && ((ArrayList)_value).Count > 0)
                return true;

            return false;
        }
    }
}
