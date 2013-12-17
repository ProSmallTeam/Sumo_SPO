using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Sumo.API;

namespace VisualSumoWPF
{
    internal class MakeMeHappy
    {
        private readonly IDbMetaManager _metaManager;
        private SumoSession _session;

        public MakeMeHappy(IDbMetaManager metaManager)
        {
            var a = new DbBookService.DbMetaManagerClient();
            a.CreateQuery("");
            _metaManager = new WcfAdapter(a);
        }

        public MakeMeHappy()
            : this(new MetaManagerStub())
        {
            _session = _metaManager.CreateQuery("");
        }


        public CategoriesMultiList GetTreeStatistic()
        {
            return _metaManager.GetStatistic(_session.SessionId);
        }

        public List<Sumo.API.Book> GetBooks()
        {
            const int booksCount = 5;

            var list = _metaManager.GetDocuments(_session.SessionId, booksCount);

            return list;
        }
    }
}