using System;

namespace iformatprovider2
{
    public class CustomFormatter : IFormatProvider
    {
        public object GetFormat(Type formatType)
        {
            Console.WriteLine("Called with " + formatType);
            return null;
        }
    }

    public class TestCustomFormatter : ICustomFormatter
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            Console.WriteLine("FORMAT");
            if (arg is string mystring2)
            {
                return mystring2;
            }
            return "john";
        }
    }
    public class TestFormatter : IFormatProvider
    {
        public object GetFormat(Type formatType)
        {
            Console.WriteLine("get format");
            return new TestCustomFormatter();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //string s = 3.ToString(new CustomFormatter());
            //Console.WriteLine(s);
            //            var ttt = 1.ToString(new TestFormatter());
            //          Console.WriteLine(ttt);
            var temp = String.Format(new TestFormatter(), "hello {0}", 1);
            Console.WriteLine(temp);
        }
    }
}
