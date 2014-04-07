using System.Collections.Generic;
using Sumo.Api;

namespace DBMetaManager
{
    internal class NullSession : ISession
    {
        public static readonly NullSession Instance = new NullSession();

        public List<Book> GetDocuments(int count, int offset = 0)
        {
            return new List<Book>();
        }

        public CategoriesMultiList GetStatistic()
        {
            return new CategoriesMultiList();
        }
    }
}