using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using Sumo.API;
using VisualSumoWPF.DbBookService;
using CategoriesMultiList = Sumo.API.CategoriesMultiList;
using IDbMetaManager = Sumo.API.IDbMetaManager;
using SumoSession = Sumo.API.SumoSession;

namespace VisualSumoWPF
{
    public class MetaManagerFacade
    {
        private readonly IDbMetaManager _metaManager;
        private SumoSession _session;
        private const int BookCapacity = 10;


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
            var list = _metaManager.GetDocuments(_session.SessionId, BookCapacity > _session.Count? _session.Count : BookCapacity);

            return list;
        }

    }
}