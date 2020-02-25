using System;
using System.Threading.Tasks;
namespace tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            //   Console.WriteLine("Test");
            var t = Task.Run(() =>
            {
                System.Threading.Thread.Sleep(2000);
                return "what";
            })
                .ContinueWith(r => Console.WriteLine(r.Result));
            var t2 = Task.Run(() => "what2")
            .ContinueWith(r => Console.WriteLine(r.Result));
            t.Wait();
            t2.Wait();
        }
    }
}
