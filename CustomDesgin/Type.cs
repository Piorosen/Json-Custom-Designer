using System;
using System.Reflection;

namespace CustomDesign
{
    public class CustomType 
    {
        public CustomType(Object value)
        {
            Value = value;
            GUID = Guid.NewGuid();
        }

        public readonly Guid GUID;
        public Type Type => Value?.GetType();
        public Object Value { get; set; }
    }
}
