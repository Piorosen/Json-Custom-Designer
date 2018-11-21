using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CustomDesign
{
    public class CustomDesign
    {
        public Observe Observe = new Observe();

        Stack<CustomType> TypeStack = new Stack<CustomType>();

        public bool LoadJson(string data)
        {
            JArray list = JArray.Parse(data);

            for (int i = 0; i < list.Count; i++)
            {
                var Type = Observe[list[i]["Name"].ToString()];
                var Enum = list[i].Children();
                TypeStack.Push(Type);
                foreach (var token in Enum)
                {
                    SelectCode(token);
                }
            }
            return true;
        }

        void SelectCode(JToken token)
        {
            JProperty p = token.ToObject<JProperty>();
            if (p.Name == "Field")
            {
                foreach (var to in token.Children().Children())
                {
                    CustomType type = TypeStack.Peek();
                    TypeStack.Push(GetField(to, type));
                    foreach (var to2 in to)
                    {
                        SelectCode(to2);
                    }
                    TypeStack.Pop();
                }

            }
            else if (p.Name == "Property")
            {
                foreach (var to in token.Children().Children())
                {
                    CustomType type = TypeStack.Peek();
                    TypeStack.Push(GetProperty(to, type));
                    foreach (var to2 in to)
                    {
                        SelectCode(to2);
                    }
                    TypeStack.Pop();
                }
            }
            else if (p.Name == "Type")
            {
                var type = Type.GetType(p.Value.ToString());
                token = token.Next;
                var data = token.ToObject<JProperty>();
                if (data.Name == "Value")
                {
                    var t = TypeStack.Pop();
                    t.Field?.SetValue(TypeStack.Peek().Value, Convert.ChangeType(data.Value, type));
                    t.Property?.SetValue(TypeStack.Peek().Value, Convert.ChangeType(data.Value, type));
                    TypeStack.Push(t);
                }
            }
        }

        public CustomType GetField(JToken token, CustomType type)
        {
            var name = token["Name"].ToString();
            var tmp = Observe.GetField(type, name, BindingFlags.NonPublic | BindingFlags.Instance);
            if (tmp.Item2 == null)
            {
                tmp = Observe.GetField(type, name, BindingFlags.Public | BindingFlags.Instance);
            }
            CustomType w = new CustomType(tmp.Item1, tmp.Item2.Value);
            foreach (var t in token.Children())
            {
                return w;
            }
            return w;
        }

        public CustomType GetProperty(JToken token, CustomType type)
        {
            var name = token["Name"].ToString();
            var tmp = Observe.GetProperty(type, name, BindingFlags.NonPublic | BindingFlags.Instance);
            if (tmp.Item2 == null)
            {
                tmp = Observe.GetProperty(type, name, BindingFlags.Public | BindingFlags.Instance);
            }
            CustomType w = new CustomType(tmp.Item1, tmp.Item2.Value);
            foreach (var t in token.Children())
            {
                return w;
            }
            return w;
        }

    }
}
