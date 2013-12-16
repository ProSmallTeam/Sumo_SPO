using System.IO;

namespace FileSystemObserver_2
{
    public class FolderWatcher : IFolderWatcher
    {

        private FileSystemWatcher _watcher;

        public void SetUpFolder(string path)
        {
            _watcher = new FileSystemWatcher
            {
                Path = path,
                NotifyFilter =
                    NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName |
                    NotifyFilters.Attributes | NotifyFilters.CreationTime | NotifyFilters.LastAccess |
                    NotifyFilters.Size,
                IncludeSubdirectories = true,
            };

            _watcher.Changed += OnChanged;
            _watcher.Created += OnCreated;
            _watcher.Deleted += OnDeleted;
            _watcher.Renamed += OnRenamed;
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            if (WatchedFoldersFileHasRenamed != null)
            {
                WatchedFoldersFileHasRenamed(this, e);
            }
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            if (WatchedFoldersFileHasDeleted != null)
            {
                WatchedFoldersFileHasDeleted(this, e);
            }
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            if (WatchedFoldersFileHasCreated != null)
            {
                WatchedFoldersFileHasCreated(this, e);
            }
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (WatchedFoldersFileHasChanged != null)
            {
                WatchedFoldersFileHasChanged(this, e);
            }
        }

        public void Run()
        {
            _watcher.EnableRaisingEvents = true;
        }

        public event FileSystemEventHandler WatchedFoldersFileHasChanged;
        public event FileSystemEventHandler WatchedFoldersFileHasCreated;
        public event FileSystemEventHandler WatchedFoldersFileHasDeleted;
        public event RenamedEventHandler WatchedFoldersFileHasRenamed;
    }
}