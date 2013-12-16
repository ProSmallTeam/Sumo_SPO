using System;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BookService
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Hell0");
            var dbMetaManagerHost = CreateDbMetaManagerHost(typeof(MetaManagerStub));

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
