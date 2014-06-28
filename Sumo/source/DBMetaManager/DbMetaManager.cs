using System.Collections.Generic;
using System.ServiceModel;
using Sumo.Api;

namespace DBMetaManager
{
    [ServiceBehavior]
    public class DbMetaManager : IDbMetaManager
    {
        private readonly IDataBase _dataBase;

        private readonly SessionStorage _sessionStorage = new SessionStorage();
        
        public DbMetaManager(IDataBase dataBase)
        {
            _dataBase = dataBase;
        }

        public SumoSession CreateQuery(string query)
        {
            int statistic = _dataBase.GetStatistic(query);

            int sessionId = _sessionStorage.AddSession(new Session(query, _dataBase));

            return new SumoSession { SessionId = sessionId, Count = statistic };
        }

        public void CloseSession(SumoSession session)
        {
            _sessionStorage.RemoveSession(session);
        }

        public List<Book> GetDocuments(int sessionId, int count, int offset = 0)
        {
            var session = GetSession(sessionId);
            return session.GetDocuments(count, offset);
        }

        public CategoriesMultiList GetStatistic(int sessionId)
        {
            var session = GetSession(sessionId);
            return session.GetStatistic();
        }

        private ISession GetSession(int sessionId)
        {
            return _sessionStorage.GetSession(sessionId);
        }
    }
}
