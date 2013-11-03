using System;
using System.IO;

namespace FileSystemObserver
{
    public class FolderObserver
    {
        private readonly string _folderPath;
        private FileSystemWatcher _watcher;

        public FolderObserver(string folderPath)
        {
            _folderPath = folderPath;
        }

        public void Run()
        {
            _watcher = CreateWatcher(_folderPath);
            _watcher.EnableRaisingEvents = true;
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

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}