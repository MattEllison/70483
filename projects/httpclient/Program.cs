using System.Diagnostics;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System;
using System.Threading;
using System.Collections.Generic;
namespace _70483
{
    class Program
    {

        [ThreadStatic]
        public static int count = 0;
        static void Main(string[] args)
        {
            var t = OtherTask().Result;
            var tt = OtherTask2().Result;
            var ttt = ParallelAsyncAll();
            //TestThread();
            //ChildrenThreads();
            //ChildThreadsFromBook();
            //ThreadPoolTest();
            //ChildTaskFactory();
        }
        static async Task<bool> OtherTask()
        {
            var sp = Stopwatch.StartNew();
            Console.WriteLine("Starting");
            var listofsites = new List<Task<string>>();
            var temp = new HttpClient();
            for (var i = 0; i < 100; i++)
            {
                listofsites.Add(temp.GetStringAsync("https://www.google.com?q=" + i));
            }

            await Task.WhenAll(listofsites);


            // foreach (var item in listofsites)
            // {
            //     //Console.WriteLine(item.Result.Length);

            // }
            sp.Stop();
            Console.WriteLine("Async await all --> " + sp.ElapsedMilliseconds);
            return true;
        }
        static async Task<bool> OtherTask2()
        {
            var sp = Stopwatch.StartNew();
            Console.WriteLine("Starting");
            var listofsites = new List<string>();
            var temp = new HttpClient();
            for (var i = 0; i < 100; i++)
            {
                listofsites.Add(await temp.GetStringAsync("https://www.google.com?q=" + i));
            }


            sp.Stop();
            Console.WriteLine("Not await all -->" + sp.ElapsedMilliseconds);
            return true;
        }
        static bool ParallelAsyncAll()
        {
            var sp = Stopwatch.StartNew();
            Console.WriteLine("Starting");
            var listofsites = new List<string>();
            var temp = new HttpClient();
            Parallel.For(0, 100, (i) =>
           {
               listofsites.Add(temp.GetStringAsync("https://www.google.com?q=" + i).Result);
           });

            sp.Stop();
            Console.WriteLine("ParallelAsyncAll -->" + sp.ElapsedMilliseconds);
            return true;
        }
        static void ChildTaskFactory()
        {
            var message = "hello";
            var parent = Task.Run(() =>
            {

                var factory = new TaskFactory(TaskCreationOptions.AttachedToParent,
                TaskContinuationOptions.ExecuteSynchronously);
                factory.StartNew(() => message += " what");
                factory.StartNew(() => message += " ehh");

            });


            var final = parent.ContinueWith(parent => Console.WriteLine(message));
            final.Wait();

        }
        static void ChildThreadsFromBook()
        {
            Task<int> parent = Task.Run(() =>
            {
                var result = new Int32[3];
                var res = 1;
                new Task(() => result[0] = 0, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => result[1] = 1, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => res = 99, TaskCreationOptions.AttachedToParent).Start();
                return res;
            });

            var finaltask = parent.ContinueWith(parentTask =>
            {
                Console.WriteLine(parentTask.Result);
                // foreach (var item in parentTask.Result)
                // {
                //     Console.WriteLine(item);
                // }

            });
            finaltask.Wait();
        }
        static void ChildrenThreads()
        {

            Task<string> parent = Task.Run(() =>
            {
                string message = "start222 -> ";

                new Task(() =>
                {
                    Console.WriteLine("starting 1");
                    message += " what";
                }, TaskCreationOptions.AttachedToParent).Start();

                new Task(() =>
                {
                    Console.WriteLine("starting 2");
                    message += " hello";
                }, TaskCreationOptions.AttachedToParent).Start();
                return message;
            });

            var final = parent.ContinueWith((i) =>
            {
                Console.WriteLine("IM in");
                Console.WriteLine(i.Result);
            });

            Console.WriteLine("waiting");
            final.Wait();
        }
        static void ThreadPoolTest()
        {

            ThreadPool.QueueUserWorkItem(x =>
            {
                string temp = "what";
                if (temp == "what")
                {
                    temp = "hello";
                    Console.WriteLine(temp);
                }
                else
                {
                    Console.WriteLine("nope");
                }

            });
            ThreadPool.QueueUserWorkItem(x =>
            {
                string temp = "1";
                if (temp == "1")
                {
                    temp = "hello";
                    //Console.WriteLine(temp);
                }


            });
            ThreadPool.QueueUserWorkItem(x =>
            {
                string temp = "what";

                if (temp == "hello")
                {

                }
                if (temp == "what")
                {
                    temp = "hello";
                    //Console.WriteLine(temp);
                }



            });

            Console.ReadLine();
        }
        static void TestThread()
        {
            var stopped = false;
            var fileex = File.Exists("test");
            if (fileex)
            {
                Console.WriteLine("Found file");
                stopped = true;
            }
            var t = new Thread(() =>
                            {
                                var threadId = Thread.CurrentThread.ManagedThreadId;
                                using (var fs = new StreamWriter($"what-test.txt"))
                                {
                                    //int count = 0;
                                    while (!stopped)
                                    {
                                        count++;
                                        Thread.Sleep(1000);
                                        Console.WriteLine($"{threadId} - .");
                                        fs.WriteLine(count);
                                        if (count > 20)
                                        {
                                            stopped = true;
                                        }
                                    }
                                }
                            });
            t.Start();
            t.Join();
            Console.ReadLine();
        }
        static void Threads()
        {
            File.Delete("what.txt");
            var stopped = false;
            for (int x = 0; x < 2; x++)
            {
                new Thread(() =>
                            {
                                var threadId = Thread.CurrentThread.ManagedThreadId;
                                using (var fs = new StreamWriter($"what{x}.txt"))
                                {
                                    //int count = 0;
                                    while (!stopped)
                                    {
                                        count++;
                                        Thread.Sleep(1000);
                                        Console.WriteLine($"{threadId} - .");
                                        fs.WriteLine(count);
                                        if (count > 9)
                                        {
                                            stopped = true;
                                        }
                                    }
                                }
                            }).Start();
            }



            Console.ReadKey();
            stopped = true;
        }
    }
}
