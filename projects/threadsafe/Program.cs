using System;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace threadsafe
{
    class Program
    {
        static void Main(string[] args)
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
