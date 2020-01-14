using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace binary_serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestingReference();
            TestingReferenceWithJson();
        }
        static void TestingReference()
        {
            var temp = new Hello("1");
            var temp2 = temp;
            var newOjb = new List<Hello>()
            {
                temp,
                temp2
            };

            var formatter = new BinaryFormatter();
            using (var stream = File.Create("./data/Hello.bin"))
            {
                formatter.Serialize(stream, newOjb);
            };
            using (var readStream = File.OpenRead("./data/Hello.bin"))
            {
                var newArray = (List<Hello>)formatter.Deserialize(readStream);

                newArray[1].Name = "what";
                Console.WriteLine(newArray.Count);
                foreach (var item in newArray)
                {
                    Console.WriteLine(item.Name);
                }
            };
        }

        static void TestingReferenceWithJson()
        {
            var temp = new Hello("1");
            var temp2 = temp;
            var newOjb = new List<Hello>()
            {
                temp,
                temp2
            };




            var result = JsonSerializer.Serialize<List<Hello>>(newOjb);
            File.WriteAllText("./data/Hello2.json", result);
            var jsonString = File.ReadAllText("./data/Hello2.json");
            var newArray = JsonSerializer.Deserialize<List<Hello>>(jsonString);

            newArray[1].Name = "what";
            Console.WriteLine(newArray.Count);
            foreach (var item in newArray)
            {
                Console.WriteLine(item.Name);
            }


        }
    }
}
