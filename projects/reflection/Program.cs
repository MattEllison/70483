using System;

namespace reflection
{

    class Test
    {
        public string Message { get; set; }
        public Test(string message)
        {
            Message = message;
        }
        public void CallMe(string ehh, string ehh2)
        {
            Console.WriteLine(ehh);
            Console.WriteLine(ehh2);
            Console.WriteLine(Message);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var temp = new Test("hey ho");
            var temp2 = new Test("what what");
            var test = temp.GetType().GetMethods();
            temp.GetType().GetMethod("CallMe").Invoke(temp2, new string[] { "test", "test3" });

        }
    }
}
