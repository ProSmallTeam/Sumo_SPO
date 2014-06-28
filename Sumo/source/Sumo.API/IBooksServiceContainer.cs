namespace Sumo.Api
{
    public interface IBooksServiceContainer
    {
        object ResolveService();

        void ReleaseService();
    }
}