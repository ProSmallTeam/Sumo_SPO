using System.Collections.Generic;
using System.IO;

namespace FileSystemObserver
{
    public class FileSystemObserver
    {
        private readonly List<string> _folders;
        private readonly List<FileSystemWatcher> _watchers;

        public FileSystemObserver(List<string> folders)
        {
            _folders = folders;
            _watchers = new List<FileSystemWatcher>();

            if (_folders.Count == 0)
            {
                return;
            }

            foreach (string folderPath in _folders)
            {
                _watchers.Add(CreateWatcher(folderPath));
            }
        }

        public void Run()
        {
            foreach (FileSystemWatcher watcher in _watchers)
            {
                watcher.EnableRaisingEvents = true;
            }
        }

        private FileSystemWatcher CreateWatcher(string path)
        {
            var watcher = new FileSystemWatcher
                {
                    Path = path,
                    NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName
                };


            watcher.Changed += OnChanged;
            watcher.Created += OnChanged;
            watcher.Deleted += OnChanged;
            watcher.Renamed += OnRenamed;


            return watcher;
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            var a = new FileObserverEventArgs(new List<string> {e.FullPath});

            if (FoldersChanged != null)
            {
                FoldersChanged(this, a);
            }
        }

        private void OnRenamed(object source, RenamedEventArgs e)
        {
            var a = new FileObserverEventArgs(new List<string> {e.FullPath, e.OldFullPath});

            if (FoldersChanged != null)
            {
                FoldersChanged(this, a);
            }
        }

        private event FileObserverEventHandler FoldersChanged;
    }
}