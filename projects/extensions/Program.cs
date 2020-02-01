using System;

namespace extensions
{
    class Program
    {
        static void Main(string[] args)
        {
            "Wath".RunMe();
            MyExtensions.RunMe("What");
            Console.WriteLine("Hello World!");
        }
    }

    static class MyExtensions
    {
        public static void RunMe(this string obj)
        {
            Console.WriteLine(obj);
        }
    }
}
