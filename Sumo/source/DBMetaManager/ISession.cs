using System.Collections.Generic;
using Sumo.Api;

namespace DBMetaManager
{
    public interface ISession
    {
        List<Book> GetDocuments(int count, int offset = 0);
        CategoriesMultiList GetStatistic();
    }
}