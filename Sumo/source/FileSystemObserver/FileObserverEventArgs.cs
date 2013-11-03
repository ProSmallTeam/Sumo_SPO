using System;
using System.Collections.Generic;

namespace FileSystemObserver
{
    public class FileObserverEventArgs : EventArgs
    {
        public readonly List<string> ChangedFolders;

        public FileObserverEventArgs(List<string> changedFolders)
        {
            ChangedFolders = changedFolders;
        }
    }
}