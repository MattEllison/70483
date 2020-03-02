using System;

namespace interface_stuff
{
    interface IPerson
    {
        void SayMyName();
        public void SayMyTest()
        {
            Console.WriteLine("tes");
        }
    }
    interface IDoctor
    {
        void SayMyName();
    }

    class Test : IPerson, IDoctor
    {
        void IDoctor.SayMyName()
        {
            Console.WriteLine("My name is Doctor");
        }
        void IPerson.SayMyName()
        {
            Console.WriteLine("My name is Person");
        }

        public void SayMyName()
        {
            Console.WriteLine("My name is Test");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            IDoctor temp1 = new Test();
            temp1.SayMyName();
            IPerson temp2 = new Test();
            temp2.SayMyName();
            temp2.SayMyTest();
            Test temp3 = new Test();
            temp3.SayMyName();

        }
    }
}
