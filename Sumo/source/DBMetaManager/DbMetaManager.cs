using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Sumo.Api;
using DB;

namespace DBMetaManager
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class DbMetaManager : IDbMetaManager
    {
        private readonly IDataBase _dataBase;
        private readonly List<SessionData> _sessionsList;
        private int _nextSessionId = 0;
        
        public DbMetaManager()
        {
            _sessionsList = new List<SessionData>();
            _dataBase = new DB.DataBase("mongodb://localhost/?safe=false"); ;
        }

        public SumoSession CreateQuery(string query)
        {
            var session = new SumoSession
            {
                SessionId = _nextSessionId,
                Count = _dataBase.GetStatistic(query)
            };

            var sessionData = new SessionData {Query = query, SessionId = session.SessionId};
            _sessionsList.Add(sessionData);

            _nextSessionId++;
            return session;
        }

        public List<Book> GetDocuments(int sessionId, int count, int offset = 0)
        {
            var query = _sessionsList.Single(t => t.SessionId == sessionId).Query;

            var bookList = _dataBase.GetBooks(query, count, offset);

            return bookList;
        }

        public CategoriesMultiList GetStatistic(int sessionId)
        {
            var query = _sessionsList.Single(t => t.SessionId == sessionId).Query;

            return _dataBase.GetStatisticTree(query);
        }

        public void CloseSession(SumoSession session)
        {
            _sessionsList.Remove(_sessionsList.Single(t => t.SessionId == session.SessionId));
        }
    }
}
