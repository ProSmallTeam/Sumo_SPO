using System.Windows;
using Sumo.API;

namespace SumoViewer
{
    internal class Presenter
    {
        private readonly MetaManagerFacade _metaManagerFacade;

        private MainWindow _mainWindow;

        public Presenter(MetaManagerFacade metaManagerFacade)
        {
            _metaManagerFacade = metaManagerFacade;
        }

        public void Run()
        {
            var app = new Application();

            _mainWindow = new MainWindow(_metaManagerFacade);

            app.Run(_mainWindow);
        }
    }
}