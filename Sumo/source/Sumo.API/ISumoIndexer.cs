namespace Sumo.API
{
    public interface ISumoIndexer
    {
        void Index(string path, string userName);
    }
}