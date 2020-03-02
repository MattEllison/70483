using System;

namespace structs
{
    class Program
    {
        class Test1
        {
            public double X { get; private set; }
            public Test1(double x)

            {
                this.X = x;
            }
        }
        public struct Test
        {
            public int X2;
            public int X { get; set; }
            // public Test(int x)

            // {
            //     X2 = 99;
            //     this.X = x;
            // }
        }
        static void Main(string[] args)
        {
            int test = new int();
            Console.WriteLine(test);

            int test2 = default;
            Console.WriteLine(test2);

            Test temp1 = default;
            Console.WriteLine(temp1.X2);
            Test[] temp = new Test[2];
            //temp[0].X = 5;
            //temp.X2 = 5;
            Console.WriteLine(temp[0].X);

            //var temp2 = new Test1(1);
            //Console.WriteLine(temp.X);
        }
    }
}
