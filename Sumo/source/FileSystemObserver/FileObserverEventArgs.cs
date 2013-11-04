using System;
using System.Collections.Generic;

namespace FileSystemObserver
{
    public class FileObserverEventArgs : EventArgs
    {
        public readonly List<string> ChangedFilesFullPath;

        public FileObserverEventArgs(List<string> changedFilesFullPath)
        {
            this.ChangedFilesFullPath = changedFilesFullPath;
        }
    }
}