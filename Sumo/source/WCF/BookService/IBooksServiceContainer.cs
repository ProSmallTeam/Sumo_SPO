using Sumo.Api;

namespace BookService
{
    public interface IBooksServiceContainer
    {
        object ResolveService();

        void ReleaseService();
    }
}