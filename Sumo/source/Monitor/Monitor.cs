using System.Collections.Generic;
using FileSystemObserver;
using Sumo.API;

namespace Monitor
{
    public class Monitor
    {
        private readonly IDbTaskManager _dbTaskManager;

        private readonly IFileSystemObserver _fileSystemObserver;

        public Monitor(IFileSystemObserver fileSystemObserver, IDbTaskManager dbTaskManager)
        {
            _fileSystemObserver = fileSystemObserver;
            _dbTaskManager = dbTaskManager;

            _fileSystemObserver.FoldersChanged += FoldersChanged;

        }

        public void Run()
        {
            _fileSystemObserver.Run();
        }

        void FoldersChanged(object sender, FileObserverEventArgs e)
        {
            _dbTaskManager.AddTasks(e.ChangedFilesFullPath);
        }
        

    }
}