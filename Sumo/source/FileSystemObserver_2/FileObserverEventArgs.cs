using System;
using System.IO;

namespace FileSystemObserver_2
{
    public class FileObserverEventArgs : EventArgs
    {
        public readonly string ChangedFilesFullPath;
        public readonly string ChangeType;

        public FileObserverEventArgs(FileSystemEventArgs e)
        {
            ChangedFilesFullPath = e.FullPath;
            ChangeType = e.ChangeType.ToString();
        }
    }
}