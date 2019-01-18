using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace CustomDesign.CUITest
{
    class Program
    {
        class testlib
        {
            

            private int Value = 0;
            private Point Pt = new Point();

            private int _property = 0;
            private int Property
            {
                get
                {
                    return _property;
                }
                set
                {
                    _property = value;
                }
            }

            private Rectangle rectangle = new Rectangle();


            void CallFunc()
            {

                Console.WriteLine("Call Func");
            }

            void CallFunc(int data, Point pt)
            {
                Console.WriteLine($"{data} : {pt.X}, {pt.Y}");
            }

        }
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("123");
            var t = list;
            t[0] = "333";
            Console.WriteLine(list[0]);
            list.ToList();


        }
    }
}
