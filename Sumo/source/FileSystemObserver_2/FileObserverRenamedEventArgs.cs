using System.IO;

namespace FileSystemObserver_2
{
    public class FileObserverRenamedEventArgs : FileObserverEventArgs
    {
        public string ChangedFilesOldFullPath;

        public FileObserverRenamedEventArgs(RenamedEventArgs e)
            : base(e)
        {

            ChangedFilesOldFullPath = e.OldFullPath;
        }
    }
}