namespace FileSystemObserver_2
{
    public interface IFileSystemObserver
    {
        void Run();

        event FileObserverEventHandler FoldersChanged;
        event FileObserverEventHandler FoldersCreated;
        event FileObserverEventHandler FoldersDeleted;
        event FileObserverRenamedEventHandler FoldersRenamed;

    }
}