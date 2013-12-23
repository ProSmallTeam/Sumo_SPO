﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
//using Sumo.API;
using Sumo.API;
using CategoryNode = Sumo.API.CategoryNode;
using IDbTaskManager = Sumo.API.IDbTaskManager;

namespace SimpleWCFClient
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    var client = new DbTaskManagerClient();

        //    var strings = new List<string>();

        //    Console.WriteLine("Введите пути(пустая строка - завершить)");

        //    while (true)
        //    {
        //        var str = Console.ReadLine();

        //        if (str == "")
        //            break;

        //        strings.Add(str);
        //    }

        //    //           fileSystemObserver.ExecuteEvent(strings);

        //    client.AddTasks(strings.ToArray());
        //    Console.WriteLine(client.TestOperation("asdf"));
        //    var a = client.GetTasks(10);

        //    foreach (var s in a)
        //    {
        //        Console.WriteLine(s);
        //    }

        //    Console.WriteLine("Done");

        //    Console.ReadKey();
        //} 
        
        static void Main(string[] args)
        {
            var a = new IDbMetaManagerService.DbMetaManagerClient();
            var b =  a;
            var q2 = b.CreateQuery("");

            Console.WriteLine(q2.Count);
            Console.WriteLine(q2.SessionId);

            var documents = b.GetDocuments(q2.SessionId, 5, 2);

            foreach (var document in documents)
            {
                Console.WriteLine(document.Name);
            }

            var book = b.GetDocuments(q2.SessionId, 1, 1);

            var statistic = b.GetStatistic(q2.SessionId);

            statistic.Childs.ToList().ForEach(c => Console.WriteLine(c.Node.Id));

            var w = new List<string>{"x", "p"};
            w.ForEach(Console.WriteLine);

            Console.WriteLine("Done");
            Console.ReadKey();
        }

        private static SimpleWCFHost.ITestingService GetService()
        {
            var tcpUri = new Uri("http://localhost:1050/TestService");

            var address = new EndpointAddress(tcpUri);
            var binding = new BasicHttpBinding();
            var factory = new ChannelFactory<SimpleWCFHost.ITestingService>(binding, address);
            var service = factory.CreateChannel();
            return service;
        }
    }
}
