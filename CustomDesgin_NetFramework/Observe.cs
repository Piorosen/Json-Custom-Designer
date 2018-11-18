using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection;

namespace CustomDesign
{
    public class Observe
    {
        ObservableCollection<CustomType> List = new ObservableCollection<CustomType>();

        public bool Add(CustomType Item)
        {
            List.Add(Item);
            return true;
        }
        public bool Add(Object Item)
        {
            List.Add(new CustomType(Item));
            
            return true;
        }
        
        public void Change()
        {
            var item = List[0].Type.GetProperty("Text");
            item?.SetValue(List[0].Value, "123");

        }

        public CustomType this[int id]
        {
            get
            {
                return List[id];
            }
            set
            {
                List[id] = new CustomType(value);
            }
        }
    }
}
