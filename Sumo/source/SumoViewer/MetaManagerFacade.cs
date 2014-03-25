using System.Collections.Generic;
using Sumo.API;

namespace SumoViewer
{
    public class MetaManagerFacade
    {
        private const int BookCapacity = 10;
        private readonly IDbMetaManager _metaManager;
        private SumoSession _session;


        public MetaManagerFacade(IDbMetaManager metaManager)
        {
            _metaManager = metaManager;

            _session = _metaManager.CreateQuery("");
        }


        public void SetQuery(string query)
        {
            _metaManager.CloseSession(_session);
            _session = _metaManager.CreateQuery(query);
        }

        public CategoriesMultiList GetTreeStatistic()
        {
            return _metaManager.GetStatistic(_session.SessionId);
        }

        public List<Sumo.API.Book> GetBooks()
        {
            List<Sumo.API.Book> list = _metaManager.GetDocuments(_session.SessionId,
                BookCapacity > _session.Count ? _session.Count : BookCapacity);

            return list;
        }
    }
}