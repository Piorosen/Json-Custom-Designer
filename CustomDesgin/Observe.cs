﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CustomDesign
{
    public class Observe
    {
        List<CustomType> List = new List<CustomType>();

        public CustomType Add(CustomType Item)
        {
            List.Add(Item);
            return Item;
        }
        public CustomType Add(Object Item, string Name)
        {
            return Add(new CustomType(Item, Name));
        }
        
        public bool Delete(Object Item)
        {
            return Delete(new CustomType(Item));
        }
        public bool Delete(CustomType Item)
        {
            var t = List.First(i => i.GUID == Item.GUID);
            if (t != null)
            {
                List.Remove(t);
                return true;
            }
            return false;
        }

        public CustomType this[int index] => List[index];
        public CustomType this[string Name] => List.First(i => i.Name == Name);

        public T2 Change<T1, T2>(T1 t1, T2 t2)
        {
            return (T2)Convert.ChangeType(t1, t2.GetType()) ;
        }

        public (FieldInfo, CustomType) GetField(CustomType obj, string Name, BindingFlags flags = BindingFlags.Public | BindingFlags.Instance)
        {
            var data = obj.Type.GetField(Name, flags);
            return (data, new CustomType(data.GetValue(obj.Value)));
        }
        public (PropertyInfo, CustomType) GetProperty(CustomType obj, string Name, BindingFlags flags = BindingFlags.Public | BindingFlags.Instance)
        {
            var data = obj.Type.GetProperty(Name, flags);   
            return (data, new CustomType(data.GetValue(obj.Value)));
        }



    }
}
