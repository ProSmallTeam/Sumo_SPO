using BookService;
using Sumo.Api;

namespace BookServiceStub
{
    public class StubbingDbMetaManagerServiceContainer : IBooksServiceContainer
    {
        public object ResolveService()
        {
            var manager = new MetaManagerStub();
            return manager;
        }

        public void ReleaseService()
        {

        }
    }
}