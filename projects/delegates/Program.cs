using System;

namespace delegates
{
    class Program
    {
        private delegate string Test();
        private delegate string Test2(string message);

        private delegate void Test3();
        private delegate void Test4(int test, string whatever);

        static void Main(string[] args)
        {

            RecreateFunc();

        }

        private delegate T2 MattsFunc<T1, T2>(T1 message);
        static void RecreateFunc()
        {


            Func<int, string> temp = (int mess) => mess.ToString();
            Console.WriteLine(temp(1));

            MattsFunc<int, string> temp2 = (int mess) => mess.ToString();
            Console.WriteLine(temp2(2));
        }

        static void Test1()
        {

            var temp = new Test(Matts);
            var temp2 = new Test2(Matts);
            Console.WriteLine(temp2("test"));

            Test2 temp3 = Matts;
            Console.WriteLine(temp3("test"));

            Test2 temp4 = (string whatever) => whatever;
            Console.WriteLine(temp4("test11"));



            Test3 temp5 = () => { Console.WriteLine("first"); };
            temp5 += delegate
            {

                Console.WriteLine("ehh1");
            };
            {
                Console.WriteLine("ehh2");
            };
            {
                Console.WriteLine("ehh3");
            };
            temp5 += () => { Console.WriteLine("ehhh6"); };
            temp5();


            Test4 temp6 = delegate
            {
                Console.WriteLine("test4");

            };

            temp6(1, "dfdf");
        }
        static string Matts()
        {
            return "What";
        }
        static string Matts(string message)
        {
            return message;
        }
    }
}
