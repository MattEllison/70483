using System.IO.Compression;
using System;
using System.IO;
using System.Text;
namespace fileReadWrite
{

    abstract class AbstractClassWithStaticMethod
    {
        public static void TestMe()
        {
            Console.WriteLine("test me");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AbstractClassWithStaticMethod.TestMe();
            //   UsingFileClass();
            //UsingStreamWriter();
        }

        static void UsingFileClass()
        {
            File.Create("what.txt");
            var contents = File.ReadAllText("newfile.txt");
            Console.WriteLine(contents);
        }
        static void UsingStreamWriter()
        {
            using (var fs = new StreamWriter("hello.txt"))
            {
                fs.Write("Hello World");
            }
        }
        static void UsingFileStram()
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
