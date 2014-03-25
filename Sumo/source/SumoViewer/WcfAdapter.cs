using System.Collections.Generic;
using System.Linq;
using SumoViewer.DbBookService;
using CategoriesMultiList = Sumo.API.CategoriesMultiList;
using CategoryNode = Sumo.API.CategoryNode;
using IDbMetaManager = Sumo.API.IDbMetaManager;
using SumoSession = Sumo.API.SumoSession;

namespace SumoViewer
{
    internal class WcfAdapter : IDbMetaManager
    {
        private readonly DbMetaManagerClient _wcfClient;

        public WcfAdapter(DbMetaManagerClient wcfClient)
        {
            _wcfClient = wcfClient;
        }

        public SumoSession CreateQuery(string query)
        {
            DbBookService.SumoSession session = _wcfClient.CreateQuery(query);
            return new SumoSession {Count = session.Count, SessionId = session.SessionId};
        }

        public List<Sumo.API.Book> GetDocuments(int sessionId, int count, int offset = 0)
        {
            List<DbBookService.Book> documents = _wcfClient.GetDocuments(sessionId, count, offset);
            var a = new List<Sumo.API.Book>();

            return
                _wcfClient.GetDocuments(sessionId, count, offset)
                    .Select(
                        d =>
                            new Sumo.API.Book
                            {
                                Md5Hash = d.Md5Hash,
                                Name = d.Name,
                                Path = d.Path,
                                SecondaryFields = d.SecondaryFields
                            })
                    .ToList();
        }

        public CategoriesMultiList GetStatistic(int sessionId)
        {
            DbBookService.CategoriesMultiList q = _wcfClient.GetStatistic(sessionId);
            var a = new CategoriesMultiList(CastToNode(q.Node))
            {
                Childs = q.Childs.Select(RecursionCastMultiList).ToList()
            };

            return a;
        }

        public void CloseSession(SumoSession session)
        {
            _wcfClient.CloseSession(new DbBookService.SumoSession {Count = session.Count, SessionId = session.SessionId});
        }

        private static CategoriesMultiList RecursionCastMultiList(DbBookService.CategoriesMultiList categoriesMultiList)
        {
            var a = new CategoriesMultiList(CastToNode(categoriesMultiList.Node));

            if (categoriesMultiList.Childs.Count != 0)
            {
                a.Childs = categoriesMultiList.Childs.Select(RecursionCastMultiList).ToList();
            }

            return a;
        }

        private static CategoryNode CastToNode(DbBookService.CategoryNode node)
        {
            return new CategoryNode {Count = node.Count, Id = node.Id, Name = node.Name};
        }

        private static CategoriesMultiList GetDefaultStatistic()
        {
            var root = new CategoryNode {Id = 0, Name = "Все книги", Count = 1};
            var authors = new CategoryNode {Id = 1, Name = "Авторы", Count = 3};
            var genres = new CategoryNode {Id = 2, Name = "Жанры", Count = 3};

            var authorsList = new CategoriesMultiList(authors, new List<CategoriesMultiList>());
            var genresList = new CategoriesMultiList(genres, new List<CategoriesMultiList>());

            var rootList = new CategoriesMultiList(root, new List<CategoriesMultiList> {authorsList, genresList});
            return rootList;
        }
    }
}