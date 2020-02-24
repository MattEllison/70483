using System;
using System.Threading;
namespace threadsafe
{
    static class Test1
    {
        private static string what = "ehh";

        private static int count = 0;
        private static Object tmp = new Object();
        public static void Run()
        {
            lock (tmp)
            {
                Console.WriteLine(count);
                if (count > 0)
                {
                    what = "hello";
                }
                Console.WriteLine(what);
                count++;
            }

        }
    }
}
