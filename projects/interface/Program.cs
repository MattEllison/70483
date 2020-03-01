using System;

namespace interface_stuff
{
    interface IPerson
    {
        void SayMyName();
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

    }
    class Program
    {
        static void Main(string[] args)
        {
            IDoctor temp1 = new Test();
            temp1.SayMyName();
            IPerson temp2 = new Test();
            temp2.SayMyName();

            Test temp3 = new Test();
            //temp3.SayMyName();
        }
    }
}
