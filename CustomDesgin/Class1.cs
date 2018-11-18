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

        public bool LoadJson(string Path)
        {
            string data = string.Empty;

            using (StreamReader stream = new StreamReader(Path))
            {
                data = stream.ReadToEnd();
            }
            JArray list = JArray.Parse(data);

            for (int i = 0; i < list.Count; i++)
            {
                var Type = Observe[list[i]["Name"].ToString()];
                var Enum = list[i].Children();


                foreach (var datas in Enum)
                {
                    JProperty p = datas.ToObject<JProperty>();
                    if (p.Name == "Field")
                    {
                        var name = datas.First["Name"].ToString();
                        CustomType w = new CustomType(Observe.GetField(Type, name, BindingFlags.NonPublic | BindingFlags.Instance).Item2.Value, Type.Name + name);
                        foreach (var data2 in datas.Values())
                        {
                            JProperty p2 = data2.ToObject<JProperty>();
                            if (p2.Name == "Property")
                            {
                                var name2 = data2.First["Name"].ToString();
                                var tmp = Observe.GetProperty(w, name2, BindingFlags.Public | BindingFlags.Instance);
                                tmp.Item1.SetValue(w.Value, data2.First["Value"].ToString());
                            }
                        }
                    }

                }
            }
            return true;
        }

    }
}
