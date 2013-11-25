using System.Collections.Generic;

namespace Sumo.API
{
    public interface IDbMetaManager
    {
        SumoSession CreateQuery(string query);

        List<Book> GetDocuments(SumoSession session, int offset, int count);

        ISumoStatistic GetStatistic(SumoSession session);

        void CloseSession(SumoSession session);


        
    }
}