using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel;

namespace Sumo.Api
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MetaManagerStub : IDbMetaManager
    {
        private int _operationsCounter = 0;
        public SumoSession CreateQuery(string query)
        {
            _operationsCounter++;
            var session = new SumoSession { SessionId = 10, Count = _operationsCounter };
            return session;
        }

        public List<Book> GetDocuments(int sessionId, int count, int offset = 0)
        {
            _operationsCounter++;

            var book = new Book();
            var list = new List<Book>();

            for (int i = 0; i < count; i++)
            {
                list.Add(book);
            }

            return list;
        }



        public CategoriesMultiList GetStatistic(int sessionId)
        {

            _operationsCounter++;

            var root = new CategoryNode { Id = 0, Name = "Все книги", Count = 1 };
            var authors = new CategoryNode { Id = 1, Name = "Авторы", Count = 3 };
            var genres = new CategoryNode { Id = 2, Name = "Жанры", Count = 3 };

            var authorsList = new CategoriesMultiList(authors, new List<CategoriesMultiList> { });
            var genresList = new CategoriesMultiList(genres, new List<CategoriesMultiList> { });

            var rootList = new CategoriesMultiList(root, new List<CategoriesMultiList> { authorsList, genresList });

            return rootList;
        }

        public void CloseSession(SumoSession session)
        {
            _operationsCounter++;

            Trace.WriteLine("CloseSession called");
        }

    }
}