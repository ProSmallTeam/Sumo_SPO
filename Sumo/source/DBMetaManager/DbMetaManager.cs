using System.Collections.Generic;
using System.Linq;
using Sumo.API;
using DataBase;

namespace DBMetaManager
{
    public class DbMetaManager : IDbMetaManager
    {
        private readonly IDataBase _dataBase;
        private List<SessionData> SessionList;
        
        public DbMetaManager(IDataBase dataBase)
        {
            SessionList = new List<SessionData>();
            _dataBase = dataBase;
        }

        public SumoSession CreateQuery(string query)
        {
            var session = new SumoSession
            {
                SessionId = SessionList.Count(),
                Count = _dataBase.GetStatistic(query)
            };

            var sessionData = new SessionData {Query = query, SessionId = session.SessionId};
            SessionList.Add(sessionData);

            return session;
        }

        public List<Book> GetDocuments(int sessionId, int count, int offset = 0)
        {
            var query = SessionList.Single(t => t.SessionId == sessionId).Query;

            var bookList = _dataBase.GetBooks(query, count, offset);

            return bookList;
        }

        public CategoriesMultiList GetStatistic(int sessionId)
        {
            return _dataBase.GetStatisticTree();
        }

        public void CloseSession(SumoSession session)
        {
            SessionList.Remove(SessionList.Single(t => t.SessionId == session.SessionId));
        }
    }
}
