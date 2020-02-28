using System;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace threadsafe
{
    class Program
    {
        static void Main(string[] args)
        {
            TestThreadStatic();

        }
        public static void TestThreadStatic()
        {
            var temp = new List<Task>();
            temp.Add(Task.Run(() =>
            {
                TestThreadStaticHelper.Run();
            }));
            temp.Add(Task.Run(() =>
            {
                TestThreadStaticHelper.Run();
            }));

            Task.WaitAll(temp.ToArray());

        }
        static void TestRun()
        {
            var temp = new List<Task>();
            temp.Add(Task.Run(() =>
            {
                Test1.Run();
            }));
            temp.Add(Task.Run(() =>
            {
                Test1.Run();
            }));

            Task.WaitAll(temp.ToArray());

        }
    }
}
