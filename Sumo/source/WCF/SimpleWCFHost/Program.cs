using System;
using System.Collections.Generic;
using System.ServiceModel;
using Sumo.API;

namespace SimpleWCFHost
{

    [ServiceContract]
    public interface ITestingService
    {
        [OperationContract]
        CategoriesMultiList Get(CategoriesMultiList categoriesMultiList);

        [OperationContract]
        List<Book> GetBookMeta(List<Book> books);
    }

    public  class TestingService : ITestingService
    {
        public CategoriesMultiList Get(CategoriesMultiList categoriesMultiList)
        {
            return categoriesMultiList;
        }

        public List<Book> GetBookMeta(List<Book> books)
        {
            return books;
        }
    }

    internal class Program
    {

        private static void Main(string[] args)
        {
            Console.WriteLine("Hell0");
            var host = new ServiceHost(typeof(TestingService), new Uri("http://localhost:1050/TestService"));
            host.AddServiceEndpoint(typeof(ITestingService), new BasicHttpBinding(), "");
            host.Open();
            Console.WriteLine("Сервер запущен");
            Console.ReadLine();

            host.Close();
        }
    }
}