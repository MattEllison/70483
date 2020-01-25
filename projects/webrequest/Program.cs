using System.Text;
using System.Net;
using System;
using System.IO;

namespace webrequest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            WebRequest request = WebRequest.Create("http://www.google.com");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            var ms = new MemoryStream();
            dataStream.CopyTo(ms);
            var buffer = new byte[ms.Length];
            dataStream.Read(buffer, 0, buffer.Length);
            var responseFromServer = Encoding.UTF8.GetString(buffer);
            //StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            //string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);





        }
    }
}
