using System;
using System.Reflection;

namespace CustomDesign
{
    public class CustomType 
    {
        public CustomType(Object Info, Object value, string Name)
        {
            if (Info is PropertyInfo)
            {
                Property = (PropertyInfo)Info;
            }else if (Info is FieldInfo)
            {
                Field = (FieldInfo)Info;
            }
            Value = value;
            GUID = Guid.NewGuid();
            this.Name = Name;
        }
        public CustomType(Object value, string Name = "")
        {
            Value = value;
            GUID = Guid.NewGuid();
            this.Name = Name;
        }
        public readonly string Name;
        public readonly Guid GUID;
        public Type Type => Value?.GetType();
        public Object Value { get; set; }

        public PropertyInfo Property = null;
        public FieldInfo Field = null;
    }
}
