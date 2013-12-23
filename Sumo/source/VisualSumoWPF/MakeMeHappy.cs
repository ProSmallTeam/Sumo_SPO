using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using VisualSumoWPF.DbBookService;
using CategoriesMultiList = Sumo.API.CategoriesMultiList;
using IDbMetaManager = Sumo.API.IDbMetaManager;
using SumoSession = Sumo.API.SumoSession;

namespace VisualSumoWPF
{
    internal class MakeMeHappy
    {
        private readonly IDbMetaManager _metaManager;
        private SumoSession _session;

        public MakeMeHappy(DbMetaManagerClient metaManager) : this(new WcfAdapter(metaManager))
        {}

        public MakeMeHappy(IDbMetaManager metaManager)
        {

           var a = new DbBookService.DbMetaManagerClient();
           // _metaManager = metaManager;
            _metaManager = new WcfAdapter(a);

            _session = _metaManager.CreateQuery("");
        }

        public MakeMeHappy()
            : this(new MetaManagerStub())
        {
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