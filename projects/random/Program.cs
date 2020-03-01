using System;
using System.Linq;
//using System.Collections.Generic;
namespace random
{
    class Program
    {
        class Test
        {
            public int MyProperty { get; set; } = 2;
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"1 {"HELLO",-20} 2");
            Console.WriteLine($"1 {"HELLO",20} 2");

            Console.WriteLine($"|{"Left",-7}|{"Right",7}|");

            //MethodC();
        }
        static void MethodC()
        {
            string[,] tempstrings = { { "what", "what2", "hey1" }, { "what", "what2", "hey2" } };

            Console.WriteLine(tempstrings.GetUpperBound(0));
            Console.WriteLine(tempstrings.GetUpperBound(1));

            int[] integers = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
            // Get the upper and lower bound of the array.
            int upper = integers.GetUpperBound(0);
            int lower = integers.GetLowerBound(0);
            Console.WriteLine(upper);

        }
        static void MethodB()
        {
            string[,] tempstrings = { { "what", "what2", "hey" }, { "what", "what2", "hey" } };

            Console.WriteLine(tempstrings.GetLength(0));
            Console.WriteLine(tempstrings.GetLength(1));
        }
        static void MethodA()
        {
            string[] tempstrings = { "what", "what2" };
            var a = from fr in tempstrings
                    let te222 = fr + 99
                    select te222;
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }


            var temp = new
            {
                FirstName = "What",
                LastName = "Ehh"
            };
            Console.WriteLine(temp.ToString());

            Test[] list = { new Test(), new Test() };
            System.Collections.Generic.IEnumerable<Test> linqTest = from x in list where x.MyProperty > 1 select x;
            foreach (var item in linqTest)
            {
                Console.WriteLine(item.MyProperty);
            }
        }
    }
}
