// This file is part of Lookup.
// Lookup is free software: you can redistribute it and/or modify it under
using System.Collections.Generic;

namespace Lookup
{
    internal class HeaderData : Data
    {
        string _value;
        public HeaderData(string label, string value) : base(label)
        {
            _value = value;
        }

        public override bool CanGet { get; protected set; } = false;
        public override bool IsHeader { get; protected set; } = true;

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
