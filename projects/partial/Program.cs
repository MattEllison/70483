using System;

namespace partial
{
    class Program
    {
        static void Main(string[] args)
        {
            var temp = new Test();
            temp.Start();
        }
    }

    partial class Test
    {
        public void Start()
        {
            StartPartial();

            Console.WriteLine("Start Final");

        }

        partial void StartPartial();


    }

    partial class Test
    {
        partial void StartPartial()
        {
            Console.WriteLine("start parti");
        }
    }
}
