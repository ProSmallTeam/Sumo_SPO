using System.Collections.Generic;
using System.ServiceModel;

namespace Sumo.Api
{
    [ServiceContract]
    public interface IDbMetaManager
    {
        [OperationContract]
        SumoSession CreateQuery(string query);


        [OperationContract]
        List<Book> GetDocuments(int sessionId, int count, int offset = 0);


        [OperationContract]
        CategoriesMultiList GetStatistic(int sessionId);


        [OperationContract]
        void CloseSession(SumoSession session);


    }
}