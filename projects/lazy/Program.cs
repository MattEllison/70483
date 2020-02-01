using System;

namespace lazy
{
    class Test
    {
        public Test()
        {
            Console.WriteLine("What");
            MyProperty = 1;
        }
        public Test(string hello)
        {
            Console.WriteLine(hello);
            MyProperty = 2;
        }

        public int MyProperty { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //var temp1 = new Test();
            //Console.WriteLine(temp1.MyProperty);
            var temp = new Lazy<Test>(() => new Test("wddf"));


            Console.WriteLine(temp.Value.MyProperty);
            Console.WriteLine(temp.Value.MyProperty);

            //Func<Test> temp2 = () => new Test("dsfdfd");

            //Console.WriteLine(temp2().MyProperty);
        }
    }
}
