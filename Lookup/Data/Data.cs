using System.Collections.Generic;
using System.ComponentModel;

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
