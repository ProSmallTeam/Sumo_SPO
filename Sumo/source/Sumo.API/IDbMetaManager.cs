using System.Collections.Generic;

namespace Sumo.API
{
    //todo дима, реализуй
    public interface IDbMetaManager
    {
        SumoSession CreateQuery(string query);

        List<Book> GetDocuments(int sessionId, int count, int offset = 0);

        CategoriesMultiList GetStatistic(int sessionId);

        void CloseSession(SumoSession session);        
    }
}