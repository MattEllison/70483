using System;
using System.Diagnostics.CodeAnalysis;

namespace object_valuecheck
{
    class Program
    {
        public class Test
        {
            public string MyProperty { get; set; }
            public override string ToString()
            {
                return MyProperty.ToString();
            }
            public override int GetHashCode()
            {
                return this.ToString().GetHashCode();
            }
            public override bool Equals(object obj)
            {
                return obj.ToString() == this.ToString();
            }


            public static bool operator ==(Test x, Test y)
            {

                return x.MyProperty == y.MyProperty;
            }
            public static bool operator !=(Test x, Test y)
            {

                return x.MyProperty != y.MyProperty;
            }

        }
        static void Main(string[] args)
        {
            Test t1 = new Test { MyProperty = "hello" };
            Test t2 = new Test { MyProperty = "hello" };
            Console.WriteLine(Object.Equals(t1.MyProperty, t2.MyProperty));
            Console.WriteLine(t1.MyProperty == t2.MyProperty);
            string test = "a";
            Console.WriteLine(Object.ReferenceEquals("test" + test, "test" + test));

            // var temp = "test";
            // var temp2 = "test2";
            // Console.WriteLine(Object.Equals(temp, temp2));
            // Console.WriteLine(temp == temp2);
            // Console.WriteLine(Object.ReferenceEquals(temp, temp2));

        }
    }
}
