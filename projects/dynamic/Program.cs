



using System.Dynamic;

using System;
using System.Collections.Generic;

namespace dynamic
{
    class Program
    {
        class Test1
        {
            public int MyProperty { get; set; } = 0;
            public void RunMe()
            {
                Console.WriteLine(MyProperty);
            }
            public static implicit operator int(Test1 d) => d.MyProperty;
            public static implicit operator string(Test1 d) => d.MyProperty.ToString();
            public static explicit operator DynamicViewDataDictionary(Test1 d) => (dynamic)new Dictionary<string, object>() { { "HEY", 1 } };

        }
        class Test2 : DynamicObject
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            // If you try to get a value of a property 
            // not defined in the class, this method is called.
            public override bool TryGetMember(
                GetMemberBinder binder, out object result)
            {
                // Converting the property name to lowercase
                // so that property names become case-insensitive.
                string name = binder.Name.ToLower();

                // If the property name is found in a dictionary,
                // set the result parameter to the property value and return true.
                // Otherwise, return false.
                return dictionary.TryGetValue(name, out result);
            }

            // If you try to set a value of a property that is
            // not defined in the class, this method is called.
            public override bool TrySetMember(
                SetMemberBinder binder, object value)
            {
                // Converting the property name to lowercase
                // so that property names become case-insensitive.
                dictionary[binder.Name.ToLower()] = value;

                // You can always add a value to a dictionary,
                // so this method always returns true.
                return true;
            }


            public int MyProperty { get; set; } = 1;
            public void RunMe()
            {
                Console.WriteLine(MyProperty);
            }
            public override bool TryGetIndex(System.Dynamic.GetIndexBinder binder, object[]
            indexes, out object result)
            {
                result = "test";
                return true;
            }

            //public static implicit operator Dictionary<string, object>(Test2 t) => t.dictionary;
        }

        static void Hey(dynamic run)
        {

            run.RunMe();
        }
        static void Hey(string test)
        {
            Console.WriteLine("test string");
        }
        static void Hey(int test)
        {
            Console.WriteLine("test int");
        }
        static void BoxTest(object t)
        {
            t = 10;
        }
        static void Main(string[] args)
        {

            dynamic temp = new Test2();
            temp.what = "HEYYY";
            Console.WriteLine(temp.MyProperty);
            Console.WriteLine(temp.what);

            //Dictionary<string, object> temp2 = temp;
            Console.WriteLine(temp["what"]);

            // int t1 = 0;
            // object t2 = t1;
            // t2 = 100;
            // Console.WriteLine(t2);

            // int? t1 = 100;
            // int t2 = (int)t1;
            // Console.WriteLine(t2);

            //Test1 temp1 = new Test1();
            //dynamic testDy = new Test1();
            // //Dictionary<string, object> t = testDy;
            // Console.WriteLine(t["HEY"]);
            // int temp2 = new Test1();
            // string temp3 = new Test1();
            // Console.WriteLine(temp1.ToString());
            // Console.WriteLine(temp2);
            // Console.WriteLine(temp3);
            // Hey(new Test1());
            // Hey(new Test2());
            // Hey("what no way");
            // dynamic t1 = 1;
            // int t2 = 2;
            // Hey(t1);
            // Hey(t2);
            // var temp1 = new
            // {
            //     Name = "Matt"
            // };

            // Console.WriteLine(temp1.Name);

            // dynamic temp2 = new
            // {
            //     Name = "Ehh"
            // };
            // temp2.What = "Ehh";
            // Console.WriteLine(temp2.Name);

            // dynamic temp1;
            // temp1 = new { hello = "hello" };
            // Console.WriteLine(temp1.hello);

            // temp1 = new { what = "what" };
            // Console.WriteLine(temp1.what);


            //Expando();
        }
        static void Expando()
        {
            var heel = "" as dynamic;
            Console.WriteLine("test");
            var temp = new ExpandoObject() as dynamic;
            temp.what = "ehh";
            Console.WriteLine(temp.what);

            Console.WriteLine((IDictionary<string, object>)temp["what"]);


        }
    }
}
