#define CONDITION1
#define TEST
using System.Diagnostics;
using System;

namespace compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("before");
            Test();
            Console.WriteLine("after");
        }
        [Conditional("TEST")]
        static void Test()
        {
            Console.WriteLine("Test22");
        }
    }
}
