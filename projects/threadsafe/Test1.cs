using System;
using System.Threading;
namespace threadsafe
{
    static class TestThreadStaticHelper
    {
        [ThreadStatic]
        private static string what = "oh no";
        static TestThreadStaticHelper()
        {
            //what = "ehh2";
        }
        private static Object temp = new Object();
        public static void Run()
        {
            lock (temp)
            {
                Console.WriteLine("Thread ID = " + Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("WHAT = " + what);
            }

        }
    }
    static class Test1
    {

        private static string what = "ehh";



        private static int count = 0;
        private static Object tmp = new Object();
        public static void Run()
        {
            lock (tmp)
            {
                Console.WriteLine("ID = " + Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine(count);
                if (count > 0)
                {
                    what = "hello";
                }
                Console.WriteLine("WHAT = " + what);
                count++;
            }

        }
        private static int counter = 0;
        public static void Run2()
        {
            Interlocked.Add(ref counter, 1);
        }

        private static int counter3 = 0;
        public static void Run3()
        {
            lock (tmp)
            {
                counter3++;
            }

        }
    }
}
