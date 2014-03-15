using System;
using Sumo.API;
using VisualSumoWPF.DbBookService;

namespace VisualSumoWPF
{
    internal class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            var metaManagerStub = new MetaManagerStub();
            var metaManager = new WcfAdapter(new DbMetaManagerClient());

            var facade = new MetaManagerFacade(metaManagerStub);

            var presenter = new Presenter(facade);

            presenter.Run();
        }
    }
}