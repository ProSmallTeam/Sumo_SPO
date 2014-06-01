﻿using System;
using DB;
using DBMetaManager;

namespace BookService
{
    class Program
    {
        /// <summary>
        /// Запускает WCF сервис.
        /// </summary>
        static void Main(string[] args)
        {

            Console.WriteLine("Hell0");

            var dbMetaManagerHost = BookServiceHost.Get(typeof(DbMetaManager));
            dbMetaManagerHost.Open();
            Console.WriteLine("Сервис запущен");

            
            Console.ReadKey();

            dbMetaManagerHost.Close();


            Console.WriteLine("Done");
        }



    }
}
