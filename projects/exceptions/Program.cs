using System;

namespace exceptions
{

    public class Test2
    {
        public static void DoSomething()
        {
            throw new Exception("Do Something Message");
        }

    }
    public class Test1
    {
        public static void DoWhat(string test)
        {
            try
            {
                Test2.DoSomething();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
        public static void DoWhat2(string test)
        {
            throw new Exception("What");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Test1.DoWhat("hello");

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                // Console.WriteLine(ex.TargetSite);
                // Console.WriteLine(ex.TargetSite.MemberType);
                // Console.WriteLine(ex.TargetSite.DeclaringType);

                // Console.WriteLine(ex.Message);
                // Console.WriteLine(ex.Source);

            }


        }
    }
}
