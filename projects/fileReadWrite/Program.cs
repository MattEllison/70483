using System;
using System.IO;
using System.Text;
namespace fileReadWrite
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using (var file = new FileStream("newfile.2txt", FileMode.Truncate))
            {
                var bytes = Encoding.UTF8.GetBytes("Whats up world 2\n");
                file.Write(bytes);
            }

        }
    }
}
