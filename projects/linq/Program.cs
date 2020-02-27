
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Linq;
using System;
namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Matt", "John" };
            var list = new List<dynamic>();
            list.Add(new { Name = "Matt", Id = 2342 });
            list.Add(new { Name = "John", Id = 343 });
            var gp = names.GroupJoin(list, x => x, y => y.Name, (a, b) => new { a, b, c = b.FirstOrDefault().Id });
            foreach (var item in gp)
            {
                Console.Write(item.a);
                Console.Write(item.c);
                // foreach (var item2 in item.b)
                // {
                //     Console.WriteLine(item);
                //     Console.WriteLine(item2);
                // }

            }
        }
    }
}
