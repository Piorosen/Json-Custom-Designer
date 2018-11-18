using System;
using System.ComponentModel;
using System.Reflection;

namespace CustomDesign
{
    public class CustomType : INotifyPropertyChanged 
    {
        public CustomType(Object value)
        {
            Value = value;
        }

        public Type Type => Value?.GetType();
        public TypeInfo TypeInfo => Value?.GetType().GetTypeInfo();
        Object _Value;
        public Object Value
        {
            get => _Value; 
            set
            {
                _Value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
