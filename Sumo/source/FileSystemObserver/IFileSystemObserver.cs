namespace FileSystemObserver
{
    public interface IFileSystemObserver
    {
        void Run();

        event FileObserverEventHandler FoldersChanged;

    }
}