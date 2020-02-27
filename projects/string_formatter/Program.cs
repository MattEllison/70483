using System;

namespace string_formatter
{
    public class PhoneNumber
    {
        public int MyProperty { get; set; }
    }
    public class PhoneNumberFormatter : ICustomFormatter, IFormatProvider
    {
        public string Format(string format, object arg, IFormatProvider provider)
        {
            return "what";
        }
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;

        }
    }
    class Program
    {

        static void Main(string[] args)
        {

            var t = string.Format(new PhoneNumberFormatter(), "{0} {1}", 1234, "sdfdsf");
            Console.WriteLine(t);
        }
    }
}
