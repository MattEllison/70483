using System;
using whatwhat;


namespace whatwhat
{

    class What2 : What1
    {
        protected override int MyProperty { get; set; }
    }
    public class What1
    {
        protected virtual int MyProperty { get; set; }
    }
    class ehh
    {

    }
}
namespace protected_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var t = new What1();
            var temp = new What2();

        }


    }

    class Test2 : Test
    {
        static void TestMethod()
        {
            //var temp = new What();
        }
    }

    public class Test
    {

        class What
        {
            public int MyProperty { get; set; }

        }
    }
}
