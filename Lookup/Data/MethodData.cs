// This file is part of Lookup.
// Lookup is free software: you can redistribute it and/or modify it under
using Lookup.Service;
using System.Collections;
using System.Collections.Generic;

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
