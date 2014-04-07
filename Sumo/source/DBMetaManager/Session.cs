using System.Collections.Generic;
using DB;
using Sumo.Api;

namespace DBMetaManager
{
    internal class Session : ISession
    {
        private readonly IDataBase _dataBase;

        private readonly string _query;

        public Session(string query, IDataBase dataBase)
        {
            _query = query;
            _dataBase = dataBase;
        }

        public List<Book> GetDocuments(int count, int offset = 0)
        {
            return _dataBase.GetBooks(_query, count, offset);
        }

        public CategoriesMultiList GetStatistic()
        {
            return _dataBase.GetStatisticTree(_query);
        }
    }
}
