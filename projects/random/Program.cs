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
