using System.Collections.Generic;
using System.IO;

namespace FileSystemObserver_2
{
    public class FileSystemObserver : IFileSystemObserver
    {
        private readonly List<string> _folders;
        private readonly List<IFolderWatcher> _watchers;

        public FileSystemObserver(List<string> folders)
        {
            _folders = folders;
            _watchers = new List<IFolderWatcher>();

            if (_folders.Count == 0)
            {
                return;
            }

            foreach (string folderPath in _folders)
            {
                _watchers.Add(CreateWatcher(folderPath));
            }
        }

        public FileSystemObserver(IEnumerable<IFolderWatcher> watchers)
        {
            foreach (var watcher in watchers)
            {
                _watchers.Add(watcher);
            }
        }

        public void Run()
        {
            foreach (var watcher in _watchers)
            {
                watcher.Run();
            }
        }

        private FolderWatcher CreateWatcher(string path)
        {
            var watcher = new FolderWatcher();
            watcher.SetUpFolder(path);

            watcher.WatchedFoldersFileHasChanged += OnChanged;
            watcher.WatchedFoldersFileHasCreated += OnCreated;
            watcher.WatchedFoldersFileHasDeleted += OnDeleted;
            watcher.WatchedFoldersFileHasRenamed += OnRenamed;

            return watcher;
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            var a = new FileObserverEventArgs(e);

            if (FoldersChanged != null)
            {
                FoldersChanged(this, a);
            }
        }

        private void OnCreated(object source, FileSystemEventArgs e)
        {
            var a = new FileObserverEventArgs(e);

            if (FoldersCreated != null)
            {
                FoldersCreated(this, a);
            }
        }

        private void OnDeleted(object source, FileSystemEventArgs e)
        {
            var a = new FileObserverEventArgs(e);

            if (FoldersDeleted != null)
            {
                FoldersDeleted(this, a);
            }
        }

        private void OnRenamed(object source, RenamedEventArgs e)
        {
            var a = new FileObserverRenamedEventArgs(e);

            if (FoldersRenamed != null)
            {
                FoldersRenamed(this, a);
            }
        }

        public event FileObserverEventHandler FoldersChanged;
        public event FileObserverEventHandler FoldersCreated;
        public event FileObserverEventHandler FoldersDeleted;
        public event FileObserverRenamedEventHandler FoldersRenamed;
    }
}