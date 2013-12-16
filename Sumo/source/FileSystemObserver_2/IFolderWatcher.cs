using System.IO;

namespace FileSystemObserver_2
{
    public interface IFolderWatcher
    {
        void SetUpFolder(string folder);

        void Run();

        event FileSystemEventHandler WatchedFoldersFileHasChanged;
        event FileSystemEventHandler WatchedFoldersFileHasCreated;
        event FileSystemEventHandler WatchedFoldersFileHasDeleted;
        event RenamedEventHandler WatchedFoldersFileHasRenamed;
    }
}