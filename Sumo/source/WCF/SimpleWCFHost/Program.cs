﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWCFHost
{
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Hell0");
                ServiceHost host = new ServiceHost(typeof(Sumo.API.DbTaskManager), new Uri("http://localhost:1050/TestService"));
                host.AddServiceEndpoint(typeof(Sumo.API.IDbTaskManager), new BasicHttpBinding(), "");
                host.Open();
                Console.WriteLine("Сервер запущен");
                Console.ReadLine();

                host.Close();
            }
        }
}
