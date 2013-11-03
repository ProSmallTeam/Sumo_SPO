using System;
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
        }

        public void Run()
        {
            if (_folders.Count == 0)
            {
                return;
            }

            foreach (var folderPath in _folders)
            {
                _watchers.Add(CreateWatcher(folderPath));
            }

            foreach (var watcher in _watchers)
            {
                StartWatcher(watcher);
            }
        }

        private void StartWatcher(FileSystemWatcher watcher)
        {
            // Begin watching.
            watcher.EnableRaisingEvents = true;
        }

        private FileSystemWatcher CreateWatcher(string path)
        {
            var watcher = new FileSystemWatcher();
            watcher.Path = path;

            /* Watch for changes in LastAccess and LastWrite times, and
           the renaming of files or directories. */
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;


            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);


            return watcher;

        }

        // Define the event handlers.
        private static void OnChanged(object source, FileSystemEventArgs e)
        {

            throw new NotImplementedException();
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {

            throw new NotImplementedException();
        }

        event FileObserverEventHandler FoldersChanged;

        protected virtual void OnFoldersChanged(FileObserverEventArgs e)
        {
            FileObserverEventHandler handler = FoldersChanged;
            if (handler != null) handler(this, e);
        }
    }
}