using System;
using System.Linq.Expressions;

namespace lamdaexpression
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<int, int>> temp = (x) => x + 2;

            var result = temp.Compile().Invoke(2);
            Console.WriteLine(result);
        }
    }
}
