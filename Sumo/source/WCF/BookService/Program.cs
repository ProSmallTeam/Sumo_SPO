using System;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
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
          //  var dbMetaManagerHost = CreateDbMetaManagerHost(typeof(MetaManagerStub));
            var dbMetaManagerHost = CreateDbMetaManagerHost(typeof(DbMetaManager));

            dbMetaManagerHost.Open();
            Console.WriteLine("Сервис запущен");

            
            Console.ReadKey();

            dbMetaManagerHost.Close();


            Console.WriteLine("Done");
        }

        private static ServiceHost CreateDbMetaManagerHost(Type type)
        {
            var host = new ServiceHost(type, new Uri("http://localhost:1060/TestService"));
            host.AddServiceEndpoint(typeof(Sumo.API.IDbMetaManager), new BasicHttpBinding(), "");
            return host;
        }
    }
}
