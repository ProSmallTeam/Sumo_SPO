using System;
using Sumo.API;
using SumoViewer.DbBookService;
using IDbMetaManager = Sumo.API.IDbMetaManager;

namespace SumoViewer
{
    internal class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            IDbMetaManager metaManager = new MetaManagerStub();

            if (args.Length == 1)
            {
                if (args[0] == "--WCF")
                {
                    metaManager = new WcfAdapter(new DbMetaManagerClient());
                }
            }


            var facade = new MetaManagerFacade(metaManager);

            var presenter = new Presenter(facade);

            presenter.Run();
        }
    }
}