using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWCFClient.ServiceReference1;

namespace SimpleWCFClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new DbTaskManagerClient();

            var strings = new List<string>();

            Console.WriteLine("Введите пути(пустая строка - завершить)");

            while (true)
            {
                var str = Console.ReadLine();

                if (str == "")
                    break;

                strings.Add(str);
            }

            //           fileSystemObserver.ExecuteEvent(strings);

            client.AddTasks(strings.ToArray());
            Console.WriteLine(client.TestOperation("asdf"));
            var a = client.GetTasks(10);

            foreach (var s in a)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("Done");

            Console.ReadKey();
        }
    }
}
